using LocalBetBiga.Interfaces.Repository;
using LocalBetBiga.Models;
using LocalBetBiga.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocalBetBiga.Domain.Repository
{
    public class ManagerHistoryRepository : IManagerHistoryRepository
    {
        private readonly ApplicationDbContext _context;

        public ManagerHistoryRepository(ApplicationDbContext context)
        {
            _context = context;

        }

        public ManagerHistory CreateHistory(ManagerHistory managerHistory)
        {
            _context.Add(managerHistory);
            _context.SaveChanges();

            return managerHistory;
            
        }

        public void DeleteHistory()
        {
            throw new NotImplementedException();
        }

        public List<ManagerHistory> GetAllHistory()
        {
            return _context.ManagerHistories.ToList();
        }

        public List<ManagerHistory> GetAllHistoryByManagerId(int managerId)
        {
            var history = _context.ManagerHistories.Include(ach => ach.AgentName)
          .Where(ach => ach.ManagerId == managerId).ToList();

            return history;
        }

        public ManagerHistory GetHistory(int id)
        {
            return _context.ManagerHistories.Find(id);
        }
    }
}
