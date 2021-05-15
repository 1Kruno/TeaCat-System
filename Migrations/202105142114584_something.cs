namespace WebApplication5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class something : DbMigration
    {
        public override void Up()
        {
            /*
            RenameTable(name: "dbo.Users", newName: "AspNetUsers");
            RenameTable(name: "dbo.IdentityUserClaim", newName: "AspNetUserClaims");
            RenameTable(name: "dbo.IdentityUserLogin", newName: "AspNetUserLogins");
            RenameTable(name: "dbo.IdentityUserRole", newName: "AspNetUserRoles");
            DropForeignKey("dbo.Assignment", "AgentID", "dbo.Agent");
            DropForeignKey("dbo.Ticket", "AgentID", "dbo.Agent");
            DropForeignKey("dbo.Assignment", "TicketID", "dbo.Ticket");
            DropForeignKey("dbo.Ticket", "DepartmentID", "dbo.Department");
            DropForeignKey("dbo.Agent", "DepartmentID", "dbo.Department");
            DropForeignKey("dbo.Agent", "UserId", "dbo.Users");
            DropForeignKey("dbo.KeywordsDepartment", "DepartmentID", "dbo.Department");
            DropForeignKey("dbo.IdentityUserClaim", "IdentityUser_Id", "dbo.Users");
            DropForeignKey("dbo.IdentityUserLogin", "IdentityUser_Id", "dbo.Users");
            DropForeignKey("dbo.IdentityUserRole", "IdentityUser_Id", "dbo.Users");
            DropIndex("dbo.Agent", new[] { "DepartmentID" });
            DropIndex("dbo.Agent", new[] { "UserId" });
            DropIndex("dbo.Assignment", new[] { "AgentID" });
            DropIndex("dbo.Assignment", new[] { "TicketID" });
            DropIndex("dbo.Ticket", new[] { "AgentID" });
            DropIndex("dbo.Ticket", new[] { "DepartmentID" });
            DropIndex("dbo.AspNetUserClaims", new[] { "IdentityUser_Id" });
            DropIndex("dbo.AspNetUserLogins", new[] { "IdentityUser_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "IdentityUser_Id" });
            DropIndex("dbo.KeywordsDepartment", new[] { "DepartmentID" });
            DropColumn("dbo.AspNetUserClaims", "UserId");
            DropColumn("dbo.AspNetUserLogins", "UserId");
            DropColumn("dbo.AspNetUserRoles", "UserId");
            RenameColumn(table: "dbo.AspNetUsers", name: "UserId", newName: "Id");
            RenameColumn(table: "dbo.AspNetUserClaims", name: "IdentityUser_Id", newName: "UserId");
            RenameColumn(table: "dbo.AspNetUserLogins", name: "IdentityUser_Id", newName: "UserId");
            RenameColumn(table: "dbo.AspNetUserRoles", name: "IdentityUser_Id", newName: "UserId");
            DropPrimaryKey("dbo.AspNetUserLogins");
            DropPrimaryKey("dbo.AspNetUserRoles");
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            AlterColumn("dbo.AspNetUsers", "Email", c => c.String(maxLength: 256));
            AlterColumn("dbo.AspNetUsers", "UserName", c => c.String(nullable: false, maxLength: 256));
            AlterColumn("dbo.AspNetUserClaims", "UserId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.AspNetUserClaims", "UserId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.AspNetUserLogins", "LoginProvider", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.AspNetUserLogins", "ProviderKey", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.AspNetUserLogins", "UserId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.AspNetUserRoles", "UserId", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.AspNetUserLogins", new[] { "LoginProvider", "ProviderKey", "UserId" });
            AddPrimaryKey("dbo.AspNetUserRoles", new[] { "UserId", "RoleId" });
            CreateIndex("dbo.AspNetUserRoles", "UserId");
            CreateIndex("dbo.AspNetUserRoles", "RoleId");
            CreateIndex("dbo.AspNetUsers", "UserName", unique: true, name: "UserNameIndex");
            CreateIndex("dbo.AspNetUserClaims", "UserId");
            CreateIndex("dbo.AspNetUserLogins", "UserId");
            AddForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            DropColumn("dbo.AspNetUsers", "Discriminator");
            DropTable("dbo.Agent");
            DropTable("dbo.Assignment");
            DropTable("dbo.Ticket");
            DropTable("dbo.Department");
            DropTable("dbo.KeywordsDepartment");
            */
        }
        
        public override void Down()
        {/*
            CreateTable(
                "dbo.KeywordsDepartment",
                c => new
                    {
                        KeywordID = c.Int(nullable: false, identity: true),
                        Keyword = c.String(),
                        DepartmentID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.KeywordID);
            
            CreateTable(
                "dbo.Department",
                c => new
                    {
                        DepartmentID = c.Int(nullable: false, identity: true),
                        DepartmentName = c.String(),
                    })
                .PrimaryKey(t => t.DepartmentID);
            
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
                .PrimaryKey(t => t.TicketID);
            
            CreateTable(
                "dbo.Assignment",
                c => new
                    {
                        AssignmentID = c.Int(nullable: false, identity: true),
                        AgentID = c.Int(nullable: false),
                        TicketID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AssignmentID);
            
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
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.AgentID);
            
            AddColumn("dbo.AspNetUsers", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropPrimaryKey("dbo.AspNetUserRoles");
            DropPrimaryKey("dbo.AspNetUserLogins");
            AlterColumn("dbo.AspNetUserRoles", "UserId", c => c.String(maxLength: 128));
            AlterColumn("dbo.AspNetUserLogins", "UserId", c => c.String(maxLength: 128));
            AlterColumn("dbo.AspNetUserLogins", "ProviderKey", c => c.String());
            AlterColumn("dbo.AspNetUserLogins", "LoginProvider", c => c.String());
            AlterColumn("dbo.AspNetUserClaims", "UserId", c => c.String(maxLength: 128));
            AlterColumn("dbo.AspNetUserClaims", "UserId", c => c.String());
            AlterColumn("dbo.AspNetUsers", "UserName", c => c.String());
            AlterColumn("dbo.AspNetUsers", "Email", c => c.String());
            DropTable("dbo.AspNetRoles");
            AddPrimaryKey("dbo.AspNetUserRoles", new[] { "RoleId", "UserId" });
            AddPrimaryKey("dbo.AspNetUserLogins", "UserId");
            RenameColumn(table: "dbo.AspNetUserRoles", name: "UserId", newName: "IdentityUser_Id");
            RenameColumn(table: "dbo.AspNetUserLogins", name: "UserId", newName: "IdentityUser_Id");
            RenameColumn(table: "dbo.AspNetUserClaims", name: "UserId", newName: "IdentityUser_Id");
            RenameColumn(table: "dbo.AspNetUsers", name: "Id", newName: "UserId");
            AddColumn("dbo.AspNetUserRoles", "UserId", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.AspNetUserLogins", "UserId", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.AspNetUserClaims", "UserId", c => c.String());
            CreateIndex("dbo.KeywordsDepartment", "DepartmentID");
            CreateIndex("dbo.AspNetUserRoles", "IdentityUser_Id");
            CreateIndex("dbo.AspNetUserLogins", "IdentityUser_Id");
            CreateIndex("dbo.AspNetUserClaims", "IdentityUser_Id");
            CreateIndex("dbo.Ticket", "DepartmentID");
            CreateIndex("dbo.Ticket", "AgentID");
            CreateIndex("dbo.Assignment", "TicketID");
            CreateIndex("dbo.Assignment", "AgentID");
            CreateIndex("dbo.Agent", "UserId");
            CreateIndex("dbo.Agent", "DepartmentID");
            AddForeignKey("dbo.IdentityUserRole", "IdentityUser_Id", "dbo.Users", "UserId");
            AddForeignKey("dbo.IdentityUserLogin", "IdentityUser_Id", "dbo.Users", "UserId");
            AddForeignKey("dbo.IdentityUserClaim", "IdentityUser_Id", "dbo.Users", "UserId");
            AddForeignKey("dbo.KeywordsDepartment", "DepartmentID", "dbo.Department", "DepartmentID");
            AddForeignKey("dbo.Agent", "UserId", "dbo.Users", "UserId");
            AddForeignKey("dbo.Agent", "DepartmentID", "dbo.Department", "DepartmentID");
            AddForeignKey("dbo.Ticket", "DepartmentID", "dbo.Department", "DepartmentID");
            AddForeignKey("dbo.Assignment", "TicketID", "dbo.Ticket", "TicketID");
            AddForeignKey("dbo.Ticket", "AgentID", "dbo.Agent", "AgentID");
            AddForeignKey("dbo.Assignment", "AgentID", "dbo.Agent", "AgentID");
            RenameTable(name: "dbo.AspNetUserRoles", newName: "IdentityUserRole");
            RenameTable(name: "dbo.AspNetUserLogins", newName: "IdentityUserLogin");
            RenameTable(name: "dbo.AspNetUserClaims", newName: "IdentityUserClaim");
            RenameTable(name: "dbo.AspNetUsers", newName: "Users");
            */
        }
    }
}
