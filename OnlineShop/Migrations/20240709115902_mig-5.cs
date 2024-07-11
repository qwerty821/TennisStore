using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineStore.Migrations
{
    /// <inheritdoc />
    public partial class mig5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.AddColumn<string>(
                name: "IP",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rackets",
                table: "Rackets",
                column: "RId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Brands",
                table: "Brands",
                column: "BId");

            migrationBuilder.CreateIndex(
                name: "IX_Rackets_RBrandNavigationBId",
                table: "Rackets",
                column: "RBrandNavigationBId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rackets_Brands_RBrandNavigationBId",
                table: "Rackets",
                column: "RBrandNavigationBId",
                principalTable: "Brands",
                principalColumn: "BId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
          

            migrationBuilder.RenameColumn(
                name: "RPrice",
                table: "Rackets",
                newName: "r_price");

            migrationBuilder.RenameColumn(
                name: "RName",
                table: "Rackets",
                newName: "r_name");

            migrationBuilder.RenameColumn(
                name: "RImageUrl",
                table: "Rackets",
                newName: "r_image_url");

            migrationBuilder.RenameColumn(
                name: "RBrand",
                table: "Rackets",
                newName: "r_brand");

            migrationBuilder.RenameColumn(
                name: "RId",
                table: "Rackets",
                newName: "r_id");

            migrationBuilder.RenameColumn(
                name: "BName",
                table: "Brands",
                newName: "b_name");

            migrationBuilder.RenameColumn(
                name: "BId",
                table: "Brands",
                newName: "b_id");

             
        }
    }
}
