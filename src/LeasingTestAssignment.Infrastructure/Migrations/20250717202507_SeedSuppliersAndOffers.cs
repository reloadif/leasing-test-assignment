using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeasingTestAssignment.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedSuppliersAndOffers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Добавляем поставщиков (5 тестовых значений)
            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "Id", "Name", "CreationDate" },
                values: new object[,]
                {
                    { 1, "Поставщик А", new DateTime(2024, 1, 1) },
                    { 2, "Поставщик Б", new DateTime(2024, 2, 1) },
                    { 3, "Поставщик В", new DateTime(2024, 3, 1) },
                    { 4, "Поставщик Г", new DateTime(2024, 4, 1) },
                    { 5, "Поставщик Д", new DateTime(2024, 5, 1) }
                }
            );

            // Добавляем офферы (15 тестовых значений)
            migrationBuilder.InsertData(
                table: "Offers",
                columns: new[] { "Id", "Mark", "Model", "SupplierId", "RegistrationDate" },
                values: new object[,]
                {
                    { 1, "Audi",    "A4",      1, new DateTime(2024, 6, 1) },
                    { 2, "BMW",     "320",     2, new DateTime(2024, 6, 2) },
                    { 3, "Toyota",  "Camry",   3, new DateTime(2024, 6, 3) },
                    { 4, "Hyundai", "Solaris", 1, new DateTime(2024, 6, 4) },
                    { 5, "Kia",     "Rio",     4, new DateTime(2024, 6, 5) },
                    { 6, "Skoda",   "Octavia", 5, new DateTime(2024, 6, 6) },
                    { 7, "VW",      "Golf",    3, new DateTime(2024, 6, 7) },
                    { 8, "Renault", "Logan",   2, new DateTime(2024, 6, 8) },
                    { 9, "Mazda",   "6",       4, new DateTime(2024, 6, 9) },
                    {10, "Ford",    "Focus",   1, new DateTime(2024, 6,10) },
                    {11, "Opel",    "Astra",   2, new DateTime(2024, 6,11) },
                    {12, "Honda",   "Civic",   5, new DateTime(2024, 6,12) },
                    {13, "Nissan",  "Almera",  3, new DateTime(2024, 6,13) },
                    {14, "Subaru",  "Impreza", 4, new DateTime(2024, 6,14) },
                    {15, "Peugeot", "308",     5, new DateTime(2024, 6,15) }
                }
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Удаляем офферы
            for (int i = 1; i <= 15; i++)
                migrationBuilder.DeleteData(table: "Offers", keyColumn: "Id", keyValue: i);

            // Удаляем поставщиков
            for (int i = 1; i <= 5; i++)
                migrationBuilder.DeleteData(table: "Suppliers", keyColumn: "Id", keyValue: i);
        }
    }
}
