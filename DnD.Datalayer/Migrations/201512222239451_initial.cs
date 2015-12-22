namespace DnD.Datalayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AbilityScores",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Strength = c.Int(nullable: false),
                        StrengthBonus = c.Int(nullable: false),
                        Dexterity = c.Int(nullable: false),
                        DexterityBonus = c.Int(nullable: false),
                        Constitution = c.Int(nullable: false),
                        ConstitutionBonus = c.Int(nullable: false),
                        Intelligence = c.Int(nullable: false),
                        IntelligenceBonus = c.Int(nullable: false),
                        Wisdom = c.Int(nullable: false),
                        WisdomBonus = c.Int(nullable: false),
                        Charisma = c.Int(nullable: false),
                        CharismaBonus = c.Int(nullable: false),
                        DateCreated = c.DateTimeOffset(nullable: false, precision: 7),
                        DateUpdated = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.CharacterClasses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        DateCreated = c.DateTimeOffset(nullable: false, precision: 7),
                        DateUpdated = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Characters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Level = c.Int(nullable: false),
                        Experience = c.Int(nullable: false),
                        AbilityScoresId = c.Int(nullable: false),
                        ClassId = c.Int(nullable: false),
                        DateCreated = c.DateTimeOffset(nullable: false, precision: 7),
                        DateUpdated = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AbilityScores", t => t.AbilityScoresId, cascadeDelete: true)
                .ForeignKey("dbo.CharacterClasses", t => t.ClassId, cascadeDelete: true)
                .Index(t => t.Id)
                .Index(t => t.AbilityScoresId)
                .Index(t => t.ClassId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Characters", "ClassId", "dbo.CharacterClasses");
            DropForeignKey("dbo.Characters", "AbilityScoresId", "dbo.AbilityScores");
            DropIndex("dbo.Characters", new[] { "ClassId" });
            DropIndex("dbo.Characters", new[] { "AbilityScoresId" });
            DropIndex("dbo.Characters", new[] { "Id" });
            DropIndex("dbo.CharacterClasses", new[] { "Id" });
            DropIndex("dbo.AbilityScores", new[] { "Id" });
            DropTable("dbo.Characters");
            DropTable("dbo.CharacterClasses");
            DropTable("dbo.AbilityScores");
        }
    }
}
