namespace HC.CommonObjects.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class User_Table_IsInternalUser_Modify : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "IsInternalUser", c => c.Boolean());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "IsInternalUser", c => c.Int());
        }
    }
}
