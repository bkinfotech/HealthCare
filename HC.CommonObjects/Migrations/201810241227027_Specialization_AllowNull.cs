namespace HC.CommonObjects.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Specialization_AllowNull : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Specializations", "CreatedBy", c => c.Int());
            AlterColumn("dbo.Specializations", "UpdatedBy", c => c.Int());
            AlterColumn("dbo.Specializations", "UpdatedDate", c => c.DateTimeOffset(precision: 7));
            AlterColumn("dbo.Specializations", "IsInternalCreated", c => c.Boolean());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Specializations", "IsInternalCreated", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Specializations", "UpdatedDate", c => c.DateTimeOffset(nullable: false, precision: 7));
            AlterColumn("dbo.Specializations", "UpdatedBy", c => c.Int(nullable: false));
            AlterColumn("dbo.Specializations", "CreatedBy", c => c.Int(nullable: false));
        }
    }
}
