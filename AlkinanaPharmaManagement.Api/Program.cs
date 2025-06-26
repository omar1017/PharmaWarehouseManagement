using AlkinanaPharma.Identity;
using AlkinanaPharma.Identity.DBContext;
using AlkinanaPharmaManagement.Api;
using AlkinanaPharmaManagement.Api.Middlewares;
using AlkinanaPharmaManagment.Application;
using AlkinanaPharmaManagment.Infrastructure;
using AlkinanaPharmaManagment.Infrastructure.Database;
using AlkinanaPharmaManagment.Infrastructure.Hubs;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(new WebApplicationOptions
{
    WebRootPath = "wwwroot"
});

// Add services to the container.

builder.Services
    .AddApplication()
    .AddPresentation()
    .AddInfrastructure(builder.Configuration);
builder.Services.AddIdentityServicesS(builder.Configuration);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Host.UseSerilog((context, loggerConfig) => loggerConfig.ReadFrom.Configuration(context.Configuration));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigins", policy =>
    {
        policy.WithOrigins("https//www.alkinanamedstore.com")
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials();
    });
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    dbContext.Database.Migrate();
}

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AlkinanaPharmaIdentityDbContext>();
    dbContext.Database.Migrate();
}

app.UseMiddleware<ExceptionMiddleware>();


// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

app.UseStaticFiles();

app.UseCors("AllowSpecificOrigins");

app.MapHub<NotificationHub>("/api/notificationHub");

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
