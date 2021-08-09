using LocalBetBiga.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocalBetBiga.Interfaces.Services
{
    public interface IAdminEquipmentDistributionService
    {
        public AdminEquipmentDistribution CreateDistribution(int managerId, int numberOfEquipment, int equipmentId, int agentId, int categoryId, DateTime dateAssigned, string managerUserName);
       
        public AdminEquipmentDistribution GetDistribution(int id);
        public List<AdminEquipmentDistribution> GetAll();
        public AdminEquipmentDistribution UpdateDistribution(AdminEquipmentDistribution distribution);

        public List<AdminEquipmentDistribution> GetAllAssignedEquipmentByManagerId(int agentId);
        public List<AdminEquipmentDistribution> GetAllAssignedEquipments();
    }
}
