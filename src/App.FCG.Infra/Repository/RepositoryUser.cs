using App.FCG.Core.Entities;
using App.FCG.Core.Interfaces;

namespace App.FCG.Infra.Repository;

public class RepositoryUser : GenericRepository<User>, IUserRepository
{
    public ApplicationDbContext _context;

    public RepositoryUser(ApplicationDbContext context):base(context)  
    {
        _context = context;
    }
}
