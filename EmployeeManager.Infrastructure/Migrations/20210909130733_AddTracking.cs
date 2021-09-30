using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeManager.Infrastructure.Migrations
{
    public partial class AddTracking : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tracking",
                columns: table => new
                {
                    TrackingID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeTeamID = table.Column<int>(type: "int", nullable: false),
                    ProjectTeamID = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WorkHours = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedUserId = table.Column<int>(type: "int", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tracking", x => x.TrackingID);
                    table.ForeignKey(
                        name: "FK_Tracking_AspNetUsers_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tracking_AspNetUsers_DeletedUserId",
                        column: x => x.DeletedUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tracking_AspNetUsers_ModifiedUserId",
                        column: x => x.ModifiedUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tracking_EmployeeTeam_EmployeeTeamID",
                        column: x => x.EmployeeTeamID,
                        principalTable: "EmployeeTeam",
                        principalColumn: "EmployeeTeamID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tracking_ProjectTeam_ProjectTeamID",
                        column: x => x.ProjectTeamID,
                        principalTable: "ProjectTeam",
                        principalColumn: "ProjectTeamID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tracking_CreatedUserId",
                table: "Tracking",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Tracking_DeletedUserId",
                table: "Tracking",
                column: "DeletedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Tracking_EmployeeTeamID",
                table: "Tracking",
                column: "EmployeeTeamID");

            migrationBuilder.CreateIndex(
                name: "IX_Tracking_ModifiedUserId",
                table: "Tracking",
                column: "ModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Tracking_ProjectTeamID",
                table: "Tracking",
                column: "ProjectTeamID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tracking");
        }
    }
}
