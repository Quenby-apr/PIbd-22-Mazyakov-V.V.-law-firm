using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;
using LawFirmBusinessLogic.Attributes;

namespace LawFirmBusinessLogic.ViewModels
{
    /// <summary> 
    ///  Компонент, требуемый для изготовления изделия  
    ///  </summary>
    [DataContract]
    public class ComponentViewModel
    {
        [Column(title: "Номер", width: 100, visible: false)]
        public int Id { get; set; }
        [Column(title: "Название компонента", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string ComponentName { get; set; }
    }
}
