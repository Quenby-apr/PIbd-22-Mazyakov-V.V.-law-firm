using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;

namespace LawFirmBusinessLogic.ViewModels
{
    [DataContract]
    public class WarehouseViewModel
    {
        [DataMember]
        public int Id { get; set; }

        [DisplayName("Название склада")]
        [DataMember]
        public string WarehouseName { get; set; }

        [DisplayName("ФИО ответственного")]
        [DataMember]
        public string NameResponsiblePerson { get; set; }

        [DisplayName("Дата создания")]
        [DataMember]
        public DateTime DateCreate { get; set; }
        [DataMember]
        public Dictionary<int, (string, int)> WarehouseComponents { get; set; }
    }
}
