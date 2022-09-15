using Application.Repositories.Interfaces;
using Domain.Entities;
using Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.Implements
{
    public class UserRepositoryAsync : GenericRepositoryAsync<User>, IUserRepositoryAsync
    {
        public UserRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
