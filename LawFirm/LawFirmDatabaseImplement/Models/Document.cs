using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LawFirmDatabaseImplement.Models
{
    public class Document
    {
        public int Id { get; set; }
        [Required]
        public string DocumentName { get; set; }
        [Required]
        public decimal Price { get; set; }
        [ForeignKey("DocumentId")]
        public virtual List<DocumentComponent> DocumentComponents { get; set; }
        [ForeignKey("DocumentId")]
        public virtual List<Order> Orders { get; set; } = new List<Order>();
    }
}
