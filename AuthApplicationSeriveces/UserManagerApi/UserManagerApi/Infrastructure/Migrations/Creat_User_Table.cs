using FluentMigrator;
using FluentMigrator.Postgres;

namespace UserManagerApi.Infrastructure.Migrations
{
    [Migration(202501252318)]
    public class Creat_User_Table : Migration
    {
        public override void Up()
        {
            Create.Table("User")
                .WithColumn("Id").AsGuid().PrimaryKey()
                .WithColumn("PersonId").AsGuid().NotNullable()
                .WithColumn("Username").AsString().NotNullable().Unique()
                .WithColumn("LowerUsername").AsString().NotNullable().Unique()
                .WithColumn("Password").AsString().NotNullable()
                .WithColumn("Email").AsString().Nullable()
                .WithColumn("Mobile").AsString().NotNullable().Unique()
                .WithColumn("Sort").AsInt64().Identity(PostgresGenerationType.Always)
                .WithColumn("CreatedDate").AsDateTime().NotNullable()
                .WithColumn("CreatedBy").AsGuid().NotNullable()
                .WithColumn("UpdatedDate").AsDateTime().Nullable()
                .WithColumn("UpdatedBy").AsGuid().Nullable();


            Create.ForeignKey("FK_User_Person")
                .FromTable("User").ForeignColumn("PersonId")
                .ToTable("Person").PrimaryColumn("Id")
                .OnDelete(System.Data.Rule.Cascade);
        }
        public override void Down()
        {
            Delete.Table("User");
        }

    }
}
