using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Progetto_S17_L5.Migrations
{
    /// <inheritdoc />
    public partial class Initial2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Registers",
                columns: table => new
                {
                    RegisterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CAP = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    FiscalCode = table.Column<string>(type: "nvarchar(17)", maxLength: 17, nullable: false),
                    Picture = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registers", x => x.RegisterId);
                });

            migrationBuilder.CreateTable(
                name: "Violations",
                columns: table => new
                {
                    ViolationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Violations", x => x.ViolationId);
                });

            migrationBuilder.CreateTable(
                name: "Verbals",
                columns: table => new
                {
                    VerbalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    VerbalDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VerbalTranscriptionDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    VerbalAddress = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    OfficerName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PointsDeduction = table.Column<int>(type: "int", nullable: false),
                    RegisterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Verbals", x => x.VerbalId);
                    table.ForeignKey(
                        name: "FK_Verbals_Registers_RegisterId",
                        column: x => x.RegisterId,
                        principalTable: "Registers",
                        principalColumn: "RegisterId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VerbalViolation",
                columns: table => new
                {
                    VerbalViolationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    VerbalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ViolationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VerbalViolation", x => x.VerbalViolationId);
                    table.ForeignKey(
                        name: "FK_VerbalViolation_Verbals_VerbalId",
                        column: x => x.VerbalId,
                        principalTable: "Verbals",
                        principalColumn: "VerbalId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VerbalViolation_Violations_ViolationId",
                        column: x => x.ViolationId,
                        principalTable: "Violations",
                        principalColumn: "ViolationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Registers",
                columns: new[] { "RegisterId", "Address", "CAP", "City", "FiscalCode", "Name", "Picture", "Surname" },
                values: new object[,]
                {
                    { new Guid("59185603-5ee1-4ba0-89c4-94a2af575a82"), "Via San Petronio 22", "40100", "Bologna", "BLNDRE80B01L219W", "Andrea", null, "Blu" },
                    { new Guid("5f39bed5-bf99-4599-ab34-85b5fff62417"), "Via Giuseppe Mazzini 40", "50100", "Firenze", "NRILCU85C01D612N", "Luca", null, "Neri" },
                    { new Guid("64373dff-19fe-4f27-af81-f49f36501bae"), "Viale Giuseppe Mazzini 12", "37100", "Verona", "RNCMTN92A41F205X", "Martina", null, "Arancio" },
                    { new Guid("6ff4e02a-6164-45cd-92f9-7b9bdc57d7e0"), "Via Roma 25", "10100", "Torino", "VRDLSA72D55L219P", "Alessandra", null, "Verdi" },
                    { new Guid("7380417d-9a44-4b1b-96fb-ff31488b5628"), "Via XX Settembre 60", "16100", "Genova", "MRNFRN75C01L219B", "Francesco", null, "Marroni" },
                    { new Guid("73f3ed80-c5de-4c4a-a87b-c39d692c1446"), "Via Libertà 30", "90100", "Palermo", "GRGSFA96C41H501D", "Sofia", null, "Grigi" },
                    { new Guid("a4ebff23-952d-48bb-a65d-8da5e818c022"), "Piazza del Duomo 5", "80100", "Napoli", "GLLLRA90A01F839T", "Laura", null, "Gialli" },
                    { new Guid("ab4d17db-f1f7-431a-85b4-3278e4395024"), "Via Dante Alighieri 10", "20100", "Milano", "RSSGLI90A01F205X", "Giulia", null, "Rossi" },
                    { new Guid("b2490619-20b1-443f-a323-6e26e91e6f6e"), "Corso Italia 15", "00100", "Roma", "BNCMRC85M01H501Y", "Marco", null, "Bianchi" },
                    { new Guid("f924db1a-29ce-4ddd-8e66-dc20394e1f34"), "Via Etnea 50", "95100", "Catania", "GLLPLA84M01H501Q", "Paolo", null, "Galli" }
                });

            migrationBuilder.InsertData(
                table: "Violations",
                columns: new[] { "ViolationId", "Description" },
                values: new object[,]
                {
                    { new Guid("1765429a-a462-44a9-a414-4facc897fd25"), "Soste abusive su strisce pedonali: Sanzione per aver parcheggiato il veicolo sopra le strisce pedonali in Corso Italia, impedendo il normale attraversamento dei pedoni" },
                    { new Guid("227e7325-49ac-4100-9076-842a6d6a2841"), "Mancata revisione del veicolo: Multa per circolazione con un veicolo non revisionato, scaduto da oltre sei mesi. La mancata revisione compromette la sicurezza del mezzo e la protezione ambientale" },
                    { new Guid("29e939cc-f9ed-4f75-b751-6c4619015f76"), "Guida senza patente: Sanzione per guida senza patente di guida, accertata durante un controllo su Viale Giuseppe Mazzini. Il conducente non era in possesso di documenti validi" },
                    { new Guid("2cfb9f95-6198-4b88-879e-2ebd0aed733e"), "Guida con cellulare: Multa per l’utilizzo del cellulare durante la guida su Via Dante, creando potenziale distrazione e pericolo per gli altri automobilisti" },
                    { new Guid("4f7e0aaa-3343-4aa8-b54c-e155df77770f"), "Violazione del divieto di transito: Sanzione per aver percorso un tratto di strada in cui il transito era vietato, ignorando il cartello di divieto" },
                    { new Guid("5ab1bb60-b119-46fb-932b-d6b6dee293f7"), "Fermata in doppia fila: Multa per aver lasciato il veicolo in doppia fila" },
                    { new Guid("5b0c745f-5bb1-4ef5-89c8-83a4fe2e4ce1"), "Spostamento del veicolo durante una sosta vietata: Sanzione per aver spostato un veicolo durante una sosta vietata, creando ostacoli al traffico e rischi per la circolazione" },
                    { new Guid("60093f5c-edb8-49b1-99f2-1e13729e5e54"), "Mancato uso delle cinture di sicurezza: Multa per non aver indossato la cintura di sicurezza durante il viaggio in autostrada. Il veicolo è stato fermato durante un controllo di routine" },
                    { new Guid("62c20d25-2140-4c65-96ca-74acbade17e7"), "Transito in area pedonale: Multa per aver circolato con il veicolo in area pedonale in Via Roma durante orario di divieto, mettendo a rischio la sicurezza dei pedoni" },
                    { new Guid("66d63944-5704-4e06-ae7a-f4f83f25844f"), "Guida sotto influenza di sostanze alcoliche" },
                    { new Guid("6e253fbd-31b6-4e62-a74c-00679f0ab1c3"), "Eccesso di velocità: Multa per aver superato il limite di velocità di 20 km/h sulla Via Roma, zona residenziale. La velocità rilevata era di 80 km/h anziché 60 km/h, causando un rischio per pedoni e ciclisti" },
                    { new Guid("72024ee1-36c6-430c-958c-1082957e604b"), "Parcheggio in divieto di sosta: Sanzione per aver parcheggiato in zona a traffico limitato in Piazza del Duomo senza autorizzazione, ostruendo il passaggio di mezzi di emergenza" },
                    { new Guid("775dda4a-f46b-48d8-b05b-defaeb6da946"), "Mancato rispetto del limite di altezza: Sanzione per aver percorso un tunnel con un veicolo che superava altezza massima consentita di 3 metri" },
                    { new Guid("81bb9c8a-f85a-454b-be77-5c55e06bd552"), "Incrocio con semaforo rosso: Multa per aver attraversato un incrocio con semaforo rosso, violando il codice della strada e mettendo in pericolo la sicurezza stradale" },
                    { new Guid("aacd8366-9a9c-4e67-94dd-8ff43903ca74"), "Mancato rispetto della precedenza: Sanzione per non aver dato la precedenza al veicolo proveniente da destra su un incrocio non regolato da semaforo" },
                    { new Guid("b4c04a96-4912-46a9-a7c8-adf8f2c40c42"), "Uso improprio delle corsie: Multa per aver viaggiato sulla corsia di emergenza in autostrada per oltre 500 metri, senza necessità, ostacolando il passaggio dei veicoli di soccorso" },
                    { new Guid("ce0c3bdd-3b8f-4c91-bbbc-ee6745b4f18c"), "Transito con veicolo non assicurato: Multa per circolazione con un veicolo privo di assicurazione obbligatoria" },
                    { new Guid("db84a569-68f9-45c1-97d6-c9f3c1b18c55"), "Eccesso di velocità in zona scolastica: Sanzione per aver superato il limite di velocità di 30 km/h nella zona residenziale" },
                    { new Guid("f50361c8-f1cf-4256-8c0a-e09bc3006dc3"), "Mancato fermo al posto di blocco: Multa per non essersi fermati a un posto di blocco della polizia" },
                    { new Guid("f956363c-9e19-47d4-9fae-ef7fe954fe76"), "Uso del veicolo per finalità diverse da quelle consentite: Sanzione per aver utilizzato un veicolo commerciale per trasporto di persone, violando le normative riguardanti il trasporto pubblico e la sicurezza stradale" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Verbals_RegisterId",
                table: "Verbals",
                column: "RegisterId");

            migrationBuilder.CreateIndex(
                name: "IX_VerbalViolation_VerbalId",
                table: "VerbalViolation",
                column: "VerbalId");

            migrationBuilder.CreateIndex(
                name: "IX_VerbalViolation_ViolationId",
                table: "VerbalViolation",
                column: "ViolationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VerbalViolation");

            migrationBuilder.DropTable(
                name: "Verbals");

            migrationBuilder.DropTable(
                name: "Violations");

            migrationBuilder.DropTable(
                name: "Registers");
        }
    }
}
