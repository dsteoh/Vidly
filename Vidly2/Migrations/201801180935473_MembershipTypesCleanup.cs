namespace Vidly2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MembershipTypesCleanup : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MembershipTypes", "Name", c => c.String());
            DropColumn("dbo.MembershipTypes", "PaymentType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MembershipTypes", "PaymentType", c => c.String());
            DropColumn("dbo.MembershipTypes", "Name");
        }
    }
}
