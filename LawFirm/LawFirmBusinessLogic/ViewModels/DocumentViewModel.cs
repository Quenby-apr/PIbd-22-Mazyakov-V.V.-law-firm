using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;

namespace LawFirmBusinessLogic.ViewModels
{
    /// <summary> 
    /// Изделие, изготавливаемое в магазине  
    /// </summary>
    [DataContract]
    public class DocumentViewModel
    {
        [DataMember] 
        public int Id { get; set; }
        [DataMember]
        [DisplayName("Название изделия")]
        public string DocumentName { get; set; }
        [DataMember]
        [DisplayName("Цена")] public decimal Price { get; set; }
        [DataMember] 
        public Dictionary<int, (string, int)> DocumentComponents { get; set; }
    }
}
