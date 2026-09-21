# Pure.RelationalSchema.Storage.Samples

Named, predefined stored data sets — cells, rows, table data sets and schema data sets — for the **Pure** ecosystem.

[![.NET build & test](https://github.com/kudima03/Pure.RelationalSchema.Storage.Samples/actions/workflows/build-and-test.yml/badge.svg?branch=main)](https://github.com/kudima03/Pure.RelationalSchema.Storage.Samples/actions/workflows/build-and-test.yml)
[![Build and Deploy](https://github.com/kudima03/Pure.RelationalSchema.Storage.Samples/actions/workflows/publish-nuget.yml/badge.svg?branch=main)](https://github.com/kudima03/Pure.RelationalSchema.Storage.Samples/actions/workflows/publish-nuget.yml)
[![NuGet](https://img.shields.io/nuget/v/Pure.RelationalSchema.Storage.Samples)](https://www.nuget.org/packages/Pure.RelationalSchema.Storage.Samples)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](LICENSE)

## Overview

`Pure.RelationalSchema.Storage.Samples` provides a fixed, deterministic catalogue of stored data set shapes implemented as sealed records over the interfaces from `Pure.RelationalSchema.Storage.Abstractions`, layered on the schema fixtures from `Pure.RelationalSchema.Samples`. Every sample is a concrete named type with a parameterless constructor and stable contents — nothing is random, nothing is generated.

The `SchemaDataSets` catalogue is graded from trivial to full-set, so a consumer can pick the exact shape it needs:

| Shape | Sample |
|---|---|
| Nothing at all | `EmptySchemaDataSet` |
| One table, one row | `SingleTableSchemaDataSet` |
| Several tables, no rows | `SchemaDataSetWithoutRows` |
| Unique, non-unique and composite indexes | `SchemaDataSetWithIndexes` |
| Every column type in one table | `SchemaDataSetWithAllColumnTypes` |
| A single-column relation | `SchemaDataSetWithForeignKeys` |
| A multi-column relation | `SchemaDataSetWithCompositeForeignKey` |
| A table referencing itself | `SchemaDataSetWithSelfReferencingTable` |
| Everything at once | `FullSchemaDataSet` |

`IStoredTableDataSet` is an `IQueryable<IRow>`, and an in-memory `AsQueryable()` requires dynamic code, so `IsAotCompatible` is deliberately not set on this package (unlike `Pure.RelationalSchema.Samples`, which is AOT-compatible).

## Schema Data Set Catalogue

```
Pure.RelationalSchema.Storage.Samples.SchemaDataSets/
├── EmptySchemaDataSet                        (empty_schema)
│
├── SingleTableSchemaDataSet                  (single_table_schema)
│   └── SingleColumnTable → SingleRowTableDataSet
│       └── SingleCellRow
│           └── id → UuidCell
│
├── SchemaDataSetWithoutRows                  (schema_without_foreign_keys)
│   ├── EmptyTable → EmptyTableDataSet
│   ├── SingleColumnTable → EmptySingleColumnTableDataSet
│   └── TableWithoutIndexes → EmptyTableWithoutIndexesDataSet
│
├── SchemaDataSetWithIndexes                  (schema_with_indexes)
│   ├── TableWithSingleIndex → TableWithSingleIndexDataSet
│   │   └── TableWithSingleIndexRow
│   │       ├── id → UuidCell
│   │       └── name → TextCell
│   └── TableWithIndexes → TableWithIndexesDataSet
│       └── TableWithIndexesRow
│           ├── id → UuidCell
│           ├── tenant_id → UuidCell
│           ├── name → TextCell
│           └── created_at → DateTimeCell
│
├── SchemaDataSetWithAllColumnTypes            (schema_with_all_column_types)
│   └── AllColumnTypesTable → AllColumnTypesTableDataSet
│       └── AllColumnTypesRow
│           ├── id → UuidCell
│           ├── name → TextCell
│           ├── age → IntCell
│           ├── quantity → LongCell
│           ├── price → DoubleCell
│           ├── is_active → BoolCell
│           ├── birth_date → DateCell
│           ├── start_time → TimeCell
│           ├── created_at → DateTimeCell
│           └── (empty name) → EmptyCell
│
├── SchemaDataSetWithForeignKeys               (schema_with_foreign_keys)
│   ├── UsersTable → UsersTableDataSet
│   │   ├── UserRow
│   │   │   ├── id → UuidCell
│   │   │   ├── tenant_id → UuidCell
│   │   │   ├── name → TextCell
│   │   │   ├── birth_date → DateCell
│   │   │   ├── is_active → BoolCell
│   │   │   └── created_at → DateTimeCell
│   │   └── EmptyCellsUserRow          (all columns) → EmptyCell
│   └── OrdersTable → OrdersTableDataSet
│       └── OrderRow
│           ├── id → UuidCell
│           ├── tenant_id → UuidCell
│           ├── user_id → UuidCell
│           ├── price → DoubleCell
│           └── created_at → DateTimeCell
│
├── SchemaDataSetWithCompositeForeignKey       (schema_with_composite_foreign_key)
│   ├── OrdersTable → OrdersTableDataSet
│   │   └── OrderRow
│   │       ├── id → UuidCell
│   │       ├── tenant_id → UuidCell
│   │       ├── user_id → UuidCell
│   │       ├── price → DoubleCell
│   │       └── created_at → DateTimeCell
│   └── OrderItemsTable → OrderItemsTableDataSet
│       └── OrderItemRow
│           ├── id → UuidCell
│           ├── tenant_id → UuidCell
│           ├── order_id → UuidCell
│           ├── product_id → UuidCell
│           └── quantity → LongCell
│
├── SchemaDataSetWithSelfReferencingTable      (schema_with_self_referencing_table)
│   └── EmployeesTable → EmployeesTableDataSet
│       └── EmployeeRow
│           ├── id → UuidCell
│           ├── name → TextCell
│           ├── manager_id → UuidCell
│           └── start_time → TimeCell
│
└── FullSchemaDataSet                          (full_schema)
    ├── EmptyTable → EmptyTableDataSet
    ├── SingleColumnTable → SingleRowTableDataSet
    │   └── SingleCellRow
    ├── TableWithoutIndexes → TableWithoutIndexesDataSet
    │   └── UnicodeTextRow
    ├── TableWithSingleIndex → TableWithSingleIndexDataSet
    │   └── TableWithSingleIndexRow
    ├── TableWithIndexes → TableWithIndexesDataSet
    │   └── TableWithIndexesRow
    ├── AllColumnTypesTable → AllColumnTypesTableDataSet
    │   └── AllColumnTypesRow
    ├── UsersTable → UsersTableDataSet
    │   ├── UserRow
    │   └── EmptyCellsUserRow
    ├── OrdersTable → OrdersTableDataSet
    │   └── OrderRow
    ├── ProductsTable → ProductsTableDataSet
    │   └── ProductRow
    ├── OrderItemsTable → OrderItemsTableDataSet
    │   └── OrderItemRow
    └── EmployeesTable → EmployeesTableDataSet
        └── EmployeeRow
```

## Schema Data Sets

`namespace Pure.RelationalSchema.Storage.Samples.SchemaDataSets`

| Class | `Schema` | Entries |
|---|---|---|
| `EmptySchemaDataSet` | `EmptyRelationalSchema` | 0 |
| `SingleTableSchemaDataSet` | `SingleTableRelationalSchema` | 1 |
| `SchemaDataSetWithoutRows` | `RelationalSchemaWithoutForeignKeys` | 3 |
| `SchemaDataSetWithIndexes` | `RelationalSchemaWithIndexes` | 2 |
| `SchemaDataSetWithAllColumnTypes` | `RelationalSchemaWithAllColumnTypes` | 1 |
| `SchemaDataSetWithForeignKeys` | `RelationalSchemaWithForeignKeys` | 2 |
| `SchemaDataSetWithCompositeForeignKey` | `RelationalSchemaWithCompositeForeignKey` | 2 |
| `SchemaDataSetWithSelfReferencingTable` | `RelationalSchemaWithSelfReferencingTable` | 1 |
| `FullSchemaDataSet` | `FullRelationalSchema` | 11 |

## Table Data Sets

`namespace Pure.RelationalSchema.Storage.Samples.TableDataSets`

| Class | `TableSchema` | Rows |
|---|---|---|
| `EmptyTableDataSet` | `EmptyTable` | *(none)* |
| `SingleEmptyRowTableDataSet` | `EmptyTable` | `EmptyRow` |
| `EmptySingleColumnTableDataSet` | `SingleColumnTable` | *(none)* |
| `SingleRowTableDataSet` | `SingleColumnTable` | `SingleCellRow` |
| `EmptyTableWithoutIndexesDataSet` | `TableWithoutIndexes` | *(none)* |
| `TableWithoutIndexesDataSet` | `TableWithoutIndexes` | `UnicodeTextRow` |
| `TableWithSingleIndexDataSet` | `TableWithSingleIndex` | `TableWithSingleIndexRow` |
| `TableWithIndexesDataSet` | `TableWithIndexes` | `TableWithIndexesRow` |
| `AllColumnTypesTableDataSet` | `AllColumnTypesTable` | `AllColumnTypesRow` |
| `EmptyUsersTableDataSet` | `UsersTable` | *(none)* |
| `UsersTableDataSet` | `UsersTable` | `UserRow`, `EmptyCellsUserRow` |
| `OrdersTableDataSet` | `OrdersTable` | `OrderRow` |
| `ProductsTableDataSet` | `ProductsTable` | `ProductRow` |
| `OrderItemsTableDataSet` | `OrderItemsTable` | `OrderItemRow` |
| `EmployeesTableDataSet` | `EmployeesTable` | `EmployeeRow` |

## Rows

`namespace Pure.RelationalSchema.Storage.Samples.Rows`

Each row's keys are exactly the columns of the table it is shaped for.

| Class | Shaped for | Cells |
|---|---|---|
| `EmptyRow` | `EmptyTable` | *(none)* |
| `SingleCellRow` | `SingleColumnTable` | `id`→`UuidCell` |
| `UnicodeTextRow` | `TableWithoutIndexes` | `id`→`UuidCell`, `name`→`UnicodeCell`, `created_at`→`DateTimeCell` |
| `TableWithSingleIndexRow` | `TableWithSingleIndex` | `id`→`UuidCell`, `name`→`TextCell` |
| `TableWithIndexesRow` | `TableWithIndexes` | `id`→`UuidCell`, `tenant_id`→`UuidCell`, `name`→`TextCell`, `created_at`→`DateTimeCell` |
| `AllColumnTypesRow` | `AllColumnTypesTable` | `id`→`UuidCell`, `name`→`TextCell`, `age`→`IntCell`, `quantity`→`LongCell`, `price`→`DoubleCell`, `is_active`→`BoolCell`, `birth_date`→`DateCell`, `start_time`→`TimeCell`, `created_at`→`DateTimeCell`, *(empty-name column)*→`EmptyCell` |
| `UserRow` | `UsersTable` | `id`→`UuidCell`, `tenant_id`→`UuidCell`, `name`→`TextCell`, `birth_date`→`DateCell`, `is_active`→`BoolCell`, `created_at`→`DateTimeCell` |
| `EmptyCellsUserRow` | `UsersTable` | all six columns → `EmptyCell` |
| `OrderRow` | `OrdersTable` | `id`→`UuidCell`, `tenant_id`→`UuidCell`, `user_id`→`UuidCell`, `price`→`DoubleCell`, `created_at`→`DateTimeCell` |
| `ProductRow` | `ProductsTable` | `id`→`UuidCell`, `name`→`TextCell`, `description`→`TextCell`, `price`→`DoubleCell` |
| `OrderItemRow` | `OrderItemsTable` | `id`→`UuidCell`, `tenant_id`→`UuidCell`, `order_id`→`UuidCell`, `product_id`→`UuidCell`, `quantity`→`LongCell` |
| `EmployeeRow` | `EmployeesTable` | `id`→`UuidCell`, `name`→`TextCell`, `manager_id`→`UuidCell`, `start_time`→`TimeCell` |

A row's `Cells` is keyed by structural column hash (`ColumnHash`), not by reference, so `row.Cells[new IdColumn()]` resolves with a freshly constructed column instance.

## Cells

`namespace Pure.RelationalSchema.Storage.Samples.Cells`

`ICell.Value` is an `IString`; typed cells wrap the matching `Pure.Primitives` type (`new String(new True())`, `new String(new Guid(…))`, `new String(new Date(…))`, …) rather than a hand-formatted literal.

| Class | `Value.TextValue` |
|---|---|
| `EmptyCell` | *(empty string)* |
| `TextCell` | `sample_text` |
| `UuidCell` | `1f0c4b2a-9d3e-4c7b-8a15-6e2d0f9b7c43` |
| `IntCell` | `42` |
| `LongCell` | `9223372036854775807` |
| `DoubleCell` | `19.99` |
| `BoolCell` | `True` |
| `DateCell` | `1/15/1990` |
| `TimeCell` | `9:30:0.0.0` |
| `DateTimeCell` | `1/15/2024 9:30:0.0.0` |
| `WhitespaceCell` | a single space |
| `UnicodeCell` | `Ünïcödé — 日本語` |

## Dependencies

- [`Pure.RelationalSchema.Samples` 0.1.0-preview.0.1.0](https://github.com/kudima03/Pure.RelationalSchema.Samples/tree/0.1.0-preview.0.1.0) — the schema fixtures every `TableSchema`/`Schema` is built from
- [`Pure.RelationalSchema.Storage.Abstractions` 0.1.0-preview.4.1.0](https://github.com/kudima03/Pure.RelationalSchema.Storage.Abstractions/tree/0.1.0-preview.4.1.0) — the interfaces every sample implements (`ICell`, `IRow`, `IStoredTableDataSet`, `IStoredSchemaDataSet`)
- [`Pure.Collections.Generic` 0.1.0-preview.3.0.0](https://github.com/kudima03/Pure.Collections.Generic/tree/0.1.0-preview.3.0.0) — the hash-keyed dictionaries backing `IRow.Cells` and `IStoredSchemaDataSet`
- [`Pure.RelationalSchema.HashCodes` 3.3.0](https://github.com/kudima03/Pure.RelationalSchema.HashCodes/tree/3.3.0) — `ColumnHash`/`TableHash` used as the dictionary key comparers
- [`Pure.Primitives` 3.6.5](https://github.com/kudima03/Pure.Primitives/tree/3.6.5) — `String`, `EmptyString` and the typed primitives (`True`, `Guid`, `Date`, `Time`, `Int`, `Long`, `Double`, …) cell values are built from

No storage *implementation* package (`Pure.RelationalSchema.Storage`) is referenced, so implementations themselves can consume these samples without a dependency cycle.

## Target Frameworks

- .NET 8
- .NET 9
- .NET 10

`Pure.Collections.Generic` targets net8.0+ only, and it is required for the hash-keyed dictionaries backing `IRow.Cells` and `IStoredSchemaDataSet` — every Pure type throws `NotSupportedException` from `GetHashCode()`, so plain dictionary keys are not an option. This package therefore does not offer net7.0, unlike `Pure.RelationalSchema.Samples`.

## Installation

```bash
dotnet add package Pure.RelationalSchema.Storage.Samples
```

## Usage

```csharp
using Pure.RelationalSchema.Storage.Abstractions;
using Pure.RelationalSchema.Storage.Samples.SchemaDataSets;

IStoredSchemaDataSet dataSet = new FullSchemaDataSet();

// dataSet.Schema.Name.TextValue == "full_schema"
// dataSet.Count                 == 11
```

A table data set is both an `IQueryable<IRow>` and an `IAsyncEnumerable<IRow>`:

```csharp
using Pure.RelationalSchema.Storage.Abstractions;
using Pure.RelationalSchema.Storage.Samples.TableDataSets;

IStoredTableDataSet dataSet = new UsersTableDataSet();

foreach (IRow row in dataSet)
{
    // synchronous enumeration
}

await foreach (IRow row in dataSet)
{
    // asynchronous enumeration
}
```

Samples are deterministic, so they compare equal across instances by structural hash — `TableDataSets` records hold a private `IQueryable<IRow>` field, so two instances are never record-equal and must be compared this way:

```csharp
using Pure.RelationalSchema.Storage.HashCodes;
using Pure.RelationalSchema.Storage.Samples.TableDataSets;

bool same = new StoredTableDataSetHash(new UsersTableDataSet()).SequenceEqual(
    new StoredTableDataSetHash(new UsersTableDataSet())
);
// true
```

A row's `Cells` is keyed by structural column hash, so a freshly constructed column instance resolves it:

```csharp
using Pure.RelationalSchema.Samples.Columns;
using Pure.RelationalSchema.Storage.Samples.Rows;

IRow row = new UserRow();

IString idValue = row.Cells[new IdColumn()].Value;
// resolves even though `new IdColumn()` is not the same instance the row was built with
```
