using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VetTail.Migrations
{
    /// <inheritdoc />
    public partial class UserIdentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "pk_vet_users_id",
                table: "vet_users");

            migrationBuilder.DropIndex(
                name: "unique_vet_users_cin",
                table: "vet_users");

            migrationBuilder.DropIndex(
                name: "unique_vet_users_email_address",
                table: "vet_users");

            migrationBuilder.DropIndex(
                name: "unique_vet_users_phone_number",
                table: "vet_users");

            migrationBuilder.DropIndex(
                name: "unique_vet_users_username",
                table: "vet_users");

            migrationBuilder.DropColumn(
                name: "account_status",
                table: "vet_users");

            migrationBuilder.DropColumn(
                name: "cin",
                table: "vet_users");

            migrationBuilder.DropColumn(
                name: "date_of_birth",
                table: "vet_users");

            migrationBuilder.DropColumn(
                name: "first_name",
                table: "vet_users");

            migrationBuilder.DropColumn(
                name: "gender",
                table: "vet_users");

            migrationBuilder.DropColumn(
                name: "last_name",
                table: "vet_users");

            migrationBuilder.DropColumn(
                name: "password",
                table: "vet_users");

            migrationBuilder.DropColumn(
                name: "phone_number",
                table: "vet_users");

            migrationBuilder.DropColumn(
                name: "role",
                table: "vet_users");

            migrationBuilder.DropColumn(
                name: "sec_hash",
                table: "vet_users");

            migrationBuilder.RenameColumn(
                name: "username",
                table: "vet_users",
                newName: "UserName");

            migrationBuilder.RenameColumn(
                name: "email_address",
                table: "vet_users",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "_id",
                table: "vet_users",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "image",
                table: "vet_users",
                newName: "SecurityStamp");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "vet_users",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "vet_users",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AccessFailedCount",
                table: "vet_users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                table: "vet_users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EmailConfirmed",
                table: "vet_users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "LockoutEnabled",
                table: "vet_users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LockoutEnd",
                table: "vet_users",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedEmail",
                table: "vet_users",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedUserName",
                table: "vet_users",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "vet_users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "vet_users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PhoneNumberConfirmed",
                table: "vet_users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "TwoFactorEnabled",
                table: "vet_users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "pk-vet_users-id",
                table: "vet_users",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_vet_users_UserId",
                        column: x => x.UserId,
                        principalTable: "vet_users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_vet_users_UserId",
                        column: x => x.UserId,
                        principalTable: "vet_users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_vet_users_UserId",
                        column: x => x.UserId,
                        principalTable: "vet_users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "vet_user_profiles",
                columns: table => new
                {
                    _id = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    first_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    last_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cin = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    phone_number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    gender = table.Column<int>(type: "int", nullable: false, defaultValue: 2),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    date_of_birth = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk-vet_user_profile-user_id", x => x._id);
                    table.ForeignKey(
                        name: "fk-vet_users-vet_user_profliles-user_id",
                        column: x => x._id,
                        principalTable: "vet_users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    RoleId = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_vet_users_UserId",
                        column: x => x.UserId,
                        principalTable: "vet_users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "vet_users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "unique-vet_users_email_address",
                table: "vet_users",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "unique-vet_users_username",
                table: "vet_users",
                column: "UserName",
                unique: true,
                filter: "[UserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "vet_users",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "unique-vet_users_cin",
                table: "vet_user_profiles",
                column: "cin",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "vet_user_profiles");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropPrimaryKey(
                name: "pk-vet_users-id",
                table: "vet_users");

            migrationBuilder.DropIndex(
                name: "EmailIndex",
                table: "vet_users");

            migrationBuilder.DropIndex(
                name: "unique-vet_users_email_address",
                table: "vet_users");

            migrationBuilder.DropIndex(
                name: "unique-vet_users_username",
                table: "vet_users");

            migrationBuilder.DropIndex(
                name: "UserNameIndex",
                table: "vet_users");

            migrationBuilder.DropColumn(
                name: "AccessFailedCount",
                table: "vet_users");

            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                table: "vet_users");

            migrationBuilder.DropColumn(
                name: "EmailConfirmed",
                table: "vet_users");

            migrationBuilder.DropColumn(
                name: "LockoutEnabled",
                table: "vet_users");

            migrationBuilder.DropColumn(
                name: "LockoutEnd",
                table: "vet_users");

            migrationBuilder.DropColumn(
                name: "NormalizedEmail",
                table: "vet_users");

            migrationBuilder.DropColumn(
                name: "NormalizedUserName",
                table: "vet_users");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "vet_users");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "vet_users");

            migrationBuilder.DropColumn(
                name: "PhoneNumberConfirmed",
                table: "vet_users");

            migrationBuilder.DropColumn(
                name: "TwoFactorEnabled",
                table: "vet_users");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "vet_users",
                newName: "username");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "vet_users",
                newName: "email_address");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "vet_users",
                newName: "_id");

            migrationBuilder.RenameColumn(
                name: "SecurityStamp",
                table: "vet_users",
                newName: "image");

            migrationBuilder.AlterColumn<string>(
                name: "username",
                table: "vet_users",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "email_address",
                table: "vet_users",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "account_status",
                table: "vet_users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "cin",
                table: "vet_users",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateOnly>(
                name: "date_of_birth",
                table: "vet_users",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<string>(
                name: "first_name",
                table: "vet_users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "gender",
                table: "vet_users",
                type: "int",
                nullable: false,
                defaultValue: 2);

            migrationBuilder.AddColumn<string>(
                name: "last_name",
                table: "vet_users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "password",
                table: "vet_users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "phone_number",
                table: "vet_users",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "role",
                table: "vet_users",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<string>(
                name: "sec_hash",
                table: "vet_users",
                type: "nvarchar(max)",
                nullable: true,
                comment: "security hash to keep track of row version and invalidate sessions");

            migrationBuilder.AddPrimaryKey(
                name: "pk_vet_users_id",
                table: "vet_users",
                column: "_id");

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
    }
}
