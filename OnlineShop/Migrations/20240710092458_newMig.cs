using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineStore.Migrations
{
    /// <inheritdoc />
    public partial class newMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rackets_Brands_RBrandNavigationBId",
                table: "Rackets");

            migrationBuilder.DropColumn(
                name: "IP",
                table: "AspNetUsers");

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
                name: "RBrandNavigationBId",
                table: "Rackets",
                newName: "BrandBId");

            migrationBuilder.RenameIndex(
                name: "IX_Rackets_RBrandNavigationBId",
                table: "Rackets",
                newName: "IX_Rackets_BrandBId");

            migrationBuilder.RenameColumn(
                name: "BName",
                table: "Brands",
                newName: "b_name");

            migrationBuilder.RenameColumn(
                name: "BId",
                table: "Brands",
                newName: "b_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Rackets_Brands_BrandBId",
                table: "Rackets",
                column: "BrandBId",
                principalTable: "Brands",
                principalColumn: "b_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rackets_Brands_BrandBId",
                table: "Rackets");

            migrationBuilder.RenameColumn(
                name: "r_price",
                table: "Rackets",
                newName: "RPrice");

            migrationBuilder.RenameColumn(
                name: "r_name",
                table: "Rackets",
                newName: "RName");

            migrationBuilder.RenameColumn(
                name: "r_image_url",
                table: "Rackets",
                newName: "RImageUrl");

            migrationBuilder.RenameColumn(
                name: "r_brand",
                table: "Rackets",
                newName: "RBrand");

            migrationBuilder.RenameColumn(
                name: "r_id",
                table: "Rackets",
                newName: "RId");

            migrationBuilder.RenameColumn(
                name: "BrandBId",
                table: "Rackets",
                newName: "RBrandNavigationBId");

            migrationBuilder.RenameIndex(
                name: "IX_Rackets_BrandBId",
                table: "Rackets",
                newName: "IX_Rackets_RBrandNavigationBId");

            migrationBuilder.RenameColumn(
                name: "b_name",
                table: "Brands",
                newName: "BName");

            migrationBuilder.RenameColumn(
                name: "b_id",
                table: "Brands",
                newName: "BId");

            migrationBuilder.AddColumn<string>(
                name: "IP",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Rackets_Brands_RBrandNavigationBId",
                table: "Rackets",
                column: "RBrandNavigationBId",
                principalTable: "Brands",
                principalColumn: "BId");
        }
    }
}
