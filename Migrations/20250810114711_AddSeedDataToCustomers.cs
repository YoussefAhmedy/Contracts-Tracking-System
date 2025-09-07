using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Contract_Tracking_System.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedDataToCustomers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "ID", "Address", "CreatedAt", "CustomerKind", "EmailAddress", "Name", "Phone" },
                values: new object[,]
                {
                    { 1, "الرياض - شارع الملك فهد", new DateTime(2025, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "شركة", "info@futuretech.com", "شركة المستقبل للتقنية", "0551234567" },
                    { 2, "جدة - حي الشاطئ", new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "فرد", "m.ahmed@example.com", "محمد أحمد", "0509876543" },
                    { 3, "الدمام - شارع الخليج", new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "شركة", "contact@modernbuild.com", "شركة البناء الحديث", "0532223334" },
                    { 4, "مكة المكرمة - حي الزاهر", new DateTime(2025, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "فرد", "ahmed.s@example.com", "أحمد سعيد", "0561112223" },
                    { 5, "الخبر - طريق الملك عبدالله", new DateTime(2025, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "شركة", "sales@smartsolutions.com", "شركة الحلول الذكية", "0595556667" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "ID",
                keyValue: 5);
        }
    }
}
