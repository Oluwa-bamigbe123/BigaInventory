
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
    public class AdminHistoryRepository : IAdminHistoryRepository
    {
        private readonly ApplicationDbContext _context;

        public AdminHistoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public AdminHistory CreateHistory(AdminHistory adminHistory)
        {
            _context.Add(adminHistory);
            _context.SaveChanges();

            return adminHistory;
        }

        public void DeleteHistory()
        {
            throw new NotImplementedException();
        }

        public List<AdminHistory> GetAllHistory()
        {
            return _context.AdminHistories.ToList();
        }

        public List<AdminHistory> GetAllHistoryByManagerId(int managerId)
        {
            var history = _context.AdminHistories.Include(ach => ach.EquipmentName)
            .Where(ach => ach.ManagerId == managerId).ToList();

            return history;
        }

        public AdminHistory GetHistory(int id)
        {
            return _context.AdminHistories.Find(id);
        }
    }
}
