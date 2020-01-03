namespace Superheroes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SuperHeroes", "Weakness", c => c.String());
            AddColumn("dbo.SuperHeroes", "Hometown", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.SuperHeroes", "Hometown");
            DropColumn("dbo.SuperHeroes", "Weakness");
        }
    }
}
