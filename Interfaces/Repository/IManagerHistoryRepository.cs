using LocalBetBiga.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocalBetBiga.Interfaces.Repository
{
    public interface IManagerHistoryRepository
    {
        public ManagerHistory GetHistory(int id);

        public ManagerHistory CreateHistory(ManagerHistory managerHistory);
        public void DeleteHistory();
        public List<ManagerHistory> GetAllHistoryByManagerId(int managerId);
        public List<ManagerHistory> GetAllHistory();
    }
}
