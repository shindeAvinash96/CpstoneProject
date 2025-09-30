using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoanApplicationWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class fourth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Repayments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsNPA",
                table: "LoanApproved",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "LoanApplications",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Repayments");

            migrationBuilder.DropColumn(
                name: "IsNPA",
                table: "LoanApproved");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "LoanApplications");
        }
    }
}
