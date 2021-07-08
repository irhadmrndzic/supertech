using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace superTech.Migrations
{
    public partial class initialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>("Confirmed", "Orders", "bit",
        nullable: true);
        }

    }
}
