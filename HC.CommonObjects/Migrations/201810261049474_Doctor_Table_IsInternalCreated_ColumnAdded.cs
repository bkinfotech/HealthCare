namespace HC.CommonObjects.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Doctor_Table_IsInternalCreated_ColumnAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Doctors", "IsInternalCreated", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Doctors", "IsInternalCreated");
        }
    }
}
