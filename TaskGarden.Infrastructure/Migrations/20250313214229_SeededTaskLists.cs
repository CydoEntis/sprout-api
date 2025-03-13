using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TaskGarden.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeededTaskLists : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b503418-dc0f-4187-93c0-2e30070b2835",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dd331e48-0dc0-4271-9655-72f7a3aa96e7", "AQAAAAIAAYagAAAAEAGj9hUAbZOawCvur4Z7aeVYYOiAM7XMERP/q6V9fHK9R99Y7KEDQxnm3dXBFL8DRA==", "3737a9a4-df25-4630-bb5b-2937f185277e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "40fcec36-7eef-42d8-8086-cd2226b88d00",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a0bd948f-3d72-4418-8eeb-7cd1e87b5960", "AQAAAAIAAYagAAAAEGMXbAQIp0PBtbKmJEo2Mmt30MopjwZ87cHRHR04gKWWe54eNmxIppRaQxPoh8WlfA==", "ce171b80-c4f6-4497-97ed-db7b4f93b341" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e22a16c-da04-4232-b479-95c3a7b89259",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c02711cc-1f42-4b38-bee9-551e397473a4", "AQAAAAIAAYagAAAAELgidyGumqrMXjRET8XT64qFTiJqBSofLjFYcm4ms0+7MbzTXPjoh/PqQqUwsNrpBg==", "039f7261-7fb2-4ae4-90e0-4557f6cb6def" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 42, 28, 602, DateTimeKind.Utc).AddTicks(5482), new DateTime(2025, 3, 13, 21, 42, 28, 602, DateTimeKind.Utc).AddTicks(5486) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 42, 28, 602, DateTimeKind.Utc).AddTicks(5497), new DateTime(2025, 3, 13, 21, 42, 28, 602, DateTimeKind.Utc).AddTicks(5497) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 42, 28, 602, DateTimeKind.Utc).AddTicks(5499), new DateTime(2025, 3, 13, 21, 42, 28, 602, DateTimeKind.Utc).AddTicks(5500) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 42, 28, 602, DateTimeKind.Utc).AddTicks(5501), new DateTime(2025, 3, 13, 21, 42, 28, 602, DateTimeKind.Utc).AddTicks(5502) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 42, 28, 602, DateTimeKind.Utc).AddTicks(5507), new DateTime(2025, 3, 13, 21, 42, 28, 602, DateTimeKind.Utc).AddTicks(5508) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 42, 28, 602, DateTimeKind.Utc).AddTicks(5510), new DateTime(2025, 3, 13, 21, 42, 28, 602, DateTimeKind.Utc).AddTicks(5511) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 42, 28, 602, DateTimeKind.Utc).AddTicks(5512), new DateTime(2025, 3, 13, 21, 42, 28, 602, DateTimeKind.Utc).AddTicks(5512) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 42, 28, 602, DateTimeKind.Utc).AddTicks(5514), new DateTime(2025, 3, 13, 21, 42, 28, 602, DateTimeKind.Utc).AddTicks(5514) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 42, 28, 602, DateTimeKind.Utc).AddTicks(5516), new DateTime(2025, 3, 13, 21, 42, 28, 602, DateTimeKind.Utc).AddTicks(5516) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 42, 28, 602, DateTimeKind.Utc).AddTicks(5518), new DateTime(2025, 3, 13, 21, 42, 28, 602, DateTimeKind.Utc).AddTicks(5518) });

            migrationBuilder.InsertData(
                table: "TaskLists",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "CreatedById", "Description", "IsCompleted", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 3, 13, 21, 42, 28, 602, DateTimeKind.Utc).AddTicks(6304), "1b503418-dc0f-4187-93c0-2e30070b2835", "This week's shopping list for ShopRite", false, "ShopRite shopping list", new DateTime(2025, 3, 13, 21, 42, 28, 602, DateTimeKind.Utc).AddTicks(6304) },
                    { 2, 1, new DateTime(2025, 3, 13, 21, 42, 28, 602, DateTimeKind.Utc).AddTicks(6310), "1b503418-dc0f-4187-93c0-2e30070b2835", "This week's shopping list for Walmart", false, "Walmart shopping list", new DateTime(2025, 3, 13, 21, 42, 28, 602, DateTimeKind.Utc).AddTicks(6311) },
                    { 3, 2, new DateTime(2025, 3, 13, 21, 42, 28, 602, DateTimeKind.Utc).AddTicks(6312), "1b503418-dc0f-4187-93c0-2e30070b2835", "Monthly rent payment reminders", false, "Rent payment", new DateTime(2025, 3, 13, 21, 42, 28, 602, DateTimeKind.Utc).AddTicks(6313) },
                    { 4, 2, new DateTime(2025, 3, 13, 21, 42, 28, 602, DateTimeKind.Utc).AddTicks(6314), "1b503418-dc0f-4187-93c0-2e30070b2835", "Electricity bill payment reminders", false, "Electricity Bill", new DateTime(2025, 3, 13, 21, 42, 28, 602, DateTimeKind.Utc).AddTicks(6315) },
                    { 5, 3, new DateTime(2025, 3, 13, 21, 42, 28, 602, DateTimeKind.Utc).AddTicks(6316), "1b503418-dc0f-4187-93c0-2e30070b2835", "List of movies to watch this weekend", false, "Movie night", new DateTime(2025, 3, 13, 21, 42, 28, 602, DateTimeKind.Utc).AddTicks(6372) },
                    { 6, 3, new DateTime(2025, 3, 13, 21, 42, 28, 602, DateTimeKind.Utc).AddTicks(6374), "1b503418-dc0f-4187-93c0-2e30070b2835", "Track upcoming concerts and events", false, "Concert Tickets", new DateTime(2025, 3, 13, 21, 42, 28, 602, DateTimeKind.Utc).AddTicks(6375) },
                    { 7, 4, new DateTime(2025, 3, 13, 21, 42, 28, 602, DateTimeKind.Utc).AddTicks(6381), "1b503418-dc0f-4187-93c0-2e30070b2835", "Plan and book flights and hotels", false, "Vacation Planning", new DateTime(2025, 3, 13, 21, 42, 28, 602, DateTimeKind.Utc).AddTicks(6381) },
                    { 8, 5, new DateTime(2025, 3, 13, 21, 42, 28, 602, DateTimeKind.Utc).AddTicks(6383), "1b503418-dc0f-4187-93c0-2e30070b2835", "Track deadlines for assignments", false, "Assignment Deadlines", new DateTime(2025, 3, 13, 21, 42, 28, 602, DateTimeKind.Utc).AddTicks(6383) },
                    { 9, 6, new DateTime(2025, 3, 13, 21, 42, 28, 602, DateTimeKind.Utc).AddTicks(6384), "9e22a16c-da04-4232-b479-95c3a7b89259", "Weekly shopping list for Giant", false, "Giant shopping list", new DateTime(2025, 3, 13, 21, 42, 28, 602, DateTimeKind.Utc).AddTicks(6385) },
                    { 10, 7, new DateTime(2025, 3, 13, 21, 42, 28, 602, DateTimeKind.Utc).AddTicks(6386), "9e22a16c-da04-4232-b479-95c3a7b89259", "Track Internet bill payments", false, "Internet Bill", new DateTime(2025, 3, 13, 21, 42, 28, 602, DateTimeKind.Utc).AddTicks(6386) },
                    { 11, 8, new DateTime(2025, 3, 13, 21, 42, 28, 602, DateTimeKind.Utc).AddTicks(6388), "40fcec36-7eef-42d8-8086-cd2226b88d00", "Grocery list for SuperMart", false, "SuperMart shopping list", new DateTime(2025, 3, 13, 21, 42, 28, 602, DateTimeKind.Utc).AddTicks(6388) },
                    { 12, 8, new DateTime(2025, 3, 13, 21, 42, 28, 602, DateTimeKind.Utc).AddTicks(6389), "40fcec36-7eef-42d8-8086-cd2226b88d00", "List of items for the local market", false, "Local Market shopping list", new DateTime(2025, 3, 13, 21, 42, 28, 602, DateTimeKind.Utc).AddTicks(6390) },
                    { 13, 9, new DateTime(2025, 3, 13, 21, 42, 28, 602, DateTimeKind.Utc).AddTicks(6391), "40fcec36-7eef-42d8-8086-cd2226b88d00", "Keep track of monthly mobile bills", false, "Mobile Bill", new DateTime(2025, 3, 13, 21, 42, 28, 602, DateTimeKind.Utc).AddTicks(6391) },
                    { 14, 10, new DateTime(2025, 3, 13, 21, 42, 28, 602, DateTimeKind.Utc).AddTicks(6393), "40fcec36-7eef-42d8-8086-cd2226b88d00", "List of fun things to do this weekend", false, "Weekend Fun Activities", new DateTime(2025, 3, 13, 21, 42, 28, 602, DateTimeKind.Utc).AddTicks(6393) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: 14);

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

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 20, 44, 19, 114, DateTimeKind.Utc).AddTicks(2193), new DateTime(2025, 3, 13, 20, 44, 19, 114, DateTimeKind.Utc).AddTicks(2197) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 20, 44, 19, 114, DateTimeKind.Utc).AddTicks(2203), new DateTime(2025, 3, 13, 20, 44, 19, 114, DateTimeKind.Utc).AddTicks(2203) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 20, 44, 19, 114, DateTimeKind.Utc).AddTicks(2205), new DateTime(2025, 3, 13, 20, 44, 19, 114, DateTimeKind.Utc).AddTicks(2205) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 20, 44, 19, 114, DateTimeKind.Utc).AddTicks(2206), new DateTime(2025, 3, 13, 20, 44, 19, 114, DateTimeKind.Utc).AddTicks(2207) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 20, 44, 19, 114, DateTimeKind.Utc).AddTicks(2208), new DateTime(2025, 3, 13, 20, 44, 19, 114, DateTimeKind.Utc).AddTicks(2209) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 20, 44, 19, 114, DateTimeKind.Utc).AddTicks(2210), new DateTime(2025, 3, 13, 20, 44, 19, 114, DateTimeKind.Utc).AddTicks(2210) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 20, 44, 19, 114, DateTimeKind.Utc).AddTicks(2211), new DateTime(2025, 3, 13, 20, 44, 19, 114, DateTimeKind.Utc).AddTicks(2211) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 20, 44, 19, 114, DateTimeKind.Utc).AddTicks(2212), new DateTime(2025, 3, 13, 20, 44, 19, 114, DateTimeKind.Utc).AddTicks(2213) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 20, 44, 19, 114, DateTimeKind.Utc).AddTicks(2213), new DateTime(2025, 3, 13, 20, 44, 19, 114, DateTimeKind.Utc).AddTicks(2214) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 20, 44, 19, 114, DateTimeKind.Utc).AddTicks(2215), new DateTime(2025, 3, 13, 20, 44, 19, 114, DateTimeKind.Utc).AddTicks(2215) });
        }
    }
}
