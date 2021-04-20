using System;
using System.Collections.Generic;
using System.Text;

namespace LawFirmBusinessLogic.ViewModels
{
    public class ReportOrdersByDateViewModel
    {
        public DateTime Date { get; set; }

        public int Count { get; set; }

        public decimal Sum { get; set; }
    }
}
