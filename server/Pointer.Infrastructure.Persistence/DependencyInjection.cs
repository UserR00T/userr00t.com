using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using Pointer.Core.Domain.Models.Entities;
using Pointer.Infrastructure.Persistence.Abstractions;
using Pointer.Infrastructure.Persistence.Managers;
using Pointer.Infrastructure.Persistence.Repositories;
using SqlKata.Compilers;
using SqlKata.Execution;

namespace Pointer.Infrastructure.Persistence
{
    public static class DependencyInjection
    {
        public static async Task AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            var connection = new NpgsqlConnection(configuration.GetConnectionString("Postgres"));
            var queryFactory = new QueryFactory(connection, new PostgresCompiler());

            services.AddSingleton(connection);
            services.AddSingleton(queryFactory);
            services.AddSingleton<Repository<User>, UserRepository>();
            services.AddSingleton<Repository<Skill>, SkillRepository>();
            services.AddSingleton<Repository<Project>, ProjectRepository>();
            services.AddSingleton<Repository<Contact>, ContactRepository>();
            services.AddSingleton<Repository<Configuration>, ConfigurationRepository>();

            services.AddSingleton<MigrationManager>();

            // TODO: Figure out how to get the dependency without doing this hacky solution
            var migrations = services.BuildServiceProvider().GetService<MigrationManager>();
            migrations.FindAll();
            await migrations.RunAll();
        }
    }
}
