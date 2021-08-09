using LocalBetBiga.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocalBetBiga.Models.ViewModel
{
    public class AdminVM
    {
        public Equipments Equipments { get; set; }
        public AdminEquipmentDistribution EquipmentDistribution { get; set; }
        public Admin Admin { get; set; }
        public string Email { get; set; }
        public int NumberOfEquipmentInStore { get; set; }
        public Manager Manager { get; set; }
        public int TotalOfNumberOfManagers { get; set; }
        public int NumberOfLaptopInStore { get; set; }
        public int NumberOfPrinterInStore { get; set; }
        public int NumberOfTelivisionInStore { get; set; }
    }
}
