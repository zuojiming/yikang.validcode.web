namespace yikang.validcode.data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.t_business",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UId = c.String(),
                        IsEnabled = c.Int(),
                        CreateTime = c.DateTime(),
                        CreateUser = c.Int(),
                        UpdateTime = c.DateTime(),
                        UpdateUser = c.Int(),
                        DeletedTime = c.DateTime(),
                        DeleteUser = c.Int(),
                        UserId = c.String(),
                        TelephoneId = c.String(),
                        Content = c.String(),
                        SendPort = c.String(),
                        ProjectId = c.Int(),
                        ProjectName = c.String(),
                        CardBusId = c.Int(),
                        CardBusMoeny = c.Decimal(precision: 18, scale: 2),
                        UserPrice = c.Decimal(precision: 18, scale: 2),
                        BusMode = c.Int(),
                        ValidCode = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.T_PayMoney",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UId = c.String(),
                        IsEnabled = c.Int(),
                        CreateTime = c.DateTime(),
                        CreateUser = c.Int(),
                        UpdateTime = c.DateTime(),
                        UpdateUser = c.Int(),
                        DeletedTime = c.DateTime(),
                        DeleteUser = c.Int(),
                        UserLoginName = c.String(),
                        UserId = c.Int(),
                        CompanyName = c.String(),
                        PayType = c.Decimal(precision: 18, scale: 2),
                        Price = c.Decimal(precision: 18, scale: 2),
                        Note = c.String(),
                        Statue = c.Int(),
                        OrderNo = c.String(),
                        FileName = c.String(),
                        CurrentMoney = c.Decimal(precision: 18, scale: 2),
                        OverMoney = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.T_PayRecords",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UId = c.String(),
                        IsEnabled = c.Int(),
                        CreateTime = c.DateTime(),
                        CreateUser = c.Int(),
                        UpdateTime = c.DateTime(),
                        UpdateUser = c.Int(),
                        DeletedTime = c.DateTime(),
                        DeleteUser = c.Int(),
                        Price = c.Decimal(precision: 18, scale: 2),
                        OverPrice = c.Decimal(precision: 18, scale: 2),
                        PayMode = c.Int(),
                        Businessid = c.Int(),
                        UserId = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.t_telephone",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UId = c.String(),
                        IsEnabled = c.Int(),
                        CreateTime = c.DateTime(),
                        CreateUser = c.Int(),
                        UpdateTime = c.DateTime(),
                        UpdateUser = c.Int(),
                        DeletedTime = c.DateTime(),
                        DeleteUser = c.Int(),
                        Phone = c.String(),
                        Status = c.Int(),
                        AreaName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.T_User",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UId = c.String(),
                        IsEnabled = c.Int(),
                        CreateTime = c.DateTime(),
                        CreateUser = c.Int(),
                        UpdateTime = c.DateTime(),
                        UpdateUser = c.Int(),
                        DeletedTime = c.DateTime(),
                        DeleteUser = c.Int(),
                        LoginName = c.String(),
                        NIckName = c.String(),
                        Pwd = c.String(),
                        UserType = c.Int(),
                        UserLevel = c.Int(),
                        Mobile = c.String(),
                        QQ = c.String(),
                        CompanyName = c.String(),
                        Balance = c.Decimal(precision: 18, scale: 2),
                        TotalPay = c.Decimal(precision: 18, scale: 2),
                        Status = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.T_User");
            DropTable("dbo.t_telephone");
            DropTable("dbo.T_PayRecords");
            DropTable("dbo.T_PayMoney");
            DropTable("dbo.t_business");
        }
    }
}
