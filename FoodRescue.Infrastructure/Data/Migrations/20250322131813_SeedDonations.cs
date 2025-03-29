using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FoodRescue.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedDonations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Donation",
                columns: new[] { "Id", "CharityId", "FoodType", "Location", "PickupTime", "Quantity", "Status", "UserId" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000006"), new Guid("00000000-0000-0000-0000-000000000004"), "Canned Goods", "NY Warehouse", new DateTime(2025, 3, 22, 15, 19, 24, 242, DateTimeKind.Utc), 20, "Pending", new Guid("00000000-0000-0000-0000-000000000005") },
                    { new Guid("00000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000005"), "Fresh Vegetables", "CA Storage", new DateTime(2025, 3, 23, 15, 19, 24, 242, DateTimeKind.Utc), 50, "Approved", new Guid("00000000-0000-0000-0000-000000000004") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Donation",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"));

            migrationBuilder.DeleteData(
                table: "Donation",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"));
        }
    }
}
