using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace again.Migrations
{
    public partial class eventmodeldbset2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EventID",
                table: "Player",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EventID",
                table: "Game",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Event",
                columns: table => new
                {
                    EventID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EventTitle = table.Column<string>(nullable: true),
                    DateTime = table.Column<DateTime>(nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    Active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event", x => x.EventID);
                });

            migrationBuilder.CreateTable(
                name: "EventGames",
                columns: table => new
                {
                    EventGamesID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EventID = table.Column<int>(nullable: false),
                    GameID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventGames", x => x.EventGamesID);
                    table.ForeignKey(
                        name: "FK_EventGames_Event_EventID",
                        column: x => x.EventID,
                        principalTable: "Event",
                        principalColumn: "EventID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventGames_Game_GameID",
                        column: x => x.GameID,
                        principalTable: "Game",
                        principalColumn: "GameID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventPlayers",
                columns: table => new
                {
                    EventPlayersID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EventID = table.Column<int>(nullable: false),
                    PlayerID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventPlayers", x => x.EventPlayersID);
                    table.ForeignKey(
                        name: "FK_EventPlayers_Event_EventID",
                        column: x => x.EventID,
                        principalTable: "Event",
                        principalColumn: "EventID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventPlayers_Player_PlayerID",
                        column: x => x.PlayerID,
                        principalTable: "Player",
                        principalColumn: "PlayerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Player_EventID",
                table: "Player",
                column: "EventID");

            migrationBuilder.CreateIndex(
                name: "IX_Game_EventID",
                table: "Game",
                column: "EventID");

            migrationBuilder.CreateIndex(
                name: "IX_EventGames_EventID",
                table: "EventGames",
                column: "EventID");

            migrationBuilder.CreateIndex(
                name: "IX_EventGames_GameID",
                table: "EventGames",
                column: "GameID");

            migrationBuilder.CreateIndex(
                name: "IX_EventPlayers_EventID",
                table: "EventPlayers",
                column: "EventID");

            migrationBuilder.CreateIndex(
                name: "IX_EventPlayers_PlayerID",
                table: "EventPlayers",
                column: "PlayerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Game_Event_EventID",
                table: "Game",
                column: "EventID",
                principalTable: "Event",
                principalColumn: "EventID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Player_Event_EventID",
                table: "Player",
                column: "EventID",
                principalTable: "Event",
                principalColumn: "EventID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Game_Event_EventID",
                table: "Game");

            migrationBuilder.DropForeignKey(
                name: "FK_Player_Event_EventID",
                table: "Player");

            migrationBuilder.DropTable(
                name: "EventGames");

            migrationBuilder.DropTable(
                name: "EventPlayers");

            migrationBuilder.DropTable(
                name: "Event");

            migrationBuilder.DropIndex(
                name: "IX_Player_EventID",
                table: "Player");

            migrationBuilder.DropIndex(
                name: "IX_Game_EventID",
                table: "Game");

            migrationBuilder.DropColumn(
                name: "EventID",
                table: "Player");

            migrationBuilder.DropColumn(
                name: "EventID",
                table: "Game");
        }
    }
}
