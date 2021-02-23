using System;
using System.Collections.Generic;
using System.Text;

namespace LawFirmBusinessLogic.BindingModels
{
    public class ComponentForWarehouseBindingModel
    {
        public int ComponentId { get; set; }

        public int WarehouseId { get; set; }

        public int Count { get; set; }
    }
}
