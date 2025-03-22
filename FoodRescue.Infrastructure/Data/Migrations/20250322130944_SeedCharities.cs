using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FoodRescue.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedCharities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Charity",
                columns: new[] { "Id", "IsVerfied", "UserId", "VerificationDocument" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000004"), true, new Guid("00000000-0000-0000-0000-000000000002"), "doc1.pdf" },
                    { new Guid("00000000-0000-0000-0000-000000000005"), false, new Guid("00000000-0000-0000-0000-000000000003"), "doc2.pdf" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Charity",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"));

            migrationBuilder.DeleteData(
                table: "Charity",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"));
        }
    }
}
