using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WMS.Api.Migrations
{
    /// <inheritdoc />
    public partial class UpdateFinishedProductIssueTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_finishedProductIssuesEntry_finishedProductIssues_FinishedProductIssueId",
                table: "finishedProductIssuesEntry");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "finishedProductIssues");

            migrationBuilder.AlterColumn<string>(
                name: "FinishedProductIssueId",
                table: "finishedProductIssuesEntry",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_finishedProductIssuesEntry_finishedProductIssues_FinishedProductIssueId",
                table: "finishedProductIssuesEntry",
                column: "FinishedProductIssueId",
                principalTable: "finishedProductIssues",
                principalColumn: "FinishedProductIssueId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_finishedProductIssuesEntry_finishedProductIssues_FinishedProductIssueId",
                table: "finishedProductIssuesEntry");

            migrationBuilder.AlterColumn<string>(
                name: "FinishedProductIssueId",
                table: "finishedProductIssuesEntry",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "finishedProductIssues",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_finishedProductIssuesEntry_finishedProductIssues_FinishedProductIssueId",
                table: "finishedProductIssuesEntry",
                column: "FinishedProductIssueId",
                principalTable: "finishedProductIssues",
                principalColumn: "FinishedProductIssueId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
