using System;
using Application.Common.Mapping;
using Application.Interfaces;
using Domain.Interfaces.IRepository;
using Infrastructure.Data;
using Infrastructure.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SATS.API.Middleware;
using SATS.Application.ServiceImpl;

namespace SATS.API
{
    public static class Program
    {
        public static void Main(string[] args) => CreateHostBuilder(args).Build().Run();

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.ConfigureServices((context, services) =>
                    {
                        var configuration = context.Configuration;
                        services.AddDbContext<AppDbContext>(options =>
                            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

                        services.AddScoped<IUserRepository, UserRepository>();
                        services.AddScoped<ICourseRepository, CourseRepository>();
                        services.AddScoped<IEnrollmentRepository, EnrollmentRepository>();
                        services.AddScoped<IAttendanceSessionRepository, AttendanceSessionRepository>();
                        services.AddScoped<IAttendanceRecordRepository, AttendanceRecordRepository>();
                        services.AddScoped<IAuditLogRepository, AuditLogRepository>();

                        services.AddScoped<IUserService, UserServiceImpl>();
                        services.AddScoped<ICourseService, CourseServiceImpl>();
                        services.AddScoped<IEnrollmentService, EnrollmentServiceImpl>();
                        services.AddScoped<IAttendanceSessionService, AttendanceSessionServiceImpl>();
                        services.AddScoped<IAttendanceRecordService, AttendanceRecordServiceImpl>();
                        services.AddScoped<IAuditLogService, AuditLogServiceImpl>();

                        services.AddAutoMapper(typeof(MappingProfile).Assembly);
                        services.AddControllers();
                        services.AddSwaggerGen();
                    });

                    webBuilder.Configure((context, app) =>
                    {
                        using (var scope = app.ApplicationServices.CreateScope())
                        {
                            var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                            db.Database.Migrate();
                        }

                        if (context.HostingEnvironment.IsDevelopment())
                            app.UseDeveloperExceptionPage();

                        app.UseMiddleware<ExceptionMiddleware>();
                        app.UseSwagger();
                        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SATS API v1"));
                        app.UseHttpsRedirection();
                        app.UseRouting();
                        app.UseEndpoints(endpoints => endpoints.MapControllers());
                    });
                });
    }
}
