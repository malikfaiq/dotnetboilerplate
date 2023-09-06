using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace netboilerplate.Migrations
{
    /// <inheritdoc />
    public partial class FactioncharacterRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Faction",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faction", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CharacterFaction",
                columns: table => new
                {
                    CharactersId = table.Column<int>(type: "int", nullable: false),
                    FactionsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterFaction", x => new { x.CharactersId, x.FactionsId });
                    table.ForeignKey(
                        name: "FK_CharacterFaction_Characters_CharactersId",
                        column: x => x.CharactersId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterFaction_Faction_FactionsId",
                        column: x => x.FactionsId,
                        principalTable: "Faction",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CharacterFaction_FactionsId",
                table: "CharacterFaction",
                column: "FactionsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CharacterFaction");

            migrationBuilder.DropTable(
                name: "Faction");
        }
    }
}
