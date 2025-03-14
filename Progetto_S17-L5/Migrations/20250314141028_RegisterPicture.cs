using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Progetto_S17_L5.Migrations
{
    /// <inheritdoc />
    public partial class RegisterPicture : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Registers",
                keyColumn: "RegisterId",
                keyValue: new Guid("59185603-5ee1-4ba0-89c4-94a2af575a82"),
                column: "Picture",
                value: "uploads\\images\\default.png");

            migrationBuilder.UpdateData(
                table: "Registers",
                keyColumn: "RegisterId",
                keyValue: new Guid("5f39bed5-bf99-4599-ab34-85b5fff62417"),
                column: "Picture",
                value: "uploads\\images\\default.png");

            migrationBuilder.UpdateData(
                table: "Registers",
                keyColumn: "RegisterId",
                keyValue: new Guid("64373dff-19fe-4f27-af81-f49f36501bae"),
                column: "Picture",
                value: "uploads\\images\\default.png");

            migrationBuilder.UpdateData(
                table: "Registers",
                keyColumn: "RegisterId",
                keyValue: new Guid("6ff4e02a-6164-45cd-92f9-7b9bdc57d7e0"),
                column: "Picture",
                value: "uploads\\images\\default.png");

            migrationBuilder.UpdateData(
                table: "Registers",
                keyColumn: "RegisterId",
                keyValue: new Guid("7380417d-9a44-4b1b-96fb-ff31488b5628"),
                column: "Picture",
                value: "uploads\\images\\default.png");

            migrationBuilder.UpdateData(
                table: "Registers",
                keyColumn: "RegisterId",
                keyValue: new Guid("73f3ed80-c5de-4c4a-a87b-c39d692c1446"),
                column: "Picture",
                value: "uploads\\images\\default.png");

            migrationBuilder.UpdateData(
                table: "Registers",
                keyColumn: "RegisterId",
                keyValue: new Guid("a4ebff23-952d-48bb-a65d-8da5e818c022"),
                column: "Picture",
                value: "uploads\\images\\default.png");

            migrationBuilder.UpdateData(
                table: "Registers",
                keyColumn: "RegisterId",
                keyValue: new Guid("ab4d17db-f1f7-431a-85b4-3278e4395024"),
                column: "Picture",
                value: "uploads\\images\\default.png");

            migrationBuilder.UpdateData(
                table: "Registers",
                keyColumn: "RegisterId",
                keyValue: new Guid("b2490619-20b1-443f-a323-6e26e91e6f6e"),
                column: "Picture",
                value: "uploads\\images\\default.png");

            migrationBuilder.UpdateData(
                table: "Registers",
                keyColumn: "RegisterId",
                keyValue: new Guid("f924db1a-29ce-4ddd-8e66-dc20394e1f34"),
                column: "Picture",
                value: "uploads\\images\\default.png");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Registers",
                keyColumn: "RegisterId",
                keyValue: new Guid("59185603-5ee1-4ba0-89c4-94a2af575a82"),
                column: "Picture",
                value: null);

            migrationBuilder.UpdateData(
                table: "Registers",
                keyColumn: "RegisterId",
                keyValue: new Guid("5f39bed5-bf99-4599-ab34-85b5fff62417"),
                column: "Picture",
                value: null);

            migrationBuilder.UpdateData(
                table: "Registers",
                keyColumn: "RegisterId",
                keyValue: new Guid("64373dff-19fe-4f27-af81-f49f36501bae"),
                column: "Picture",
                value: null);

            migrationBuilder.UpdateData(
                table: "Registers",
                keyColumn: "RegisterId",
                keyValue: new Guid("6ff4e02a-6164-45cd-92f9-7b9bdc57d7e0"),
                column: "Picture",
                value: null);

            migrationBuilder.UpdateData(
                table: "Registers",
                keyColumn: "RegisterId",
                keyValue: new Guid("7380417d-9a44-4b1b-96fb-ff31488b5628"),
                column: "Picture",
                value: null);

            migrationBuilder.UpdateData(
                table: "Registers",
                keyColumn: "RegisterId",
                keyValue: new Guid("73f3ed80-c5de-4c4a-a87b-c39d692c1446"),
                column: "Picture",
                value: null);

            migrationBuilder.UpdateData(
                table: "Registers",
                keyColumn: "RegisterId",
                keyValue: new Guid("a4ebff23-952d-48bb-a65d-8da5e818c022"),
                column: "Picture",
                value: null);

            migrationBuilder.UpdateData(
                table: "Registers",
                keyColumn: "RegisterId",
                keyValue: new Guid("ab4d17db-f1f7-431a-85b4-3278e4395024"),
                column: "Picture",
                value: null);

            migrationBuilder.UpdateData(
                table: "Registers",
                keyColumn: "RegisterId",
                keyValue: new Guid("b2490619-20b1-443f-a323-6e26e91e6f6e"),
                column: "Picture",
                value: null);

            migrationBuilder.UpdateData(
                table: "Registers",
                keyColumn: "RegisterId",
                keyValue: new Guid("f924db1a-29ce-4ddd-8e66-dc20394e1f34"),
                column: "Picture",
                value: null);
        }
    }
}
