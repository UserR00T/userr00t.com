using System.Threading.Tasks;
using Pointer.Infrastructure.Persistence.Abstractions;
using SqlKata.Execution;

namespace Pointer.Infrastructure.Persistence.Migrations.Create.Table
{
    public class CreateConfigurations : Migration
    {
        public CreateConfigurations(QueryFactory database) : base(database)
        {
            Description = "create(table): configurations";
        }

        public override async Task<bool> Exists()
        {
            return await _db.Query("information_schema.tables")
                            .Where("table_schema", "public")
                            .Where("table_name", "configurations")
                            .ExistsAsync();
        }

        public override async Task Up()
        {
            await _db.StatementAsync(@"CREATE TABLE public.configurations (
                ""Id"" char(16) NOT NULL,
                ""Key"" text NOT NULL,
                ""Value"" text NOT NULL,
                ""Updated"" timestamp with time zone NOT NULL DEFAULT now(),
                ""Created"" timestamp with time zone NOT NULL DEFAULT now(),
                CONSTRAINT configurations_pk PRIMARY KEY (""Id"")
            );");
        }

        public override async Task Down()
        {
            await _db.StatementAsync("DROP TABLE IF EXISTS public.configurations CASCADE");
        }
    }
}