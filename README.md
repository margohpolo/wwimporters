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
dotnet ef migrations script ../efmigrations/initial_idempotent.sql --idempotent
```

<br />
<br />
<br />