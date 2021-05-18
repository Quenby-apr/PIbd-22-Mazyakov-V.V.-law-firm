using System;
using System.Collections.Generic;
using System.Text;
using LawFirmBusinessLogic.BindingModels;
using LawFirmBusinessLogic.ViewModels;

namespace LawFirmBusinessLogic.Interfaces
{
    public interface IMessageInfoStorage
    {
        List<MessageInfoViewModel> GetFullList();
        List<MessageInfoViewModel> GetFilteredList(MessageInfoBindingModel model);
        void Insert(MessageInfoBindingModel model);
        int Count();
        List<MessageInfoViewModel> GetMessagesForPage(MessageInfoBindingModel model);
    }
}
