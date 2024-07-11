using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineStore.Migrations
{
    /// <inheritdoc />
    public partial class newMig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rackets_Brands_BrandBId",
                table: "Rackets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rackets",
                table: "Rackets");

            migrationBuilder.DropIndex(
                name: "IX_Rackets_BrandBId",
                table: "Rackets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Brands",
                table: "Brands");

            migrationBuilder.DropColumn(
                name: "BrandBId",
                table: "Rackets");

            migrationBuilder.AlterColumn<decimal>(
                name: "r_price",
                table: "Rackets",
                type: "decimal(5,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<string>(
                name: "r_name",
                table: "Rackets",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "r_image_url",
                table: "Rackets",
                type: "varchar(500)",
                unicode: false,
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "b_name",
                table: "Brands",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Racket_Id",
                table: "Rackets",
                column: "r_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Brand_Id",
                table: "Brands",
                column: "b_id");

            migrationBuilder.CreateIndex(
                name: "IX_Rackets_r_brand",
                table: "Rackets",
                column: "r_brand");

            migrationBuilder.AddForeignKey(
                name: "FK_Brands_To_Rackets",
                table: "Rackets",
                column: "r_brand",
                principalTable: "Brands",
                principalColumn: "b_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Brands_To_Rackets",
                table: "Rackets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Racket_Id",
                table: "Rackets");

            migrationBuilder.DropIndex(
                name: "IX_Rackets_r_brand",
                table: "Rackets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Brand_Id",
                table: "Brands");

            migrationBuilder.AlterColumn<decimal>(
                name: "r_price",
                table: "Rackets",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(5,2)");

            migrationBuilder.AlterColumn<string>(
                name: "r_name",
                table: "Rackets",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldUnicode: false,
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "r_image_url",
                table: "Rackets",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(500)",
                oldUnicode: false,
                oldMaxLength: 500);

            migrationBuilder.AddColumn<Guid>(
                name: "BrandBId",
                table: "Rackets",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "b_name",
                table: "Brands",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldUnicode: false,
                oldMaxLength: 50);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rackets",
                table: "Rackets",
                column: "r_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Brands",
                table: "Brands",
                column: "b_id");

            migrationBuilder.CreateIndex(
                name: "IX_Rackets_BrandBId",
                table: "Rackets",
                column: "BrandBId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rackets_Brands_BrandBId",
                table: "Rackets",
                column: "BrandBId",
                principalTable: "Brands",
                principalColumn: "b_id");
        }
    }
}
