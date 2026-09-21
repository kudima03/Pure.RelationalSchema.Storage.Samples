# Pure.RelationalSchema.Storage.Samples

Named, predefined stored data sets — cells, rows, table data sets and schema data sets — for the **Pure** ecosystem.

[![.NET build & test](https://github.com/kudima03/Pure.RelationalSchema.Storage.Samples/actions/workflows/build-and-test.yml/badge.svg?branch=main)](https://github.com/kudima03/Pure.RelationalSchema.Storage.Samples/actions/workflows/build-and-test.yml)
[![Build and Deploy](https://github.com/kudima03/Pure.RelationalSchema.Storage.Samples/actions/workflows/publish-nuget.yml/badge.svg?branch=main)](https://github.com/kudima03/Pure.RelationalSchema.Storage.Samples/actions/workflows/publish-nuget.yml)
[![NuGet](https://img.shields.io/nuget/v/Pure.RelationalSchema.Storage.Samples)](https://www.nuget.org/packages/Pure.RelationalSchema.Storage.Samples)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](LICENSE)

## Overview

`Pure.RelationalSchema.Storage.Samples` provides a fixed, deterministic catalogue of stored data sets implemented as sealed records over the interfaces from `Pure.RelationalSchema.Storage.Abstractions`, layered on the schema fixtures from `Pure.RelationalSchema.Samples`. Every sample has stable, hard-coded contents — nothing is random, nothing is generated, nothing reads the clock or the current culture.

The catalogue is two families.

**The shape family** exercises *structure*: an empty table, a single-column table, indexes, every column type at once. Its relations keep generic names (`id`, `name`, `created_at`, `tenant_id`) and its cells carry one value per shape. Use it to assert that something handles a shape, not a value.

**The query family** exercises *execution*: six users, six orders, four products, four order items, four logins and four statuses, spread over three schemas, with repeated values, NULLs, numeric extremes and calendar edges. Its column names are globally unique and every cell renders as canonical, culture-independent text, so a `TryParse`-based engine reads back exactly what the fixture stored. Use it to assert that a query returns the right rows.

`IStoredTableDataSet` is an `IQueryable<IRow>`, and an in-memory `AsQueryable()` requires dynamic code, so `IsAotCompatible` is deliberately not set on this package (unlike `Pure.RelationalSchema.Samples`, which is AOT-compatible).

### Grading

| Shape | Sample |
|---|---|
| Nothing at all | `EmptySchemaDataSet` |
| One table, one row | `SingleTableSchemaDataSet` |
| Several tables, no rows | `SchemaDataSetWithoutRows` |
| Unique, non-unique and composite indexes | `SchemaDataSetWithIndexes` |
| Same-named columns across joined tables | `SchemaDataSetWithAmbiguousIds` |
| One logical uuid stored in two casings | `UuidCasingSchemaDataSet` |
| Every column type in one table | `SchemaDataSetWithAllColumnTypes` |
| The query-grade domain, five relations | `SchemaDataSetWithForeignKeys` |
| A second domain, referencing outwards | `AuditSchemaDataSet` |
| A third domain, referenced only | `RefsSchemaDataSet` |
| A multi-column relation | `SchemaDataSetWithCompositeForeignKey` |
| A table referencing itself | `SchemaDataSetWithSelfReferencingTable` |
| Everything at once | `FullSchemaDataSet` |
| Any schema, any table data sets | `StoredSchemaDataSet` |

## Invariant cell text

`ICell.Value` is an `IString`, so every stored value is text. That text is produced by one public type, `InvariantCellText`, to a contract a `TryParse`-based reader can consume under any culture:

| .NET value | Text |
|---|---|
| `bool` | `True` / `False` |
| `double` | `InvariantCulture`, round-trippable |
| `DateOnly` | `yyyy-MM-dd` |
| `DateTime` | `yyyy-MM-ddTHH:mm:ss` |
| `TimeOnly` | `HH:mm:ss` |
| `Guid` | lowercase `D` format |
| NULL | the empty string |

`InvariantCellText` takes either a `Pure.Primitives` value (`IBool`, `IDate`, `IDateTime`, `ITime`, `IGuid`, `INumber<double>`, `INumber<int>`, `INumber<long>`, `IString`) or a plain .NET one (`bool`, `double`, `double?`, `Guid`, `Guid?`, `DateOnly`, `TimeOnly`, `DateTime`, `string`). The samples themselves always wrap the matching Pure type; the plain overloads exist so a consumer holding the [ground-truth mirrors](#ground-truth-mirrors) can build an expected value exactly the way the stored one was built.

`InvariantCell` is the `ICell` over it, with the same set of overloads. The named cell samples (`TextCell`, `DateCell`, …) cover one value per shape; the query-family rows need a distinct value per row and build their cells through `InvariantCell` instead.

## The query family

Three schemas, seven relations, joined so that every relation is reachable from every other:

```
        audit.logins ──login_user_id──┐
                                      ▼
  employees ──employee_user_id──▶  users  ◀──order_user_id── orders ──order_status──▶ refs.statuses
      │                                                        ▲
      └─employee_manager_id─┘ (self)                            │ (order_id, order_tenant_id)
                                                          order_items ──item_product_id──▶ products
```

`#n` below is the deterministic uuid `new Guid(n, 0, 0, new byte[8])` — `#1` is `00000001-0000-0000-0000-000000000000`.

### users — `UsersTableDataSet`, in `SchemaDataSetWithForeignKeys`

| Row | user_id | user_tenant_id | user_name | signup_date | user_active | last_login | user_age | shift_start | user_score | user_precision_value | user_edge_date | user_edge_datetime | user_edge_time |
|---|---|---|---|---|---|---|---|---|---|---|---|---|---|
| `UserRow` | `#1` | `#901` | `Ann` | `2020-01-15` | `True` | `2024-06-01T08:30:00` | `30` | `09:00:00` | `30` | `1.7976931348623157E+308` | `2024-02-29` | `2024-02-29T00:00:00` | `00:00:00` |
| `SecondUserRow` | `#2` | `#901` | `Bob` | `2021-03-20` | `False` | `2024-06-02T09:15:00` | `25` | `10:00:00` | *(NULL)* | `-1.7976931348623157E+308` | `2024-12-31` | `2024-12-31T23:59:59` | `23:59:59` |
| `ThirdUserRow` | `#3` | `#901` | `Cara` | `2019-07-10` | `True` | `2024-05-30T14:00:00` | `30` | `09:00:00` | `30` | `5E-324` | `2024-03-10` | `2024-03-10T02:30:00` | `02:30:00` |
| `FourthUserRow` | `#4` | `#902` | `Dan` | `2022-11-05` | `True` | `2024-06-03T18:45:00` | `42` | `11:30:00` | *(NULL)* | `-5E-324` | `2024-11-03` | `2024-11-03T01:30:00` | `01:30:00` |
| `FifthUserRow` | `#5` | `#902` | `Eve` | `2023-02-28` | `False` | `2024-06-04T07:05:00` | `25` | `08:00:00` | `10` | `1E+308` | `0001-01-01` | `0001-01-01T00:00:00` | `00:00:00` |
| `SixthUserRow` | `#6` | `#902` | `Fay` | `2020-01-15` | `True` | `2024-06-01T08:30:00` | `28` | `09:00:00` | `28` | `123456789.123456` | `9999-12-31` | `9999-12-31T23:59:59` | `23:59:59` |


Three properties are load-bearing:

- `user_age` and `user_score` repeat (30 twice, 25 twice), so GROUP BY produces real groups rather than one group per user;
- Ann, Cara and Fay have `user_score == user_age`, Eve has a real mismatch and Bob and Dan are NULL, so a failed match is attributable to a mismatch or to NULL, never to both;
- Fay repeats Ann's `signup_date`, `last_login` and `shift_start`, so each of those columns is discriminating for DISTINCT over its own type.

`user_precision_value` carries the numeric extremes and the `user_edge_*` triple the calendar extremes, so a round trip through cell text is covered at the boundaries as well as in the middle. `EmptyCellsUsersTableDataSet` holds the all-NULL users row, which the six-row mix deliberately cannot express.

### orders — `OrdersTableDataSet`, in `SchemaDataSetWithForeignKeys`

| Row | order_id | order_tenant_id | order_user_id | order_total | placed_at | order_status | placed_on |
|---|---|---|---|---|---|---|---|
| `OrderRow` | `#101` | `#901` | `#1` | `100.5` | `2024-06-01T10:00:00` | `shipped` | `2024-06-01` |
| `SecondOrderRow` | `#102` | `#901` | `#1` | `50` | `2024-06-02T11:00:00` | `pending` | `2024-06-02` |
| `ThirdOrderRow` | `#103` | `#901` | `#2` | `200` | `2024-06-03T12:00:00` | `shipped` | `2024-06-03` |
| `FourthOrderRow` | `#104` | `#902` | `#3` | `75.25` | `2024-06-04T13:00:00` | `cancelled` | `2024-06-04` |
| `FifthOrderRow` | `#105` | `#902` | `#3` | `300` | `2024-06-05T14:00:00` | `shipped` | `2024-06-05` |
| `SixthOrderRow` | `#106` | `#902` | `#4` | `100.5` | `2024-06-06T15:00:00` | `pending` | `2024-06-06` |


Four of the six users have orders (user 1 twice, user 2 once, user 3 twice, user 4 once); users 5 and 6 have none, so an outer join has unmatched rows on the users side. `order_total` repeats for DISTINCT, and the statuses are lowercase ASCII so ordinal ordering is collation-independent.

### products — `ProductsTableDataSet`, in `SchemaDataSetWithForeignKeys`

| Row | product_id | product_name | product_description | product_price | product_in_stock |
|---|---|---|---|---|---|
| `ProductRow` | `#201` | `Widget` | `Basic widget` | `9.99` | `True` |
| `SecondProductRow` | `#202` | `Gadget` | `Premium gadget` | `19.99` | `False` |
| `ThirdProductRow` | `#203` | `Gizmo` | `Compact gizmo` | `4.5` | `True` |
| `FourthProductRow` | `#204` | `Deluxe` | `Deluxe bundle` | `250` | `True` |


### order_items — `OrderItemsTableDataSet`, in `SchemaDataSetWithForeignKeys` and `SchemaDataSetWithCompositeForeignKey`

| Row | item_id | item_tenant_id | item_order_id | item_product_id | item_qty |
|---|---|---|---|---|---|
| `OrderItemRow` | `#301` | `#901` | `#101` | `#201` | `2` |
| `SecondOrderItemRow` | `#302` | `#901` | `#101` | `#202` | `1` |
| `ThirdOrderItemRow` | `#303` | `#901` | `#103` | `#203` | `5` |
| `FourthOrderItemRow` | `#304` | `#902` | `#105` | `#201` | `3` |


Deliberately neither 1:1 nor uniform — orders 101, 101, 103 and 105, products 201, 202, 203 and 201 — so join cardinality is testable. `item_tenant_id` matches the referenced order's `order_tenant_id`, which is what makes the composite foreign key hold.

### employees — `EmployeesTableDataSet`, in `SchemaDataSetWithForeignKeys` and `SchemaDataSetWithSelfReferencingTable`

| Row | employee_id | employee_name | employee_manager_id | employee_shift_start | employee_user_id |
|---|---|---|---|---|---|
| `EmployeeRow` | `#701` | `Grace` | *(NULL)* | `09:00:00` | `#1` |
| `SecondEmployeeRow` | `#702` | `Hank` | `#701` | `10:00:00` | `#2` |
| `ThirdEmployeeRow` | `#703` | `Iris` | `#701` | `11:30:00` | `#3` |
| `FourthEmployeeRow` | `#704` | `Jack` | `#702` | `08:00:00` | `#4` |


Grace has no manager, so the self-join has an unmatched root row.

### logins — `LoginsTableDataSet`, in `AuditSchemaDataSet`

| Row | login_id | login_user_id | login_at |
|---|---|---|---|
| `LoginRow` | `#401` | `#1` | `2024-06-01T07:00:00` |
| `SecondLoginRow` | `#402` | `#1` | `2024-06-02T07:30:00` |
| `ThirdLoginRow` | `#403` | `#2` | `2024-06-03T08:00:00` |
| `FourthLoginRow` | `#404` | `#5` | `2024-06-04T06:45:00` |


The `audit` schema. `login_user_id` points at `users.user_id` across a schema boundary on a **uuid** key; users 3, 4 and 6 have no login. `login_at` gives a cross-schema query something to range over besides an equality on a key.

### statuses — `StatusesTableDataSet`, in `RefsSchemaDataSet`

| Row | status_code | status_label | status_is_final |
|---|---|---|---|
| `StatusRow` | `shipped` | `Shipped` | `True` |
| `SecondStatusRow` | `pending` | `Pending` | `False` |
| `ThirdStatusRow` | `cancelled` | `Cancelled` | `True` |
| `FourthStatusRow` | `refunded` | `Refunded` | `True` |


The `refs` schema. `orders.order_status` points at `status_code` across a schema boundary on a **string** key, in the opposite direction to `logins`. `refunded` is referenced by no order, so the join has an unmatched row on the *referenced* side.

## Same-named columns

`SchemaDataSetWithAmbiguousIds` is the counterpart of the query family: both of its relations carry columns literally named `id` and `name`, joined on `table_with_indexes.tenant_id = table_with_single_index.id`, so a bare field reference across the two only resolves once it is entity-qualified.

### table_with_indexes — `AmbiguousIdTableDataSet`

| Row | id | tenant_id | name | created_at |
|---|---|---|---|---|
| `FirstAmbiguousIdRow` | `#1` | `#501` | `first_entry` | `2024-01-01T00:00:00` |
| `SecondAmbiguousIdRow` | `#2` | `#501` | `second_entry` | `2024-01-02T01:00:00` |
| `ThirdAmbiguousIdRow` | `#3` | `#502` | `third_entry` | `2024-01-03T02:00:00` |
| `FourthAmbiguousIdRow` | `#4` | `#502` | `fourth_entry` | `2024-01-04T03:00:00` |
| `FifthAmbiguousIdRow` | `#5` | `#502` | `fifth_entry` | `2024-01-05T04:00:00` |
| `SixthAmbiguousIdRow` | `#6` | `#503` | `sixth_entry` | `2024-01-06T05:00:00` |


### table_with_single_index — `AmbiguousIdLookupTableDataSet`

| Row | id | name |
|---|---|---|
| `FirstAmbiguousIdLookupRow` | `#501` | `Welder` |
| `SecondAmbiguousIdLookupRow` | `#502` | `Fitter` |
| `ThirdAmbiguousIdLookupRow` | `#503` | `Painter` |
| `FourthAmbiguousIdLookupRow` | `#504` | `Rigger` |


`Rigger` is referenced by no row on the referencing side, so an outer join has something to pad.

## Uuid casing

`UuidCasingTableDataSet`, held by `UuidCasingSchemaDataSet`, stores one logical uuid twice:

| Row | id | name | created_at |
|---|---|---|---|
| `LowercaseUuidRow` | `0f9e8d7c-6b5a-4938-8271-605f4e3d2c1b` | `lowercase` | `2024-01-01T00:00:00` |
| `UppercaseUuidRow` | `0F9E8D7C-6B5A-4938-8271-605F4E3D2C1B` | `uppercase` | `2024-01-02T00:00:00` |

Uuid text parses case-insensitively, so both rows must read back as the same value.

## Ground-truth mirrors

`namespace Pure.RelationalSchema.Storage.Samples.Records`

Every query-family relation is mirrored by a plain .NET record, so a consumer can compute an expected result from the values without re-deriving it from the code under test. Each mirror's field order matches its relation's column order, and rendering a field through `InvariantCellText` reproduces the matching cell's text exactly — asserted by the package's own tests.

| Shape | Catalogue | Mirrors |
|---|---|---|
| `UserRecord` | `UserRecords` | `UsersTableDataSet` |
| `OrderRecord` | `OrderRecords` | `OrdersTableDataSet` |
| `ProductRecord` | `ProductRecords` | `ProductsTableDataSet` |
| `OrderItemRecord` | `OrderItemRecords` | `OrderItemsTableDataSet` |
| `EmployeeRecord` | `EmployeeRecords` | `EmployeesTableDataSet` |
| `LoginRecord` | `LoginRecords` | `LoginsTableDataSet` |
| `StatusRecord` | `StatusRecords` | `StatusesTableDataSet` |
| `AmbiguousIdRecord` | `AmbiguousIdRecords` | `AmbiguousIdTableDataSet` |
| `AmbiguousIdLookupRecord` | `AmbiguousIdLookupRecords` | `AmbiguousIdLookupTableDataSet` |
| `UuidCasingRecord` | `UuidCasingRecords` | `UuidCasingTableDataSet` |

A catalogue is an `IEnumerable<T>` with a parameterless constructor, in the same order as its data set's rows. `UuidCasingRecord` carries `IdText` alongside `Id`, because the casing of the stored text is what that sample exists to vary.

```csharp
using Pure.RelationalSchema.Storage.Samples.Cells;
using Pure.RelationalSchema.Storage.Samples.Records;

double expectedTotal = new OrderRecords().Sum(order => order.OrderTotal);

string expectedText = new InvariantCellText(new UserRecords().First().SignupDate)
    .TextValue;
// "2020-01-15"
```

## Schema Data Sets

`namespace Pure.RelationalSchema.Storage.Samples.SchemaDataSets`

| Class | `Schema` | Entries |
|---|---|---|
| `EmptySchemaDataSet` | `EmptyRelationalSchema` | 0 |
| `SingleTableSchemaDataSet` | `SingleTableRelationalSchema` | 1 |
| `SchemaDataSetWithoutRows` | `RelationalSchemaWithoutForeignKeys` | 3 |
| `UuidCasingSchemaDataSet` | `RelationalSchemaWithoutForeignKeys` | 1 |
| `SchemaDataSetWithIndexes` | `RelationalSchemaWithIndexes` | 2 |
| `SchemaDataSetWithAmbiguousIds` | `RelationalSchemaWithIndexes` | 2 |
| `SchemaDataSetWithAllColumnTypes` | `RelationalSchemaWithAllColumnTypes` | 1 |
| `SchemaDataSetWithForeignKeys` | `RelationalSchemaWithForeignKeys` | 5 |
| `AuditSchemaDataSet` | `AuditRelationalSchema` | 1 |
| `RefsSchemaDataSet` | `RefsRelationalSchema` | 1 |
| `SchemaDataSetWithCompositeForeignKey` | `RelationalSchemaWithCompositeForeignKey` | 2 |
| `SchemaDataSetWithSelfReferencingTable` | `RelationalSchemaWithSelfReferencingTable` | 1 |
| `FullSchemaDataSet` | `FullRelationalSchema` | 13 |
| `StoredSchemaDataSet` | *(given)* | *(given)* |

`SchemaDataSetWithoutRows` and `UuidCasingSchemaDataSet` share a schema and hold different subsets of its tables, as do `SchemaDataSetWithIndexes` and `SchemaDataSetWithAmbiguousIds` — a schema data set is not required to hold every table its schema declares.

`StoredSchemaDataSet` is the one schema data set that is not a named singleton: it takes `(ISchema, IEnumerable<IStoredTableDataSet>)` and keys the data sets by the table schema each one carries. It is what a consumer needs for shapes no singleton can produce — two data sets sharing one schema name, for instance.

## Table Data Sets

`namespace Pure.RelationalSchema.Storage.Samples.TableDataSets`

| Class | `TableSchema` | Rows |
|---|---|---|
| `EmptyTableDataSet` | `EmptyTable` | *(none)* |
| `SingleEmptyRowTableDataSet` | `EmptyTable` | 1 |
| `EmptySingleColumnTableDataSet` | `SingleColumnTable` | *(none)* |
| `SingleRowTableDataSet` | `SingleColumnTable` | 1 |
| `EmptyTableWithoutIndexesDataSet` | `TableWithoutIndexes` | *(none)* |
| `TableWithoutIndexesDataSet` | `TableWithoutIndexes` | 1 |
| `UuidCasingTableDataSet` | `TableWithoutIndexes` | 2 |
| `TableWithSingleIndexDataSet` | `TableWithSingleIndex` | 1 |
| `AmbiguousIdLookupTableDataSet` | `TableWithSingleIndex` | 4 |
| `TableWithIndexesDataSet` | `TableWithIndexes` | 1 |
| `AmbiguousIdTableDataSet` | `TableWithIndexes` | 6 |
| `AllColumnTypesTableDataSet` | `AllColumnTypesTable` | 1 |
| `EmptyUsersTableDataSet` | `UsersTable` | *(none)* |
| `EmptyCellsUsersTableDataSet` | `UsersTable` | 1 |
| `UsersTableDataSet` | `UsersTable` | 6 |
| `OrdersTableDataSet` | `OrdersTable` | 6 |
| `ProductsTableDataSet` | `ProductsTable` | 4 |
| `OrderItemsTableDataSet` | `OrderItemsTable` | 4 |
| `EmployeesTableDataSet` | `EmployeesTable` | 4 |
| `LoginsTableDataSet` | `LoginsTable` | 4 |
| `StatusesTableDataSet` | `StatusesTable` | 4 |
| `StoredTableDataSet` | *(given)* | *(given)* |

`StoredTableDataSet` takes `(ITable, IEnumerable<IRow>)` and imposes no relationship between the two, so a consumer can build a deliberately malformed row — a uuid column holding `not-a-valid-uuid`, say — without depending on a storage implementation package.

## Rows

`namespace Pure.RelationalSchema.Storage.Samples.Rows`

Each row's keys are exactly the columns of the table it is shaped for, keyed by structural column hash (`ColumnHash`) rather than by reference, so `row.Cells[new UserIdColumn()]` resolves with a freshly constructed column instance.

The shape family:

| Class | Shaped for | Cells |
|---|---|---|
| `EmptyRow` | `EmptyTable` | *(none)* |
| `SingleCellRow` | `SingleColumnTable` | `id`→`UuidCell` |
| `UnicodeTextRow` | `TableWithoutIndexes` | `id`→`UuidCell`, `name`→`UnicodeCell`, `created_at`→`DateTimeCell` |
| `TableWithSingleIndexRow` | `TableWithSingleIndex` | `id`→`UuidCell`, `name`→`TextCell` |
| `TableWithIndexesRow` | `TableWithIndexes` | `id`→`UuidCell`, `tenant_id`→`UuidCell`, `name`→`TextCell`, `created_at`→`DateTimeCell` |
| `AllColumnTypesRow` | `AllColumnTypesTable` | `id`→`UuidCell`, `name`→`TextCell`, `age`→`IntCell`, `quantity`→`LongCell`, `price`→`DoubleCell`, `is_active`→`BoolCell`, `birth_date`→`DateCell`, `start_time`→`TimeCell`, `created_at`→`DateTimeCell`, *(empty-name column)*→`EmptyCell` |
| `EmptyCellsUserRow` | `UsersTable` | all thirteen columns → `EmptyCell` |

The query family, one record per row, values as tabulated above:

| Table | Rows |
|---|---|
| `UsersTable` | `UserRow`, `SecondUserRow`, `ThirdUserRow`, `FourthUserRow`, `FifthUserRow`, `SixthUserRow` |
| `OrdersTable` | `OrderRow`, `SecondOrderRow`, `ThirdOrderRow`, `FourthOrderRow`, `FifthOrderRow`, `SixthOrderRow` |
| `ProductsTable` | `ProductRow`, `SecondProductRow`, `ThirdProductRow`, `FourthProductRow` |
| `OrderItemsTable` | `OrderItemRow`, `SecondOrderItemRow`, `ThirdOrderItemRow`, `FourthOrderItemRow` |
| `EmployeesTable` | `EmployeeRow`, `SecondEmployeeRow`, `ThirdEmployeeRow`, `FourthEmployeeRow` |
| `LoginsTable` | `LoginRow`, `SecondLoginRow`, `ThirdLoginRow`, `FourthLoginRow` |
| `StatusesTable` | `StatusRow`, `SecondStatusRow`, `ThirdStatusRow`, `FourthStatusRow` |
| `TableWithIndexes` | `FirstAmbiguousIdRow` … `SixthAmbiguousIdRow` |
| `TableWithSingleIndex` | `FirstAmbiguousIdLookupRow` … `FourthAmbiguousIdLookupRow` |
| `TableWithoutIndexes` | `LowercaseUuidRow`, `UppercaseUuidRow` |

The unprefixed name in each group — `UserRow`, `OrderRow`, `ProductRow`, `OrderItemRow`, `EmployeeRow`, `LoginRow`, `StatusRow` — is the first row of its relation.

## Cells

`namespace Pure.RelationalSchema.Storage.Samples.Cells`

The named cells carry one value per shape and render through `InvariantCellText`:

| Class | `Value.TextValue` |
|---|---|
| `EmptyCell` | *(empty string)* |
| `TextCell` | `sample_text` |
| `UuidCell` | `1f0c4b2a-9d3e-4c7b-8a15-6e2d0f9b7c43` |
| `IntCell` | `42` |
| `LongCell` | `9223372036854775807` |
| `DoubleCell` | `19.99` |
| `BoolCell` | `True` |
| `DateCell` | `1990-01-15` |
| `TimeCell` | `09:30:00` |
| `DateTimeCell` | `2024-01-15T09:30:00` |
| `WhitespaceCell` | a single space |
| `UnicodeCell` | `Ünïcödé — 日本語` |
| `InvariantCell` | *(given)* |
| `InvariantCellText` | *(given, an `IString` rather than an `ICell`)* |

## Dependencies

- [`Pure.RelationalSchema.Samples` 0.1.0-preview.1.0.0](https://github.com/kudima03/Pure.RelationalSchema.Samples/tree/0.1.0-preview.1.0.0) — the schema fixtures every `TableSchema`/`Schema` is built from
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
// dataSet.Count                 == 13
```

A cross-schema query runs against several data sets at once:

```csharp
using Pure.RelationalSchema.Storage.Abstractions;
using Pure.RelationalSchema.Storage.Samples.SchemaDataSets;

IEnumerable<IStoredSchemaDataSet> database =
[
    new SchemaDataSetWithForeignKeys(),
    new AuditSchemaDataSet(),
    new RefsSchemaDataSet(),
];
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

IString name = row.Cells[new UserNameColumn()].Value;
// "Ann" — resolves even though `new UserNameColumn()` is not the instance the row was built with
```

Any table schema can be paired with any rows:

```csharp
using Pure.RelationalSchema.Samples.Tables;
using Pure.RelationalSchema.Storage.Abstractions;
using Pure.RelationalSchema.Storage.Samples.Rows;
using Pure.RelationalSchema.Storage.Samples.TableDataSets;

IStoredTableDataSet malformed = new StoredTableDataSet(
    new UsersTable(),
    [new EmptyRow()]
);
```
