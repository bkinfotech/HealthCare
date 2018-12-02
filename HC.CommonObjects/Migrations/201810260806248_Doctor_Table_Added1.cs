namespace HC.CommonObjects.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Doctor_Table_Added1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Doctors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Degree = c.String(),
                        Address = c.String(maxLength: 100),
                        Contact = c.String(maxLength: 44),
                        Latitude = c.String(maxLength: 10),
                        Longitude = c.String(maxLength: 10),
                        CityId = c.Int(),
                        SpecializationId = c.Int(),
                        CreatedBy = c.Int(),
                        CreatedDate = c.DateTimeOffset(precision: 7),
                        UpdatedBy = c.Int(),
                        UpdatedDate = c.DateTimeOffset(precision: 7),
                        IsActive = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Doctors");
        }
    }
}
