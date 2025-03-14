using Microsoft.EntityFrameworkCore;
using Progetto_S17_L5.Models;

namespace Progetto_S17_L5.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Register> Registers { get; set; }
        public DbSet<Verbal> Verbals { get; set; }
        public DbSet<Violation> Violations { get; set; }
        public DbSet<VerbalViolation> VerbalViolation { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // relazione uno a molti register-verbals
            modelBuilder.Entity<Verbal>().HasOne(r => r.Register).WithMany(v => v.Verbals);

            modelBuilder.Entity<Register>().HasMany(v => v.Verbals).WithOne(r => r.Register);

            // default value per Register Picture
            //modelBuilder.Entity<Register>().Property(r => r.Picture).HasDefaultValueSql(" ");

            // default value per Verbal VerbalTranscriptionDate
            modelBuilder
                .Entity<Verbal>()
                .Property(v => v.VerbalTranscriptionDate)
                .HasDefaultValueSql("GETDATE()");

            // default value per Register RegisterId
            modelBuilder
                .Entity<Register>()
                .Property(r => r.RegisterId)
                .HasDefaultValueSql("NEWSEQUENTIALID()");

            // default value per Verbal VerbalId
            modelBuilder
                .Entity<Verbal>()
                .Property(v => v.VerbalId)
                .HasDefaultValueSql("NEWSEQUENTIALID()");

            // default value per VerbalViolation VerbalViolationId
            modelBuilder
                .Entity<VerbalViolation>()
                .Property(vv => vv.VerbalViolationId)
                .HasDefaultValueSql("NEWSEQUENTIALID()");

            // default value per Violation ViolationId
            modelBuilder
                .Entity<Violation>()
                .Property(v => v.ViolationId)
                .HasDefaultValueSql("NEWSEQUENTIALID()");

            // inserimento dati tabella Registers
            modelBuilder
                .Entity<Register>()
                .HasData(
                    new Register()
                    {
                        RegisterId = Guid.Parse("AB4D17DB-F1F7-431A-85B4-3278E4395024"),
                        Name = "Giulia",
                        Surname = "Rossi",
                        Address = "Via Dante Alighieri 10",
                        City = "Milano",
                        CAP = "20100",
                        FiscalCode = "RSSGLI90A01F205X",
                        Picture = "uploads\\images\\default.png",
                    },
                    new Register()
                    {
                        RegisterId = Guid.Parse("B2490619-20B1-443F-A323-6E26E91E6F6E"),
                        Name = "Marco",
                        Surname = "Bianchi",
                        Address = "Corso Italia 15",
                        City = "Roma",
                        CAP = "00100",
                        FiscalCode = "BNCMRC85M01H501Y",
                        Picture = "uploads\\images\\default.png",
                    },
                    new Register()
                    {
                        RegisterId = Guid.Parse("6FF4E02A-6164-45CD-92F9-7B9BDC57D7E0"),
                        Name = "Alessandra",
                        Surname = "Verdi",
                        Address = "Via Roma 25",
                        City = "Torino",
                        CAP = "10100",
                        FiscalCode = "VRDLSA72D55L219P",
                        Picture = "uploads\\images\\default.png",
                    },
                    new Register()
                    {
                        RegisterId = Guid.Parse("5F39BED5-BF99-4599-AB34-85B5FFF62417"),
                        Name = "Luca",
                        Surname = "Neri",
                        Address = "Via Giuseppe Mazzini 40",
                        City = "Firenze",
                        CAP = "50100",
                        FiscalCode = "NRILCU85C01D612N",
                        Picture = "uploads\\images\\default.png",
                    },
                    new Register()
                    {
                        RegisterId = Guid.Parse("A4EBFF23-952D-48BB-A65D-8DA5E818C022"),
                        Name = "Laura",
                        Surname = "Gialli",
                        Address = "Piazza del Duomo 5",
                        City = "Napoli",
                        CAP = "80100",
                        FiscalCode = "GLLLRA90A01F839T",
                        Picture = "uploads\\images\\default.png",
                    },
                    new Register()
                    {
                        RegisterId = Guid.Parse("59185603-5EE1-4BA0-89C4-94A2AF575A82"),
                        Name = "Andrea",
                        Surname = "Blu",
                        Address = "Via San Petronio 22",
                        City = "Bologna",
                        CAP = "40100",
                        FiscalCode = "BLNDRE80B01L219W",
                        Picture = "uploads\\images\\default.png",
                    },
                    new Register()
                    {
                        RegisterId = Guid.Parse("73F3ED80-C5DE-4C4A-A87B-C39D692C1446"),
                        Name = "Sofia",
                        Surname = "Grigi",
                        Address = "Via Libertà 30",
                        City = "Palermo",
                        CAP = "90100",
                        FiscalCode = "GRGSFA96C41H501D",
                        Picture = "uploads\\images\\default.png",
                    },
                    new Register()
                    {
                        RegisterId = Guid.Parse("F924DB1A-29CE-4DDD-8E66-DC20394E1F34"),
                        Name = "Paolo",
                        Surname = "Galli",
                        Address = "Via Etnea 50",
                        City = "Catania",
                        CAP = "95100",
                        FiscalCode = "GLLPLA84M01H501Q",
                        Picture = "uploads\\images\\default.png",
                    },
                    new Register()
                    {
                        RegisterId = Guid.Parse("64373DFF-19FE-4F27-AF81-F49F36501BAE"),
                        Name = "Martina",
                        Surname = "Arancio",
                        Address = "Viale Giuseppe Mazzini 12",
                        City = "Verona",
                        CAP = "37100",
                        FiscalCode = "RNCMTN92A41F205X",
                        Picture = "uploads\\images\\default.png",
                    },
                    new Register()
                    {
                        RegisterId = Guid.Parse("7380417D-9A44-4B1B-96FB-FF31488B5628"),
                        Name = "Francesco",
                        Surname = "Marroni",
                        Address = "Via XX Settembre 60",
                        City = "Genova",
                        CAP = "16100",
                        FiscalCode = "MRNFRN75C01L219B",
                        Picture = "uploads\\images\\default.png",
                    }
                );

            // inserimento dati tabella Violations
            modelBuilder
                .Entity<Violation>()
                .HasData(
                    new Violation()
                    {
                        ViolationId = Guid.Parse("6E253FBD-31B6-4E62-A74C-00679F0AB1C3"),
                        Description =
                            "Eccesso di velocità: Multa per aver superato il limite di velocità di 20 km/h sulla Via Roma, zona residenziale. La velocità rilevata era di 80 km/h anziché 60 km/h, causando un rischio per pedoni e ciclisti",
                    },
                    new Violation()
                    {
                        ViolationId = Guid.Parse("72024EE1-36C6-430C-958C-1082957E604B"),
                        Description =
                            "Parcheggio in divieto di sosta: Sanzione per aver parcheggiato in zona a traffico limitato in Piazza del Duomo senza autorizzazione, ostruendo il passaggio di mezzi di emergenza",
                    },
                    new Violation()
                    {
                        ViolationId = Guid.Parse("60093F5C-EDB8-49B1-99F2-1E13729E5E54"),
                        Description =
                            "Mancato uso delle cinture di sicurezza: Multa per non aver indossato la cintura di sicurezza durante il viaggio in autostrada. Il veicolo è stato fermato durante un controllo di routine",
                    },
                    new Violation()
                    {
                        ViolationId = Guid.Parse("2CFB9F95-6198-4B88-879E-2EBD0AED733E"),
                        Description =
                            "Guida con cellulare: Multa per l’utilizzo del cellulare durante la guida su Via Dante, creando potenziale distrazione e pericolo per gli altri automobilisti",
                    },
                    new Violation()
                    {
                        ViolationId = Guid.Parse("1765429A-A462-44A9-A414-4FACC897FD25"),
                        Description =
                            "Soste abusive su strisce pedonali: Sanzione per aver parcheggiato il veicolo sopra le strisce pedonali in Corso Italia, impedendo il normale attraversamento dei pedoni",
                    },
                    new Violation()
                    {
                        ViolationId = Guid.Parse("81BB9C8A-F85A-454B-BE77-5C55E06BD552"),
                        Description =
                            "Incrocio con semaforo rosso: Multa per aver attraversato un incrocio con semaforo rosso, violando il codice della strada e mettendo in pericolo la sicurezza stradale",
                    },
                    new Violation()
                    {
                        ViolationId = Guid.Parse("29E939CC-F9ED-4F75-B751-6C4619015F76"),
                        Description =
                            "Guida senza patente: Sanzione per guida senza patente di guida, accertata durante un controllo su Viale Giuseppe Mazzini. Il conducente non era in possesso di documenti validi",
                    },
                    new Violation()
                    {
                        ViolationId = Guid.Parse("62C20D25-2140-4C65-96CA-74ACBADE17E7"),
                        Description =
                            "Transito in area pedonale: Multa per aver circolato con il veicolo in area pedonale in Via Roma durante orario di divieto, mettendo a rischio la sicurezza dei pedoni",
                    },
                    new Violation()
                    {
                        ViolationId = Guid.Parse("5B0C745F-5BB1-4EF5-89C8-83A4FE2E4CE1"),
                        Description =
                            "Spostamento del veicolo durante una sosta vietata: Sanzione per aver spostato un veicolo durante una sosta vietata, creando ostacoli al traffico e rischi per la circolazione",
                    },
                    new Violation()
                    {
                        ViolationId = Guid.Parse("227E7325-49AC-4100-9076-842A6D6A2841"),
                        Description =
                            "Mancata revisione del veicolo: Multa per circolazione con un veicolo non revisionato, scaduto da oltre sei mesi. La mancata revisione compromette la sicurezza del mezzo e la protezione ambientale",
                    },
                    new Violation()
                    {
                        ViolationId = Guid.Parse("AACD8366-9A9C-4E67-94DD-8FF43903CA74"),
                        Description =
                            "Mancato rispetto della precedenza: Sanzione per non aver dato la precedenza al veicolo proveniente da destra su un incrocio non regolato da semaforo",
                    },
                    new Violation()
                    {
                        ViolationId = Guid.Parse("B4C04A96-4912-46A9-A7C8-ADF8F2C40C42"),
                        Description =
                            "Uso improprio delle corsie: Multa per aver viaggiato sulla corsia di emergenza in autostrada per oltre 500 metri, senza necessità, ostacolando il passaggio dei veicoli di soccorso",
                    },
                    new Violation()
                    {
                        ViolationId = Guid.Parse("DB84A569-68F9-45C1-97D6-C9F3C1B18C55"),
                        Description =
                            "Eccesso di velocità in zona scolastica: Sanzione per aver superato il limite di velocità di 30 km/h nella zona residenziale",
                    },
                    new Violation()
                    {
                        ViolationId = Guid.Parse("5AB1BB60-B119-46FB-932B-D6B6DEE293F7"),
                        Description =
                            "Fermata in doppia fila: Multa per aver lasciato il veicolo in doppia fila",
                    },
                    new Violation()
                    {
                        ViolationId = Guid.Parse("66D63944-5704-4E06-AE7A-F4F83F25844F"),
                        Description = "Guida sotto influenza di sostanze alcoliche",
                    },
                    new Violation()
                    {
                        ViolationId = Guid.Parse("775DDA4A-F46B-48D8-B05B-DEFAEB6DA946"),
                        Description =
                            "Mancato rispetto del limite di altezza: Sanzione per aver percorso un tunnel con un veicolo che superava altezza massima consentita di 3 metri",
                    },
                    new Violation()
                    {
                        ViolationId = Guid.Parse("F50361C8-F1CF-4256-8C0A-E09BC3006DC3"),
                        Description =
                            "Mancato fermo al posto di blocco: Multa per non essersi fermati a un posto di blocco della polizia",
                    },
                    new Violation()
                    {
                        ViolationId = Guid.Parse("4F7E0AAA-3343-4AA8-B54C-E155DF77770F"),
                        Description =
                            "Violazione del divieto di transito: Sanzione per aver percorso un tratto di strada in cui il transito era vietato, ignorando il cartello di divieto",
                    },
                    new Violation()
                    {
                        ViolationId = Guid.Parse("CE0C3BDD-3B8F-4C91-BBBC-EE6745B4F18C"),
                        Description =
                            "Transito con veicolo non assicurato: Multa per circolazione con un veicolo privo di assicurazione obbligatoria",
                    },
                    new Violation()
                    {
                        ViolationId = Guid.Parse("F956363C-9E19-47D4-9FAE-EF7FE954FE76"),
                        Description =
                            "Uso del veicolo per finalità diverse da quelle consentite: Sanzione per aver utilizzato un veicolo commerciale per trasporto di persone, violando le normative riguardanti il trasporto pubblico e la sicurezza stradale",
                    }
                );

            //modelBuilder
            //    .Entity<Verbal>()
            //    .HasData(
            //        new Verbal()
            //        {
            //            VerbalId = Guid.Parse("85A06C79-29AD-434B-AC94-057E3041073D"),
            //            VerbalDate = DateTime.Parse("2009-05-20"),
            //            VerbalAddress = "Via Nazionale 2, Genova",
            //            OfficerName = "Cst. Francesco Marroni",
            //            VerbalTranscriptionDate = DateTime.Parse("2009-05-25"),
            //            Amount = decimal.Parse("530"),
            //            PointsDeduction = 8,
            //            RegisterId = Guid.Parse("AB4D17DB-F1F7-431A-85B4-3278E4395024"),
            //        },
            //        new Verbal()
            //        {
            //            VerbalId = Guid.Parse("CEB874C0-D731-4F77-9B88-19B3D63FA766"),
            //            VerbalDate = DateTime.Parse("2024-07-11"),
            //            VerbalAddress = "Via San Petronio 22, Bologna",
            //            OfficerName = "Cpl. Andrea Blu",
            //            VerbalTranscriptionDate = DateTime.Parse("2024-07-15"),
            //            Amount = decimal.Parse("220"),
            //            PointsDeduction = 4,
            //            RegisterId = Guid.Parse("AB4D17DB-F1F7-431A-85B4-3278E4395024"),
            //        },
            //        new Verbal()
            //        {
            //            VerbalId = Guid.Parse("CFA60A66-610A-414E-AC15-25590FDC9F42"),
            //            VerbalDate = DateTime.Parse("2024-04-15"),
            //            VerbalAddress = "Via San Giovanni 45, Milano",
            //            OfficerName = "Cst. Laura Rossi",
            //            VerbalTranscriptionDate = DateTime.Parse("2024-04-18"),
            //            Amount = decimal.Parse("250"),
            //            PointsDeduction = 5,
            //            RegisterId = Guid.Parse("B2490619-20B1-443F-A323-6E26E91E6F6E"),
            //        },
            //        new Verbal()
            //        {
            //            VerbalId = Guid.Parse("DBAD30B1-CE88-422E-866E-4104EDD4205E"),
            //            VerbalDate = DateTime.Parse("2025-01-11"),
            //            VerbalAddress = "Via XX Settembre 60, Genova",
            //            OfficerName = "Cst. Francesco Marroni",
            //            VerbalTranscriptionDate = DateTime.Parse("2025-01-15"),
            //            Amount = decimal.Parse("150"),
            //            PointsDeduction = 2,
            //            RegisterId = Guid.Parse("B2490619-20B1-443F-A323-6E26E91E6F6E"),
            //        },
            //        new Verbal()
            //        {
            //            VerbalId = Guid.Parse("C3A8EF7F-1525-4E6B-98AC-4A309996614D"),
            //            VerbalDate = DateTime.Parse("2009-04-10"),
            //            VerbalAddress = "Via Della Repubblica 32, Roma",
            //            OfficerName = "SGT. Mattia Rospo",
            //            VerbalTranscriptionDate = DateTime.Parse("2009-04-14"),
            //            Amount = decimal.Parse("60"),
            //            PointsDeduction = 2,
            //            RegisterId = Guid.Parse("B2490619-20B1-443F-A323-6E26E91E6F6E"),
            //        },
            //        new Verbal()
            //        {
            //            VerbalId = Guid.Parse("E2922F19-6A11-4C0D-A7E4-54BFCA29B496"),
            //            VerbalDate = DateTime.Parse("2024-05-20"),
            //            VerbalAddress = "Via Roma 25, Torino",
            //            OfficerName = "Cpl. Alessandro Verdi",
            //            VerbalTranscriptionDate = DateTime.Parse("2024-05-23"),
            //            Amount = decimal.Parse("200"),
            //            PointsDeduction = 4,
            //            RegisterId = Guid.Parse("5F39BED5-BF99-4599-AB34-85B5FFF62417"),
            //        },
            //        new Verbal()
            //        {
            //            VerbalId = Guid.Parse("E1C38B72-2563-4EF4-AB5F-61EE425BB9D7"),
            //            VerbalDate = DateTime.Parse("2024-12-25"),
            //            VerbalAddress = "Viale Giuseppe Mazzini 12, Verona",
            //            OfficerName = "Cpl. Martina Arancio",
            //            VerbalTranscriptionDate = DateTime.Parse("2024-12-29"),
            //            Amount = decimal.Parse("180"),
            //            PointsDeduction = 3,
            //            RegisterId = Guid.Parse("5F39BED5-BF99-4599-AB34-85B5FFF62417"),
            //        },
            //        new Verbal()
            //        {
            //            VerbalId = Guid.Parse("EECA0954-6217-439A-BFB2-7373DA211E98"),
            //            VerbalDate = DateTime.Parse("2025-02-10"),
            //            VerbalAddress = "Via Dante Alighieri 10, Milano",
            //            OfficerName = "SGT. Luca Ferri",
            //            VerbalTranscriptionDate = DateTime.Parse("2025-02-12"),
            //            Amount = decimal.Parse("150"),
            //            PointsDeduction = 2,
            //            RegisterId = Guid.Parse("A4EBFF23-952D-48BB-A65D-8DA5E818C022"),
            //        },
            //        new Verbal()
            //        {
            //            VerbalId = Guid.Parse("1F42E277-C4AA-46E6-B80C-785081E7769B"),
            //            VerbalDate = DateTime.Parse("2025-02-10"),
            //            VerbalAddress = "Via Nazionale 10, Roma",
            //            OfficerName = "SGT. Marco Ferrara",
            //            VerbalTranscriptionDate = DateTime.Parse("2025-02-14"),
            //            Amount = decimal.Parse("350"),
            //            PointsDeduction = 6,
            //            RegisterId = Guid.Parse("59185603-5EE1-4BA0-89C4-94A2AF575A82"),
            //        },
            //        new Verbal()
            //        {
            //            VerbalId = Guid.Parse("31021983-E124-4BE9-AC12-90596D38297A"),
            //            VerbalDate = DateTime.Parse("2024-04-12"),
            //            VerbalAddress = "Corso Italia 15, Roma",
            //            OfficerName = "Cst. Maria Bianchi",
            //            VerbalTranscriptionDate = DateTime.Parse("2024-04-20"),
            //            Amount = decimal.Parse("120"),
            //            PointsDeduction = 3,
            //            RegisterId = Guid.Parse("73F3ED80-C5DE-4C4A-A87B-C39D692C1446"),
            //        },
            //        new Verbal()
            //        {
            //            VerbalId = Guid.Parse("DCA725BF-F57C-450E-88D2-AF295E1B6077"),
            //            VerbalDate = DateTime.Parse("2024-03-01"),
            //            VerbalAddress = "Piazza del Duomo 5, Napoli",
            //            OfficerName = "SGT. Paolo Gialli",
            //            VerbalTranscriptionDate = DateTime.Parse("2024-03-06"),
            //            Amount = decimal.Parse("100"),
            //            PointsDeduction = 1,
            //            RegisterId = Guid.Parse("F924DB1A-29CE-4DDD-8E66-DC20394E1F34"),
            //        },
            //        new Verbal()
            //        {
            //            VerbalId = Guid.Parse("21D213AE-7A41-469F-945C-B010FDCC12DA"),
            //            VerbalDate = DateTime.Parse("2023-10-20"),
            //            VerbalAddress = "Via Etnea 50, Catania",
            //            OfficerName = "SGT. Paolo Galli",
            //            VerbalTranscriptionDate = DateTime.Parse("2023-10-25"),
            //            Amount = decimal.Parse("140"),
            //            PointsDeduction = 3,
            //            RegisterId = Guid.Parse("F924DB1A-29CE-4DDD-8E66-DC20394E1F34"),
            //        },
            //        new Verbal()
            //        {
            //            VerbalId = Guid.Parse("EDFAA7F2-4338-4CF9-A175-BF1C67253A0B"),
            //            VerbalDate = DateTime.Parse("2025-02-10"),
            //            VerbalAddress = "Via Dante Alighieri 10, Milano",
            //            OfficerName = "SGT. Luca Ferri",
            //            VerbalTranscriptionDate = DateTime.Parse("2025-02-12"),
            //            Amount = decimal.Parse("150"),
            //            PointsDeduction = 2,
            //            RegisterId = Guid.Parse("64373DFF-19FE-4F27-AF81-F49F36501BAE"),
            //        },
            //        new Verbal()
            //        {
            //            VerbalId = Guid.Parse("1431630D-4348-432D-BC53-CB5E049D99EF"),
            //            VerbalDate = DateTime.Parse("2023-02-22"),
            //            VerbalAddress = "Via Giuseppe Mazzini 40, Firenze",
            //            OfficerName = "Cst. Chiara Neri",
            //            VerbalTranscriptionDate = DateTime.Parse("2023-02-27"),
            //            Amount = decimal.Parse("180"),
            //            PointsDeduction = 3,
            //            RegisterId = Guid.Parse("7380417D-9A44-4B1B-96FB-FF31488B5628"),
            //        },
            //        new Verbal()
            //        {
            //            VerbalId = Guid.Parse("96CDAC3A-2B32-41B6-8C48-F3393F965874"),
            //            VerbalDate = DateTime.Parse("2024-01-09"),
            //            VerbalAddress = "Via Libertà 30, Palermo",
            //            OfficerName = "Cst. Sofia Grigi",
            //            VerbalTranscriptionDate = DateTime.Parse("2024-01-13"),
            //            Amount = decimal.Parse("160"),
            //            PointsDeduction = 2,
            //            RegisterId = Guid.Parse("7380417D-9A44-4B1B-96FB-FF31488B5628"),
            //        }
            //    );

            // tabella VerbalViolations
            //modelBuilder
            //    .Entity<Verbal>()
            //    .HasData(
            //        new VerbalViolation()
            //        {
            //            VerbalViolationId = Guid.Parse("3f2504e0-4f89-11d3-9a0c-0305e82c3301"),
            //            VerbalId = Guid.Parse("85A06C79-29AD-434B-AC94-057E3041073D"),
            //            ViolationId = Guid.Parse("6E253FBD-31B6-4E62-A74C-00679F0AB1C3"),
            //        },
            //        new VerbalViolation()
            //        {
            //            VerbalViolationId = Guid.Parse("b9e7b3f8-8bf5-4c6a-bc63-4f5d7a8c93b3"),
            //            VerbalId = Guid.Parse("CEB874C0-D731-4F77-9B88-19B3D63FA766"),
            //            ViolationId = Guid.Parse("AACD8366-9A9C-4E67-94DD-8FF43903CA74"),
            //        },
            //        new VerbalViolation()
            //        {
            //            VerbalViolationId = Guid.Parse("d2d2d2d2-aaaa-bbbb-cccc-123456789abc"),
            //            VerbalId = Guid.Parse("CFA60A66-610A-414E-AC15-25590FDC9F42"),
            //            ViolationId = Guid.Parse("4F7E0AAA-3343-4AA8-B54C-E155DF77770F"),
            //        },
            //        new VerbalViolation()
            //        {
            //            VerbalViolationId = Guid.Parse("45d3e54a-1c2b-4f7a-8d19-68a2950fbb9e"),
            //            VerbalId = Guid.Parse("DBAD30B1-CE88-422E-866E-4104EDD4205E"),
            //            ViolationId = Guid.Parse("6E253FBD-31B6-4E62-A74C-00679F0AB1C3"),
            //        },
            //        new VerbalViolation()
            //        {
            //            VerbalViolationId = Guid.Parse("89b1e92d-7ad1-45f2-bc3c-a0b72b698e71"),
            //            VerbalId = Guid.Parse("C3A8EF7F-1525-4E6B-98AC-4A309996614D"),
            //            ViolationId = Guid.Parse("62C20D25-2140-4C65-96CA-74ACBADE17E7"),
            //        },
            //        new VerbalViolation()
            //        {
            //            VerbalViolationId = Guid.Parse("7e8a0c2b-9d63-40aa-b3f5-d12a98b7e7c6"),
            //            VerbalId = Guid.Parse("E2922F19-6A11-4C0D-A7E4-54BFCA29B496"),
            //            ViolationId = Guid.Parse("5AB1BB60-B119-46FB-932B-D6B6DEE293F7"),
            //        },
            //        new VerbalViolation()
            //        {
            //            VerbalViolationId = Guid.Parse("f39d5e6b-472d-4e08-903a-59b5e2d81a0f"),
            //            VerbalId = Guid.Parse("E1C38B72-2563-4EF4-AB5F-61EE425BB9D7"),
            //            ViolationId = Guid.Parse("F956363C-9E19-47D4-9FAE-EF7FE954FE76"),
            //        },
            //        new VerbalViolation()
            //        {
            //            VerbalViolationId = Guid.Parse("9a7c3e1f-482d-49a7-8c1f-3f72b5e2c7a0"),
            //            VerbalId = Guid.Parse("EECA0954-6217-439A-BFB2-7373DA211E98"),
            //            ViolationId = Guid.Parse("81BB9C8A-F85A-454B-BE77-5C55E06BD552"),
            //        },
            //        new VerbalViolation()
            //        {
            //            VerbalViolationId = Guid.Parse("0142c196-1dd2-4a75-8f67-2f38c51e9c0b"),
            //            VerbalId = Guid.Parse("1F42E277-C4AA-46E6-B80C-785081E7769B"),
            //            ViolationId = Guid.Parse("2CFB9F95-6198-4B88-879E-2EBD0AED733E"),
            //        },
            //        new VerbalViolation()
            //        {
            //            VerbalViolationId = Guid.Parse("a872c54b-3a0d-4e5c-9f12-7c38d2e5a7f3"),
            //            VerbalId = Guid.Parse("31021983-E124-4BE9-AC12-90596D38297A"),
            //            ViolationId = Guid.Parse("4F7E0AAA-3343-4AA8-B54C-E155DF77770F"),
            //        },
            //        new VerbalViolation()
            //        {
            //            VerbalViolationId = Guid.Parse("59e4d3b8-7a1c-4d2f-8b63-a2c3e7d5f81a"),
            //            VerbalId = Guid.Parse("DCA725BF-F57C-450E-88D2-AF295E1B6077"),
            //            ViolationId = Guid.Parse("29E939CC-F9ED-4F75-B751-6C4619015F76"),
            //        },
            //        new VerbalViolation()
            //        {
            //            VerbalViolationId = Guid.Parse("c5e2a7b3-4f1d-492c-9a70-38d7b5e4c2f8"),
            //            VerbalId = Guid.Parse("21D213AE-7A41-469F-945C-B010FDCC12DA"),
            //            ViolationId = Guid.Parse("DB84A569-68F9-45C1-97D6-C9F3C1B18C55"),
            //        },
            //        new VerbalViolation()
            //        {
            //            VerbalViolationId = Guid.Parse("1a2b3c4d-5e6f-7a8b-9c0d-1e2f3a4b5c6d"),
            //            VerbalId = Guid.Parse("EDFAA7F2-4338-4CF9-A175-BF1C67253A0B"),
            //            ViolationId = Guid.Parse("AACD8366-9A9C-4E67-94DD-8FF43903CA74"),
            //        },
            //        new VerbalViolation()
            //        {
            //            VerbalViolationId = Guid.Parse("e7c3b5a2-9f4d-1d8b-2c7a-3e5f0a1b6d4c"),
            //            VerbalId = Guid.Parse("1431630D-4348-432D-BC53-CB5E049D99EF"),
            //            ViolationId = Guid.Parse("1765429A-A462-44A9-A414-4FACC897FD25"),
            //        },
            //        new VerbalViolation()
            //        {
            //            VerbalViolationId = Guid.Parse("4f7a2c3e-9b1d-58a0-d2f5-6c7e3a4b1d8b"),
            //            VerbalId = Guid.Parse("96CDAC3A-2B32-41B6-8C48-F3393F965874"),
            //            ViolationId = Guid.Parse("2CFB9F95-6198-4B88-879E-2EBD0AED733E"),
            //        }
            //    );
        }
    }
}
