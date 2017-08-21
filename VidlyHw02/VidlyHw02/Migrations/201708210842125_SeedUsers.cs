namespace VidlyHw02.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'2ffdabb2-93aa-489a-8941-45c1908fece2', N'simen1127@gmail.com', 0, N'AGpKLxNoxbzMHvmWUsHFSKza/nRUFNXhkhef7PrOOQ5fxFBMRECOjDdS6gSMR6zyVA==', N'c8348447-f53b-41e6-9534-64a6d03f1c33', NULL, 0, 0, NULL, 1, 0, N'simen1127@gmail.com')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'793ab3ea-89d3-42b2-b2e6-c6583297d909', N'CanManageMovies')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'2ffdabb2-93aa-489a-8941-45c1908fece2', N'793ab3ea-89d3-42b2-b2e6-c6583297d909')
");
        }
        
        public override void Down()
        {
        }
    }
}
