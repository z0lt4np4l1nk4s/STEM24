using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace STEM24.Repository.Migrations
{
    /// <inheritdoc />
    public partial class AddedEventIdToDnsRecords : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "EventId",
                table: "DnsRecords",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_DnsRecords_EventId",
                table: "DnsRecords",
                column: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_DnsRecords_Events_EventId",
                table: "DnsRecords",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DnsRecords_Events_EventId",
                table: "DnsRecords");

            migrationBuilder.DropIndex(
                name: "IX_DnsRecords_EventId",
                table: "DnsRecords");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "DnsRecords");
        }
    }
}
