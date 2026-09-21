using System.Collections;

namespace Pure.RelationalSchema.Storage.Samples.Records;

// The four statuses of StatusesTableDataSet, as plain .NET values.
public sealed record StatusRecords : IEnumerable<StatusRecord>
{
    private static IEnumerable<StatusRecord> Records =>
        [
            new StatusRecord("shipped", "Shipped", true),
            new StatusRecord("pending", "Pending", false),
            new StatusRecord("cancelled", "Cancelled", true),
            new StatusRecord("refunded", "Refunded", true),
        ];

    public IEnumerator<StatusRecord> GetEnumerator()
    {
        return Records.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
