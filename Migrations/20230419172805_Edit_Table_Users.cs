using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ELearning.Migrations
{
    /// <inheritdoc />
    public partial class Edit_Table_Users : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "username",
                keyValue: null,
                column: "username",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "username",
                table: "users",
                type: "varchar(200)",
                unicode: false,
                maxLength: 200,
                nullable: false,
                collation: "utf8mb4_unicode_520_ci",
                oldClrType: typeof(string),
                oldType: "varchar(200)",
                oldUnicode: false,
                oldMaxLength: 200,
                oldNullable: true)
                .OldAnnotation("Relational:Collation", "utf8mb4_unicode_520_ci");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "password",
                keyValue: null,
                column: "password",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "password",
                table: "users",
                type: "varchar(200)",
                maxLength: 200,
                nullable: false,
                collation: "utf8mb4_unicode_520_ci",
                oldClrType: typeof(string),
                oldType: "varchar(200)",
                oldMaxLength: 200,
                oldNullable: true)
                .OldAnnotation("Relational:Collation", "utf8mb4_unicode_520_ci");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "fullname",
                keyValue: null,
                column: "fullname",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "fullname",
                table: "users",
                type: "varchar(200)",
                maxLength: 200,
                nullable: false,
                collation: "utf8mb4_unicode_520_ci",
                oldClrType: typeof(string),
                oldType: "varchar(200)",
                oldMaxLength: 200,
                oldNullable: true)
                .OldAnnotation("Relational:Collation", "utf8mb4_unicode_520_ci");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "email",
                keyValue: null,
                column: "email",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "users",
                type: "varchar(200)",
                unicode: false,
                maxLength: 200,
                nullable: false,
                collation: "utf8mb4_unicode_520_ci",
                oldClrType: typeof(string),
                oldType: "varchar(200)",
                oldUnicode: false,
                oldMaxLength: 200,
                oldNullable: true)
                .OldAnnotation("Relational:Collation", "utf8mb4_unicode_520_ci");

            migrationBuilder.AddColumn<string>(
                name: "biography",
                table: "users",
                type: "varchar(250)",
                unicode: false,
                maxLength: 250,
                nullable: true,
                collation: "utf8mb4_unicode_520_ci");

            migrationBuilder.AddColumn<DateTime>(
                name: "birthday",
                table: "users",
                type: "datetime(6)",
                unicode: false,
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "create_at",
                table: "users",
                type: "datetime(6)",
                unicode: false,
                nullable: false,
                defaultValue: new DateTime(2023, 4, 20, 0, 28, 5, 22, DateTimeKind.Local).AddTicks(8766));

            migrationBuilder.AddColumn<string>(
                name: "facebook",
                table: "users",
                type: "varchar(11)",
                unicode: false,
                maxLength: 11,
                nullable: true,
                collation: "utf8mb4_unicode_520_ci");

            migrationBuilder.AddColumn<int>(
                name: "is_active",
                table: "users",
                type: "int",
                unicode: false,
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "is_deleted",
                table: "users",
                type: "int",
                unicode: false,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "update_at",
                table: "users",
                type: "datetime(6)",
                unicode: false,
                nullable: false,
                defaultValue: new DateTime(2023, 4, 20, 0, 28, 5, 22, DateTimeKind.Local).AddTicks(9035));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "biography",
                table: "users");

            migrationBuilder.DropColumn(
                name: "birthday",
                table: "users");

            migrationBuilder.DropColumn(
                name: "create_at",
                table: "users");

            migrationBuilder.DropColumn(
                name: "facebook",
                table: "users");

            migrationBuilder.DropColumn(
                name: "is_active",
                table: "users");

            migrationBuilder.DropColumn(
                name: "is_deleted",
                table: "users");

            migrationBuilder.DropColumn(
                name: "update_at",
                table: "users");

            migrationBuilder.AlterColumn<string>(
                name: "username",
                table: "users",
                type: "varchar(200)",
                unicode: false,
                maxLength: 200,
                nullable: true,
                collation: "utf8mb4_unicode_520_ci",
                oldClrType: typeof(string),
                oldType: "varchar(200)",
                oldUnicode: false,
                oldMaxLength: 200)
                .OldAnnotation("Relational:Collation", "utf8mb4_unicode_520_ci");

            migrationBuilder.AlterColumn<string>(
                name: "password",
                table: "users",
                type: "varchar(200)",
                maxLength: 200,
                nullable: true,
                collation: "utf8mb4_unicode_520_ci",
                oldClrType: typeof(string),
                oldType: "varchar(200)",
                oldMaxLength: 200)
                .OldAnnotation("Relational:Collation", "utf8mb4_unicode_520_ci");

            migrationBuilder.AlterColumn<string>(
                name: "fullname",
                table: "users",
                type: "varchar(200)",
                maxLength: 200,
                nullable: true,
                collation: "utf8mb4_unicode_520_ci",
                oldClrType: typeof(string),
                oldType: "varchar(200)",
                oldMaxLength: 200)
                .OldAnnotation("Relational:Collation", "utf8mb4_unicode_520_ci");

            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "users",
                type: "varchar(200)",
                unicode: false,
                maxLength: 200,
                nullable: true,
                collation: "utf8mb4_unicode_520_ci",
                oldClrType: typeof(string),
                oldType: "varchar(200)",
                oldUnicode: false,
                oldMaxLength: 200)
                .OldAnnotation("Relational:Collation", "utf8mb4_unicode_520_ci");
        }
    }
}
