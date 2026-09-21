using System.Collections;

namespace Pure.RelationalSchema.Storage.Samples.Records;

// The four logins of LoginsTableDataSet, as plain .NET values.
public sealed record LoginRecords : IEnumerable<LoginRecord>
{
    private static IEnumerable<LoginRecord> Records =>
        [
            new LoginRecord(
                new Guid("00000191-0000-0000-0000-000000000000"),
                new Guid("00000001-0000-0000-0000-000000000000"),
                new DateTime(2024, 6, 1, 7, 0, 0)
            ),
            new LoginRecord(
                new Guid("00000192-0000-0000-0000-000000000000"),
                new Guid("00000001-0000-0000-0000-000000000000"),
                new DateTime(2024, 6, 2, 7, 30, 0)
            ),
            new LoginRecord(
                new Guid("00000193-0000-0000-0000-000000000000"),
                new Guid("00000002-0000-0000-0000-000000000000"),
                new DateTime(2024, 6, 3, 8, 0, 0)
            ),
            new LoginRecord(
                new Guid("00000194-0000-0000-0000-000000000000"),
                new Guid("00000005-0000-0000-0000-000000000000"),
                new DateTime(2024, 6, 4, 6, 45, 0)
            ),
        ];

    public IEnumerator<LoginRecord> GetEnumerator()
    {
        return Records.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
