namespace WebApplication5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Agent",
                c => new
                    {
                        AgentID = c.Int(nullable: false, identity: true),
                        Surname = c.String(),
                        FirstName = c.String(),
                        Email = c.String(),
                        DepartmentID = c.Int(nullable: false),
                        Role = c.String(),
                        TicketsAssigned = c.Int(nullable: false),
                        TicketsPending = c.Int(nullable: false),
                        TicketsSolved = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AgentID)
                .ForeignKey("dbo.Department", t => t.DepartmentID)
                .Index(t => t.DepartmentID);
            
            CreateTable(
                "dbo.Assignment",
                c => new
                    {
                        AssignmentID = c.Int(nullable: false, identity: true),
                        AgentID = c.Int(nullable: false),
                        TicketID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AssignmentID)
                .ForeignKey("dbo.Agent", t => t.AgentID)
                .ForeignKey("dbo.Ticket", t => t.TicketID)
                .Index(t => t.AgentID)
                .Index(t => t.TicketID);
            
            CreateTable(
                "dbo.Ticket",
                c => new
                    {
                        TicketID = c.Int(nullable: false),
                        Title = c.String(),
                        Body = c.String(),
                        Status = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        AgentID = c.Int(nullable: false),
                        DepartmentID = c.Int(),
                    })
                .PrimaryKey(t => t.TicketID)
                .ForeignKey("dbo.Agent", t => t.AgentID)
                .ForeignKey("dbo.Department", t => t.DepartmentID)
                .Index(t => t.AgentID)
                .Index(t => t.DepartmentID);
            
            CreateTable(
                "dbo.Department",
                c => new
                    {
                        DepartmentId = c.Int(nullable: false, identity: true),
                        DepartmentName = c.String(),
                    })
                .PrimaryKey(t => t.DepartmentId);
            
            CreateTable(
                "dbo.KeywordsDepartment",
                c => new
                    {
                        KeywordID = c.Int(nullable: false, identity: true),
                        Keyword = c.String(),
                        DepartmentID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.KeywordID)
                .ForeignKey("dbo.Department", t => t.DepartmentID)
                .Index(t => t.DepartmentID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.KeywordsDepartment", "DepartmentID", "dbo.Department");
            DropForeignKey("dbo.Agent", "DepartmentID", "dbo.Department");
            DropForeignKey("dbo.Ticket", "DepartmentID", "dbo.Department");
            DropForeignKey("dbo.Assignment", "TicketID", "dbo.Ticket");
            DropForeignKey("dbo.Ticket", "AgentID", "dbo.Agent");
            DropForeignKey("dbo.Assignment", "AgentID", "dbo.Agent");
            DropIndex("dbo.KeywordsDepartment", new[] { "DepartmentID" });
            DropIndex("dbo.Ticket", new[] { "DepartmentID" });
            DropIndex("dbo.Ticket", new[] { "AgentID" });
            DropIndex("dbo.Assignment", new[] { "TicketID" });
            DropIndex("dbo.Assignment", new[] { "AgentID" });
            DropIndex("dbo.Agent", new[] { "DepartmentID" });
            DropTable("dbo.KeywordsDepartment");
            DropTable("dbo.Department");
            DropTable("dbo.Ticket");
            DropTable("dbo.Assignment");
            DropTable("dbo.Agent");
        }
    }
}
