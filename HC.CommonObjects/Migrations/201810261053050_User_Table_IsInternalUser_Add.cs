namespace HC.CommonObjects.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class User_Table_IsInternalUser_Add : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "IsInternalUser", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "IsInternalUser");
        }
    }
}
