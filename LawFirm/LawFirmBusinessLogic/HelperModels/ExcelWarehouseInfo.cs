using System;
using System.Collections.Generic;
using System.Text;
using LawFirmBusinessLogic.ViewModels;

namespace LawFirmBusinessLogic.HelperModels
{
    public class ExcelWarehouseInfo
    {
        public string FileName { get; set; }

        public string Title { get; set; }

        public List<ReportWarehouseComponentViewModel> WarehouseComponents { get; set; }
    }
}
