namespace yikang.validcode.data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class validcode1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.T_User", "Status", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.T_User", "Status", c => c.Int());
        }
    }
}
