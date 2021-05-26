using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;
using LawFirmBusinessLogic.Attributes;

namespace LawFirmBusinessLogic.ViewModels
{
    [DataContract]
    public class ClientViewModel
    {
        [DataMember]
        [Column(title: "Номер", width: 100, visible: false)]
        public int? Id { get; set; }

        [DataMember]
        [Column(title: "Клиент", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string ClientFIO { get; set; }

        [DataMember]
        [Column(title: "Почта", width: 250)]
        public string Email { get; set; }

        [DataMember]
        [Column(title: "Пароль", width: 200)]
        public string Password { get; set; }
    }
}
