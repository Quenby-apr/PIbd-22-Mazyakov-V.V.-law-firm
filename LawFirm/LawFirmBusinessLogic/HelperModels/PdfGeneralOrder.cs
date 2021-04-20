using System;
using System.Collections.Generic;
using System.Text;
using LawFirmBusinessLogic.ViewModels;

namespace LawFirmBusinessLogic.HelperModels
{
    public class PdfGeneralOrder
    {
        public string FileName { get; set; }

        public string Title { get; set; }

        public List<ReportOrdersByDateViewModel> Orders { get; set; }
    }
}
