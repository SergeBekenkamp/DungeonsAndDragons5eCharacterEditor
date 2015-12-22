namespace DnD.Datalayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CharacterClasses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Characters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClassId = c.Int(nullable: false),
                        Name = c.String(),
                        Level = c.Int(nullable: false),
                        Experience = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CharacterClasses", t => t.ClassId, cascadeDelete: true)
                .Index(t => t.Id)
                .Index(t => t.ClassId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Characters", "ClassId", "dbo.CharacterClasses");
            DropIndex("dbo.Characters", new[] { "ClassId" });
            DropIndex("dbo.Characters", new[] { "Id" });
            DropIndex("dbo.CharacterClasses", new[] { "Id" });
            DropTable("dbo.Characters");
            DropTable("dbo.CharacterClasses");
        }
    }
}
