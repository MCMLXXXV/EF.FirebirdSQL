namespace App.Database.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Staffs",
                c => new
                {
                    StaffId = c.Int(nullable: false, identity: true),
                    FirstName = c.String(maxLength: 64),
                    LastName = c.String(maxLength: 64),
                    CreatedAt = c.DateTime(nullable: false),
                    UpdatedAt = c.DateTime(nullable: false),
                    ManagerId = c.Int(),
                })
                .PrimaryKey(t => t.StaffId)
                .ForeignKey("dbo.Staffs", t => t.ManagerId)
                .Index(t => t.ManagerId);
        }

        public override void Down()
        {
            DropForeignKey("dbo.Staffs", "ManagerId", "dbo.Staffs");
            DropIndex("dbo.Staffs", new[] { "ManagerId" });
            DropTable("dbo.Staffs");
        }
    }
}
