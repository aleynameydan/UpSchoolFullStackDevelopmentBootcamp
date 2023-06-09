using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Infrastructure.Persistance.Contexts;

public class ApplicationContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 27));
            optionsBuilder.UseMySql("Server=141.98.112.67;Port=7002;Database=aleyna_meydan_upstorage;Uid=aleyna_meydan;Pwd=ROwH92oymymdIU76IgJ4VJaLj;",serverVersion);

            return new ApplicationDbContext(optionsBuilder.Options);
        }
}