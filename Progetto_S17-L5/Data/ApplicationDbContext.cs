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
            //modelBuilder
            //    .Entity<Register>()
            //    .HasData(
            //        new Register()
            //        {
            //            Name = "Giulia",
            //            Surame = "Rossi",
            //            Address = "Via Dante Alighieri 10",
            //            City = "Milano",
            //            CAP = "20100",
            //            FiscalCode = "RSSGLI90A01F205X",
            //        },
            //        new Register()
            //        {
            //            Name = "Marco",
            //            Surame = "Bianchi",
            //            Address = "Corso Italia 15",
            //            City = "Roma",
            //            CAP = "00100",
            //            FiscalCode = "BNCMRC85M01H501Y",
            //        },
            //        new Register()
            //        {
            //            Name = "Alessandra",
            //            Surame = "Verdi",
            //            Address = "Via Roma 25",
            //            City = "Torino",
            //            CAP = "10100",
            //            FiscalCode = "VRDLSA72D55L219P",
            //        },
            //        new Register()
            //        {
            //            Name = "Luca",
            //            Surame = "Neri",
            //            Address = "Via Giuseppe Mazzini 40",
            //            City = "Firenze",
            //            CAP = "50100",
            //            FiscalCode = "NRILCU85C01D612N",
            //        },
            //        new Register()
            //        {
            //            Name = "Laura",
            //            Surame = "Gialli",
            //            Address = "Piazza del Duomo 5",
            //            City = "Napoli",
            //            CAP = "80100",
            //            FiscalCode = "GLLLRA90A01F839T",
            //        },
            //        new Register()
            //        {
            //            Name = "Andrea",
            //            Surame = "Blu",
            //            Address = "Via San Petronio 22",
            //            City = "Bologna",
            //            CAP = "40100",
            //            FiscalCode = "BLNDRE80B01L219W",
            //        },
            //        new Register()
            //        {
            //            Name = "Sofia",
            //            Surame = "Grigi",
            //            Address = "Via Libertà 30",
            //            City = "Palermo",
            //            CAP = "90100",
            //            FiscalCode = "GRGSFA96C41H501D",
            //        },
            //        new Register()
            //        {
            //            Name = "Paolo",
            //            Surame = "Galli",
            //            Address = "Via Etnea 50",
            //            City = "Catania",
            //            CAP = "95100",
            //            FiscalCode = "GLLPLA84M01H501Q",
            //        },
            //        new Register()
            //        {
            //            Name = "Martina",
            //            Surame = "Arancio",
            //            Address = "Viale Giuseppe Mazzini 12",
            //            City = "Verona",
            //            CAP = "37100",
            //            FiscalCode = "RNCMTN92A41F205X",
            //        },
            //        new Register()
            //        {
            //            Name = "Francesco",
            //            Surame = "Marroni",
            //            Address = "Via XX Settembre 60",
            //            City = "Genova",
            //            CAP = "16100",
            //            FiscalCode = "MRNFRN75C01L219B",
            //        }
            //    );

            // inserimento dati tabella Violations
            //modelBuilder
            //    .Entity<Violation>()
            //    .HasData(
            //        new Violation()
            //        {
            //            Description =
            //                "Eccesso di velocità: Multa per aver superato il limite di velocità di 20 km/h sulla Via Roma, zona residenziale. La velocità rilevata era di 80 km/h anziché 60 km/h, causando un rischio per pedoni e ciclisti",
            //        },
            //        new Violation()
            //        {
            //            Description =
            //                "Parcheggio in divieto di sosta: Sanzione per aver parcheggiato in zona a traffico limitato in Piazza del Duomo senza autorizzazione, ostruendo il passaggio di mezzi di emergenza",
            //        },
            //        new Violation()
            //        {
            //            Description =
            //                "Mancato uso delle cinture di sicurezza: Multa per non aver indossato la cintura di sicurezza durante il viaggio in autostrada. Il veicolo è stato fermato durante un controllo di routine",
            //        },
            //        new Violation()
            //        {
            //            Description =
            //                "Guida con cellulare: Multa per l’utilizzo del cellulare durante la guida su Via Dante, creando potenziale distrazione e pericolo per gli altri automobilisti",
            //        },
            //        new Violation()
            //        {
            //            Description =
            //                "Soste abusive su strisce pedonali: Sanzione per aver parcheggiato il veicolo sopra le strisce pedonali in Corso Italia, impedendo il normale attraversamento dei pedoni",
            //        },
            //        new Violation()
            //        {
            //            Description =
            //                "Incrocio con semaforo rosso: Multa per aver attraversato un incrocio con semaforo rosso, violando il codice della strada e mettendo in pericolo la sicurezza stradale",
            //        },
            //        new Violation()
            //        {
            //            Description =
            //                "Guida senza patente: Sanzione per guida senza patente di guida, accertata durante un controllo su Viale Giuseppe Mazzini. Il conducente non era in possesso di documenti validi",
            //        },
            //        new Violation()
            //        {
            //            Description =
            //                "Transito in area pedonale: Multa per aver circolato con il veicolo in area pedonale in Via Roma durante orario di divieto, mettendo a rischio la sicurezza dei pedoni",
            //        },
            //        new Violation()
            //        {
            //            Description =
            //                "Spostamento del veicolo durante una sosta vietata: Sanzione per aver spostato un veicolo durante una sosta vietata, creando ostacoli al traffico e rischi per la circolazione",
            //        },
            //        new Violation()
            //        {
            //            Description =
            //                "Mancata revisione del veicolo: Multa per circolazione con un veicolo non revisionato, scaduto da oltre sei mesi. La mancata revisione compromette la sicurezza del mezzo e la protezione ambientale",
            //        },
            //        new Violation()
            //        {
            //            Description =
            //                "Mancato rispetto della precedenza: Sanzione per non aver dato la precedenza al veicolo proveniente da destra su un incrocio non regolato da semaforo",
            //        },
            //        new Violation()
            //        {
            //            Description =
            //                "Uso improprio delle corsie: Multa per aver viaggiato sulla corsia di emergenza in autostrada per oltre 500 metri, senza necessità, ostacolando il passaggio dei veicoli di soccorso",
            //        },
            //        new Violation()
            //        {
            //            Description =
            //                "Eccesso di velocità in zona scolastica: Sanzione per aver superato il limite di velocità di 30 km/h nella zona residenziale",
            //        },
            //        new Violation()
            //        {
            //            Description =
            //                "Fermata in doppia fila: Multa per aver lasciato il veicolo in doppia fila",
            //        },
            //        new Violation() { Description = "Guida sotto influenza di sostanze alcoliche" },
            //        new Violation()
            //        {
            //            Description =
            //                "Mancato rispetto del limite di altezza: Sanzione per aver percorso un tunnel con un veicolo che superava altezza massima consentita di 3 metri",
            //        },
            //        new Violation()
            //        {
            //            Description =
            //                "Mancato fermo al posto di blocco: Multa per non essersi fermati a un posto di blocco della polizia",
            //        },
            //        new Violation()
            //        {
            //            Description =
            //                "Violazione del divieto di transito: Sanzione per aver percorso un tratto di strada in cui il transito era vietato, ignorando il cartello di divieto",
            //        },
            //        new Violation()
            //        {
            //            Description =
            //                "Transito con veicolo non assicurato: Multa per circolazione con un veicolo privo di assicurazione obbligatoria",
            //        },
            //        new Violation()
            //        {
            //            Description =
            //                "Uso del veicolo per finalità diverse da quelle consentite: Sanzione per aver utilizzato un veicolo commerciale per trasporto di persone, violando le normative riguardanti il trasporto pubblico e la sicurezza stradale",
            //        }
            //    );
        }
    }
}
