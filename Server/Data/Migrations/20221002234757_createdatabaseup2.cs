using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Server.Data.Migrations
{
    public partial class createdatabaseup2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Rank",
                table: "Questions",
                newName: "RankId");

            migrationBuilder.RenameColumn(
                name: "Category",
                table: "Questions",
                newName: "CategoryId");

            migrationBuilder.AddColumn<int>(
                name: "AnswerID",
                table: "Questions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuestionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rank",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuestionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rank", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Questions_CategoryId",
                table: "Questions",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_RankId",
                table: "Questions",
                column: "RankId");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Category_CategoryId",
                table: "Questions",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Rank_RankId",
                table: "Questions",
                column: "RankId",
                principalTable: "Rank",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Category_CategoryId",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Rank_RankId",
                table: "Questions");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Rank");

            migrationBuilder.DropIndex(
                name: "IX_Questions_CategoryId",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Questions_RankId",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "AnswerID",
                table: "Questions");

            migrationBuilder.RenameColumn(
                name: "RankId",
                table: "Questions",
                newName: "Rank");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Questions",
                newName: "Category");
        }
    }
}
