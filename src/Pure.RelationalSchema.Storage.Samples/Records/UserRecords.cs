using System.Collections;

namespace Pure.RelationalSchema.Storage.Samples.Records;

// The six users of UsersTableDataSet, as plain .NET values.
public sealed record UserRecords : IEnumerable<UserRecord>
{
    private static IEnumerable<UserRecord> Records =>
        [
            new UserRecord(
                new Guid("00000001-0000-0000-0000-000000000000"),
                new Guid("00000385-0000-0000-0000-000000000000"),
                "Ann",
                new DateOnly(2020, 1, 15),
                true,
                new DateTime(2024, 6, 1, 8, 30, 0),
                30,
                new TimeOnly(9, 0, 0),
                30,
                double.MaxValue,
                new DateOnly(2024, 2, 29),
                new DateTime(2024, 2, 29, 0, 0, 0),
                new TimeOnly(0, 0, 0)
            ),
            new UserRecord(
                new Guid("00000002-0000-0000-0000-000000000000"),
                new Guid("00000385-0000-0000-0000-000000000000"),
                "Bob",
                new DateOnly(2021, 3, 20),
                false,
                new DateTime(2024, 6, 2, 9, 15, 0),
                25,
                new TimeOnly(10, 0, 0),
                null,
                double.MinValue,
                new DateOnly(2024, 12, 31),
                new DateTime(2024, 12, 31, 23, 59, 59),
                new TimeOnly(23, 59, 59)
            ),
            new UserRecord(
                new Guid("00000003-0000-0000-0000-000000000000"),
                new Guid("00000385-0000-0000-0000-000000000000"),
                "Cara",
                new DateOnly(2019, 7, 10),
                true,
                new DateTime(2024, 5, 30, 14, 0, 0),
                30,
                new TimeOnly(9, 0, 0),
                30,
                double.Epsilon,
                new DateOnly(2024, 3, 10),
                new DateTime(2024, 3, 10, 2, 30, 0),
                new TimeOnly(2, 30, 0)
            ),
            new UserRecord(
                new Guid("00000004-0000-0000-0000-000000000000"),
                new Guid("00000386-0000-0000-0000-000000000000"),
                "Dan",
                new DateOnly(2022, 11, 5),
                true,
                new DateTime(2024, 6, 3, 18, 45, 0),
                42,
                new TimeOnly(11, 30, 0),
                null,
                -double.Epsilon,
                new DateOnly(2024, 11, 3),
                new DateTime(2024, 11, 3, 1, 30, 0),
                new TimeOnly(1, 30, 0)
            ),
            new UserRecord(
                new Guid("00000005-0000-0000-0000-000000000000"),
                new Guid("00000386-0000-0000-0000-000000000000"),
                "Eve",
                new DateOnly(2023, 2, 28),
                false,
                new DateTime(2024, 6, 4, 7, 5, 0),
                25,
                new TimeOnly(8, 0, 0),
                10,
                1e308,
                new DateOnly(1, 1, 1),
                new DateTime(1, 1, 1, 0, 0, 0),
                new TimeOnly(0, 0, 0)
            ),
            new UserRecord(
                new Guid("00000006-0000-0000-0000-000000000000"),
                new Guid("00000386-0000-0000-0000-000000000000"),
                "Fay",
                new DateOnly(2020, 1, 15),
                true,
                new DateTime(2024, 6, 1, 8, 30, 0),
                28,
                new TimeOnly(9, 0, 0),
                28,
                123456789.123456,
                new DateOnly(9999, 12, 31),
                new DateTime(9999, 12, 31, 23, 59, 59),
                new TimeOnly(23, 59, 59)
            ),
        ];

    public IEnumerator<UserRecord> GetEnumerator()
    {
        return Records.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
