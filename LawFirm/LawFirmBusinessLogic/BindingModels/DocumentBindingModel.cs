using System;
using System.Collections.Generic;
using System.Text;


namespace LawFirmBusinessLogic.BindingModels
{
    /// <summary>
    /// Изделие, изготавливаемое в фирме 
    /// </summary>
    public class DocumentBindingModel
    {
        public int? Id { get; set; }
        public string DocumentName { get; set; }
        public decimal Price { get; set; }
        public Dictionary<int, (string, int)> DocumentComponents { get; set; }
    }
}

