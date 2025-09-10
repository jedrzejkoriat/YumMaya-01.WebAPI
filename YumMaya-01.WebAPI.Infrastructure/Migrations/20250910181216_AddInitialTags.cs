using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace YumMaya_01.WebAPI.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddInitialTags : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Servings",
                table: "Recipes",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "PreparationTime",
                table: "Recipes",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "CookingTime",
                table: "Recipes",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("005d9684-7f2e-47eb-885b-027eac046e57"), "Savory" },
                    { new Guid("128d75d6-6184-4e24-b182-d5882805a2f2"), "Fit" },
                    { new Guid("20db370a-bc89-4594-a32d-f541f116d022"), "Sweet" },
                    { new Guid("262d6aa6-41ee-4824-8769-07a397dbcdc0"), "Vegan" },
                    { new Guid("462ec5fc-d3cc-4ef6-b9a2-4ec049bca6dd"), "Vegetarian" },
                    { new Guid("4ee7389d-20b3-4d65-beaa-ebd8c5d984f9"), "Protein" },
                    { new Guid("6557296d-8bc7-495f-8c78-ed90702d7587"), "Gluten-Free" },
                    { new Guid("8f7bcfa2-686a-4cfd-b5e4-963d1fddc9b3"), "Spicy" },
                    { new Guid("aa0ebb7a-3061-4b76-87b2-02ef97154bf5"), "Keto" },
                    { new Guid("c04dc859-3044-4f4f-a1cd-b49c8cf21c05"), "Nut-Free" },
                    { new Guid("e475a0b8-c470-475f-a6e3-b33620628da7"), "Dairy-Free" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("005d9684-7f2e-47eb-885b-027eac046e57"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("128d75d6-6184-4e24-b182-d5882805a2f2"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("20db370a-bc89-4594-a32d-f541f116d022"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("262d6aa6-41ee-4824-8769-07a397dbcdc0"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("462ec5fc-d3cc-4ef6-b9a2-4ec049bca6dd"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("4ee7389d-20b3-4d65-beaa-ebd8c5d984f9"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("6557296d-8bc7-495f-8c78-ed90702d7587"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("8f7bcfa2-686a-4cfd-b5e4-963d1fddc9b3"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("aa0ebb7a-3061-4b76-87b2-02ef97154bf5"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("c04dc859-3044-4f4f-a1cd-b49c8cf21c05"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("e475a0b8-c470-475f-a6e3-b33620628da7"));

            migrationBuilder.AlterColumn<int>(
                name: "Servings",
                table: "Recipes",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PreparationTime",
                table: "Recipes",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CookingTime",
                table: "Recipes",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);
        }
    }
}
