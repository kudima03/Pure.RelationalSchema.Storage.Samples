using System.Collections;

namespace Pure.RelationalSchema.Storage.Samples.Records;

// The four order items of OrderItemsTableDataSet, as plain .NET values.
public sealed record OrderItemRecords : IEnumerable<OrderItemRecord>
{
    private static IEnumerable<OrderItemRecord> Records =>
        [
            new OrderItemRecord(
                new Guid("0000012d-0000-0000-0000-000000000000"),
                new Guid("00000385-0000-0000-0000-000000000000"),
                new Guid("00000065-0000-0000-0000-000000000000"),
                new Guid("000000c9-0000-0000-0000-000000000000"),
                2
            ),
            new OrderItemRecord(
                new Guid("0000012e-0000-0000-0000-000000000000"),
                new Guid("00000385-0000-0000-0000-000000000000"),
                new Guid("00000065-0000-0000-0000-000000000000"),
                new Guid("000000ca-0000-0000-0000-000000000000"),
                1
            ),
            new OrderItemRecord(
                new Guid("0000012f-0000-0000-0000-000000000000"),
                new Guid("00000385-0000-0000-0000-000000000000"),
                new Guid("00000067-0000-0000-0000-000000000000"),
                new Guid("000000cb-0000-0000-0000-000000000000"),
                5
            ),
            new OrderItemRecord(
                new Guid("00000130-0000-0000-0000-000000000000"),
                new Guid("00000386-0000-0000-0000-000000000000"),
                new Guid("00000069-0000-0000-0000-000000000000"),
                new Guid("000000c9-0000-0000-0000-000000000000"),
                3
            ),
        ];

    public IEnumerator<OrderItemRecord> GetEnumerator()
    {
        return Records.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
