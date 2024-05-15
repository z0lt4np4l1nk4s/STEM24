using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace STEM24.Repository.Migrations
{
    public partial class AddedDnsRecordsAndAdditionalColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MatchingKeywords",
                table: "Events",
                newName: "Keywords");

            migrationBuilder.RenameColumn(
                name: "DomainRegistration",
                table: "Events",
                newName: "DomainRegistrationTime");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Events",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "EventId",
                table: "Comments",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "DnsRecords",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DnsRecords", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DnsRecords");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "Keywords",
                table: "Events",
                newName: "MatchingKeywords");

            migrationBuilder.RenameColumn(
                name: "DomainRegistrationTime",
                table: "Events",
                newName: "DomainRegistration");
        }
    }
}
