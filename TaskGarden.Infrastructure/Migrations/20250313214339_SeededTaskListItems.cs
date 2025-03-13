using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TaskGarden.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeededTaskListItems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b503418-dc0f-4187-93c0-2e30070b2835",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ea134c6a-a912-481e-9c1d-5552218c4ca8", "AQAAAAIAAYagAAAAEOY59L4gcaRoETXuKgjbzDJJ2P4IpuEBiFN3ERktQ2D0/ryqAFYpT65iJ7W8EihRUQ==", "3b1fbdd2-3f94-4ab8-9532-665e7680ad7a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "40fcec36-7eef-42d8-8086-cd2226b88d00",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "10924ff3-3809-4302-8ce1-f1ae4383f547", "AQAAAAIAAYagAAAAEBWrzVxb6sPlt/lgKWoadIoP5XYbqPhGOG0V3ZXtfx8EIiizLk8pXjiPO3lpNvN7QQ==", "100aae54-f659-47e5-9964-5ec844fe7078" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e22a16c-da04-4232-b479-95c3a7b89259",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4e410f0f-8cb1-4fa3-a431-db95485d4a9a", "AQAAAAIAAYagAAAAEOdqidL96n2T/HTrkms9YP5ebty61AYYEJk4PyjytxmHjtcAilubo89u6Hpi1jL9Fg==", "5b477896-9ba7-468b-960b-03c72044ffa6" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(6092), new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(6096) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(6105), new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(6105) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(6107), new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(6107) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(6110), new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(6110) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(6112), new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(6112) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(6114), new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(6114) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(6115), new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(6116) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(6117), new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(6117) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(6119), new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(6119) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(6120), new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(6121) });

            migrationBuilder.InsertData(
                table: "TaskListItems",
                columns: new[] { "Id", "CompletedById", "CreatedAt", "Description", "IsCompleted", "Position", "TaskListId", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7367), "Buy apples", false, 1, 1, new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7367) },
                    { 2, "1b503418-dc0f-4187-93c0-2e30070b2835", new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7371), "Buy bananas", true, 2, 1, new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7372) },
                    { 3, null, new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7373), "Buy oranges", false, 3, 1, new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7373) },
                    { 4, "1b503418-dc0f-4187-93c0-2e30070b2835", new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7374), "Buy milk", true, 4, 1, new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7375) },
                    { 5, null, new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7376), "Buy eggs", false, 5, 1, new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7376) },
                    { 6, "1b503418-dc0f-4187-93c0-2e30070b2835", new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7377), "Buy toothpaste", true, 1, 2, new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7377) },
                    { 7, null, new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7378), "Buy toothbrush", false, 2, 2, new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7379) },
                    { 8, null, new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7380), "Buy shampoo", false, 3, 2, new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7380) },
                    { 9, "1b503418-dc0f-4187-93c0-2e30070b2835", new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7381), "Buy conditioner", true, 4, 2, new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7382) },
                    { 10, null, new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7383), "Buy soap", false, 5, 2, new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7383) },
                    { 11, null, new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7384), "Pay rent", false, 1, 3, new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7384) },
                    { 12, "1b503418-dc0f-4187-93c0-2e30070b2835", new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7385), "Confirm payment", true, 2, 3, new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7385) },
                    { 13, null, new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7386), "Pay electricity bill", false, 1, 4, new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7387) },
                    { 14, "1b503418-dc0f-4187-93c0-2e30070b2835", new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7388), "Check bill amount", true, 2, 4, new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7388) },
                    { 15, null, new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7389), "Buy popcorn", false, 1, 5, new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7389) },
                    { 16, "1b503418-dc0f-4187-93c0-2e30070b2835", new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7390), "Pick movie", true, 2, 5, new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7390) },
                    { 17, null, new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7391), "Prepare snacks", false, 3, 5, new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7392) },
                    { 18, null, new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7393), "Buy concert tickets", false, 1, 6, new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7393) },
                    { 19, "1b503418-dc0f-4187-93c0-2e30070b2835", new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7394), "Confirm concert date", true, 2, 6, new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7394) },
                    { 20, "1b503418-dc0f-4187-93c0-2e30070b2835", new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7395), "Book flights", true, 1, 7, new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7396) },
                    { 21, null, new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7397), "Reserve hotel", false, 2, 7, new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7397) },
                    { 22, null, new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7398), "Plan itinerary", false, 3, 7, new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7398) },
                    { 23, null, new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7399), "Submit math assignment", false, 1, 8, new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7399) },
                    { 24, "1b503418-dc0f-4187-93c0-2e30070b2835", new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7400), "Submit history assignment", true, 2, 8, new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7400) },
                    { 25, "9e22a16c-da04-4232-b479-95c3a7b89259", new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7401), "Buy bread", true, 1, 9, new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7402) },
                    { 26, null, new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7403), "Buy butter", false, 2, 9, new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7403) },
                    { 27, "9e22a16c-da04-4232-b479-95c3a7b89259", new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7404), "Pay internet bill", true, 1, 10, new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7404) },
                    { 28, null, new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7405), "Buy sugar", false, 1, 11, new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7405) },
                    { 29, "40fcec36-7eef-42d8-8086-cd2226b88d00", new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7406), "Buy rice", true, 2, 11, new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7407) },
                    { 30, "40fcec36-7eef-42d8-8086-cd2226b88d00", new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7408), "Buy tomatoes", true, 1, 12, new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7408) },
                    { 31, null, new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7409), "Pay mobile bill", false, 1, 13, new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7409) },
                    { 32, null, new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7410), "Plan weekend trip", false, 1, 14, new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7411) },
                    { 33, "40fcec36-7eef-42d8-8086-cd2226b88d00", new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7411), "Book tickets", true, 2, 14, new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7412) }
                });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 1, "1b503418-dc0f-4187-93c0-2e30070b2835" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7180), new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7181) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 2, "1b503418-dc0f-4187-93c0-2e30070b2835" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7183), new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7184) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 3, "1b503418-dc0f-4187-93c0-2e30070b2835" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7185), new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7185) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 4, "1b503418-dc0f-4187-93c0-2e30070b2835" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7186), new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7186) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 5, "1b503418-dc0f-4187-93c0-2e30070b2835" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7187), new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7188) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 6, "1b503418-dc0f-4187-93c0-2e30070b2835" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7188), new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7189) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 7, "1b503418-dc0f-4187-93c0-2e30070b2835" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7189), new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7190) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 8, "1b503418-dc0f-4187-93c0-2e30070b2835" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7191), new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7191) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 11, "1b503418-dc0f-4187-93c0-2e30070b2835" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7210), new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7210) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 12, "1b503418-dc0f-4187-93c0-2e30070b2835" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7211), new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7211) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 13, "1b503418-dc0f-4187-93c0-2e30070b2835" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7212), new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7212) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 14, "1b503418-dc0f-4187-93c0-2e30070b2835" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7213), new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7214) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 9, "40fcec36-7eef-42d8-8086-cd2226b88d00" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7208), new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7208) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 10, "40fcec36-7eef-42d8-8086-cd2226b88d00" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7209), new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7209) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 11, "40fcec36-7eef-42d8-8086-cd2226b88d00" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7194), new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7195) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 12, "40fcec36-7eef-42d8-8086-cd2226b88d00" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7195), new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7196) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 13, "40fcec36-7eef-42d8-8086-cd2226b88d00" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7197), new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7197) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 14, "40fcec36-7eef-42d8-8086-cd2226b88d00" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7198), new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7198) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 1, "9e22a16c-da04-4232-b479-95c3a7b89259" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7199), new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7199) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 2, "9e22a16c-da04-4232-b479-95c3a7b89259" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7200), new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7200) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 3, "9e22a16c-da04-4232-b479-95c3a7b89259" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7201), new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7201) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 4, "9e22a16c-da04-4232-b479-95c3a7b89259" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7202), new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7202) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 5, "9e22a16c-da04-4232-b479-95c3a7b89259" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7203), new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7204) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 6, "9e22a16c-da04-4232-b479-95c3a7b89259" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7204), new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7205) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 7, "9e22a16c-da04-4232-b479-95c3a7b89259" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7205), new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7206) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 8, "9e22a16c-da04-4232-b479-95c3a7b89259" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7207), new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7207) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 9, "9e22a16c-da04-4232-b479-95c3a7b89259" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7192), new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7192) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 10, "9e22a16c-da04-4232-b479-95c3a7b89259" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7193), new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7193) });

            migrationBuilder.UpdateData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(6771), new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(6771) });

            migrationBuilder.UpdateData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(6776), new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(6776) });

            migrationBuilder.UpdateData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(6779), new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(6779) });

            migrationBuilder.UpdateData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(6781), new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(6781) });

            migrationBuilder.UpdateData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(6782), new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(6837) });

            migrationBuilder.UpdateData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(6839), new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(6839) });

            migrationBuilder.UpdateData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(6852), new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(6852) });

            migrationBuilder.UpdateData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(6854), new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(6854) });

            migrationBuilder.UpdateData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(6856), new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(6856) });

            migrationBuilder.UpdateData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(6858), new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(6858) });

            migrationBuilder.UpdateData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(6859), new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(6860) });

            migrationBuilder.UpdateData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(6861), new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(6861) });

            migrationBuilder.UpdateData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(6863), new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(6863) });

            migrationBuilder.UpdateData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(6864), new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(6865) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b503418-dc0f-4187-93c0-2e30070b2835",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "01c714ca-2912-4c17-ab29-b4fc6518726c", "AQAAAAIAAYagAAAAEA9iSgUIa+20Cd4c0TLET8KUwmcqXVvvdNTd7k5VUQxg7o7vIFzkaewqnUJmIRGF+w==", "a695b8e6-795d-451f-837d-dcef423e2757" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "40fcec36-7eef-42d8-8086-cd2226b88d00",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b15fd5a1-8dd9-4cdd-9b05-ae1898c3ec74", "AQAAAAIAAYagAAAAEJhv84jDo/GWIcuE4fMlICqlCsZtskTIXBsfyoQGg0RgCGCCJ/3lQwm3n5c+ZjQZHw==", "e4d8c9a3-2003-4c56-afcc-8a09603ec3fc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e22a16c-da04-4232-b479-95c3a7b89259",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a1547723-881a-4e87-8dbc-a20c899ea936", "AQAAAAIAAYagAAAAEGBiaUigNTRipVzJKZPHrVhA9lFq8xmM4ZQjR1+uKbiOiR687LQ+3BMzD2WsTizgEA==", "82454142-df6d-4521-a727-f7c23136419f" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(3625), new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(3631) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(3642), new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(3642) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(3645), new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(3645) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(3648), new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(3648) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(3649), new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(3650) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(3652), new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(3653) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(3654), new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(3654) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(3655), new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(3656) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(3657), new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(3658) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(3659), new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(3659) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 1, "1b503418-dc0f-4187-93c0-2e30070b2835" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(5052), new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(5052) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 2, "1b503418-dc0f-4187-93c0-2e30070b2835" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(5054), new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(5054) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 3, "1b503418-dc0f-4187-93c0-2e30070b2835" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(5055), new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(5055) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 4, "1b503418-dc0f-4187-93c0-2e30070b2835" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(5056), new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(5057) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 5, "1b503418-dc0f-4187-93c0-2e30070b2835" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(5058), new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(5058) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 6, "1b503418-dc0f-4187-93c0-2e30070b2835" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(5059), new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(5059) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 7, "1b503418-dc0f-4187-93c0-2e30070b2835" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(5060), new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(5060) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 8, "1b503418-dc0f-4187-93c0-2e30070b2835" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(5061), new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(5062) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 11, "1b503418-dc0f-4187-93c0-2e30070b2835" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(5082), new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(5082) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 12, "1b503418-dc0f-4187-93c0-2e30070b2835" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(5083), new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(5083) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 13, "1b503418-dc0f-4187-93c0-2e30070b2835" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(5084), new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(5084) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 14, "1b503418-dc0f-4187-93c0-2e30070b2835" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(5085), new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(5085) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 9, "40fcec36-7eef-42d8-8086-cd2226b88d00" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(5079), new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(5079) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 10, "40fcec36-7eef-42d8-8086-cd2226b88d00" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(5080), new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(5081) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 11, "40fcec36-7eef-42d8-8086-cd2226b88d00" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(5065), new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(5065) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 12, "40fcec36-7eef-42d8-8086-cd2226b88d00" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(5066), new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(5066) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 13, "40fcec36-7eef-42d8-8086-cd2226b88d00" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(5067), new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(5068) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 14, "40fcec36-7eef-42d8-8086-cd2226b88d00" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(5068), new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(5069) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 1, "9e22a16c-da04-4232-b479-95c3a7b89259" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(5070), new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(5070) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 2, "9e22a16c-da04-4232-b479-95c3a7b89259" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(5071), new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(5071) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 3, "9e22a16c-da04-4232-b479-95c3a7b89259" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(5072), new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(5072) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 4, "9e22a16c-da04-4232-b479-95c3a7b89259" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(5073), new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(5074) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 5, "9e22a16c-da04-4232-b479-95c3a7b89259" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(5074), new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(5075) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 6, "9e22a16c-da04-4232-b479-95c3a7b89259" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(5076), new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(5076) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 7, "9e22a16c-da04-4232-b479-95c3a7b89259" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(5077), new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(5077) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 8, "9e22a16c-da04-4232-b479-95c3a7b89259" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(5078), new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(5078) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 9, "9e22a16c-da04-4232-b479-95c3a7b89259" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(5062), new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(5063) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 10, "9e22a16c-da04-4232-b479-95c3a7b89259" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(5064), new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(5064) });

            migrationBuilder.UpdateData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(4669), new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(4670) });

            migrationBuilder.UpdateData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(4674), new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(4674) });

            migrationBuilder.UpdateData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(4676), new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(4676) });

            migrationBuilder.UpdateData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(4678), new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(4678) });

            migrationBuilder.UpdateData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(4680), new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(4746) });

            migrationBuilder.UpdateData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(4749), new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(4749) });

            migrationBuilder.UpdateData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(4751), new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(4751) });

            migrationBuilder.UpdateData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(4752), new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(4753) });

            migrationBuilder.UpdateData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(4822), new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(4823) });

            migrationBuilder.UpdateData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(4824), new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(4825) });

            migrationBuilder.UpdateData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(4826), new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(4826) });

            migrationBuilder.UpdateData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(4828), new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(4828) });

            migrationBuilder.UpdateData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(4829), new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(4830) });

            migrationBuilder.UpdateData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(4889), new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(4889) });
        }
    }
}
