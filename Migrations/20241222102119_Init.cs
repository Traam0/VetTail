using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VetTail.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "vet_users",
                columns: table => new
                {
                    _id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    first_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    last_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cin = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    phone_number = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    gender = table.Column<int>(type: "int", nullable: false, defaultValue: 2),
                    username = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    role = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    account_status = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    sec_hash = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "security hash to keep track of row version and invalidate sessions"),
                    email_address = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    date_of_birth = table.Column<DateOnly>(type: "date", nullable: false),
                    updated_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    created_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_vet_users_id", x => x._id);
                });

            migrationBuilder.CreateIndex(
                name: "unique_vet_users_cin",
                table: "vet_users",
                column: "cin",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "unique_vet_users_email_address",
                table: "vet_users",
                column: "email_address",
                unique: true,
                filter: "[email_address] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "unique_vet_users_phone_number",
                table: "vet_users",
                column: "phone_number");

            migrationBuilder.CreateIndex(
                name: "unique_vet_users_username",
                table: "vet_users",
                column: "username",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "vet_users");
        }
    }
}
