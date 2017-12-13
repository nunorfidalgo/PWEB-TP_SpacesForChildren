namespace SpacesForChildren.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDataBase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Children",
                c => new
                    {
                        ChildrenId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(),
                        RegistryDateTime = c.DateTime(),
                        Service_ServiceId = c.Int(),
                    })
                .PrimaryKey(t => t.ChildrenId)
                .ForeignKey("dbo.User", t => t.UserId)
                .ForeignKey("dbo.Service", t => t.Service_ServiceId)
                .Index(t => t.UserId)
                .Index(t => t.Service_ServiceId);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        BI = c.Int(nullable: false),
                        NIF = c.Int(nullable: false),
                        EmailAddress = c.String(nullable: false),
                        Name = c.String(nullable: false),
                        PhoneNumber = c.String(),
                        Address = c.String(),
                        BirthDate = c.DateTime(),
                        RegistryDateTime = c.DateTime(),
                        UserType = c.Int(),
                        Evaluation_EvaluationId = c.Int(),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Evaluation", t => t.Evaluation_EvaluationId)
                .Index(t => t.Evaluation_EvaluationId);
            
            CreateTable(
                "dbo.Evaluation",
                c => new
                    {
                        EvaluationId = c.Int(nullable: false, identity: true),
                        StarGrade = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Description = c.String(),
                        RegistryDateTime = c.DateTime(),
                        Service_ServiceId = c.Int(),
                    })
                .PrimaryKey(t => t.EvaluationId)
                .ForeignKey("dbo.Service", t => t.Service_ServiceId)
                .Index(t => t.Service_ServiceId);
            
            CreateTable(
                "dbo.Institution",
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
                "dbo.Service",
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
                .ForeignKey("dbo.Institution", t => t.Institution_InstitutionId)
                .Index(t => t.Institution_InstitutionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Service", "Institution_InstitutionId", "dbo.Institution");
            DropForeignKey("dbo.Evaluation", "Service_ServiceId", "dbo.Service");
            DropForeignKey("dbo.Children", "Service_ServiceId", "dbo.Service");
            DropForeignKey("dbo.User", "Evaluation_EvaluationId", "dbo.Evaluation");
            DropForeignKey("dbo.Children", "UserId", "dbo.User");
            DropIndex("dbo.Service", new[] { "Institution_InstitutionId" });
            DropIndex("dbo.Evaluation", new[] { "Service_ServiceId" });
            DropIndex("dbo.User", new[] { "Evaluation_EvaluationId" });
            DropIndex("dbo.Children", new[] { "Service_ServiceId" });
            DropIndex("dbo.Children", new[] { "UserId" });
            DropTable("dbo.Service");
            DropTable("dbo.Institution");
            DropTable("dbo.Evaluation");
            DropTable("dbo.User");
            DropTable("dbo.Children");
        }
    }
}
