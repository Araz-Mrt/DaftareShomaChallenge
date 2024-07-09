﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DaftareShomaChallenge.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Add_Date_To_Order : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "Date",
                table: "Orders",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "Orders");
        }
    }
}
