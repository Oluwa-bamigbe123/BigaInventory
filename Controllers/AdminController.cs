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
    public class AdminController : Controller
    {
        private readonly IAdminService _adminService;
        private readonly IManagerService _managerService;
        private readonly IEquipmentService _equipmentService;
        private readonly IAdminEquipmentDistributionService _adminEquipmentDistribution;
        private readonly ICategoryService _categoryService;

        public AdminController(IAdminService adminService, IManagerService managerService, IEquipmentService equipmentService, IAdminEquipmentDistributionService adminEquipmentDistributionService, ICategoryService categoryService)
        {
            _adminService = adminService;
            _managerService = managerService;
            _equipmentService = equipmentService;
            _adminEquipmentDistribution = adminEquipmentDistributionService;
            _categoryService = categoryService;
        }
        public IActionResult Index()
        {
            return View(_adminService.GetAll());
        }
        public IActionResult Create()
        {
            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Admin adm)
        {
            if (ModelState.IsValid)
            {
                _adminService.AddAdmin(adm);
                return RedirectToAction(nameof(Index));

            }
            return View(adm);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var admin = _adminService.GetAdmin(id.Value);
            if (admin == null)
            {
                return NotFound();
            }
            return View(admin);
        }

        [HttpPost]
        public IActionResult Edit(int id, Admin admin)
        {
            if (id != admin.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _adminService.UpdateAdmin(admin);
                return RedirectToAction(nameof(Index));
            }
            return View(admin);
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

            var admin = _adminService.Login(email, password);
            if (admin == null)
            {
                ViewBag.Message = "Invalid Username/Password";
                return View();
            }
            else
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, $"{admin.FirstName}"),
                    new Claim(ClaimTypes.GivenName, $"{admin.FirstName} {admin.LastName}"),
                    new Claim(ClaimTypes.NameIdentifier, admin.Id.ToString()),
                    new Claim(ClaimTypes.Email, admin.Email),
                    new Claim(ClaimTypes.Role, "Admin"),

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
            return RedirectToAction("Login", "Admin");
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Dashboard()
        {
            AdminVM adminVM = new AdminVM();
            int adminId = int.Parse(HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);
            Admin admin = _adminService.GetAdmin(adminId);
            string email = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email).Value;
            Admin adminV = _adminService.FindByEmail(email);

            adminVM.Email = email;



            return View();

        }
        [HttpGet]
        public IActionResult GetAllAssignedEquipment()
        {

            return View(_adminEquipmentDistribution.GetAllAssignedEquipments());
        }


        public IActionResult ExportToExcel()
        {
            List<AdminEquipmentDistribution> distributions = _adminEquipmentDistribution.GetAllAssignedEquipments();

            var builder = new StringBuilder();

            foreach (var distribution in distributions)
            {
                builder.AppendLine($"{distribution.Equipments.EquipmentType}, {distribution.Manager.UserName}, {distribution.NumberOfEquipmentAssigned}, {distribution.DateAssigned}");
            }

            return File(Encoding.UTF8.GetBytes(builder.ToString()), "text/csv", "Distribution.csv");
        }



        public IActionResult AssignEquipment()
        {
            AssignEquipmentToManagerVM assignEquipmentVM = new AssignEquipmentToManagerVM();

            List<SelectListItem> ManagerNameSelectList = new List<SelectListItem>();
            List<SelectListItem> EquipmentNameSelectList = new List<SelectListItem>();
            List<SelectListItem> CategorySelectList = new List<SelectListItem>();
            List<SelectListItem> EquipmentBrandSelectList = new List<SelectListItem>();

            List<Manager> managers = _managerService.GetAll();
            List<Equipments> equipments = _equipmentService.GetAll();
            List<Category> categories = _categoryService.GetAll();
            //List<Equipments> brands = _equipmentService.FindByTypeAndBrand(equals,);



            foreach (var manager in managers)
            {
                ManagerNameSelectList.Add(new SelectListItem
                {
                    Value = manager.Id.ToString(),
                    Text = manager.UserName
                });
            }

            foreach (var equipment in equipments)
            {
                EquipmentNameSelectList.Add(new SelectListItem
                {
                    Value = equipment.Id.ToString(),
                    Text = equipment.EquipmentType
                });
            }
            foreach (var category in categories)
            {
                CategorySelectList.Add(new SelectListItem
                {
                    Value = category.Id.ToString(),
                    Text = category.CategoryName
                });
            }
            //foreach (var brand in categories)
            //{
            //    CategorySelectList.Add(new SelectListItem
            //    {
            //        Value = category.Id.ToString(),
            //        Text = category.CategoryName
            //    });
            //}

            assignEquipmentVM.EquipmentTypeSelectList = EquipmentNameSelectList;
            assignEquipmentVM.ManagerNameSelectList = ManagerNameSelectList;
            assignEquipmentVM.CategorySelectList = CategorySelectList;


            return View(assignEquipmentVM);


        }
        [HttpPost]
        public IActionResult AssignEquipment(AssignEquipmentToManagerVM assignEquipmentVM)
        {
            Admin admin = new Admin();

            AdminEquipmentDistribution equipmentDistribution = new AdminEquipmentDistribution();

            int equipmentId = int.Parse(assignEquipmentVM.EquipmentId.ToString());

            int adminId = int.Parse(HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);

            int managerId = int.Parse(assignEquipmentVM.ManagerId.ToString());

            Manager manager = _managerService.GetManager(managerId);

            string managerUserName = _managerService.GetManager(assignEquipmentVM.ManagerId).UserName;

            managerUserName = assignEquipmentVM.ManagerUserName;

            int categoryId = int.Parse(assignEquipmentVM.CategoryId.ToString());

            Category category = _categoryService.GetCategory(categoryId);

            DateTime dateAssigned = DateTime.Parse(assignEquipmentVM.DateAssigned.ToString());

            if (manager == null)
            {
                return View(assignEquipmentVM);
            }
            else
            {
                _equipmentService.DeductEquipment(assignEquipmentVM.EquipmentId, assignEquipmentVM.NumberOfEquipmentAssigned);

                _adminEquipmentDistribution.CreateDistribution(adminId, assignEquipmentVM.NumberOfEquipmentAssigned, assignEquipmentVM.EquipmentId, assignEquipmentVM.ManagerId, categoryId, dateAssigned, managerUserName);



            }

            return RedirectToAction(nameof(Dashboard));

        }
    }
}
