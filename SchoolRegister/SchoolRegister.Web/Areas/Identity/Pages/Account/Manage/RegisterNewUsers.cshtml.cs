using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using SchoolRegister.BLL.Entities;
using SchoolRegister.DAL.EF;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace SchoolRegister.Web.Areas.Identity.Pages.Account.Manage
{
    [Authorize(Roles = "Admin")]
    public class RegisterNewUsersDataModel : PageModel
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly ILogger<RegisterNewUsersDataModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly ApplicationDbContext _dbContext;

        [BindProperty]
        public InputModel Input { get; set; }

        public RegisterNewUsersDataModel(UserManager<User> userManager,
            SignInManager<User> signInManager,
            ILogger<RegisterNewUsersDataModel> logger,
            IEmailSender emailSender, ApplicationDbContext dbContext)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _dbContext = dbContext;
        }

        public void OnGet()
        {
            ViewData["Roles"] = new SelectList(_dbContext.Roles.Select(t => new
            {
                Text = t.Name,
                Value = t.Id
            }), "Value", "Text", _dbContext.Roles.FirstOrDefault(x => x.RoleValue == RoleValue.Parent).Id);
            ViewData["Groups"] = new SelectList(_dbContext.Groups.Select(t => new
            {
                Text = t.Name,
                Value = t.Id
            }), "Value", "Text");
            ViewData["Parents"] = new SelectList(_dbContext.Users.OfType<Parent>().Select(t => new
            {
                Text = $"{t.FirstName} {t.LastName}",
                Value = t.Id
            }), "Value", "Text");
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var returnUrl = "~/Identity/Account/Manage/RegisterNewUsers";
            if (ModelState.IsValid)
            {
                var tupleUserRole = CreateUserBasedOnRole(Input);
                var result = await _userManager.CreateAsync(tupleUserRole.Item1, Input.Password);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(tupleUserRole.Item1);
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { userId = tupleUserRole.Item1.Id, code = code },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Input.Email, "Confirm your email", $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");
                    await _userManager.AddToRoleAsync(tupleUserRole.Item1, tupleUserRole.Item2.Name);
                    return LocalRedirect(returnUrl);
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }

        private Tuple<User, Role> CreateUserBasedOnRole(InputModel inputModel)
        {
            var role = _dbContext.Roles.FirstOrDefault(r => r.Id == inputModel.RoleId);
            if (role == null)
            {
                throw new InvalidOperationException("Role not exists.");
            }

            switch (role.RoleValue)
            {
                case RoleValue.Student:
                    return new Tuple<User, Role>(new Student
                    {
                        UserName = inputModel.Email,
                        Email = inputModel.Email,
                        FirstName = inputModel.FirstName,
                        LastName = inputModel.LastName,
                        GroupId = inputModel.GroupId,
                        ParentId = inputModel.ParentId,
                        RegistrationDate = DateTime.Now
                    }, role);
                case RoleValue.Parent:
                    return new Tuple<User, Role>(new Parent
                    {
                        UserName = inputModel.Email,
                        Email = inputModel.Email,
                        FirstName = inputModel.FirstName,
                        LastName = inputModel.LastName,
                        RegistrationDate = DateTime.Now,
                    }, role);
                case RoleValue.Teacher:
                    return new Tuple<User, Role>(new Teacher
                    {
                        UserName = inputModel.Email,
                        Email = inputModel.Email,
                        FirstName = inputModel.FirstName,
                        LastName = inputModel.LastName,
                        RegistrationDate = DateTime.Now,
                        Title = inputModel.TeacherTitles
                    }, role);
                case RoleValue.Admin:
                case RoleValue.User:
                    return new Tuple<User, Role>(new User
                    {
                        UserName = inputModel.Email,
                        Email = inputModel.Email,
                        FirstName = inputModel.FirstName,
                        LastName = inputModel.LastName,
                        RegistrationDate = DateTime.Now
                    }, role);
                default: return null;
            }
        }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Text)]
            [Display(Name = "First name")]
            public string FirstName { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Text)]
            [Display(Name = "Last name")]
            public string LastName { get; set; }

            [Required]
            [Display(Name = "Role")]
            public int RoleId { get; set; }

            [Display(Name = "Parent")]

            public int? ParentId { get; set; }

            [Display(Name = "Teacher titles")]
            public string TeacherTitles { get; set; }

            public int? GroupId { get; set; }

        }
    }
}
