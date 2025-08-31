# DatabaseVerbali

**DatabaseVerbali** — progetto didattico ASP.NET MVC (C#) nato come esercitazione per mettere alla prova il pattern MVC, la manipolazione di query SQL complesse (join, filtri restrittivi) e la presentazione dei risultati nelle view Razor tramite appositi modelli / viewmodels.

---

## Sommario
- [Obiettivo](#obiettivo)  
- [Caratteristiche principali](#caratteristiche-principali)  
- [Tecnologie utilizzate](#tecnologie-utilizzate)  
- [Architettura e struttura consigliata / trovata](#architettura-e-struttura-consigliata--trovata)  
- [Modelli e mapping dei dati](#modelli-e-mapping-dei-dati)  
- [Esempi di query SQL (pattern usati nel progetto)](#esempi-di-query-sql-pattern-usati-nel-progetto)  
- [Passaggio dati: Controller → ViewModel → View (Razor)](#passaggio-dati-controller--viewmodel--view-razor)  
- [Installazione e avvio (sviluppo)](#installazione-e-avvio-sviluppo)  

---

## Obiettivo
L'obiettivo del progetto è mettere in pratica:
- Il pattern **Model–View–Controller** in ASP.NET MVC con Razor Views.  
- L'uso di query SQL complesse (JOIN, filtri molto restrittivi, subquery) per estrarre “sottoinsiemi” di dati significativi dal database relazionale.  
- La trasformazione dei risultati (recordset) in ViewModel fortemente tipizzati e la loro visualizzazione in tabelle nelle view.

---

## Caratteristiche principali
- Interfaccia MVC con controller che eseguono query SQL e passano ViewModel alle view.  
- Esempi di query con `JOIN` tra più tabelle, filtri `WHERE` restrittivi e ordinamenti mirati.  
- Tabelle HTML (Razor) che mostrano i risultati delle query in modo leggibile (paginazione/ordinamento opzionali).  
- Progetto pensato come esercitazione: codice orientato a prova di concetti piuttosto che a una produzione completa.

---

## Tecnologie utilizzate
- **ASP.NET MVC (C#)** — struttura MVC con Razor Views.  
- **Microsoft SQL Server** — database relazionale per i dati e i test delle query.  
- Linguaggi nel repository: C# e HTML (il repository mostra prevalenza di C# con codice server-side e view HTML/Razor). citeturn0view0turn1view0

---

## Architettura e struttura consigliata / trovata
Tipica (e coerente con progetti didattici ASP.NET MVC):

```
/Progetto_S17-L5/
  /Controllers/
    VerbaliController.cs
    HomeController.cs
  /Models/
    Verbale.cs
    Soggetto.cs
    AltraEntita.cs
  /ViewModels/
    VerbaliListViewModel.cs
  /Views/
    /Verbali/Index.cshtml
    /Verbali/Details.cshtml
  /Data/
    DbConnectionHelper.cs  # helper ADO.NET o repository
    SqlScripts/
      create_tables.sql
      sample_data.sql
  appsettings.json
  Progetto_S17-L5.sln
  Progetto_S17-L5.csproj
```

> Se nella repo usi EF Core, Dapper o ADO.NET puro, è utile specificarlo; nella maggior parte degli esercizi didattici per testare query SQL si usa ADO.NET con `SqlConnection` / `SqlCommand` o Dapper per mapping leggero.

---

## Modelli e mapping dei dati (concetto)
Esempi di entità che frequentemente compaiono in un progetto sui verbali (adatta ai nomi reali nel tuo progetto):

**Verbale**
- `Id` (int)  
- `Numero` (string)  
- `DataVerbale` (datetime)  
- `SoggettoId` (int) — FK  
- `Tipo` (string)  
- `Note` (text)

**Soggetto**
- `Id`  
- `Nome`, `Cognome`  
- `CodiceFiscale` / `Piva`  
- `Indirizzo`

**Altre tabelle** (es. `Luoghi`, `Tipologie`, `Operatori`) collegate via FK.

---

## Esempi di query SQL (pattern usati nel progetto)
Qui sotto trovi pattern di query che mostrano come ottenere insiemi ristretti di dati con join e filtri — puoi adattarle alle tue tabelle reali.

### 1) Join base con filtro restrittivo (date + tipo)
```sql
SELECT v.Id, v.Numero, v.DataVerbale, s.Nome + ' ' + s.Cognome AS Soggetto, t.Descrizione AS Tipo
FROM Verbali v
JOIN Soggetti s ON v.SoggettoId = s.Id
JOIN Tipologie t ON v.Tipo = t.Codice
WHERE v.DataVerbale BETWEEN @startDate AND @endDate
  AND t.Codice = @tipo
ORDER BY v.DataVerbale DESC;
```

### 2) Selezione di “casi particolari” con subquery e HAVING
Esempio: soggetti con più di N verbali in un periodo.
```sql
SELECT s.Id, s.Nome, s.Cognome, COUNT(v.Id) AS TotaleVerbali
FROM Soggetti s
JOIN Verbali v ON v.SoggettoId = s.Id
WHERE v.DataVerbale >= @fromDate
GROUP BY s.Id, s.Nome, s.Cognome
HAVING COUNT(v.Id) > @minVerbali
ORDER BY TotaleVerbali DESC;
```

### 3) Query molto restrittiva con più join e condizioni
```sql
SELECT v.Id, v.Numero, v.DataVerbale, l.NomeLuogo, o.Username AS Operatore
FROM Verbali v
JOIN Soggetti s ON v.SoggettoId = s.Id
JOIN Luoghi l ON v.LuogoId = l.Id
LEFT JOIN Operatori o ON v.OperatoreId = o.Id
WHERE v.DataVerbale BETWEEN @start AND @end
  AND l.Provincia = @provincia
  AND v.Severita >= @minSeverita
  AND s.Categoria = @categoria
ORDER BY v.DataVerbale DESC;
```

**Nota importante**: usa sempre query parametrizzate (non concatenare stringhe) per prevenire SQL Injection. Vedi esempio ADO.NET più in basso.

---

## Esecuzione di query parametrizzate (esempio ADO.NET)
```csharp
var sql = @"SELECT v.Id, v.Numero, v.DataVerbale, s.Nome, s.Cognome
            FROM Verbali v
            JOIN Soggetti s ON v.SoggettoId = s.Id
            WHERE v.DataVerbale BETWEEN @start AND @end
              AND s.CodiceFiscale = @cf";

using(var conn = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
using(var cmd = new SqlCommand(sql, conn))
{
    cmd.Parameters.AddWithValue("@start", startDate);
    cmd.Parameters.AddWithValue("@end", endDate);
    cmd.Parameters.AddWithValue("@cf", codiceFiscale);
    conn.Open();
    using(var reader = cmd.ExecuteReader())
    {
        var list = new List<VerbaleViewModel>();
        while(reader.Read())
        {
            list.Add(new VerbaleViewModel {
                Id = reader.GetInt32(0),
                Numero = reader.GetString(1),
                DataVerbale = reader.GetDateTime(2),
                Nome = reader.GetString(3),
                Cognome = reader.GetString(4)
            });
        }
        return list;
    }
}
```

---

## Passaggio dati: Controller → ViewModel → View (Razor)
Esempio semplificato di controller action che recupera dati e li passa alla view:
```csharp
public IActionResult Index(DateTime? from, DateTime? to)
{
    var model = _verbaliRepository.GetVerbali(from, to);
    return View(model); // model è List<VerbaleViewModel>
}
```

Esempio View Razor (tabella semplificata):
```html
@model IEnumerable<VerbaleViewModel>

<table class="table table-striped">
  <thead>
    <tr>
      <th>Numero</th>
      <th>Data</th>
      <th>Soggetto</th>
      <th>Azioni</th>
    </tr>
  </thead>
  <tbody>
  @foreach(var v in Model) {
    <tr>
      <td>@v.Numero</td>
      <td>@v.DataVerbale.ToString("yyyy-MM-dd")</td>
      <td>@(v.Nome + " " + v.Cognome)</td>
      <td>
        <a asp-action="Details" asp-route-id="@v.Id">Dettagli</a>
      </td>
    </tr>
  }
  </tbody>
</table>
```

---

## Installazione e avvio (sviluppo)

### Prerequisiti
- .NET SDK (verifica la versione target nel file `.csproj`).  
- Microsoft SQL Server (Express va bene per sviluppo).  
- Visual Studio / VS Code o favore preferito per lo sviluppo.

### Passaggi
```bash
git clone https://github.com/Gianlu201/DatabaseVerbali.git
cd DatabaseVerbali/Progetto_S17-L5   # o nella cartella del progetto corretto
dotnet restore
```
1. Aggiorna la `ConnectionStrings:DefaultConnection` in `appsettings.json` con la tua istanza di SQL Server.  
2. Se sono presenti script SQL nella cartella `Data/SqlScripts` o simile, eseguili sul database per creare tabelle e inserire dati di esempio.  
3. Se il progetto usa migrazioni EF Core, esegui:
```bash
dotnet ef database update
```
4. Avvia l'app:
```bash
dotnet run
```
5. Apri `https://localhost:5001` oppure l'URL mostrato dalla CLI.

---
