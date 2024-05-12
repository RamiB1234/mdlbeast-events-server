using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mdlbeast_events_server.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Attended = table.Column<bool>(type: "bit", nullable: false),
                    EventName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PurchaseDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Date", "Description", "ImageURL", "Location", "Name" },
                values: new object[] { 1, "14/12/2023", "Another One In The Bag! For our 4th Soundstorm - we went bigger and wilder with 3 thrilling nights, 8 stages, and 200 artists to form your memorable experience. If you missed this year’s Storm, here’s a recap of the loudest music event in the region! This is Soundstorm.", "images/soundstorm.PNG", "Riyadh", "Soundstorm" });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Date", "Description", "ImageURL", "Location", "Name" },
                values: new object[] { 2, "25/04/2024", "It's time to get Social. Join our intimate gathering of Jeddah's music heads on Bait Zainal's rooftop in the heart of historic Al-Balad.With iconic views, carefully curated tunes by the finest homegrown and international DJ's and crave-worthy bites... we could go on and on, but the dancefloor is calling.", "images/balad.PNG", "Jeddah", "Balad Social" });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Date", "Description", "ImageURL", "Location", "Name" },
                values: new object[] { 3, "01/03/2024", "Introducing Kokub, AlUla’s supernova of music. This is planet sound - get ready to dance amongst the stars. Every other Friday, take off to Kokub - AlUla", "images/kokub.PNG", "Al Ula", "KOKOUB" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Tickets");
        }
    }
}
