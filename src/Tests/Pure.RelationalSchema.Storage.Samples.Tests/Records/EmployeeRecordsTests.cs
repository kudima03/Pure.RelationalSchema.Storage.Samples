using System.Collections;
using Pure.RelationalSchema.Samples.Columns;
using Pure.RelationalSchema.Storage.Abstractions;
using Pure.RelationalSchema.Storage.Samples.Cells;
using Pure.RelationalSchema.Storage.Samples.Records;
using Pure.RelationalSchema.Storage.Samples.TableDataSets;

namespace Pure.RelationalSchema.Storage.Samples.Tests.Records;

public sealed record EmployeeRecordsTests
{
    [Fact]
    public void CountIs4()
    {
        Assert.Equal(4, new EmployeeRecords().Count());
    }

    [Fact]
    public void MirrorsRowCount()
    {
        Assert.Equal(new EmployeesTableDataSet().Count(), new EmployeeRecords().Count());
    }

    [Fact]
    public void NonGenericEnumeratorEnumeratesEveryRecord()
    {
        IEnumerator enumerator = ((IEnumerable)new EmployeeRecords()).GetEnumerator();

        int count = 0;
        while (enumerator.MoveNext())
        {
            _ = Assert.IsType<EmployeeRecord>(enumerator.Current);
            count++;
        }

        Assert.Equal(4, count);
    }

    [Fact]
    public void MirrorsEmployeeIdText()
    {
        IRow[] rows = [.. new EmployeesTableDataSet()];
        EmployeeRecord[] records = [.. new EmployeeRecords()];

        Assert.Equal(
            records.Select(record => new InvariantCellText(record.EmployeeId).TextValue),
            rows.Select(row => row.Cells[new EmployeeIdColumn()].Value.TextValue)
        );
    }

    [Fact]
    public void MirrorsEmployeeNameText()
    {
        IRow[] rows = [.. new EmployeesTableDataSet()];
        EmployeeRecord[] records = [.. new EmployeeRecords()];

        Assert.Equal(
            records.Select(record =>
                new InvariantCellText(record.EmployeeName).TextValue
            ),
            rows.Select(row => row.Cells[new EmployeeNameColumn()].Value.TextValue)
        );
    }

    [Fact]
    public void MirrorsEmployeeManagerIdText()
    {
        IRow[] rows = [.. new EmployeesTableDataSet()];
        EmployeeRecord[] records = [.. new EmployeeRecords()];

        Assert.Equal(
            records.Select(record =>
                new InvariantCellText(record.EmployeeManagerId).TextValue
            ),
            rows.Select(row => row.Cells[new EmployeeManagerIdColumn()].Value.TextValue)
        );
    }

    [Fact]
    public void MirrorsEmployeeShiftStartText()
    {
        IRow[] rows = [.. new EmployeesTableDataSet()];
        EmployeeRecord[] records = [.. new EmployeeRecords()];

        Assert.Equal(
            records.Select(record =>
                new InvariantCellText(record.EmployeeShiftStart).TextValue
            ),
            rows.Select(row => row.Cells[new EmployeeShiftStartColumn()].Value.TextValue)
        );
    }

    [Fact]
    public void MirrorsEmployeeUserIdText()
    {
        IRow[] rows = [.. new EmployeesTableDataSet()];
        EmployeeRecord[] records = [.. new EmployeeRecords()];

        Assert.Equal(
            records.Select(record =>
                new InvariantCellText(record.EmployeeUserId).TextValue
            ),
            rows.Select(row => row.Cells[new EmployeeUserIdColumn()].Value.TextValue)
        );
    }
}
