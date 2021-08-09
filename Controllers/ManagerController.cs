using LocalBetBiga.Interfaces.Services;
using LocalBetBiga.Models.Entities;
using LocalBetBiga.Models.ViewModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace LocalBetBiga.Controllers
{
    public class ManagerController : Controller
    {
        private readonly IManagerService _managerService;
        private readonly IEquipmentService _equipmentService;
        private readonly IManagerEquipmentDistributionService _managerEquipmentDistributionService;
        private readonly IAdminEquipmentDistributionService _adminEquipmentDistribution;
        private readonly ICategoryService _categoryService;
        public ManagerController(IManagerService managerService, IEquipmentService equipmentService, IManagerEquipmentDistributionService managerEquipmentDistributionService, ICategoryService categoryService, IAdminEquipmentDistributionService adminEquipmentDistribution)
        {
            _managerService = managerService;
            _equipmentService = equipmentService;
            _managerEquipmentDistributionService = managerEquipmentDistributionService;
            _categoryService = categoryService;
            _adminEquipmentDistribution = adminEquipmentDistribution;
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            return View(_managerService.GetAll());
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();

        }
        // POST CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public IActionResult Create(Manager man)
        {
            if (ModelState.IsValid)
            {
                _managerService.AddManager(man);
                return RedirectToAction(nameof(Index));

            }
            return View(man);
        }

        [HttpGet]
        [AllowAnonymous]

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public IActionResult Login(string email, string password)
        {

            var manager = _managerService.Login(email, password);
            if (manager == null)
            {
                ViewBag.Message = "Invalid Username/Password";
                return View();
            }
            else
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, $"{manager.UserName}"),
                    new Claim(ClaimTypes.GivenName, $"{manager.UserName} {manager.Email}"),
                    new Claim(ClaimTypes.NameIdentifier, manager.Id.ToString()),
                    new Claim(ClaimTypes.Email, manager.Email),
                    new Claim(ClaimTypes.MobilePhone, manager.PhoneNumber),
                    new Claim(ClaimTypes.Role, "Manager"),

                };
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authenticationProperties = new AuthenticationProperties();
                var principal = new ClaimsPrincipal(claimsIdentity);
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, authenticationProperties);
                return RedirectToAction(nameof(Dashboard));
            }


        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Login", "Manager");
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var manager = _managerService.GetManager(id.Value);
            if (manager == null)
            {
                return NotFound();
            }
            return View(manager);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {

            _managerService.DeleteManager(id);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Details(int? id)
        {
            return View(_managerService.GetManager(id.Value));
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var manager = _managerService.GetManager(id.Value);
            if (manager == null)
            {
                return NotFound();
            }
            return View(manager);
        }
        [HttpPost]
        public IActionResult Edit(int id, Manager manager)
        {
            if (id != manager.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _managerService.UpdateManager(manager);
                return RedirectToAction(nameof(Index));
            }
            return View(manager);
        }

        [Authorize(Roles = "Manager")]
        public IActionResult Dashboard()
        {

            int managerId = int.Parse(HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);
            Manager manager = _managerService.GetManager(managerId);
            return View(manager);

        }
        public IActionResult ViewDetails(ManagerViewDetailsVM managerViewDetails)
        {
            int managerId = int.Parse(HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);
            Manager manager = _managerService.GetManager(managerId);
            string userName = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name).Value;
            Manager managerV = _managerService.FindByUserName(userName);
            string email = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email).Value;
            Manager manEmail = _managerService.GetManagerByEmail(email);
            string phoneNumber = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.MobilePhone).Value;
            Manager mgPhone = _managerService.FindByPhoneNumber(phoneNumber);

            managerViewDetails.ManagerId = managerId;
            managerViewDetails.UserName = userName;
            managerViewDetails.Email = email;
            managerViewDetails.PhoneNumber = phoneNumber;


            return View(managerViewDetails);
        }

        public IActionResult AssignEquipmentToAgent()
        {
            AssignEquipmentToAgentVM assignEquipmentVM = new AssignEquipmentToAgentVM();


            List<SelectListItem> EquipmentNameSelectList = new List<SelectListItem>();

            int managerId = int.Parse(User.Claims.FirstOrDefault(cl => cl.Type == ClaimTypes.NameIdentifier).Value);



            List<AdminEquipmentDistribution> equipmentDistributions = _adminEquipmentDistribution.GetAllAssignedEquipmentByManagerId(managerId);

            foreach (var equipment in equipmentDistributions)
            {
                EquipmentNameSelectList.Add(new SelectListItem
                {
                    Value = equipment.Id.ToString(),
                    Text = equipment.Equipments.EquipmentType
                });
            }

            assignEquipmentVM.EquipmentNameSelectList = EquipmentNameSelectList;

           

            return View(assignEquipmentVM);

        }
        [HttpPost]
        public IActionResult AssignEquipmentToAgent(AssignEquipmentToAgentVM assignEquipmentVM)
        {

            ManagerEquipmentDistribution equipmentDistribution = new ManagerEquipmentDistribution();

            int equipmentId = int.Parse(assignEquipmentVM.EquipmentId.ToString());

            //string equipmentName = assignEquipmentVM.EquipmentName;

            string shopAddress = assignEquipmentVM.ShopAddress;

            int numberOfEquipmentAssigned = int.Parse(assignEquipmentVM.NumberOfEquipmentAssigned.ToString());

            int managerId = int.Parse(HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);

            DateTime dateAssigned = DateTime.Parse(assignEquipmentVM.DateAssigned.ToString());


            Manager manager = _managerService.GetManager(managerId);

            List<AdminEquipmentDistribution> allEquipmentAssigned = _adminEquipmentDistribution.GetAllAssignedEquipmentByManagerId(managerId);

            if (allEquipmentAssigned == null)
            {
                return View(assignEquipmentVM);
            }
            else
            {


                //_managerEquipmentDistributionService.DeductEquipment(assignEquipmentVM.EquipmentId, assignEquipmentVM.NumberOfEquipmentAssigned);

                _managerEquipmentDistributionService.CreateDistribution(managerId, assignEquipmentVM.NumberOfEquipmentAssigned, assignEquipmentVM.NameOfAgent, dateAssigned, shopAddress, assignEquipmentVM.NameOfEquipmentAssigned);



            }

            return RedirectToAction(nameof(Dashboard));

        }

        public IActionResult ExportToExcel()
        {
            List<ManagerEquipmentDistribution> distributions = _managerEquipmentDistributionService.GetAllAssignedEquipmentByAgentId(int.Parse(User.Claims.FirstOrDefault(cl => cl.Type == ClaimTypes.NameIdentifier).Value));

            var builder = new StringBuilder();

            foreach (var distribution in distributions)
            {
                builder.AppendLine($"{distribution.NameOfAgentAssignedTo}, {distribution.NameOfEquipmentAssigned}, {distribution.NumberOfEquipmentAssigned}, {distribution.ShopAddress}, {distribution.DateAssigned}");
            }

            return File(Encoding.UTF8.GetBytes(builder.ToString()), "text/csv", "Manager Equipment Distribution.csv");
        }

        [HttpGet]
        public IActionResult GetAllAssignedEquipment()
        {
            int managerId = int.Parse(User.Claims.FirstOrDefault(cl => cl.Type == ClaimTypes.NameIdentifier).Value);

            return View(_managerEquipmentDistributionService.GetAllAssignedEquipmentByAgentId(managerId));
        }

        [HttpGet]
        public IActionResult History(int managerId)
        {
             managerId = int.Parse(User.Claims.FirstOrDefault(cl => cl.Type == ClaimTypes.NameIdentifier).Value);

            return View(_adminEquipmentDistribution.GetAllAssignedEquipmentByManagerId(managerId));
        }

    }
}
