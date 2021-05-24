using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;
using LawFirmBusinessLogic.Attributes;

namespace LawFirmBusinessLogic.ViewModels
{
    /// <summary> 
    /// Изделие, изготавливаемое в магазине  
    /// </summary>
    [DataContract]
    public class DocumentViewModel
    {
        [DataMember]
        [Column(title: "Номер", width: 100, visible: false)]
        public int Id { get; set; }
        [DataMember]
        [Column(title: "Название изделия", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string DocumentName { get; set; }
        [DataMember]
        [Column(title: "Цена", width: 150)]
        public decimal Price { get; set; }
        [DataMember] 
        public Dictionary<int, (string, int)> DocumentComponents { get; set; }
    }
}
