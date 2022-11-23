# WWImporters POC

 

What started out as a reverse-scaffolding of WideWorldImporters DB, has now grown into a full on tinkering project.

Documentation is now in reverse-chronological order:

<br />

<br />

<h3>23 Nov Commit</h3>

- All Stored Procedures are now created **after** all EFMigration changes (See my reply to [Open Issue #24710](https://github.com/dotnet/efcore/issues/24710#issuecomment-1323928750))
- Stored Procedures for DB setup are immediately run after (Other DB Maintenance e.g. Index Rebuilding can be run here too)
- Also debugged the Scripts for FullTextIndexing & PartitionTableCreation Stored Procedures
- Also enabled FullText for Dockerised SQL Server (Thankfully, it can work on SQL Server Express)
- Finally, also noted the importance of SQL Server Schema Compare for CodeFirst development

<br />

<h3>20 Nov 2022 Commit</h3>

- Added EF Migration script approach to creating Stored Procedures on Migrate
    => This does <b>not</b> run the said created SPs
    => This is either a <b>risky</b> approach, or error-prone, or both...
- Tidied up OnModelCreating using the OnModelCreatingPartial auto-generated via DbFirst

<br />

<h3>16 Nov 2022 Commit</h3>

- Added original table & column comments from the original DB
- Also noted that reverse-scaffolding might have led to incorrect max char length declarations in EntityConfigurations for nVarChar columns (e.g. 10 -> 18, 100 -> 107, 256 -> 264)
    => <b>TODO:</b> Explore SQL Server Schema Compare in Azure Data Studio


<br />
<br />


<h3>***HiddenMain has been merged to Main Branch</h3>

- SQL Bundle Command (Run on same Layer as Program/StartUp; generate bundle on Migrations Layer):

```
dotnet ef migrations script -o ../efmigrations/initial_idempotent.sql --idempotent
```

<br />

<h3>HiddenMain Branch (Last Updated 29 Oct 2022):</h3>

- Reverse-scaffolded WideWorldImporters DB.
- Implemented EFMigrations Layer by following [Microsoft Doc](https://learn.microsoft.com/en-us/ef/core/managing-schemas/migrations/projects?tabs=vs). Use case is for instances of multiple Migration files being added during Development, especially for large DBs and/or multiple EF Migration scripts.
- Added Architecture Unit Tests.

<br />

<h3>[Initial Commit on Main Branch @ 22/07/2022 | 0100h]</h3>

- Skeleton Layout was a Dependency Injection puzzle for Yun Cong.

<br />
<br />
<br />