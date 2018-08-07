using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace again.Migrations
{
    public partial class newModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PlayerID",
                table: "Game",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Player",
                columns: table => new
                {
                    PlayerID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Player", x => x.PlayerID);
                });

            migrationBuilder.CreateTable(
                name: "Library",
                columns: table => new
                {
                    LibraryID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PlayerID = table.Column<int>(nullable: false),
                    GameID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Library", x => x.LibraryID);
                    table.ForeignKey(
                        name: "FK_Library_Game_GameID",
                        column: x => x.GameID,
                        principalTable: "Game",
                        principalColumn: "GameID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Library_Player_PlayerID",
                        column: x => x.PlayerID,
                        principalTable: "Player",
                        principalColumn: "PlayerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Game_PlayerID",
                table: "Game",
                column: "PlayerID");

            migrationBuilder.CreateIndex(
                name: "IX_Library_GameID",
                table: "Library",
                column: "GameID");

            migrationBuilder.CreateIndex(
                name: "IX_Library_PlayerID",
                table: "Library",
                column: "PlayerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Game_Player_PlayerID",
                table: "Game",
                column: "PlayerID",
                principalTable: "Player",
                principalColumn: "PlayerID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Game_Player_PlayerID",
                table: "Game");

            migrationBuilder.DropTable(
                name: "Library");

            migrationBuilder.DropTable(
                name: "Player");

            migrationBuilder.DropIndex(
                name: "IX_Game_PlayerID",
                table: "Game");

            migrationBuilder.DropColumn(
                name: "PlayerID",
                table: "Game");
        }
    }
}
