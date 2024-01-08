using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class mig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Atoms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Symbol = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AtomicNumber = table.Column<int>(type: "int", nullable: false),
                    AtomicMass = table.Column<double>(type: "float", nullable: false),
                    ElectroValency = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atoms", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Atoms",
                columns: new[] { "Id", "AtomicMass", "AtomicNumber", "ElectroValency", "Name", "Symbol" },
                values: new object[,]
                {
                    { new Guid("002d9add-fe1c-4e42-a351-4fd7bdb0a8bc"), 6.9400000000000004, 3, 1, "Lithium", "Li" },
                    { new Guid("15abd866-b43e-4ca7-877c-3052769598c7"), 40.078000000000003, 20, 2, "Calcium", "Ca" },
                    { new Guid("27251887-3bca-4fbb-8e06-57b39e495f59"), 12.010999999999999, 6, 4, "Carbon", "C" },
                    { new Guid("3a59c779-d930-454d-8c5f-3b76896c800c"), 28.085000000000001, 14, 0, "Silicon", "Si" },
                    { new Guid("3e9b52b2-3bec-41c6-b181-780eaef1a588"), 39.097999999999999, 19, 1, "Potassium", "K" },
                    { new Guid("4768b422-0faf-4333-9c29-d7bdef9c4966"), 32.060000000000002, 16, 2, "Sulphur", "S" },
                    { new Guid("47d59787-7aa8-460f-bb62-95fc3006f7af"), 30.974, 15, 4, "Phosphorus", "P" },
                    { new Guid("5aaed026-9192-43a7-a3a0-8eaed12cc10d"), 14.007, 7, 3, "Nitrogen", "N" },
                    { new Guid("a1cdb287-8c5f-4a82-b5ac-d2e84bf44230"), 4.0026000000000002, 2, 0, "Helium", "He" },
                    { new Guid("be1c681e-cce3-4340-b0fd-e72261f0e960"), 1.008, 1, 1, "Hygrogen", "H" },
                    { new Guid("be39cc70-5356-440d-8000-bac283cabc7d"), 15.999000000000001, 8, 2, "Oxygen", "O" },
                    { new Guid("c3e39aaf-9dc1-4966-88e0-f0ab41e2d0a5"), 9.0122, 4, 2, "Beryllium", "Be" },
                    { new Guid("cda61de0-20e2-4bf3-924d-dc4f1f5cd51c"), 24.305, 12, 2, "Magnesium", "Mg" },
                    { new Guid("da1197d8-7ba7-455e-ba33-c8293ad7765a"), 18.998000000000001, 9, 1, "Fluorine", "F" },
                    { new Guid("e2dc19b7-c857-4beb-8adc-c0519c908bee"), 35.450000000000003, 17, 1, "Chlorine", "Cl" },
                    { new Guid("e7f18280-06ab-4eaa-a23b-65290a308f8a"), 10.81, 5, 3, "Boron", "B" },
                    { new Guid("edd390be-4365-4655-ad29-4c6084cd3b15"), 26.981999999999999, 13, 3, "Aluminium", "Al" },
                    { new Guid("ef19273e-7bbe-4d90-beb4-17b6cf74a3f5"), 20.18, 10, 0, "Neon", "Ne" },
                    { new Guid("f993f6f6-bf55-4a99-afe4-9dd0e63bc64b"), 39.950000000000003, 18, 0, "Argon", "Ar" },
                    { new Guid("fb9fad70-1020-43b3-8871-bedd67a5001e"), 22.989999999999998, 11, 1, "Sodium", "Na" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Atoms");
        }
    }
}
