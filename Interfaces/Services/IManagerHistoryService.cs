using LocalBetBiga.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocalBetBiga.Interfaces.Services
{
    public interface IManagerHistoryService
    {
        public ManagerHistory CreateHistory(int managerId, int numberOfEquipmentAssigned, string nameOfEquipmentAssigned, string agentAddress, DateTime dateAssigned);

        public List<ManagerHistory> GetAllHistoryByManagerId(int managerId);
        public List<ManagerHistory> GetAllHistory();
        public ManagerHistory GetHistory(int id);
    }
}
