using LocalBetBiga.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocalBetBiga.Controllers
{
    public class AdminEquipmentDistributionController : Controller
    {
        private readonly IAdminEquipmentDistributionService _adminEquipmentDistribution;
        public AdminEquipmentDistributionController(IAdminEquipmentDistributionService adminEquipmentDistribution)
        {
            _adminEquipmentDistribution = adminEquipmentDistribution;
        }


        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            return View(_adminEquipmentDistribution.GetAll());
        }
    }
}
