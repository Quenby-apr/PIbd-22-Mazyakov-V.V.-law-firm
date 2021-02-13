using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace LawFirmBusinessLogic.ViewModels
{
    /// <summary> 
    /// Изделие, изготавливаемое в магазине  
    /// </summary>
    public class DocumentViewModel
    {
        public int Id { get; set; }
        [DisplayName("Название изделия")]
        public string DocumentName { get; set; }
        [DisplayName("Цена")]
        public decimal Price { get; set; }
        public Dictionary<int, (string, int)> DocumentComponents { get; set; }
    }
}
