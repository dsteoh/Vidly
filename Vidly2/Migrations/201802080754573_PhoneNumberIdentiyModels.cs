namespace Vidly2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PhoneNumberIdentiyModels : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE AspNetUsers SET PhoneNumber= '' WHERE PhoneNumber IS NULL" );
            AlterColumn("dbo.AspNetUsers", "PhoneNumber", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "PhoneNumber", c => c.String());
        }
    }
}
