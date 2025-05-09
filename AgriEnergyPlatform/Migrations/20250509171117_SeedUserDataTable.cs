using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgriEnergyPlatform.Migrations
{
    /// <inheritdoc />
    public partial class SeedUserDataTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$imDHbUk0.gZV5A8Ti9rfQ.EjOF./5RQuc8NvL5fGsZgAi3x7719g6");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "$2a$11$JUyNN/PvKmwOl9xKQhv4Z.1p/ERjKRzBGMTrB0eJ4CgeQkMIDjUaS");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "PasswordHash",
                value: "$2a$11$v9BgCRMoTlTTgiLeZO.ZG.MkcANQZ9pc/A5bTw/kqwtO.3Te0pH7a");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "PasswordHash",
                value: "$2a$11$bNKQO7kAb7RtlfOofPa6DOJAX6e0YuPYgXtDDEJGjWP88QaLIXqmS");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$XVyBKTnkxwMB5/R0zphS5ONwBxtm.MXaVTIGgnhBAnDTb35hHh/cm");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "$2a$11$YNwYxH4VbuRDI7ukkyGnKehBRD4qnl2IAPB9YD7pJXiHDz20Ln1AK");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "PasswordHash",
                value: "$2a$11$Zuomzz4IyWFkDTZMBAN.6OLwOzgnhaRRjAXg8U/hZb8McpBJ7KjBa");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "PasswordHash",
                value: "$2a$11$.4v88BKkSqk3YMYa8QyGeelbUCml8/6eptEZmvbe5wzDaNezEm.RC");
        }
    }
}
