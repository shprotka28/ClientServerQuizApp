using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Server.Data.Migrations
{
    public partial class createdatabaseup4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuestionId",
                table: "Rank");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Rank");

            migrationBuilder.DropColumn(
                name: "AnswerID",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "CorrectAnswerId",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "QuestionId",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Category");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "QuestionId",
                table: "Rank",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Rank",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AnswerID",
                table: "Questions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CorrectAnswerId",
                table: "Questions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "QuestionId",
                table: "Category",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Category",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
