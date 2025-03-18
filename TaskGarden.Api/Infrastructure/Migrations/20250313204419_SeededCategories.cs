using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TaskGarden.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeededCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b503418-dc0f-4187-93c0-2e30070b2835",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fb4513ac-62e1-42f2-bf48-88fb5a529e87", "AQAAAAIAAYagAAAAELacx8W8QJFAgeJ3lj5Y9Lm2VihytD8ir3huA1WHUQDX5Aqbdib+emf7CIY388LyFA==", "34d230d5-50e1-4981-9cb1-7db652db0f7c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "40fcec36-7eef-42d8-8086-cd2226b88d00",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e1928c4e-aed0-4ad9-bffe-c75b78e787a6", "AQAAAAIAAYagAAAAED/R/K+61pWPrvvPMofiEwp1QF+GfMcVI3DFgKHUup4rkEqdo0tkuyGskEEhUpNVFA==", "e0141bbe-fc74-438a-bccf-ebb8df3aa442" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e22a16c-da04-4232-b479-95c3a7b89259",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a26279da-f7e6-40fa-9888-05b922f9e804", "AQAAAAIAAYagAAAAEEZua3HmUalWosg1j92knDCsuTRE6dJHDyHiPLxw6KI1BEQkUvOwKpAjdS1Y8uFm0w==", "678deaca-059a-427e-907f-aae7bba45531" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Color", "CreatedAt", "Name", "Tag", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { 1, "lime", new DateTime(2025, 3, 13, 20, 44, 19, 114, DateTimeKind.Utc).AddTicks(2193), "Groceries", "shopping-cart", new DateTime(2025, 3, 13, 20, 44, 19, 114, DateTimeKind.Utc).AddTicks(2197), "1b503418-dc0f-4187-93c0-2e30070b2835" },
                    { 2, "red", new DateTime(2025, 3, 13, 20, 44, 19, 114, DateTimeKind.Utc).AddTicks(2203), "Bills", "banknote", new DateTime(2025, 3, 13, 20, 44, 19, 114, DateTimeKind.Utc).AddTicks(2203), "1b503418-dc0f-4187-93c0-2e30070b2835" },
                    { 3, "blue", new DateTime(2025, 3, 13, 20, 44, 19, 114, DateTimeKind.Utc).AddTicks(2205), "Entertainment", "roller-coaster", new DateTime(2025, 3, 13, 20, 44, 19, 114, DateTimeKind.Utc).AddTicks(2205), "1b503418-dc0f-4187-93c0-2e30070b2835" },
                    { 4, "yellow", new DateTime(2025, 3, 13, 20, 44, 19, 114, DateTimeKind.Utc).AddTicks(2206), "Travel", "plane", new DateTime(2025, 3, 13, 20, 44, 19, 114, DateTimeKind.Utc).AddTicks(2207), "1b503418-dc0f-4187-93c0-2e30070b2835" },
                    { 5, "grape", new DateTime(2025, 3, 13, 20, 44, 19, 114, DateTimeKind.Utc).AddTicks(2208), "School", "university", new DateTime(2025, 3, 13, 20, 44, 19, 114, DateTimeKind.Utc).AddTicks(2209), "1b503418-dc0f-4187-93c0-2e30070b2835" },
                    { 6, "cyan", new DateTime(2025, 3, 13, 20, 44, 19, 114, DateTimeKind.Utc).AddTicks(2210), "Groceries", "shopping-cart", new DateTime(2025, 3, 13, 20, 44, 19, 114, DateTimeKind.Utc).AddTicks(2210), "9e22a16c-da04-4232-b479-95c3a7b89259" },
                    { 7, "orange", new DateTime(2025, 3, 13, 20, 44, 19, 114, DateTimeKind.Utc).AddTicks(2211), "Bills", "receipt", new DateTime(2025, 3, 13, 20, 44, 19, 114, DateTimeKind.Utc).AddTicks(2211), "9e22a16c-da04-4232-b479-95c3a7b89259" },
                    { 8, "indigo", new DateTime(2025, 3, 13, 20, 44, 19, 114, DateTimeKind.Utc).AddTicks(2212), "Groceries", "shopping-basket", new DateTime(2025, 3, 13, 20, 44, 19, 114, DateTimeKind.Utc).AddTicks(2213), "40fcec36-7eef-42d8-8086-cd2226b88d00" },
                    { 9, "teal", new DateTime(2025, 3, 13, 20, 44, 19, 114, DateTimeKind.Utc).AddTicks(2213), "Bills", "hand-coins", new DateTime(2025, 3, 13, 20, 44, 19, 114, DateTimeKind.Utc).AddTicks(2214), "40fcec36-7eef-42d8-8086-cd2226b88d00" },
                    { 10, "pink", new DateTime(2025, 3, 13, 20, 44, 19, 114, DateTimeKind.Utc).AddTicks(2215), "Entertainment", "theater", new DateTime(2025, 3, 13, 20, 44, 19, 114, DateTimeKind.Utc).AddTicks(2215), "40fcec36-7eef-42d8-8086-cd2226b88d00" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b503418-dc0f-4187-93c0-2e30070b2835",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "567171cd-d59a-4288-bd35-2aa76c64b894", "AQAAAAIAAYagAAAAEHbQ2h9dMb8p1M/ipj0kvNJlrfgWxfIe6aBeQDasoAvXWs4YphUSgiuK+hAMfl8ykA==", "6c377364-2af5-4430-9c29-5d7736d30a97" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "40fcec36-7eef-42d8-8086-cd2226b88d00",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5058c24a-1d3b-41b1-a4a9-0f74c16d323b", "AQAAAAIAAYagAAAAED2WQyd8h8i3GUG6WbEo1J7M9SJ3PC6hqPNsDYFd6FSYleQpMBCKfQ6xcyv/IbRq1A==", "a4cee769-0434-4fe6-975f-969a1cd97717" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e22a16c-da04-4232-b479-95c3a7b89259",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9a78cff3-b57d-45aa-838d-59def44ec1b2", "AQAAAAIAAYagAAAAEG7iMpBrtuQVqPIQsmKQZVbiJjWHjeMIi5KrMnCrOx+7aQM8GRj/9PeeHsi5RIbw8w==", "1a7470d5-ba0b-4a41-8850-db52dfb6b660" });
        }
    }
}
