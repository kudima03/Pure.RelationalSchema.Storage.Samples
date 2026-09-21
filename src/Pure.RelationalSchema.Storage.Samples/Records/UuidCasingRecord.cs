namespace Pure.RelationalSchema.Storage.Samples.Records;

// Ground-truth mirror of a UuidCasingTableDataSet row. Unlike every other
// mirror it carries the stored text as well as the value, because the casing of
// IdText is exactly what the sample exists to vary - Id is the same value in
// both rows.
public sealed record UuidCasingRecord(
    Guid Id,
    string IdText,
    string Name,
    DateTime CreatedAt
);
