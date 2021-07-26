using System.Threading.Tasks;
using Pointer.Infrastructure.Persistence.Abstractions;
using SqlKata.Execution;

namespace Pointer.Infrastructure.Persistence.Migrations.Create.Table
{
    public class CreateContacts : Migration
    {
        public CreateContacts(QueryFactory database) : base(database)
        {
            Description = "create(table): contacts";
        }

        public override async Task<bool> Exists()
        {
            return await _db.Query("information_schema.tables")
                            .Where("table_schema", "public")
                            .Where("table_name", "contacts")
                            .ExistsAsync();
        }

        public override async Task Up()
        {
            await _db.StatementAsync(@"CREATE TABLE public.contacts (
                ""Id"" char(16) NOT NULL,
                ""Name"" text NOT NULL,
                ""Value"" text NOT NULL,
                ""Url"" text,
                ""Tags"" text[],
                ""Updated"" timestamp with time zone NOT NULL DEFAULT now(),
                ""Created"" timestamp with time zone NOT NULL DEFAULT now(),
                CONSTRAINT contacts_pk PRIMARY KEY (""Id"")
            );");
        }

        public override async Task Down()
        {
            await _db.StatementAsync("DROP TABLE IF EXISTS public.contacts CASCADE");
        }
    }
}