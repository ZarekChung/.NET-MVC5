namespace VidlyHw02.Migrations
{
	using System;
	using System.Data.Entity.Migrations;
	
	public partial class AddMovieNumberAvailable : DbMigration
	{
		public override void Up()
		{
			AddColumn("dbo.Movies", "NumberAvailable", c => c.Byte(nullable: false));

			Sql("update Movies set NumberAvailable = NumberInStock");
		}
		
		public override void Down()
		{
			DropColumn("dbo.Movies", "NumberAvailable");
		}
	}
}
