using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;
using LawFirmBusinessLogic.Attributes;
using LawFirmBusinessLogic.Enums;

namespace LawFirmBusinessLogic.ViewModels
{
    /// <summary>   
    /// Заказ    
    /// </summary>
    [DataContract]
    public class OrderViewModel
    {
        [Column(title: "Номер", width: 70)]
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int ClientId { get; set; }
        [DataMember]
        public int DocumentId { get; set; }
        [DataMember]
        public int? ImplementerId { get; set; }
        [DataMember]
        [Column(title: "Клиент", width: 150)]
        public string ClientFIO { get; set; }
        [DataMember]
        [Column(title: "Исполнитель", width: 150)]
        public string ImplementerFIO { get; set; }
        [DataMember]
        [Column(title: "Документ", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string DocumentName { get; set; }
        [DataMember]
        [Column(title: "Количество", width: 100)]
        public int Count { get; set; }
        [DataMember]
        [Column(title: "Сумма", width: 100)]
        public decimal Sum { get; set; }
        [DataMember]
        [Column(title: "Статус", width: 100)]
        public OrderStatus Status { get; set; }
        [DataMember]
        [Column(title: "Дата создания", width: 150)]
        public DateTime DateCreate { get; set; }
        [DataMember]
        [Column(title: "Дата выполнения", width: 150)]
        public DateTime? DateImplement { get; set; }
    }
}
