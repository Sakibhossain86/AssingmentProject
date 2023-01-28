using ExcelTech_Project.Models;

namespace ExcelTech_Project.HostedServices
{
    public class DbSeederHostedService : IHostedService
    {
        private readonly IServiceProvider serviceProvider;
        public DbSeederHostedService(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            using var scope = serviceProvider.CreateScope();
            var seeder = scope.ServiceProvider.GetRequiredService<DbSeeder>();
            await seeder.SeedAsync();
        }

        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
    }
}
