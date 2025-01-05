using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VetTail.Migrations
{
    /// <inheritdoc />
    public partial class inventoryManagment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.AddColumn<decimal>(
                name: "ProfileUserId",
                table: "vet_users",
                type: "decimal(20,0)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "vet_categories",
                columns: table => new
                {
                    _id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    category_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    category_description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk-vet_categories-id", x => x._id);
                });

            migrationBuilder.CreateTable(
                name: "vet_products",
                columns: table => new
                {
                    _id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    product_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    product_description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    stock = table.Column<long>(type: "bigint", nullable: false),
                    unit_price = table.Column<decimal>(type: "DECIMAL(10,2)", nullable: false),
                    expiry_date = table.Column<DateOnly>(type: "date", nullable: true),
                    created_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    updated_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk-vet_products-id", x => x._id);
                });

            migrationBuilder.CreateTable(
                name: "vet_suppliers",
                columns: table => new
                {
                    _id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    supplier_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    supplier_phone_number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    supplier_email_address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    supplier_address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk-vet_suppliers-id", x => x._id);
                });

            migrationBuilder.CreateTable(
                name: "vet_products_categories",
                columns: table => new
                {
                    CategoriesId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    ProductsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vet_products_categories", x => new { x.CategoriesId, x.ProductsId });
                    table.ForeignKey(
                        name: "FK_vet_products_categories_vet_categories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "vet_categories",
                        principalColumn: "_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_vet_products_categories_vet_products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "vet_products",
                        principalColumn: "_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "vet_products-suppliers",
                columns: table => new
                {
                    ProductsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SuppliersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vet_products-suppliers", x => new { x.ProductsId, x.SuppliersId });
                    table.ForeignKey(
                        name: "FK_vet_products-suppliers_vet_products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "vet_products",
                        principalColumn: "_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_vet_products-suppliers_vet_suppliers_SuppliersId",
                        column: x => x.SuppliersId,
                        principalTable: "vet_suppliers",
                        principalColumn: "_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "vet_stock_movements",
                columns: table => new
                {
                    _id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    movement_type = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: "ADD"),
                    movement_reason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    quantity = table.Column<long>(type: "bigint", nullable: false),
                    movement_time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SupplierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk-vet_stock_movements-id", x => x._id);
                    table.ForeignKey(
                        name: "fk-stock_movements-vet_suppliers-supplier_id",
                        column: x => x.SupplierId,
                        principalTable: "vet_suppliers",
                        principalColumn: "_id");
                    table.ForeignKey(
                        name: "fk-vet_products-vet-stock_movments-product_id",
                        column: x => x.ProductId,
                        principalTable: "vet_products",
                        principalColumn: "_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_vet_users_ProfileUserId",
                table: "vet_users",
                column: "ProfileUserId");

            migrationBuilder.CreateIndex(
                name: "IX_vet_products_categories_ProductsId",
                table: "vet_products_categories",
                column: "ProductsId");

            migrationBuilder.CreateIndex(
                name: "IX_vet_products-suppliers_SuppliersId",
                table: "vet_products-suppliers",
                column: "SuppliersId");

            migrationBuilder.CreateIndex(
                name: "IX_vet_stock_movements_ProductId",
                table: "vet_stock_movements",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_vet_stock_movements_SupplierId",
                table: "vet_stock_movements",
                column: "SupplierId");

            migrationBuilder.AddForeignKey(
                name: "FK_vet_users_vet_user_profiles_ProfileUserId",
                table: "vet_users",
                column: "ProfileUserId",
                principalTable: "vet_user_profiles",
                principalColumn: "_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_vet_users_vet_user_profiles_ProfileUserId",
                table: "vet_users");

            migrationBuilder.DropTable(
                name: "vet_products_categories");

            migrationBuilder.DropTable(
                name: "vet_products-suppliers");

            migrationBuilder.DropTable(
                name: "vet_stock_movements");

            migrationBuilder.DropTable(
                name: "vet_categories");

            migrationBuilder.DropTable(
                name: "vet_suppliers");

            migrationBuilder.DropTable(
                name: "vet_products");

            migrationBuilder.DropIndex(
                name: "IX_vet_users_ProfileUserId",
                table: "vet_users");

            migrationBuilder.DropColumn(
                name: "ProfileUserId",
                table: "vet_users");

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountStatus = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });
        }
    }
}
