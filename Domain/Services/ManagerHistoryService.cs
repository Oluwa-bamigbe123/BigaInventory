using LocalBetBiga.Interfaces.Repository;
using LocalBetBiga.Interfaces.Services;
using LocalBetBiga.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocalBetBiga.Domain.Services
{
    public class ManagerHistoryService : IManagerHistoryService
    {
        private readonly IAdminEquipmentDistributionRepository _adminEquipmentRepository;
        private readonly IEquipmentRepository _equipmentRepository;
        private readonly IManagerRepository _managerRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IAdminRepository _adminRepository;
        private readonly IManagerHistoryRepository _managerHistory;

        public ManagerHistoryService(IAdminEquipmentDistributionRepository adminEquipmentDistribution, IEquipmentRepository equipmentRepository, IAdminRepository adminRepository, IManagerRepository managerRepository, ICategoryRepository categoryRepository, IManagerHistoryRepository managerHistory)
        {
            _adminEquipmentRepository = adminEquipmentDistribution;
            _equipmentRepository = equipmentRepository;
            _managerRepository = managerRepository;
            _categoryRepository = categoryRepository;
            _adminRepository = adminRepository;
            _managerHistory = managerHistory;
        }
        public ManagerHistory CreateHistory(int managerId, int numberOfEquipmentAssigned, string nameOfEquipmentAssigned, string agentAddress, DateTime dateAssigned)
        {
            throw new NotImplementedException();
        }

        public List<ManagerHistory> GetAllHistory()
        {
            throw new NotImplementedException();
        }

        public List<ManagerHistory> GetAllHistoryByManagerId(int managerId)
        {
            throw new NotImplementedException();
        }

        public ManagerHistory GetHistory(int id)
        {
            throw new NotImplementedException();
        }
    }
}
