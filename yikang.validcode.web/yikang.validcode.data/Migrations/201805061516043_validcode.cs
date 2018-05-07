namespace yikang.validcode.data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class validcode : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.T_User", "UserType", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.T_User", "UserType", c => c.Int());
        }
    }
}
