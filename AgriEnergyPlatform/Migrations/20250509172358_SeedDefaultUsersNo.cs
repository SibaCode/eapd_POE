using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgriEnergyPlatform.Migrations
{
    /// <inheritdoc />
    public partial class SeedDefaultUsersNo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$yl7ivZuaQXXkYfwTFAIjSO3.ezOiPs.hjGYeTNbcdY6ZJbbHti63e");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "$2a$11$7G.Y105XT2IviU5.TnU0EuQbJ2R5Whu8yclJlyEw0VoTG/b6uCdla");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "PasswordHash",
                value: "$2a$11$4wrJTblTYaFKhLS.awUy0OmB3j7497.JSGl/Mg4qq6LfZTMOZvCHC");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "PasswordHash",
                value: "$2a$11$FOWyX0YS2A275EKP.sOh0.XjaoofvymA9drDnpvYQmIAggmDr0gBC");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$qvDrzyGSqMNVMNA4us830OheneBJskliWCO7HF5Fo1Uv7z57D4zVu");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "$2a$11$CXIujr/hQlyGcWjbBVsjDeibemUB7jplZl2oS3DZWPopzGQX8vNqm");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "PasswordHash",
                value: "$2a$11$EKeZPjCfuCnZLtNA2vyRV.D0Ph5p95TFl9MTYyPS9mhkvoCf.rfKa");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "PasswordHash",
                value: "$2a$11$K0cKwlQ0CvQJKRr/IIavReWYRZXuFET.IZcFWPpzXTXAz0IcZOl3q");
        }
    }
}
