namespace Vidly2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomerDobField : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Dob", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "Dob");
        }
    }
}
