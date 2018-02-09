namespace Vidly2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'4bdfa81b-e1f0-4b6f-ba93-5dce76dfc199', N'guest@vidly.com', 0, N'AOaXmqnTuxFmWIVCEmJC6QQcsCIhMvjWQEzIT59CwiShA2MhEpYRWkx5cELwSQi0Fg==', N'6002f78f-b8b0-413b-a4df-ad75ebf8d915', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'bcc442ac-7e7d-48ae-852e-4b82f3a76cda', N'admin@vidly.com', 0, N'ACFAEQtfjEEkGNe/v0lo+YB72zQT08cFUnncW7Zg4WoeKmyCmaEpNG2Wuxi/gq6YgQ==', N'8cbb85d2-7ddc-4ba2-848b-c68191a5dbfe', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'19f3c661-0890-49cb-8814-9b1cd349b06c', N'CanManageMovie')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'bcc442ac-7e7d-48ae-852e-4b82f3a76cda', N'19f3c661-0890-49cb-8814-9b1cd349b06c')


");
        }
        
        public override void Down()
        {
        }
    }
}
