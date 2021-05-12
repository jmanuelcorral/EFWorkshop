using HomeSchool.Data.Repositories;
using HomeSchool.Data.UnitOfWork;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeSchool.Data
{
    public static class ServiceExtensions
    {
        public static IApplicationBuilder MigrateDatabase<TContext>(this IApplicationBuilder app) where TContext : DbContext
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<TContext>();
                context.Database.Migrate();
            }
            return app;
        }


        public static IServiceCollection AddDatabaseServices(this IServiceCollection services)
        {
            services.AddScoped<ISchoolUnitOfWork, SchoolUnitOfWork>();
            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<ICourseReadOnlyRepository, CourseReadOnlyRepository>();
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<IProfessorRepository, ProfessorRepository>();
            return services;
        }
    }
}
