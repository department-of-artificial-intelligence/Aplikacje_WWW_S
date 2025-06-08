using Kolokwium.DAL;
using Kolokwium.Services.Configuration.AutoMapperProfiles;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder (args);

// Add services to the container.
builder.Services.AddAutoMapper (typeof (MainProfile));
builder.Services.AddCors ();
builder.Services.AddDbContext<ApplicationDbContext> (options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);
builder.Services.AddControllers ();
builder.Services.AddSwaggerGen (options => {
    options.SwaggerDoc ("v1", new OpenApiInfo { Title = "Kolokwium API", Version = "v1" });
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "bearer"
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});
builder.Services.AddEndpointsApiExplorer ();
builder.Services.AddTransient (typeof (ILogger), typeof (Logger<Program>));


var app = builder.Build ();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment ()) {
    app.UseDeveloperExceptionPage ();
    app.UseSwagger ();
    app.UseSwaggerUI (c => {
        c.SwaggerEndpoint ("/swagger/v1/swagger.json", "Kolokwium.Api v1");
        c.RoutePrefix = string.Empty;
    });
}

app.UseCors (options =>
    options.WithOrigins ("http://localhost:3000", "http://localhost:4200")
    .WithMethods ("GET", "POST", "PUT", "DELETE")
    .AllowAnyHeader()
);
app.UseRouting ();
app.UseAuthorization ();
app.MapControllers ();
app.Run ();