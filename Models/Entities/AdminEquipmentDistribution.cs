using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LocalBetBiga.Models.Entities
{
    public class AdminEquipmentDistribution : BaseEntity
    {
        public Equipments Equipments { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public int EquipmentsId { get; set; }
        public string EquipmentType { get; set; }

        public string Brand { get; set; }
        public string ManagerUserName { get; set; }
        public Manager Manager { get; set; }
        [Required]
        public int ManagerId { get; set; }
        public Admin Admin { get; set; }
        [Required]
        public int AdminId { get; set; }

        [Required]
        public DateTime DateAssigned { get; set; }
        [Required]
        public int NumberOfEquipmentAssigned { get; set; }
    }
}
