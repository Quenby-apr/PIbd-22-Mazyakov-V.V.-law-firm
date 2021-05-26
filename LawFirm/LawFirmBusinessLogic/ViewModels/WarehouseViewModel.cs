using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;
using LawFirmBusinessLogic.Attributes;

namespace LawFirmBusinessLogic.ViewModels
{
    [DataContract]
    public class WarehouseViewModel
    {
        [DataMember]
        [Column(title: "Номер", width: 100, visible: false)]
        public int Id { get; set; }

        [DataMember]
        [Column(title: "Название склада", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string WarehouseName { get; set; }

        [DataMember]
        [Column(title: "Имя ответственного", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string NameResponsiblePerson { get; set; }

        [DataMember]
        [Column(title: "Дата создания", gridViewAutoSize: GridViewAutoSize.Fill, dateFormat:"D")]
        public DateTime DateCreate { get; set; }
        [DataMember]
        [Column(title: "Список компонент", visible: false)]
        public Dictionary<int, (string, int)> WarehouseComponents { get; set; }
    }
}
