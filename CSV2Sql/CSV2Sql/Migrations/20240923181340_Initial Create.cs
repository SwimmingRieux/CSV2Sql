using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CSV2Sql.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Qualities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Q = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Qualities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Years",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ImpactFactor = table.Column<string>(type: "text", nullable: false),
                    YearPublished = table.Column<string>(type: "text", nullable: false),
                    CumulativeCitations = table.Column<string>(type: "text", nullable: false),
                    ImmediateImpactFactor = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Years", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Journals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    ISSN = table.Column<string>(type: "text", nullable: false),
                    EISSN = table.Column<string>(type: "text", nullable: false),
                    Language = table.Column<string>(type: "text", nullable: false),
                    Country = table.Column<string>(type: "text", nullable: false),
                    Province = table.Column<string>(type: "text", nullable: false),
                    Publisher = table.Column<string>(type: "text", nullable: false),
                    YearId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Journals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Journals_Years_YearId",
                        column: x => x.YearId,
                        principalTable: "Years",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JournalQualities",
                columns: table => new
                {
                    JournalsId = table.Column<int>(type: "integer", nullable: false),
                    QualitiesId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JournalQualities", x => new { x.JournalsId, x.QualitiesId });
                    table.ForeignKey(
                        name: "FK_JournalQualities_Journals_JournalsId",
                        column: x => x.JournalsId,
                        principalTable: "Journals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JournalQualities_Qualities_QualitiesId",
                        column: x => x.QualitiesId,
                        principalTable: "Qualities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JournalQualities_QualitiesId",
                table: "JournalQualities",
                column: "QualitiesId");

            migrationBuilder.CreateIndex(
                name: "IX_Journals_YearId",
                table: "Journals",
                column: "YearId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JournalQualities");

            migrationBuilder.DropTable(
                name: "Journals");

            migrationBuilder.DropTable(
                name: "Qualities");

            migrationBuilder.DropTable(
                name: "Years");
        }
    }
}
