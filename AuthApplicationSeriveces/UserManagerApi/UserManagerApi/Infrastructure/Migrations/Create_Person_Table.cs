using FluentMigrator;
using FluentMigrator.Postgres;

namespace UserManagerApi.Infrastructure.Migrations
{
    [Migration(202501252317)]
    public class Create_Person_Table : Migration
    {
        public override void Up()
        {
            Create.Table("Person")
                .WithColumn("Id").AsGuid().PrimaryKey().NotNullable()
                .WithColumn("FirstName").AsString(100).NotNullable()
                .WithColumn("MiddleName").AsString(100).Nullable()
                .WithColumn("LastName").AsString(100).NotNullable()
                .WithColumn("Sort").AsInt64().Identity(PostgresGenerationType.Always)
                .WithColumn("CreatedDate").AsDateTime().NotNullable()
                .WithColumn("CreatedBy").AsGuid().NotNullable()
                .WithColumn("UpdatedDate").AsDateTime().Nullable()
                .WithColumn("UpdatedBy").AsGuid().Nullable();
        }

        public override void Down()
        {
            Delete.Table("Person");
        }

    }
}
