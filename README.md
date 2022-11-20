# WWImporters POC

[Initial Commit on Main Branch @ 22/07/2022 | 0100h] Skeleton Dependency Injection puzzle for Yun Cong.

Since then:

<br />
<h3>HiddenMain Branch (Last Updated 29 Oct 2022):</h3>

- Reverse-scaffolded WideWorldImporters DB.
- Implemented EFMigrations Layer by following [Microsoft Doc](https://learn.microsoft.com/en-us/ef/core/managing-schemas/migrations/projects?tabs=vs). Use case is for instances of multiple Migration files being added during Development, especially for large DBs and/or multiple EF Migration scripts.
- Added Architecture Unit Tests.

<br />

<h3>***HiddenMain has been merged to Main Branch</h3>

- SQL Bundle Command (Run on same Layer as Program/StartUp; generate bundle on Migrations Layer):

```
dotnet ef migrations script -o ../efmigrations/initial_idempotent.sql --idempotent
```

<br />

<h3>16 Nov 2022 Commit</h3>

- Added original table & column comments from the original DB
- Also noted that reverse-scaffolding might have led to incorrect max char length declarations in EntityConfigurations for nVarChar columns (e.g. 10 -> 18, 100 -> 107, 256 -> 264)
    => <b>TODO:</b> Explore SQL Server Schema Compare in Azure Data Studio

<br />

<h3>20 Nov 2022 Commit</h3>

- Added EF Migration script approach to creating Stored Procedures on Migrate
    => This does <b>not</b> run the said created SPs
    => This is either a <b>risky</b> approach, or error-prone, or both...
- Tidied up OnModelCreating using the OnModelCreatingPartial auto-generated via DbFirst

<br />
<br />
<br />