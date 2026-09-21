# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.1.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [Unreleased]

### Added

- `InvariantCellText`, a public `IString` that renders a value as the canonical,
  culture-independent text a stored cell holds — `True`/`False`, invariant
  round-trippable doubles, `yyyy-MM-dd`, `yyyy-MM-ddTHH:mm:ss`, `HH:mm:ss`,
  lowercase uuids and the empty string for NULL. It accepts either a
  `Pure.Primitives` value or a plain .NET one, so a consumer can build an
  expected value exactly the way the stored one was built.
- `InvariantCell`, the `ICell` over `InvariantCellText`, with the same overloads.
- A query-grade row family with a distinct value per row: six users, six orders,
  four products, four order items, four employees, four logins and four
  statuses, with deterministic ids `new Guid(seed, 0, 0, new byte[8])`.
- `LoginsTableDataSet` and `StatusesTableDataSet` over the new `logins` and
  `statuses` relations, and `AuditSchemaDataSet` and `RefsSchemaDataSet` over the
  new `audit` and `refs` schemas — two foreign keys crossing a schema boundary in
  opposite directions, on a uuid key and on a string key.
- `EmptyCellsUsersTableDataSet`, a home for the all-NULL `EmptyCellsUserRow`.
- `SchemaDataSetWithAmbiguousIds`, with `AmbiguousIdTableDataSet` and
  `AmbiguousIdLookupTableDataSet` — two joined relations both carrying columns
  named `id` and `name`, for entity-qualification tests.
- `UuidCasingSchemaDataSet` and `UuidCasingTableDataSet`, storing one logical
  uuid twice, once lowercase-hex and once uppercase-hex.
- `StoredTableDataSet(ITable, IEnumerable<IRow>)` and
  `StoredSchemaDataSet(ISchema, IEnumerable<IStoredTableDataSet>)`, the two
  samples that are not named singletons, for shapes no singleton can produce —
  a deliberately malformed row, or two data sets sharing one schema name.
- `Pure.RelationalSchema.Storage.Samples.Records`: plain .NET ground-truth
  mirrors (`UserRecord`/`UserRecords`, `OrderRecord`/`OrderRecords`, …) of every
  query-grade relation, so a consumer can compute an expected result without
  re-deriving it from the code under test.

### Changed

- **Breaking.** `DateCell`, `TimeCell` and `DateTimeCell` now render invariant
  text: `1990-01-15`, `09:30:00` and `2024-01-15T09:30:00` instead of
  `1/15/1990`, `9:30:0.0.0` and `1/15/2024 9:30:0.0.0`. The old text was
  culture-dependent and, for time and datetime, unparsable by any `TryParse`
  reader. `DoubleCell`, `IntCell`, `LongCell`, `BoolCell` and `UuidCell` now
  render through `InvariantCellText` as well; their text is unchanged.
- **Breaking.** `UserRow`, `OrderRow`, `ProductRow`, `OrderItemRow`,
  `EmployeeRow` and `EmptyCellsUserRow` are retargeted to the renamed, prefixed
  columns of `Pure.RelationalSchema.Samples` 0.1.0-preview.1.0.0 (`user_id`,
  `order_total`, `item_qty`, `employee_manager_id`, …) and now hold the first
  row of their relation's values rather than one value per shape.
- **Breaking.** `UsersTableDataSet` holds the six user rows instead of
  `UserRow` and `EmptyCellsUserRow`; `OrdersTableDataSet`,
  `ProductsTableDataSet`, `OrderItemsTableDataSet` and `EmployeesTableDataSet`
  hold their full row sets.
- **Breaking.** `SchemaDataSetWithForeignKeys` holds five tables (was two) and
  `FullSchemaDataSet` thirteen (was eleven).
- Bumped `Pure.RelationalSchema.Samples` to 0.1.0-preview.1.0.0.

No public type was removed or renamed, so package validation against
0.1.0-preview.0.1.0 stays green. Every `CellHash`, `RowHash`,
`StoredTableDataSetHash` and `StoredSchemaDataSetHash` above changes; consumers
pinning hashes must retake them.

## [0.1.0-preview.0.1.0] - 2026-09-21

### Added

- Cell samples for every primitive shape: `EmptyCell`, `TextCell`, `UuidCell`,
  `IntCell`, `LongCell`, `DoubleCell`, `BoolCell`, `DateCell`, `TimeCell`,
  `DateTimeCell`, `WhitespaceCell`, `UnicodeCell`.
- Row samples shaped for each table from `Pure.RelationalSchema.Samples`.
- Table data set samples pairing a table schema with zero or more rows,
  including empty variants.
- Schema data set samples graded from `EmptySchemaDataSet` to
  `FullSchemaDataSet`.

[0.1.0-preview.0.1.0]: https://github.com/kudima03/Pure.RelationalSchema.Storage.Samples/releases/tag/0.1.0-preview.0.1.0
