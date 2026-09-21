using System.Collections;

namespace Pure.RelationalSchema.Storage.Samples.Records;

// The six orders of OrdersTableDataSet, as plain .NET values.
public sealed record OrderRecords : IEnumerable<OrderRecord>
{
    private static IEnumerable<OrderRecord> Records =>
        [
            new OrderRecord(
                new Guid("00000065-0000-0000-0000-000000000000"),
                new Guid("00000385-0000-0000-0000-000000000000"),
                new Guid("00000001-0000-0000-0000-000000000000"),
                100.50,
                new DateTime(2024, 6, 1, 10, 0, 0),
                "shipped",
                new DateOnly(2024, 6, 1)
            ),
            new OrderRecord(
                new Guid("00000066-0000-0000-0000-000000000000"),
                new Guid("00000385-0000-0000-0000-000000000000"),
                new Guid("00000001-0000-0000-0000-000000000000"),
                50,
                new DateTime(2024, 6, 2, 11, 0, 0),
                "pending",
                new DateOnly(2024, 6, 2)
            ),
            new OrderRecord(
                new Guid("00000067-0000-0000-0000-000000000000"),
                new Guid("00000385-0000-0000-0000-000000000000"),
                new Guid("00000002-0000-0000-0000-000000000000"),
                200,
                new DateTime(2024, 6, 3, 12, 0, 0),
                "shipped",
                new DateOnly(2024, 6, 3)
            ),
            new OrderRecord(
                new Guid("00000068-0000-0000-0000-000000000000"),
                new Guid("00000386-0000-0000-0000-000000000000"),
                new Guid("00000003-0000-0000-0000-000000000000"),
                75.25,
                new DateTime(2024, 6, 4, 13, 0, 0),
                "cancelled",
                new DateOnly(2024, 6, 4)
            ),
            new OrderRecord(
                new Guid("00000069-0000-0000-0000-000000000000"),
                new Guid("00000386-0000-0000-0000-000000000000"),
                new Guid("00000003-0000-0000-0000-000000000000"),
                300,
                new DateTime(2024, 6, 5, 14, 0, 0),
                "shipped",
                new DateOnly(2024, 6, 5)
            ),
            new OrderRecord(
                new Guid("0000006a-0000-0000-0000-000000000000"),
                new Guid("00000386-0000-0000-0000-000000000000"),
                new Guid("00000004-0000-0000-0000-000000000000"),
                100.50,
                new DateTime(2024, 6, 6, 15, 0, 0),
                "pending",
                new DateOnly(2024, 6, 6)
            ),
        ];

    public IEnumerator<OrderRecord> GetEnumerator()
    {
        return Records.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
