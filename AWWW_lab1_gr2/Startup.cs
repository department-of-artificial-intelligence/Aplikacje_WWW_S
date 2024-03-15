using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AWWW_lab1_gr2.Models; // Przypuśćmy, że DbContext znajduje się w tym namespace

public class Startup
{
    private IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        // Skonfiguruj Connection String z pliku appsettings.json
        string connectionString = Configuration.GetConnectionString("MyConnection");

        // Dodaj DbContext z użyciem skonfigurowanego Connection String
        services.AddDbContext<MyDbContext>(options =>
            options.UseSqlServer(connectionString));

        // Dodaj inne usługi do kontenera DI
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        // Konfiguracja aplikacji
    }
}
