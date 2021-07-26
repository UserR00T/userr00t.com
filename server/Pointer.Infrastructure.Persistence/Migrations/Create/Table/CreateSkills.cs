using System.Threading.Tasks;
using Pointer.Infrastructure.Persistence.Abstractions;
using SqlKata.Execution;

namespace Pointer.Infrastructure.Persistence.Migrations.Create.Table
{
    public class CreateSkills : Migration
    {
        public CreateSkills(QueryFactory database) : base(database)
        {
            Description = "create(table): skills";
        }

        public override async Task<bool> Exists()
        {
            return await _db.Query("information_schema.tables")
                            .Where("table_schema", "public")
                            .Where("table_name", "skills")
                            .ExistsAsync();
        }

        public override async Task Up()
        {
            await _db.StatementAsync(@"CREATE TABLE public.skills (
                ""Id"" char(16) NOT NULL,
                ""Category"" text NOT NULL,
                ""Name"" text NOT NULL,
                ""Value"" integer NOT NULL,
                ""Updated"" timestamp with time zone NOT NULL DEFAULT now(),
                ""Created"" timestamp with time zone NOT NULL DEFAULT now(),
                CONSTRAINT skills_pk PRIMARY KEY (""Id"")
            );");
        }

        public override async Task Down()
        {
            await _db.StatementAsync("DROP TABLE IF EXISTS public.skills CASCADE");
        }
    }
}