using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using LawFirmWarehouseApi.Models;
using Microsoft.Extensions.Configuration;
using LawFirmBusinessLogic.ViewModels;
using LawFirmBusinessLogic.BindingModels;

namespace LawFirmWarehouseApi.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration configuration;
        public HomeController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public IActionResult Index()
        {
            if (!Program.Auth)
            {
                return Redirect("~/Home/Enter");
            }
            return View(APIClient.GetRequest<List<WarehouseViewModel>>($"api/warehouse/getallwarehouses"));
        }
        [HttpGet]
        public IActionResult Enter()
        {
            return View();
        }

        [HttpPost]
        public void Enter(string password)
        {
            if (!string.IsNullOrEmpty(password))
            {
                Program.Auth = password == configuration["Password"];
                if (!Program.Auth)
                {
                    throw new Exception("Неверный пароль");
                }

                Response.Redirect("Index");
                return;
            }
            throw new Exception("Введите пароль");
        }
        [HttpGet]
        public IActionResult Create()
        {
            if (!Program.Auth)
            {
                return Redirect("~/Home/Enter");
            }
            return View();
        }

        [HttpPost]
        public void Create([Bind("WarehouseName, NameResponsiblePerson")] WarehouseBindingModel model)
        {
            if (string.IsNullOrEmpty(model.WarehouseName) || string.IsNullOrEmpty(model.NameResponsiblePerson))
            {
                return;
            }
            model.WarehouseComponents = new Dictionary<int, (string, int)>();
            APIClient.PostRequest("api/warehouse/create", model);
            Response.Redirect("Index");
        }
        [HttpGet]
        public IActionResult Update(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var warehouse = APIClient.GetRequest<List<WarehouseViewModel>>(
                $"api/warehouse/getallwarehouses").FirstOrDefault(rec => rec.Id == id);
            if (warehouse == null)
            {
                return NotFound();
            }

            return View(warehouse);
        }

        [HttpPost]
        public IActionResult Update(int id, [Bind("Id,WarehouseName,NameResponsiblePerson")] WarehouseBindingModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            var warehouse = APIClient.GetRequest<List<WarehouseViewModel>>(
                $"api/warehouse/getall").FirstOrDefault(rec => rec.Id == id);

            model.WarehouseComponents = warehouse.WarehouseComponents;

            APIClient.PostRequest("api/warehouse/update", model);
            return Redirect("~/Home/Index");
        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var warehouse = APIClient.GetRequest<List<WarehouseViewModel>>(
                $"api/warehouse/getallwarehouses").FirstOrDefault(rec => rec.Id == id);
            if (warehouse == null)
            {
                return NotFound();
            }

            return View(warehouse);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            APIClient.PostRequest("api/warehouse/delete", new WarehouseBindingModel { Id = id });
            return Redirect("~/Home/Index");
        }
        [HttpGet]
        public IActionResult AddComponent()
        {
            if (!Program.Auth)
            {
                return Redirect("~/Home/Enter");
            }
            ViewBag.Warehouses = APIClient.GetRequest<List<WarehouseViewModel>>("api/warehouse/getallwarehouses");
            ViewBag.Components = APIClient.GetRequest<List<ComponentViewModel>>($"api/warehouse/getallcomponents");

            return View();
        }

        [HttpPost]
        public IActionResult AddComponent([Bind("WarehouseId, ComponentId, Count")] ComponentForWarehouseBindingModel model)
        {
            if (model.WarehouseId == 0 || model.ComponentId == 0 || model.Count <= 0)
            {
                return NotFound();
            }

            var warehouse = APIClient.GetRequest<List<WarehouseViewModel>>(
                "api/warehouse/getallwarehouses").FirstOrDefault(rec => rec.Id == model.WarehouseId);

            if (warehouse == null)
            {
                return NotFound();
            }

            var component = APIClient.GetRequest<List<WarehouseViewModel>>(
                "api/warehouse/getallcomponents").FirstOrDefault(rec => rec.Id == model.ComponentId);

            if (component == null)
            {
                return NotFound();
            }

            APIClient.PostRequest("api/warehouse/addcomponent", model);
            return Redirect("~/Home/Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
