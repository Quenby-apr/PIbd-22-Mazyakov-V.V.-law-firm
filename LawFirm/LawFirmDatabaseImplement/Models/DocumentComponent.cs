using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LawFirmDatabaseImplement.Models
{
    public class DocumentComponent
    {
        public int Id { get; set; }
        public int DocumentId { get; set; }
        public int ComponentId { get; set; }
        [Required]
        public int Count { get; set; }
        public virtual Component Component { get; set; }
        public virtual Document Document { get; set; }
    }
}
