using Application.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contexts;
using Persistence.Repositories.Implements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructurePersistenceLayer(this IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(opt => 
                opt.UseInMemoryDatabase("TodoBD"));


            services.AddTransient(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));
            services.AddTransient<IUserRepositoryAsync, UserRepositoryAsync>();

            services.AddAutoMapper(Assembly.GetExecutingAssembly());
        }
    }
}
