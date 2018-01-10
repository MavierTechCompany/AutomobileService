using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace AutomobileWebService.Migrations
{
    public partial class MigrationV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Automobile");

            migrationBuilder.CreateTable(
                name: "Brands",
                schema: "Automobile",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                schema: "Automobile",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CompanyAddressId = table.Column<Guid>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    FoundationDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Phone = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "Automobile",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    HashedPassword = table.Column<string>(nullable: false),
                    Login = table.Column<string>(nullable: false),
                    MobilePhone = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                schema: "Automobile",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    BrandId = table.Column<Guid>(nullable: false),
                    BrandName = table.Column<string>(nullable: false),
                    Generation = table.Column<int>(nullable: false),
                    Horsepower = table.Column<int>(nullable: false),
                    Model = table.Column<string>(nullable: false),
                    ProdutionDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cars_Brands_BrandId",
                        column: x => x.BrandId,
                        principalSchema: "Automobile",
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                schema: "Automobile",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    BuildingNumber = table.Column<int>(nullable: false),
                    CompanyId = table.Column<Guid>(nullable: false),
                    Country = table.Column<string>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    FlatNumber = table.Column<int>(nullable: false),
                    State = table.Column<string>(nullable: false),
                    Street = table.Column<string>(nullable: false),
                    Town = table.Column<string>(nullable: false),
                    ZipCode = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalSchema: "Automobile",
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                schema: "Automobile",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CarId = table.Column<Guid>(nullable: false),
                    Category = table.Column<string>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    EngineModel = table.Column<string>(nullable: false),
                    HasSupercharger = table.Column<bool>(nullable: false),
                    HasTurbochager = table.Column<bool>(nullable: false),
                    Horsepower = table.Column<int>(nullable: false),
                    ProjectName = table.Column<string>(nullable: false),
                    TopSpeedInKilometers = table.Column<float>(nullable: false),
                    TopSpeedInMiles = table.Column<float>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    ZeroToHundreds = table.Column<float>(nullable: false),
                    ZeroToSixty = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projects_Cars_CarId",
                        column: x => x.CarId,
                        principalSchema: "Automobile",
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Projects_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "Automobile",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                schema: "Automobile",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CommentText = table.Column<string>(nullable: false),
                    CommenterId = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    ProjectId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Users_CommenterId",
                        column: x => x.CommenterId,
                        principalSchema: "Automobile",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comments_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalSchema: "Automobile",
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CompanyId",
                schema: "Automobile",
                table: "Addresses",
                column: "CompanyId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cars_BrandId",
                schema: "Automobile",
                table: "Cars",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_CommenterId",
                schema: "Automobile",
                table: "Comments",
                column: "CommenterId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ProjectId",
                schema: "Automobile",
                table: "Comments",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_CarId",
                schema: "Automobile",
                table: "Projects",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_UserId",
                schema: "Automobile",
                table: "Projects",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses",
                schema: "Automobile");

            migrationBuilder.DropTable(
                name: "Comments",
                schema: "Automobile");

            migrationBuilder.DropTable(
                name: "Companies",
                schema: "Automobile");

            migrationBuilder.DropTable(
                name: "Projects",
                schema: "Automobile");

            migrationBuilder.DropTable(
                name: "Cars",
                schema: "Automobile");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "Automobile");

            migrationBuilder.DropTable(
                name: "Brands",
                schema: "Automobile");
        }
    }
}
