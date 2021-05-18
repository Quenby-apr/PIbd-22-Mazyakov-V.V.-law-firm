using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;
using LawFirmBusinessLogic.Attributes;

namespace LawFirmBusinessLogic.ViewModels
{
    public class MessageInfoViewModel
    {
        [DataMember]
        [Column(title: "Идентификатор", width: 100, visible: false)]
        public string MessageId { get; set; }
        [Column(title: "Отправитель", width: 150)]
        [DataMember]
        public string SenderName { get; set; }
        [Column(title: "Дата письма", width: 150)]
        [DataMember]
        public DateTime DateDelivery { get; set; }
        [Column(title: "Заголовок", width: 150)]
        [DataMember]
        public string Subject { get; set; }
        [Column(title: "Текст", gridViewAutoSize: GridViewAutoSize.Fill)]
        [DataMember]
        public string Body { get; set; }
    }
}
