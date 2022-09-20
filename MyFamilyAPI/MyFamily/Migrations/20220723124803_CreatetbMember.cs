using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyFamily.Migrations
{
    public partial class CreatetbMember : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbAddresss",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AddressLine1 = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbAddresss", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbGroups",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Level = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DESCRIPTION = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbMembers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mother = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Father = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tbAddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbMembers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbMembers_tbAddresss_tbAddressId",
                        column: x => x.tbAddressId,
                        principalTable: "tbAddresss",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbFamilys",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MemberId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    GroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MainAddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    tbGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    tbMemberId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbFamilys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbFamilys_tbGroups_tbGroupId",
                        column: x => x.tbGroupId,
                        principalTable: "tbGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbFamilys_tbMembers_tbMemberId",
                        column: x => x.tbMemberId,
                        principalTable: "tbMembers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbFamilys_tbGroupId",
                table: "tbFamilys",
                column: "tbGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_tbFamilys_tbMemberId",
                table: "tbFamilys",
                column: "tbMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_tbMembers_tbAddressId",
                table: "tbMembers",
                column: "tbAddressId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbFamilys");

            migrationBuilder.DropTable(
                name: "tbGroups");

            migrationBuilder.DropTable(
                name: "tbMembers");

            migrationBuilder.DropTable(
                name: "tbAddresss");
        }
    }
}
