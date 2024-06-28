using Microsoft.Extensions.DependencyInjection;
using Repository.Repostories.Interfaces;
using Repository.Repostories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRepositoryLayer(this IServiceCollection services)
        {
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

            services.AddScoped<IGroupRepository, GroupRepository>();

            services.AddScoped<IStudentRepository, StudentRepository>();




            return services;

        }
    }
}
