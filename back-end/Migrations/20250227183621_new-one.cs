using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CareerPathRecommender.Migrations
{
    /// <inheritdoc />
    public partial class new_one : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Relations",
                table: "Relations");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Skills",
                newName: "SkillName");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Skills",
                newName: "SkillId");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Jobs",
                newName: "JobName");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Jobs",
                newName: "JobId");

            migrationBuilder.AlterColumn<int>(
                name: "RelationId",
                table: "Relations",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Experience",
                table: "Relations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Usefulness",
                table: "Relations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Relations",
                table: "Relations",
                column: "RelationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Relations",
                table: "Relations");

            migrationBuilder.DropColumn(
                name: "Experience",
                table: "Relations");

            migrationBuilder.DropColumn(
                name: "Usefulness",
                table: "Relations");

            migrationBuilder.RenameColumn(
                name: "SkillName",
                table: "Skills",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "SkillId",
                table: "Skills",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "JobName",
                table: "Jobs",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "JobId",
                table: "Jobs",
                newName: "Id");

            migrationBuilder.AlterColumn<int>(
                name: "RelationId",
                table: "Relations",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Relations",
                table: "Relations",
                columns: new[] { "JobId", "SkillId" });
        }
    }
}
