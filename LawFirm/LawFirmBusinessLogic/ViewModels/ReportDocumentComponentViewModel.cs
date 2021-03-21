using System;
using System.Collections.Generic;

namespace LawFirmBusinessLogic.ViewModels
{
    /// <summary>   
    /// Отчёт по компонентам документов 
    /// </summary>
    public class ReportDocumentComponentViewModel
    {
        public string ComponentName { get; set; }
        public int TotalCount { get; set; }
        public List<Tuple<string, int>> Documents { get; set; }
    }
}
