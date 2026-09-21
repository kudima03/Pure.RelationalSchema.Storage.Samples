using System.Collections;

namespace Pure.RelationalSchema.Storage.Samples.Records;

// The six rows of AmbiguousIdTableDataSet, as plain .NET values.
public sealed record AmbiguousIdRecords : IEnumerable<AmbiguousIdRecord>
{
    private static IEnumerable<AmbiguousIdRecord> Records =>
        [
            new AmbiguousIdRecord(
                new Guid("00000001-0000-0000-0000-000000000000"),
                new Guid("000001f5-0000-0000-0000-000000000000"),
                "first_entry",
                new DateTime(2024, 1, 1, 0, 0, 0)
            ),
            new AmbiguousIdRecord(
                new Guid("00000002-0000-0000-0000-000000000000"),
                new Guid("000001f5-0000-0000-0000-000000000000"),
                "second_entry",
                new DateTime(2024, 1, 2, 1, 0, 0)
            ),
            new AmbiguousIdRecord(
                new Guid("00000003-0000-0000-0000-000000000000"),
                new Guid("000001f6-0000-0000-0000-000000000000"),
                "third_entry",
                new DateTime(2024, 1, 3, 2, 0, 0)
            ),
            new AmbiguousIdRecord(
                new Guid("00000004-0000-0000-0000-000000000000"),
                new Guid("000001f6-0000-0000-0000-000000000000"),
                "fourth_entry",
                new DateTime(2024, 1, 4, 3, 0, 0)
            ),
            new AmbiguousIdRecord(
                new Guid("00000005-0000-0000-0000-000000000000"),
                new Guid("000001f6-0000-0000-0000-000000000000"),
                "fifth_entry",
                new DateTime(2024, 1, 5, 4, 0, 0)
            ),
            new AmbiguousIdRecord(
                new Guid("00000006-0000-0000-0000-000000000000"),
                new Guid("000001f7-0000-0000-0000-000000000000"),
                "sixth_entry",
                new DateTime(2024, 1, 6, 5, 0, 0)
            ),
        ];

    public IEnumerator<AmbiguousIdRecord> GetEnumerator()
    {
        return Records.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
