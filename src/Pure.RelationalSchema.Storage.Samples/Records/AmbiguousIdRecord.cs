namespace Pure.RelationalSchema.Storage.Samples.Records;

// Ground-truth mirror of a TableWithIndexes row, as plain .NET values. A consumer
// computes an expected result from these instead of re-deriving it from the
// code under test; the cell text of the matching IRow sample is exactly what
// InvariantCellText renders for each value here.
public sealed record AmbiguousIdRecord(
    Guid Id,
    Guid TenantId,
    string Name,
    DateTime CreatedAt
);
