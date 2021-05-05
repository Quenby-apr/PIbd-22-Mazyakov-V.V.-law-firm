using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LawFirmBusinessLogic.BindingModels;
using LawFirmBusinessLogic.BusinessLogics;
using LawFirmBusinessLogic.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LawFirmRestApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class WarehouseController : ControllerBase
    {
        private readonly WarehouseLogic warehouseLogic;
        private readonly ComponentLogic componentLogic;
        public WarehouseController(WarehouseLogic warehouseLogic, ComponentLogic componentLogic)
        {
            this.warehouseLogic = warehouseLogic;
            this.componentLogic = componentLogic;
        }
        [HttpGet]
        public List<WarehouseViewModel> GetAllWarehouses() => warehouseLogic.Read(null).ToList();
        [HttpGet]
        public List<ComponentViewModel> GetAllComponents() => componentLogic.Read(null).ToList();

        [HttpPost]
        public void Create(WarehouseBindingModel model) => warehouseLogic.CreateOrUpdate(model);

        [HttpPost]
        public void Update(WarehouseBindingModel model) => warehouseLogic.CreateOrUpdate(model);

        [HttpPost]
        public void Delete(WarehouseBindingModel model) => warehouseLogic.Delete(model);

        [HttpPost]
        public void AddComponent(ComponentForWarehouseBindingModel model) => warehouseLogic.AddComponents(model);
    }
}