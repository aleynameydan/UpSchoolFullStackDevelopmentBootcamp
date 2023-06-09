using System.Reflection;
using Domain.Entities;
using Domain.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistance.Context;

public class IdentityContext:IdentityDbContext<User,Role,string,UserClaim,UserRole,UserLogin,RoleClaims,UserToken>
{
    //constructor
    public IdentityContext(DbContextOptions<IdentityContext> options):base(options)
    {
        
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //Configurations
        //burası ne yapıyor araştır???
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        
        //Ignores
        modelBuilder.Ignore<Account>();
        modelBuilder.Ignore<Country>();
        modelBuilder.Ignore<City>();
        modelBuilder.Ignore<AccountCategory>();
        modelBuilder.Ignore<Address>();
        modelBuilder.Ignore<Category>();
        modelBuilder.Ignore<Note>();
        modelBuilder.Ignore<NoteCategory>();


        base.OnModelCreating(modelBuilder);
    }
}
