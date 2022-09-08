using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entities.Migrations
{
    public partial class CreateDatabaseStructure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBAddresses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Complement = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Number = table.Column<int>(type: "int", nullable: false),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBAddresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TBBooks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Series = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Publisher = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PublishingYear = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Isbn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Language = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalVolumes = table.Column<long>(type: "bigint", nullable: true),
                    AvailableVolumes = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBBooks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TBPeople",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Role = table.Column<int>(type: "int", nullable: true),
                    BookBorrowLimit = table.Column<long>(type: "bigint", nullable: true),
                    BookBorrowedId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBPeople", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBPeople_TBAddresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "TBAddresses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TBPeople_TBBooks_BookBorrowedId",
                        column: x => x.BookBorrowedId,
                        principalTable: "TBBooks",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TBTags",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TagName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BookTaggedId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBTags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBTags_TBBooks_BookTaggedId",
                        column: x => x.BookTaggedId,
                        principalTable: "TBBooks",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TBBorrowments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateBorrowment = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ReturningDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DaysBorrowed = table.Column<long>(type: "bigint", nullable: true),
                    Renewable = table.Column<bool>(type: "bit", nullable: true),
                    BorrowedBookId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BorrowerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBBorrowments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBBorrowments_TBBooks_BorrowedBookId",
                        column: x => x.BorrowedBookId,
                        principalTable: "TBBooks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TBBorrowments_TBPeople_BorrowerId",
                        column: x => x.BorrowerId,
                        principalTable: "TBPeople",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TBBorrowments_BorrowedBookId",
                table: "TBBorrowments",
                column: "BorrowedBookId");

            migrationBuilder.CreateIndex(
                name: "IX_TBBorrowments_BorrowerId",
                table: "TBBorrowments",
                column: "BorrowerId");

            migrationBuilder.CreateIndex(
                name: "IX_TBPeople_AddressId",
                table: "TBPeople",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_TBPeople_BookBorrowedId",
                table: "TBPeople",
                column: "BookBorrowedId");

            migrationBuilder.CreateIndex(
                name: "IX_TBTags_BookTaggedId",
                table: "TBTags",
                column: "BookTaggedId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBBorrowments");

            migrationBuilder.DropTable(
                name: "TBTags");

            migrationBuilder.DropTable(
                name: "TBPeople");

            migrationBuilder.DropTable(
                name: "TBAddresses");

            migrationBuilder.DropTable(
                name: "TBBooks");
        }
    }
}
