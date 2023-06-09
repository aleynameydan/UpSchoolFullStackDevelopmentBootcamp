using System.Reflection;
using Application.Common.Interfaces;
using Domain.Entities;
using Domain.Identity;
using Domain.Identity;
using Infrastructure.Persistance.Configurations.Application;
using Microsoft.EntityFrameworkCore;
using Role = Domain.Identity.Role;
using User = Domain.Identity.User;
using UserClaim = Domain.Identity.UserClaim;
using UserLogin = Domain.Identity.UserLogin;
using UserRole = Domain.Identity.UserRole;
using UserToken = Domain.Identity.UserToken;
using RoleClaims = Domain.Identity.RoleClaims;

namespace Infrastructure.Persistance.Contexts;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public DbSet<Account> Accounts { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Note> Notes { get; set; }

    public Task<Address> GetByIdAsync(string id, bool v)
    {
        throw new NotImplementedException();
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, DbSet<Account> accounts, DbSet<Country> countries, DbSet<City> cities, DbSet<Address> addresses, DbSet<Note> notes):base(options)
    {
        Accounts = accounts;
        Countries = countries;
        Cities = cities;
        Addresses = addresses;
        Notes = notes;
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> optionsBuilderOptions)
    {
        throw new NotImplementedException();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
        //Override for homework
        modelBuilder.ApplyConfiguration(new AccountCategoryConfiguration());
        modelBuilder.ApplyConfiguration(new AccountConfiguration());
        modelBuilder.ApplyConfiguration(new AddressConfiguration());
        modelBuilder.ApplyConfiguration(new CityConfiguration());
        modelBuilder.ApplyConfiguration(new CountryConfiguration());
        modelBuilder.ApplyConfiguration(new NoteCategoryConfiguration());
        modelBuilder.ApplyConfiguration(new NoteConfiguration());

        // Configurations
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        // Ignores
        modelBuilder.Ignore<User>();
        modelBuilder.Ignore<Role>();
        modelBuilder.Ignore<UserRole>();
        modelBuilder.Ignore<RoleClaims>();
        modelBuilder.Ignore<UserToken>();
        modelBuilder.Ignore<UserClaim>();
        modelBuilder.Ignore<UserLogin>();
      
        base.OnModelCreating(modelBuilder);
    }
}
