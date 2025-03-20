using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vehicle_Insurance_Management.Migrations
{
    /// <inheritdoc />
    public partial class full : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "addpolicytypes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    policy_name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_addpolicytypes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "CompanyExpenses",
                columns: table => new
                {
                    ExpenseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateOfExpense = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TypeOfExpense = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    AmountOfExpense = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyExpenses", x => x.ExpenseId);
                });

            migrationBuilder.CreateTable(
                name: "Customer_Information",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login_Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CNIC = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfIssue = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfExpiry = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Sex = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer_Information", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "feedbacks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    SubmittedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_feedbacks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "signUp",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    User_Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    User_Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_signUp", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "vehicle_Information",
                columns: table => new
                {
                    VehicleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login_Id = table.Column<int>(type: "int", nullable: false),
                    VehicleName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    OwnerName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Model = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Version = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Rate = table.Column<int>(type: "int", nullable: false),
                    BodyNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EngineNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    VehicleNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vehicle_Information", x => x.VehicleId);
                });

            migrationBuilder.CreateTable(
                name: "insurancepolicies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PolicyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PolicyType = table.Column<int>(type: "int", nullable: false),
                    PolicyDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PolicyImages = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_insurancepolicies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_insurancepolicies_addpolicytypes_PolicyType",
                        column: x => x.PolicyType,
                        principalTable: "addpolicytypes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "estimates",
                columns: table => new
                {
                    EstimateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    VehicleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VehicleModel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VehicleRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    VehicleWarranty = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VehiclePolicyType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_estimates", x => x.EstimateId);
                    table.ForeignKey(
                        name: "FK_estimates_Customer_Information_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer_Information",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BillingInformation",
                columns: table => new
                {
                    BillNo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    Policynumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VehicleId = table.Column<int>(type: "int", nullable: false),
                    CustomerAddProof = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillingInformation", x => x.BillNo);
                    table.ForeignKey(
                        name: "FK_BillingInformation_Customer_Information_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer_Information",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BillingInformation_vehicle_Information_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "vehicle_Information",
                        principalColumn: "VehicleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "insurance_processes",
                columns: table => new
                {
                    InsuranceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login_Id = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    VehicleId = table.Column<int>(type: "int", nullable: false),
                    PolicyNumber = table.Column<int>(type: "int", nullable: false),
                    PolicyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PolicyDuration = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_insurance_processes", x => x.InsuranceId);
                    table.ForeignKey(
                        name: "FK_insurance_processes_Customer_Information_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer_Information",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_insurance_processes_vehicle_Information_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "vehicle_Information",
                        principalColumn: "VehicleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "claimDetails",
                columns: table => new
                {
                    ClaimNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PolicyNumber = table.Column<int>(type: "int", nullable: false),
                    PolicyStartDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PolicyEndDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlaceOfAccident = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfAccident = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InsuredAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ClaimableAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_claimDetails", x => x.ClaimNumber);
                    table.ForeignKey(
                        name: "FK_claimDetails_insurancepolicies_PolicyNumber",
                        column: x => x.PolicyNumber,
                        principalTable: "insurancepolicies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BillingInformation_CustomerId",
                table: "BillingInformation",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_BillingInformation_VehicleId",
                table: "BillingInformation",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_claimDetails_PolicyNumber",
                table: "claimDetails",
                column: "PolicyNumber");

            migrationBuilder.CreateIndex(
                name: "IX_estimates_CustomerId",
                table: "estimates",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_insurance_processes_CustomerId",
                table: "insurance_processes",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_insurance_processes_VehicleId",
                table: "insurance_processes",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_insurancepolicies_PolicyType",
                table: "insurancepolicies",
                column: "PolicyType");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BillingInformation");

            migrationBuilder.DropTable(
                name: "claimDetails");

            migrationBuilder.DropTable(
                name: "CompanyExpenses");

            migrationBuilder.DropTable(
                name: "estimates");

            migrationBuilder.DropTable(
                name: "feedbacks");

            migrationBuilder.DropTable(
                name: "insurance_processes");

            migrationBuilder.DropTable(
                name: "signUp");

            migrationBuilder.DropTable(
                name: "insurancepolicies");

            migrationBuilder.DropTable(
                name: "Customer_Information");

            migrationBuilder.DropTable(
                name: "vehicle_Information");

            migrationBuilder.DropTable(
                name: "addpolicytypes");
        }
    }
}
