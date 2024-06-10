using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using SchoolRegister.DAL.EF; 
using SchoolRegister.Model.DataModels;
using SchoolRegister.Services.ConcreteServices;
using SchoolRegister.Services.Configuration.AutoMapperProfiles;
using SchoolRegister.Services.Interfaces;
using SchoolRegister.Web.Controllers;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Dodanie automappera - wazne
builder.Services.AddAutoMapper(typeof(MainProfile)); 

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<Role>()
    .AddRoleManager<RoleManager<Role>>()
    .AddUserManager<UserManager<User>>()
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddTransient(typeof(ILogger), typeof(Logger<Program>));
builder.Services.AddControllersWithViews();



// cos 
// builder.Services.AddScoped<IStringLocalizer, StringLocalizer<BaseController>> ();
builder.Services.AddScoped<ISubjectService, SubjectService> ();
builder.Services.AddScoped<IGradeService, GradeService> ();
// builder.Services.AddScoped<IGroupService, GroupService> ();
builder.Services.AddScoped<IStudentService, StudentService> ();
builder.Services.AddScoped<ITeacherService, TeacherService> ();

// var supportedCultures = new [] { "en", "pl-PL" };
// builder.Services.Configure<RequestLocalizationOptions> (options => {
// options.SetDefaultCulture (supportedCultures[0])
// .AddSupportedCultures (supportedCultures)
// .AddSupportedUICultures (supportedCultures);
// });

// builder.Services.AddLocalization (options => options.ResourcesPath = "Resources");
// builder.Services.AddControllersWithViews ()
// .AddRazorRuntimeCompilation ()
// .AddViewLocalization ()
// .AddDataAnnotationsLocalization ();
// builder.Services.AddRazorPages ()
// .AddRazorRuntimeCompilation ()
// .AddViewLocalization ()
// .AddDataAnnotationsLocalization ();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication(); 
app.UseAuthorization();

// cos
// var localizationOption = new RequestLocalizationOptions ()
// .SetDefaultCulture (supportedCultures[0])
// .AddSupportedCultures (supportedCultures)
// .AddSupportedUICultures (supportedCultures);
// app.UseRequestLocalization (localizationOption);



app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
