using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgriEnergyPlatform.Migrations
{
    /// <inheritdoc />
    public partial class SeedDefaultUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$xOHNIfu9hm5WqxsrQUXXPO9pOxUj3ZEpSJq6KUcRT/DbSOsANPc02");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "$2a$11$w5cLf2HtNxhWRQuP9FX93unZ77kKG9WiFu.iK7iaJb4PdGzwGR91a");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "PasswordHash",
                value: "$2a$11$MzsfNNBHWnyh4zwvnbRc.unvH1Dup7UV3a9b5ZpCsA2l.HUOQR/Zq");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "PasswordHash",
                value: "$2a$11$v/0eHTol8uQPqF9kAMDtGOf/VVW89so4zjTzjpzb1ZLGxEfsgqSF6");
        }
    }
}
