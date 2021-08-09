using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocalBetBiga.Models.Entities
{
    public class AdminHistory : BaseEntity
    {
        public string EquipmentName { get; set; }
        public int NumberOfEquipmentAssigned { get; set; }
        public DateTime DateAssigned { get; set; }
        public Admin Admin { get; set; }
        public int AdminId { get; set; }
        public Manager Manager { get; set; }
        public int ManagerId { get; set; }
    }
}
