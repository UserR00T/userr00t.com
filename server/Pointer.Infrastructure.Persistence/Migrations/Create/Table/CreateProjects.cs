using System.Threading.Tasks;
using Pointer.Infrastructure.Persistence.Abstractions;
using SqlKata.Execution;

namespace Pointer.Infrastructure.Persistence.Migrations.Create.Table
{
    public class CreateProjects : Migration
    {
        public CreateProjects(QueryFactory database) : base(database)
        {
            Description = "create(table): projects";
        }

        public override async Task<bool> Exists()
        {
            return await _db.Query("information_schema.tables")
                            .Where("table_schema", "public")
                            .Where("table_name", "projects")
                            .ExistsAsync();
        }

        public override async Task Up()
        {
            await _db.StatementAsync(@"CREATE TABLE public.projects (
                ""Id"" char(16) NOT NULL,
                ""Name"" text NOT NULL,
                ""ShortDescription"" text NOT NULL,
                ""Description"" text,
                ""Url"" text,
                ""Tags"" text[],
                ""Updated"" timestamp with time zone NOT NULL DEFAULT now(),
                ""Created"" timestamp with time zone NOT NULL DEFAULT now(),
                CONSTRAINT projects_pk PRIMARY KEY (""Id"")
            );");
        }

        public override async Task Down()
        {
            await _db.StatementAsync("DROP TABLE IF EXISTS public.projects CASCADE");
        }
    }
}