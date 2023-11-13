using AutoMapper;
using Data.ViewModels;
using HastyBLCAdmin.Authentication;
using HastyBLCAdmin.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using Services.Manager;
using Services.ServiceModels;
using Services.Services;
using System.ComponentModel.DataAnnotations;

namespace HastyBLCAdmin.Controllers
{
    [Authorize(Roles = "Superadmin")]
    public class SuperadminController : Controller
    {
        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [BindProperty]
        public InputModel? Input { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public IList<AuthenticationScheme>? ExternalLogins { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public string? ReturnUrl { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [TempData]
        public string? ErrorMessage { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public class InputModel
        {
            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Required]
            public string? Email { get; set; }

            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Required]
            [DataType(DataType.Password)]
            public string? Password { get; set; }

            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Display(Name = "Remember me?")]
            public bool RememberMe { get; set; }
        }
        private readonly SessionManager? _sessionManager;
        //private readonly SignInManager _signInManager;
        private readonly TokenValidationParametersFactory _tokenValidationParametersFactory;
        private readonly TokenProviderOptionsFactory _tokenProviderOptionsFactory;
        private readonly IConfiguration _appConfiguration;
        private readonly IUserService _userService;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        protected ILogger _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountController"/> class.
        /// </summary>
        /// <param name="signInManager">The sign in manager.</param>
        /// <param name="localizer">The localizer.</param>
        /// <param name="userService">The user service.</param>
        /// <param name="httpContextAccessor">The HTTP context accessor.</param>
        /// <param name="loggerFactory">The logger factory.</param>
        /// <param name="configuration">The configuration.</param>
        /// <param name="mapper">The mapper.</param>
        /// <param name="tokenValidationParametersFactory">The token validation parameters factory.</param>
        /// <param name="tokenProviderOptionsFactory">The token provider options factory.</param>
        public SuperadminController(
                            //SignInManager signInManager,
                            SignInManager<IdentityUser> signInManager,
                            IHttpContextAccessor httpContextAccessor,
                            ILoggerFactory loggerFactory,
                            IConfiguration configuration,
                            IMapper mapper,
                            IUserService userService,
                            TokenValidationParametersFactory tokenValidationParametersFactory,
                            TokenProviderOptionsFactory tokenProviderOptionsFactory,
                            RoleManager<IdentityRole> roleManager,
                            UserManager<IdentityUser> userManager)
        {
            //this._sessionManager = new SessionManager(this._session);
            this._signInManager = signInManager;
            this._tokenProviderOptionsFactory = tokenProviderOptionsFactory;
            this._tokenValidationParametersFactory = tokenValidationParametersFactory;
            this._appConfiguration = configuration;
            this._userService = userService;
            this._roleManager = roleManager;
            this._userManager = userManager;
            this._logger = loggerFactory.CreateLogger<SuperadminController>();
        }
        public async Task<IActionResult> Index()
        {
            var superadminViewModel = new SuperadminViewModel
            {
                Roles = _roleManager.Roles.OrderBy(r => r.Name).ToList(),
                Users = _userManager.Users.OrderBy(u => u.UserName).ToList(),
                UserRoles = new Dictionary<string, List<IdentityRole>>()
            };

            foreach (var user in superadminViewModel.Users)
            {
                var roles = await _userManager.GetRolesAsync(user);
                var identityRoles = new List<IdentityRole>();

                foreach (var roleName in roles)
                {
                    var role = await _roleManager.FindByNameAsync(roleName);
                    if (role != null)
                    {
                        identityRoles.Add(role);
                    }
                }

                superadminViewModel.UserRoles.Add(user.Id, identityRoles);
            }

            ViewBag.Roles = superadminViewModel.Roles;
            return View(superadminViewModel);
        }


        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleViewModel createRoleViewModel)
        {

            IdentityResult result = await _userService.CreateRole(createRoleViewModel.RoleName!);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Superadmin");
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteRole(string roleId)
        {
            // Retrieve the role by ID
            var role = await _roleManager.FindByIdAsync(roleId);

            if (role != null)
            {
                // Attempt to delete the role
                var _ = await _roleManager.DeleteAsync(role);
            }
            return RedirectToAction("Index", "Superadmin");
        }

        [HttpPost]
        public async Task<IActionResult> EditRole(AspNetRoleViewModel model)
        {
            // Retrieve the role by ID
            var role = await _roleManager.FindByIdAsync(model.RoleId!);

            if (role != null)
            {
                // Set the new role name
                role.Name = model.Name;
                role.NormalizedName = model.Name!.ToUpper();

                // Attempt to update the role
                var _ = await _roleManager.UpdateAsync(role);
                
            }
            return RedirectToAction("Index", "Superadmin");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserViewModel model)
        {
            try
            {
                var identityUser = new IdentityUser();
                identityUser.Email = model.Email;
                identityUser.UserName = model.Username;
                var result = await _userManager.CreateAsync(identityUser, model.Password!);

                /*if (result.Succeeded)
                {
                    var userRole = _roleManager.FindByNameAsync("Admin").Result;

                    if (userRole != null)
                    {
                        await _userManager.AddToRoleAsync(identityUser, userRole.Name!);
                    }
                }*/
                foreach (var error in result.Errors)
                {
                    Console.WriteLine($"Error: {error.Description}");
                }


                return RedirectToAction("Index", "Superadmin");
            }
            catch (InvalidDataException ex)
            {
                TempData["ErrorMessage"] = ex.Message;
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = Resources.Messages.Errors.ServerError + ex;
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EditUser(UserViewModel model)
        {
            // Retrieve the user by ID
            var user = await _userManager.FindByIdAsync(model.Id!);

            if (user != null)
            {
                // Update user properties
                user.Email = model.Email;
                user.UserName = model.Username;

                // Attempt to update the user
                var result = await _userManager.UpdateAsync(user);

                if (result.Succeeded)
                {
                    // If a new password is provided, update the password
                    if (!string.IsNullOrEmpty(model.Password) && model.Password != "noedit")
                    {
                        var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                        var _ = await _userManager.ResetPasswordAsync(user, token, model.Password);
                    }
                }
            }
            return RedirectToAction("Index", "Superadmin");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteUser(string userId)
        {
            // Retrieve the user by ID
            var user = await _userManager.FindByIdAsync(userId);

            if (user != null)
            {
                // Attempt to delete the role
                var _ = await _userManager.DeleteAsync(user);
            }
            return RedirectToAction("Index", "Superadmin");
        }

        [HttpPost]
		public async Task<IActionResult> AddUserRole(AspNetUserRoleViewModel model)
		{
			// Retrieve the user by ID
			var user = await _userManager.FindByIdAsync(model.UserId!);

			if (user != null)
			{
				// Check if the role exists
				var role = await _roleManager.FindByNameAsync(model.RoleName!);

				if (role != null)
				{
					// Check if the user is not already in the role
					if (!await _userManager.IsInRoleAsync(user, role.Name!))
					{
						// Add the user to the role
						var _ = await _userManager.AddToRoleAsync(user, role.Name!);
					}
				}
			}
			return RedirectToAction("Index", "Superadmin");
		}


	}
}
