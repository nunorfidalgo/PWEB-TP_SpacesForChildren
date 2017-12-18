namespace SpacesForChildren.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Evaluations",
                c => new
                    {
                        EvaluationId = c.Int(nullable: false, identity: true),
                        StarGrade = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Description = c.String(),
                        RegistryDateTime = c.DateTime(),
                        Service_ServiceId = c.Int(),
                    })
                .PrimaryKey(t => t.EvaluationId)
                .ForeignKey("dbo.Services", t => t.Service_ServiceId)
                .Index(t => t.Service_ServiceId);
            
            CreateTable(
                "dbo.IdentityUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                        Evaluation_EvaluationId = c.Int(),
                        Institution_InstitutionId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Evaluations", t => t.Evaluation_EvaluationId)
                .ForeignKey("dbo.Institutions", t => t.Institution_InstitutionId)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex")
                .Index(t => t.Evaluation_EvaluationId)
                .Index(t => t.Institution_InstitutionId);
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        IdentityUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.IdentityUsers", t => t.IdentityUser_Id)
                .Index(t => t.IdentityUser_Id);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                        IdentityUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.IdentityUsers", t => t.IdentityUser_Id)
                .Index(t => t.IdentityUser_Id);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                        IdentityUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.IdentityUsers", t => t.IdentityUser_Id)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.RoleId)
                .Index(t => t.IdentityUser_Id);
            
            CreateTable(
                "dbo.Institutions",
                c => new
                    {
                        InstitutionId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Location = c.String(nullable: false),
                        DateTime = c.DateTime(nullable: false),
                        Descricao = c.String(),
                        RegistryDateTime = c.DateTime(),
                        InstitutionType = c.Int(),
                    })
                .PrimaryKey(t => t.InstitutionId);
            
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        ServiceId = c.Int(nullable: false, identity: true),
                        Type = c.String(nullable: false),
                        Description = c.String(),
                        AgeMinus = c.Int(nullable: false),
                        AgeMajor = c.Int(nullable: false),
                        EducationLevel = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MonthlyPayment = c.Single(nullable: false),
                        Address = c.String(),
                        RegistryDateTime = c.DateTime(),
                        Institution_InstitutionId = c.Int(),
                    })
                .PrimaryKey(t => t.ServiceId)
                .ForeignKey("dbo.Institutions", t => t.Institution_InstitutionId)
                .Index(t => t.Institution_InstitutionId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        BI = c.Int(nullable: false),
                        NIF = c.Int(nullable: false),
                        Address = c.String(),
                        BirthDate = c.DateTime(),
                        RegistryDateTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.IdentityUsers", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                        Service_ServiceId = c.Int(),
                        StudentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.Services", t => t.Service_ServiceId)
                .Index(t => t.Id)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.Service_ServiceId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "Service_ServiceId", "dbo.Services");
            DropForeignKey("dbo.Students", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Students", "Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "Id", "dbo.IdentityUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Services", "Institution_InstitutionId", "dbo.Institutions");
            DropForeignKey("dbo.Evaluations", "Service_ServiceId", "dbo.Services");
            DropForeignKey("dbo.IdentityUsers", "Institution_InstitutionId", "dbo.Institutions");
            DropForeignKey("dbo.IdentityUsers", "Evaluation_EvaluationId", "dbo.Evaluations");
            DropForeignKey("dbo.AspNetUserRoles", "IdentityUser_Id", "dbo.IdentityUsers");
            DropForeignKey("dbo.AspNetUserLogins", "IdentityUser_Id", "dbo.IdentityUsers");
            DropForeignKey("dbo.AspNetUserClaims", "IdentityUser_Id", "dbo.IdentityUsers");
            DropIndex("dbo.Students", new[] { "Service_ServiceId" });
            DropIndex("dbo.Students", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Students", new[] { "Id" });
            DropIndex("dbo.AspNetUsers", new[] { "Id" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Services", new[] { "Institution_InstitutionId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "IdentityUser_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "IdentityUser_Id" });
            DropIndex("dbo.AspNetUserClaims", new[] { "IdentityUser_Id" });
            DropIndex("dbo.IdentityUsers", new[] { "Institution_InstitutionId" });
            DropIndex("dbo.IdentityUsers", new[] { "Evaluation_EvaluationId" });
            DropIndex("dbo.IdentityUsers", "UserNameIndex");
            DropIndex("dbo.Evaluations", new[] { "Service_ServiceId" });
            DropTable("dbo.Students");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Services");
            DropTable("dbo.Institutions");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.IdentityUsers");
            DropTable("dbo.Evaluations");
        }
    }
}
