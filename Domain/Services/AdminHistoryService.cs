using LocalBetBiga.Interfaces.Repository;
using LocalBetBiga.Interfaces.Services;
using LocalBetBiga.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocalBetBiga.Domain.Services
{
    public class AdminHistoryService : IAdminHistoryService
    {
        private readonly IAdminEquipmentDistributionRepository _adminEquipmentRepository;
        private readonly IEquipmentRepository _equipmentRepository;
        private readonly IManagerRepository _managerRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IAdminRepository _adminRepository;

        public AdminHistoryService(IAdminEquipmentDistributionRepository adminEquipmentDistribution, IEquipmentRepository equipmentRepository, IAdminRepository adminRepository, IManagerRepository managerRepository, ICategoryRepository categoryRepository)
        {
            _adminEquipmentRepository = adminEquipmentDistribution;
            _equipmentRepository = equipmentRepository;
            _managerRepository = managerRepository;
            _categoryRepository = categoryRepository;
            _adminRepository = adminRepository;
        }

        public AdminHistory CreateHistory(int adminId, int managerId, int numberOfEquipmentAssigned, string nameOfEquipmentAssigned, string agentAddress, DateTime dateAssigned)
        {
            throw new NotImplementedException();
        }

        public List<AdminHistory> GetAllHistory()
        {
            throw new NotImplementedException();
        }

        public List<AdminHistory> GetAllHistoryByManagerId(int managerId)
        {
            throw new NotImplementedException();
        }

        public AdminHistory GetHistory(int id)
        {
            throw new NotImplementedException();
        }
    }
}
