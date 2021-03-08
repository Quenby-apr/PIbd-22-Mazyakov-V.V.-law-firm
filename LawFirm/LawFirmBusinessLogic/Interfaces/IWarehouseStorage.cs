using System;
using System.Collections.Generic;
using System.Text;
using LawFirmBusinessLogic.BindingModels;
using LawFirmBusinessLogic.ViewModels;

namespace LawFirmBusinessLogic.Interfaces
{
    public interface IWarehouseStorage
    {
        List<WarehouseViewModel> GetFullList();
        List<WarehouseViewModel> GetFilteredList(WarehouseBindingModel model);
        WarehouseViewModel GetElement(WarehouseBindingModel model);
        void Insert(WarehouseBindingModel model);
        void Update(WarehouseBindingModel model);
        void Delete(WarehouseBindingModel model);
        bool CheckAndWriteOff(Dictionary<int, (string, int)> components, int countOfDocs);
    }
}
