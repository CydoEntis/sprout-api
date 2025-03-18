using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskGarden.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeededDemoUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b503418-dc0f-4187-93c0-2e30070b2835",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "31551e36-19c2-404f-8b9d-485aaaa6a2f8", "AQAAAAIAAYagAAAAEDThA7gIh1rKeQchIn8xTJi5Wq0dV9gAM3kI/UsShhhvB2X+panG9eGQCGOlfpQWeA==", "2c31b37e-884c-427e-af31-3f86db16a00c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "40fcec36-7eef-42d8-8086-cd2226b88d00",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "085d8894-ca6e-4915-a200-7d570cac078d", "AQAAAAIAAYagAAAAEOVwEVKhE0KlzszWuJU/l67R6zxndIzLsKcPCbh7CZ22MXuPG3ceSvAdBaU8QQcgQQ==", "9390620e-041e-4e5b-97bd-f137cba78b35" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e22a16c-da04-4232-b479-95c3a7b89259",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ff9469df-9393-4284-ab58-00a0fd20be4b", "AQAAAAIAAYagAAAAEPQIoNSl5Kyt3TqcWqMIqDGY3C1tIYm2fVgoNXb5/rfKpha7I1v4F2Ni8wh2D+M8YA==", "c3dd54a8-cf48-4049-ac30-e82f0fce6bca" });
        }
    }
}
