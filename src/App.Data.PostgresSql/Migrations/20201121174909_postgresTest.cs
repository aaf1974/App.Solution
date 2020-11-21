using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace App.Data.Migrations
{
    public partial class postgresTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BailiffServices",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ShortName = table.Column<string>(maxLength: 255, nullable: true),
                    Adress = table.Column<string>(maxLength: 255, nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    WorkerChangedBy = table.Column<int>(nullable: false),
                    ChangeDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BailiffServices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CourthouseTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(maxLength: 255, nullable: true),
                    Code = table.Column<string>(maxLength: 8, nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    WorkerChangedBy = table.Column<int>(nullable: false),
                    ChangeDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourthouseTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EnforcementProceedingReasonEnding",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NoteNumber = table.Column<string>(maxLength: 20, nullable: true),
                    NoteText = table.Column<string>(maxLength: 255, nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    WorkerChangedBy = table.Column<int>(nullable: false),
                    ChangeDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnforcementProceedingReasonEnding", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PretensionWorks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DepartureDate = table.Column<DateTime>(nullable: false),
                    IndebtednessSum = table.Column<decimal>(nullable: false),
                    DepartureMethodId = table.Column<int>(nullable: false),
                    IndebtednessPeriodId = table.Column<int>(nullable: false),
                    BillingPremiseAccountId = table.Column<int>(nullable: true),
                    OwnerLegalEntityId = table.Column<int>(nullable: true),
                    OwnerPhysicalPersonId = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    WorkerChangedBy = table.Column<int>(nullable: false),
                    ChangeDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PretensionWorks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Courthouses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ShortName = table.Column<string>(maxLength: 255, nullable: false),
                    PostAdress = table.Column<string>(maxLength: 255, nullable: false),
                    CourthouseTypeId = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    WorkerChangedBy = table.Column<int>(nullable: false),
                    ChangeDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courthouses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Courthouses_CourthouseTypes_CourthouseTypeId",
                        column: x => x.CourthouseTypeId,
                        principalTable: "CourthouseTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PretensionWorkPremiseAccounts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PretensionWorkId = table.Column<int>(nullable: false),
                    BillingPersonalAccountId = table.Column<int>(nullable: false),
                    IndebtednessSum = table.Column<decimal>(nullable: false),
                    IndebtednessPeriodId = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    WorkerChangedBy = table.Column<int>(nullable: false),
                    ChangeDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PretensionWorkPremiseAccounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PretensionWorkPremiseAccounts_PretensionWorks_PretensionWor~",
                        column: x => x.PretensionWorkId,
                        principalTable: "PretensionWorks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JudicialWorks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    JudicalWorkTypeId = table.Column<int>(nullable: false),
                    CourthouseId = table.Column<int>(nullable: false),
                    DepartureDate = table.Column<DateTime>(nullable: false),
                    IndebtednessBeginFinePeriod = table.Column<DateTime>(nullable: true),
                    IndebtednessEndFinePeriod = table.Column<DateTime>(nullable: true),
                    IndebtednessSum = table.Column<decimal>(nullable: false),
                    IndebtednessFine = table.Column<decimal>(nullable: false),
                    IndebtednessStateDuty = table.Column<decimal>(nullable: false),
                    DecisionDate = table.Column<DateTime>(nullable: true),
                    JudicalDecisionTypeId = table.Column<int>(nullable: true),
                    CollectedSum = table.Column<decimal>(nullable: false),
                    CollectedFine = table.Column<decimal>(nullable: false),
                    CollectedStateDuty = table.Column<decimal>(nullable: false),
                    TaxReturnDate = table.Column<DateTime>(nullable: true),
                    TaxSum = table.Column<decimal>(nullable: false),
                    StateBudgetReturnedSum = table.Column<decimal>(nullable: false),
                    VoluntaryPaymentSum = table.Column<decimal>(nullable: false),
                    VoluntaryPaymentFine = table.Column<decimal>(nullable: false),
                    VoluntaryPaymentStateDuty = table.Column<decimal>(nullable: false),
                    CourtOrderStateDuty = table.Column<decimal>(nullable: false),
                    CancellationDate = table.Column<DateTime>(nullable: true),
                    PhysicalPersonId = table.Column<int>(nullable: false),
                    CaseNumber = table.Column<string>(maxLength: 20, nullable: true),
                    JudicalWorkExclusionReasonId = table.Column<int>(nullable: true),
                    SerialCaseNumber = table.Column<string>(maxLength: 20, nullable: true),
                    IndebtednessBeginDate = table.Column<DateTime>(nullable: false),
                    IndebtednessEndDate = table.Column<DateTime>(nullable: false),
                    RefinancingRateId = table.Column<int>(nullable: true),
                    OwnerLegalEntityId = table.Column<int>(nullable: true),
                    OwnerPhysicalPersonId = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    WorkerChangedBy = table.Column<int>(nullable: false),
                    ChangeDate = table.Column<DateTime>(nullable: false),
                    OwnerPhysicalPersonBillingId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JudicialWorks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JudicialWorks_Courthouses_CourthouseId",
                        column: x => x.CourthouseId,
                        principalTable: "Courthouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EnforcementDocuments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ExecutiveDocumentData = table.Column<DateTime>(nullable: false),
                    ExecutiveDocumentNumber = table.Column<string>(maxLength: 20, nullable: true),
                    ExecutiveDocumentRecevingDate = table.Column<DateTime>(nullable: true),
                    ExecutiveDocumentTypeId = table.Column<int>(nullable: false),
                    JudicialWorkId = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    WorkerChangedBy = table.Column<int>(nullable: false),
                    ChangeDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnforcementDocuments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EnforcementDocuments_JudicialWorks_JudicialWorkId",
                        column: x => x.JudicialWorkId,
                        principalTable: "JudicialWorks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JudicialWorkPremiseAccounts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    JudicialWorkId = table.Column<int>(nullable: false),
                    BillingPersonalAccountId = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    WorkerChangedBy = table.Column<int>(nullable: false),
                    ChangeDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JudicialWorkPremiseAccounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JudicialWorkPremiseAccounts_JudicialWorks_JudicialWorkId",
                        column: x => x.JudicialWorkId,
                        principalTable: "JudicialWorks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EnforcementProceedings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SendingDate = table.Column<DateTime>(nullable: false),
                    BailiffServiceId = table.Column<int>(nullable: false),
                    EnforcementProceedingExicationDate = table.Column<DateTime>(nullable: true),
                    EnforcementProceedingEndDate = table.Column<DateTime>(nullable: true),
                    EnforcementProceedingNumber = table.Column<string>(maxLength: 20, nullable: true),
                    EnforcementProceedingRequirementTypeId = table.Column<int>(nullable: false),
                    IndebtednessSum = table.Column<decimal>(nullable: false),
                    FineSum = table.Column<decimal>(nullable: false),
                    StateDutySum = table.Column<decimal>(nullable: false),
                    EnforcementProceedingReasonEndingId = table.Column<int>(nullable: true),
                    BasisEnding = table.Column<string>(nullable: true),
                    EnforcementDocumentId = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    WorkerChangedBy = table.Column<int>(nullable: false),
                    ChangeDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnforcementProceedings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EnforcementProceedings_BailiffServices_BailiffServiceId",
                        column: x => x.BailiffServiceId,
                        principalTable: "BailiffServices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EnforcementProceedings_EnforcementDocuments_EnforcementDocu~",
                        column: x => x.EnforcementDocumentId,
                        principalTable: "EnforcementDocuments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EnforcementProceedings_EnforcementProceedingReasonEnding_En~",
                        column: x => x.EnforcementProceedingReasonEndingId,
                        principalTable: "EnforcementProceedingReasonEnding",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "JudicialWorkFines",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    JudicialWorkPremiseAccountId = table.Column<int>(nullable: false),
                    PeriodId = table.Column<int>(nullable: false),
                    DebtSum = table.Column<decimal>(nullable: false),
                    BeginDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    DaysCount = table.Column<int>(nullable: false),
                    Rate = table.Column<decimal>(nullable: false),
                    Pays = table.Column<decimal>(nullable: false),
                    Fine = table.Column<decimal>(nullable: false),
                    HasPays = table.Column<bool>(nullable: false),
                    PayDate = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    WorkerChangedBy = table.Column<int>(nullable: false),
                    ChangeDate = table.Column<DateTime>(nullable: false),
                    PenaltyCoeficient = table.Column<decimal>(nullable: false),
                    RecalculationPeriodId = table.Column<int>(nullable: true),
                    PenaltyBasisPeriodId = table.Column<int>(nullable: true),
                    PenaltyBasisRootPeriodId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JudicialWorkFines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JudicialWorkFines_JudicialWorkPremiseAccounts_JudicialWorkP~",
                        column: x => x.JudicialWorkPremiseAccountId,
                        principalTable: "JudicialWorkPremiseAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EnforcementProceedingBailiffComplains",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EnforcementProceedingId = table.Column<int>(nullable: false),
                    SendingDate = table.Column<DateTime>(nullable: false),
                    Executive = table.Column<string>(maxLength: 255, nullable: false),
                    TextComplain = table.Column<string>(maxLength: 500, nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    WorkerChangedBy = table.Column<int>(nullable: false),
                    ChangeDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnforcementProceedingBailiffComplains", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EnforcementProceedingBailiffComplains_EnforcementProceeding~",
                        column: x => x.EnforcementProceedingId,
                        principalTable: "EnforcementProceedings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EnforcementProceedingEvents",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EventDate = table.Column<DateTime>(nullable: false),
                    EnforcementProceedingId = table.Column<int>(nullable: false),
                    EnforcementProceedingEventTypeId = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    WorkerChangedBy = table.Column<int>(nullable: false),
                    ChangeDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnforcementProceedingEvents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EnforcementProceedingEvents_EnforcementProceedings_Enforcem~",
                        column: x => x.EnforcementProceedingId,
                        principalTable: "EnforcementProceedings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EnforcementProceedingPenalties",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EnforcementProceedingId = table.Column<int>(nullable: false),
                    PerformanceDate = table.Column<DateTime>(nullable: false),
                    IndebtednessSum = table.Column<decimal>(nullable: false),
                    StateDutySum = table.Column<decimal>(nullable: false),
                    FineSum = table.Column<decimal>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    WorkerChangedBy = table.Column<int>(nullable: false),
                    ChangeDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnforcementProceedingPenalties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EnforcementProceedingPenalties_EnforcementProceedings_Enfor~",
                        column: x => x.EnforcementProceedingId,
                        principalTable: "EnforcementProceedings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Courthouses_CourthouseTypeId",
                table: "Courthouses",
                column: "CourthouseTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_EnforcementDocuments_JudicialWorkId",
                table: "EnforcementDocuments",
                column: "JudicialWorkId");

            migrationBuilder.CreateIndex(
                name: "IX_EnforcementProceedingBailiffComplains_EnforcementProceeding~",
                table: "EnforcementProceedingBailiffComplains",
                column: "EnforcementProceedingId");

            migrationBuilder.CreateIndex(
                name: "IX_EnforcementProceedingEvents_EnforcementProceedingId",
                table: "EnforcementProceedingEvents",
                column: "EnforcementProceedingId");

            migrationBuilder.CreateIndex(
                name: "IX_EnforcementProceedingPenalties_EnforcementProceedingId",
                table: "EnforcementProceedingPenalties",
                column: "EnforcementProceedingId");

            migrationBuilder.CreateIndex(
                name: "IX_EnforcementProceedings_BailiffServiceId",
                table: "EnforcementProceedings",
                column: "BailiffServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_EnforcementProceedings_EnforcementDocumentId",
                table: "EnforcementProceedings",
                column: "EnforcementDocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_EnforcementProceedings_EnforcementProceedingReasonEndingId",
                table: "EnforcementProceedings",
                column: "EnforcementProceedingReasonEndingId");

            migrationBuilder.CreateIndex(
                name: "IX_JudicialWorkFines_JudicialWorkPremiseAccountId",
                table: "JudicialWorkFines",
                column: "JudicialWorkPremiseAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_JudicialWorkPremiseAccounts_JudicialWorkId",
                table: "JudicialWorkPremiseAccounts",
                column: "JudicialWorkId");

            migrationBuilder.CreateIndex(
                name: "IX_JudicialWorks_CourthouseId",
                table: "JudicialWorks",
                column: "CourthouseId");

            migrationBuilder.CreateIndex(
                name: "IX_PretensionWorkPremiseAccounts_PretensionWorkId",
                table: "PretensionWorkPremiseAccounts",
                column: "PretensionWorkId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EnforcementProceedingBailiffComplains");

            migrationBuilder.DropTable(
                name: "EnforcementProceedingEvents");

            migrationBuilder.DropTable(
                name: "EnforcementProceedingPenalties");

            migrationBuilder.DropTable(
                name: "JudicialWorkFines");

            migrationBuilder.DropTable(
                name: "PretensionWorkPremiseAccounts");

            migrationBuilder.DropTable(
                name: "EnforcementProceedings");

            migrationBuilder.DropTable(
                name: "JudicialWorkPremiseAccounts");

            migrationBuilder.DropTable(
                name: "PretensionWorks");

            migrationBuilder.DropTable(
                name: "BailiffServices");

            migrationBuilder.DropTable(
                name: "EnforcementDocuments");

            migrationBuilder.DropTable(
                name: "EnforcementProceedingReasonEnding");

            migrationBuilder.DropTable(
                name: "JudicialWorks");

            migrationBuilder.DropTable(
                name: "Courthouses");

            migrationBuilder.DropTable(
                name: "CourthouseTypes");
        }
    }
}
