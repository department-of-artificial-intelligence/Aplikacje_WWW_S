using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SchoolRegister.BLL.Entities;
using SchoolRegister.DAL.EF;
using SchoolRegister.Services.Interfaces;
using SchoolRegister.Services.Services;
using SchoolRegister.Web.Configuration;
using System;
using System.Globalization;
using System.Net;
using System.Net.Mail;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Options;
namespace SchoolRegister.Web
{
    public class Startup
    {
        private readonly string _connectionString;
        public IHostingEnvironment HostingEnvironment { get; set; }
        public IServiceCollection Services { get; private set; }
        public IConfiguration Configuration { get; set; }
        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(env.ContentRootPath)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
            .AddEnvironmentVariables();
            Configuration = builder.Build();
            if (env.IsEnvironment("Development"))
            {
                builder.AddApplicationInsightsSettings(developerMode: true);
            }           builder.AddEnvironmentVariables();
            Configuration = builder.Build();
            _connectionString = Configuration["ConnectionStrings:MsSqlConnection"];
            HostingEnvironment = env;
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
    
     public void ConfigureServices(IServiceCollection services)
        {
            #region Framework Services
            // Add framework services.
            services.AddOptions();
            services.AddApplicationInsightsTelemetry(Configuration);
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                 options.CheckConsentNeeded = context => true;
                 options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            services.Configure<RequestLocalizationOptions>(options =>
            {
                var supportedCultures = new[]
                {
                    new CultureInfo("en"),
                    new CultureInfo("pl-PL")
                    // add other cultures
                 };
                options.DefaultRequestCulture = new RequestCulture(culture: "en", uiCulture:
               "en");
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
            });
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(10);
                options.Cookie.HttpOnly = true;
            });
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(_connectionString); // SQL SERVER
            });
            services.AddIdentity<User, Role>()
            .AddRoles<Role>()
            .AddRoleManager<RoleManager<Role>>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddSignInManager<SignInManager<User>>()
            .AddDefaultUI()
            .AddDefaultTokenProviders();
            services.AddScoped<IUserClaimsPrincipalFactory<User>,
            UserClaimsPrincipalFactory<User, Role>>();
            services.AddAntiforgery(options => options.HeaderName = "X-XSRF-TOKEN");
            services.Configure<FormOptions>(x =>
            {
                x.ValueLengthLimit = int.MaxValue;
                x.MultipartBodyLengthLimit = int.MaxValue;
                x.KeyLengthLimit = int.MaxValue;
            });
            services.AddScoped((serviceProvider) =>
            {
                var config = serviceProvider.GetRequiredService<IConfiguration>();
                return new SmtpClient()
                {
                    Host = config.GetValue<String>("Email:Smtp:Host"),
                    Port = config.GetValue<int>("Email:Smtp:Port"),
                    Credentials = new NetworkCredential(
                config.GetValue<String>("Email:Smtp:Username"),
               config.GetValue<String>("Email:Smtp:Password")
                )
                };
            });
            services.AddScoped<IGroupService, GroupService>();
            services.AddScoped<IGradeService, GradeService>();
            services.AddScoped<ISubjectService, SubjectService>();
            services.AddScoped<ITeacherService, TeacherService>();
            services.AddScoped<IStudentService, StudentService>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddJsonOptions(x =>
                    x.SerializerSettings.DateFormatHandling =
            Newtonsoft.Json.DateFormatHandling.MicrosoftDateFormat)
                .AddViewLocalization()
                .AddDataAnnotationsLocalization();
            services.AddLocalization(options => options.ResourcesPath = "Resources");
            #endregion
            #region Our Services
            var cs = new ConnectionStringDto() { ConnectionString = _connectionString };
            services.AddSingleton(cs);
            var mappingConfig = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.Mapping();
            });
            services.AddSingleton(x => mappingConfig.CreateMapper());
            services.AddScoped<DbContext, ApplicationDbContext>();
            services.AddScoped<DbContextOptions<ApplicationDbContext>>();
            services.AddScoped<ISubjectService, SubjectService>();
            #endregion
            Services = services;
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    
     public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory
    loggerFactory)
        {
            var localizationOption =
           app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();
            app.UseRequestLocalization(localizationOption.Value);
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }
            loggerFactory.AddFile("Log/SchoolRegister-{Date}.txt");
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                name: "default",
               template: "{controller=Subject}/{action=Index}/{id?}");
            });
        }
    }

}