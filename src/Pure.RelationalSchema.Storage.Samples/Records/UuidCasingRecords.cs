using System.Collections;

namespace Pure.RelationalSchema.Storage.Samples.Records;

// The two rows of UuidCasingTableDataSet, as plain .NET values.
public sealed record UuidCasingRecords : IEnumerable<UuidCasingRecord>
{
    private static IEnumerable<UuidCasingRecord> Records =>
        [
            new UuidCasingRecord(
                new Guid("0f9e8d7c-6b5a-4938-8271-605f4e3d2c1b"),
                "0f9e8d7c-6b5a-4938-8271-605f4e3d2c1b",
                "lowercase",
                new DateTime(2024, 1, 1, 0, 0, 0)
            ),
            new UuidCasingRecord(
                new Guid("0f9e8d7c-6b5a-4938-8271-605f4e3d2c1b"),
                "0F9E8D7C-6B5A-4938-8271-605F4E3D2C1B",
                "uppercase",
                new DateTime(2024, 1, 2, 0, 0, 0)
            ),
        ];

    public IEnumerator<UuidCasingRecord> GetEnumerator()
    {
        return Records.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
