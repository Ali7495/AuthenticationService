using FluentMigrator;

namespace UserManagerApi.Infrastructure.Migrations
{
    public class Create_Person_Table : Migration
    {
        public override void Up()
        {
            Create.Table("Person")
                .WithColumn("Id").AsGuid().PrimaryKey().NotNullable()
                .WithColumn("FirstName").AsString(100).NotNullable()
                .WithColumn("MiddleName").AsString(100).Nullable()
                .WithColumn("LastName").AsString(100).NotNullable()
        }

        public override void Down()
        {
            throw new NotImplementedException();
        }

    }
}
