
using LocalBetBiga.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocalBetBiga.Interfaces.Services
{
    public interface IAdminHistoryService
    {
        public AdminHistory CreateHistory(int adminId,int managerId, int numberOfEquipmentAssigned, string nameOfEquipmentAssigned, string agentAddress, DateTime dateAssigned);

        public List<AdminHistory> GetAllHistoryByManagerId(int managerId);
        public List<AdminHistory> GetAllHistory();
        public AdminHistory GetHistory(int id);
    }
}
