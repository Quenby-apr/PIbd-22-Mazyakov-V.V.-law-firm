using System;
using System.Collections.Generic;
using System.Text;

namespace LawFirmFileImplement.Models
{
    public class Document
    {
        public int Id { get; set; }
        public string DocumentName { get; set; }
        public decimal Price { get; set; }
        public Dictionary<int, int> DocumentComponents { get; set; }
    }
}
