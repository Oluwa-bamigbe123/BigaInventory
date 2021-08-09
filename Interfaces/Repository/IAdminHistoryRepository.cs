using LocalBetBiga.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocalBetBiga.Interfaces.Repository
{
    public interface IAdminHistoryRepository
    {
        public AdminHistory GetHistory(int id);

        public AdminHistory CreateHistory(AdminHistory adminHistory);
        public void DeleteHistory();
        public List<AdminHistory> GetAllHistoryByManagerId(int managerId);
        public List<AdminHistory> GetAllHistory();
    }
}
