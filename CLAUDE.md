# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Commands

All `dotnet` commands must be run from the `./src` directory.

```bash
dotnet restore
dotnet tool restore
dotnet build --no-restore -warnaserror
dotnet format --verify-no-changes              # check code style (CI enforces this)
dotnet csharpier check .                       # check code style (CI enforces this)
dotnet format && dotnet csharpier format .     # auto-fix code style
dotnet test --no-build --verbosity normal --logger trx --collect:"XPlat Code Coverage"
dotnet stryker --mutation-level Complete       # mutation testing (CI enforces this)
dotnet pack --configuration Release -p:Version=<version> --output .
```

## Architecture

This is a **sample-data NuGet library**: a catalogue of named, predefined *stored data set* instances (cells, rows, table data sets and schema data sets) used as fixtures by other repositories in the ecosystem. There is no logic here — every type is a sealed record with parameterless construction and hard-coded contents.

**Sub-namespaces, one sealed record per file:**

- `Cells` — `ICell` samples, one per primitive shape (`EmptyCell`, `TextCell`, `UuidCell`, `IntCell`, `LongCell`, `DoubleCell`, `BoolCell`, `DateCell`, `TimeCell`, `DateTimeCell`, `WhitespaceCell`, `UnicodeCell`)
- `Rows` — `IRow` samples, each shaped for one table from `Pure.RelationalSchema.Samples`, cells keyed by structural column hash
- `TableDataSets` — `IStoredTableDataSet` samples, each pairing a table schema with zero or more rows
- `SchemaDataSets` — `IStoredSchemaDataSet` samples, graded from `EmptySchemaDataSet` to `FullSchemaDataSet`

**Everything is public API.** Consumers reference individual components (`new UsersTableDataSet()`), not only whole schema data sets, so no type here is an implementation detail. Renaming or changing the contents of an existing sample is a breaking change for every repository that asserts against it.

**Determinism is the contract.** Samples must never use randomness, ambient state, time or culture-sensitive formatting. Two instances of the same sample type must always produce identical structural hashes. Cell values wrap the matching `Pure.Primitives` type (`new String(new True())`, `new String(new Guid(…))`) instead of a hand-formatted literal, for the same reason `new EmptyString()` is preferred over `new String("")`.

**The catalogue is graded.** When adding a table data set, add it to `FullSchemaDataSet` too if it belongs to the exhaustive set.

**Dependencies are deliberately minimal:** `Pure.RelationalSchema.Samples` for the schema fixtures, `Pure.RelationalSchema.Storage.Abstractions` for the interfaces, `Pure.Collections.Generic` for the hash-keyed dictionaries, `Pure.RelationalSchema.HashCodes` for the key comparers, and `Pure.Primitives` for `String`/`EmptyString`/the typed primitives. Do **not** reference `Pure.RelationalSchema.Storage` or any other storage implementation package — implementations themselves consume these samples, and a reference would create a cycle.

**Multi-targeting:** net8.0, net9.0, net10.0 — not net7.0. `Pure.Collections.Generic` needs net8.0+ and is required for the hash-keyed dictionaries backing `IRow.Cells` and `IStoredSchemaDataSet` (every Pure type throws `NotSupportedException` from `GetHashCode()`, so a plain dictionary key is not an option).

**`IsAotCompatible` is deliberately not set.** `IStoredTableDataSet` is an `IQueryable<IRow>`, and an in-memory `AsQueryable()` carries `[RequiresUnreferencedCode]`/`[RequiresDynamicCode]`. Setting `IsAotCompatible` under `-warnaserror` fails the build with IL2026/IL3050.

**`TableDataSets` records are not record-equal.** Each holds a private `IQueryable<IRow>` field (built once via a private constructor the public parameterless constructor delegates to), so compare two instances with `StoredTableDataSetHash`, never `==`/`Equals`. `GetAsyncEnumerator` returns a shared internal `SynchronousAsyncRowEnumerator` wrapping the underlying `IEnumerator<IRow>` — this exists so the same code path runs for empty and populated data sets alike (no dead branch, no `Stryker disable` comment needed).

**Package validation** is not yet enabled in the csproj — there is no published baseline. Add `EnablePackageValidation` and set `PackageValidationBaselineVersion` to the latest released version once the first tag is published, so breaking API changes fail the build.

**Tests:** xUnit project targeting net10.0, mirroring the source layout one `…Tests` record per sample. Membership is asserted by structural hash (`ColumnHash`, `TableHash`, `SchemaHash` from `Pure.RelationalSchema.HashCodes`; `CellHash`, `RowHash`, `StoredTableDataSetHash`, `StoredSchemaDataSetHash` from `Pure.RelationalSchema.Storage.HashCodes`), never by reference equality.

**CI thresholds** (`.github/workflows/build-and-test.yml`): line coverage 98 (warning at 99) and mutation score 97. The mutation threshold is 97, not 98, because a couple of mutants are genuinely equivalent rather than untested: mutating `EmptySchemaDataSet.ContainsKey`/`TryGetValue` to unconditionally return `false` is behaviorally identical to the real always-empty lookup, and `SynchronousAsyncRowEnumerator.DisposeAsync`'s `_enumerator.Dispose();` has no externally observable effect that a public-API test can assert on. Neither is suppressed with a `Stryker disable` comment — this repository does not use them; a real coverage or mutation gap is fixed by writing a test or redesigning the code, not annotated away.

**Publishing:** triggered by pushing a semver tag matching `*.*.*`. The tag name becomes the package version. Packages are published to both GitHub Packages and NuGet.org.

## Code Style

Enforced via `.editorconfig` and `dotnet format` + `csharpier` in CI:

- No `var` — always use explicit types
- No expression-bodied methods or constructors — use block bodies
- Properties and indexers use expression bodies (`=>`)
- File-scoped namespaces (`namespace Foo.Bar;`)
- No implicit object creation when the type is not apparent — `new Foo()`, not `new()`
- Private fields: `_camelCase`
- Max line length: 90 characters
- Prefer the dedicated `Pure.Primitives` type over a parameterised one — `new EmptyString()`, not `new String("")`
- Use `string.Empty` rather than `""` in test assertions
- Use `_ = Assert.Single(...)` in tests — an unused expression value trips IDE0058
- Do **not** override `ToString()`/`GetHashCode()` — the *Samples* convention, not the implementation-repo one

## Commit Messages

Do not mention Claude or AI assistance in commit messages.
