using System.Collections;

namespace Pure.RelationalSchema.Storage.Samples.Records;

// The four employees of EmployeesTableDataSet, as plain .NET values.
public sealed record EmployeeRecords : IEnumerable<EmployeeRecord>
{
    private static IEnumerable<EmployeeRecord> Records =>
        [
            new EmployeeRecord(
                new Guid("000002bd-0000-0000-0000-000000000000"),
                "Grace",
                null,
                new TimeOnly(9, 0, 0),
                new Guid("00000001-0000-0000-0000-000000000000")
            ),
            new EmployeeRecord(
                new Guid("000002be-0000-0000-0000-000000000000"),
                "Hank",
                new Guid("000002bd-0000-0000-0000-000000000000"),
                new TimeOnly(10, 0, 0),
                new Guid("00000002-0000-0000-0000-000000000000")
            ),
            new EmployeeRecord(
                new Guid("000002bf-0000-0000-0000-000000000000"),
                "Iris",
                new Guid("000002bd-0000-0000-0000-000000000000"),
                new TimeOnly(11, 30, 0),
                new Guid("00000003-0000-0000-0000-000000000000")
            ),
            new EmployeeRecord(
                new Guid("000002c0-0000-0000-0000-000000000000"),
                "Jack",
                new Guid("000002be-0000-0000-0000-000000000000"),
                new TimeOnly(8, 0, 0),
                new Guid("00000004-0000-0000-0000-000000000000")
            ),
        ];

    public IEnumerator<EmployeeRecord> GetEnumerator()
    {
        return Records.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
