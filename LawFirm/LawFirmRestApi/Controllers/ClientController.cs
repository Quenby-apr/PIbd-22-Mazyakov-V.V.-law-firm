using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using LawFirmBusinessLogic.BindingModels;
using LawFirmBusinessLogic.BusinessLogic;
using LawFirmBusinessLogic.BusinessLogics;
using LawFirmBusinessLogic.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LawFirmRestApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly ClientLogic _logic;
        private readonly MailLogic _mailLogic;
        private readonly int _passwordMaxLength = 50;
        private readonly int _passwordMinLength = 10;

        public ClientController(ClientLogic logic, MailLogic mailLogic)
        {
            _logic = logic;
            _mailLogic = mailLogic;
        }
        [HttpGet]
        public ClientViewModel Login(string login, string password) => _logic.Read(new ClientBindingModel
        { Email = login, Password = password })?[0];
        [HttpGet]
        public List<MessageInfoViewModel> GetMessages(int clientId) =>
        _mailLogic.Read(new MessageInfoBindingModel { ClientId = clientId });
        [HttpPost]
        public void Register(ClientBindingModel model)
        {
            CheckData(model);
            _logic.CreateOrUpdate(model);
        }
        [HttpPost]
        public void UpdateData(ClientBindingModel model)
        {
            CheckData(model);
            _logic.CreateOrUpdate(model);
        }
        private void CheckData(ClientBindingModel model)
        {
            if (!Regex.IsMatch(model.Email, @"^([a-z0-9_-]+\.)*[a-z0-9_-]+@[a-z0-9_-]+(\.[a-z0-9_-]+)*\.[a-z]{2,6}$"))
            {
                throw new Exception("В качестве логина почта указана должна быть");
            }
            if (model.Password.Length > _passwordMaxLength || model.Password.Length < _passwordMinLength || !Regex.IsMatch(model.Password,
           @"^((\w+\d+\W+)|(\w+\W+\d+)|(\d+\w+\W+)|(\d+\W+\w+)|(\W+\w+\d+)|(\W+\d+\w+))[\w\d\W]*$"))
            {
                throw new Exception($"Пароль длиной от {_passwordMinLength} до" +
                    $" { _passwordMaxLength } должен быть и из цифр, букв и небуквенных символов должен состоять");
            }
        }
        [HttpGet]
        public PageViewModel GetPage(int pageSize, int page, int ClientId)
        {
            return new PageViewModel(_mailLogic.Count(), page, pageSize, _mailLogic.GetMessagesForPage(new MessageInfoBindingModel
            {
                Page = page,
                PageSize = pageSize,
                ClientId = ClientId
            }));
        }
    }
}