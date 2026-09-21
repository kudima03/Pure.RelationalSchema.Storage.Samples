namespace Pure.RelationalSchema.Storage.Samples.Records;

// Ground-truth mirror of a OrderItemsTable row, as plain .NET values. A consumer
// computes an expected result from these instead of re-deriving it from the
// code under test; the cell text of the matching IRow sample is exactly what
// InvariantCellText renders for each value here.
public sealed record OrderItemRecord(
    Guid ItemId,
    Guid ItemTenantId,
    Guid ItemOrderId,
    Guid ItemProductId,
    double ItemQty
);
