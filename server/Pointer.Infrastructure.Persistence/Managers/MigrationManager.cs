using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Pointer.Infrastructure.Persistence.Abstractions;
using SqlKata.Execution;

namespace Pointer.Infrastructure.Persistence.Managers
{
    public class MigrationManager
    {
        private readonly ILogger<MigrationManager> _logger;

        private readonly QueryFactory _database;

        public Dictionary<string, Migration> Migrations { get; } = new Dictionary<string, Migration>();

        public MigrationManager(ILogger<MigrationManager> logger, QueryFactory db)
        {
            _logger = logger;
            _database = db;
        }

        public void FindAll()
        {
            var types = GetType().Assembly.GetTypes().Where(x => typeof(Migration).IsAssignableFrom(x) && !x.IsAbstract);
            foreach (var type in types)
            {
                var migration = (Migration)Activator.CreateInstance(type, _database);
                Migrations[migration.Id] = migration;
            }
        }

        public async Task RunAll()
        {
            foreach (var migration in Migrations.Values)
            {
                if (await migration.Exists())
                {
                    continue;
                }
                _logger.LogWarning($"{migration.Id}: Migration does not exist, running...");
                _logger.LogInformation($"{migration.Description}: down");
                await migration.Down();
                _logger.LogInformation($"{migration.Description}: up");
                await migration.Up();
            }
        }
    }
}