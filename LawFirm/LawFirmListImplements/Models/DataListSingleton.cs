using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LawFirmListImplement.Models;

namespace LawFirmListImplement.Models
{
    public class DataListSingleton
    {
        private static DataListSingleton instance;
        public List<Component> Components { get; set; }
        public List<Order> Orders { get; set; }
        public List<Document> Documents { get; set; }
        public List<Warehouse> Warehouses { get; set; }
        private DataListSingleton() {
            Components = new List<Component>();
            Orders = new List<Order>();
            Documents = new List<Document>();
            Warehouses = new List<Warehouse>(); }
        public static DataListSingleton GetInstance()
        {
            if (instance == null)
            {
                instance = new DataListSingleton();
            }
            return instance;
        }
    }
}
