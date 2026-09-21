using System.Collections;
using Pure.RelationalSchema.Samples.Columns;
using Pure.RelationalSchema.Storage.Abstractions;
using Pure.RelationalSchema.Storage.Samples.Cells;
using Pure.RelationalSchema.Storage.Samples.Records;
using Pure.RelationalSchema.Storage.Samples.TableDataSets;

namespace Pure.RelationalSchema.Storage.Samples.Tests.Records;

public sealed record LoginRecordsTests
{
    [Fact]
    public void CountIs4()
    {
        Assert.Equal(4, new LoginRecords().Count());
    }

    [Fact]
    public void MirrorsRowCount()
    {
        Assert.Equal(new LoginsTableDataSet().Count(), new LoginRecords().Count());
    }

    [Fact]
    public void NonGenericEnumeratorEnumeratesEveryRecord()
    {
        IEnumerator enumerator = ((IEnumerable)new LoginRecords()).GetEnumerator();

        int count = 0;
        while (enumerator.MoveNext())
        {
            _ = Assert.IsType<LoginRecord>(enumerator.Current);
            count++;
        }

        Assert.Equal(4, count);
    }

    [Fact]
    public void MirrorsLoginIdText()
    {
        IRow[] rows = [.. new LoginsTableDataSet()];
        LoginRecord[] records = [.. new LoginRecords()];

        Assert.Equal(
            records.Select(record => new InvariantCellText(record.LoginId).TextValue),
            rows.Select(row => row.Cells[new LoginIdColumn()].Value.TextValue)
        );
    }

    [Fact]
    public void MirrorsLoginUserIdText()
    {
        IRow[] rows = [.. new LoginsTableDataSet()];
        LoginRecord[] records = [.. new LoginRecords()];

        Assert.Equal(
            records.Select(record => new InvariantCellText(record.LoginUserId).TextValue),
            rows.Select(row => row.Cells[new LoginUserIdColumn()].Value.TextValue)
        );
    }

    [Fact]
    public void MirrorsLoginAtText()
    {
        IRow[] rows = [.. new LoginsTableDataSet()];
        LoginRecord[] records = [.. new LoginRecords()];

        Assert.Equal(
            records.Select(record => new InvariantCellText(record.LoginAt).TextValue),
            rows.Select(row => row.Cells[new LoginAtColumn()].Value.TextValue)
        );
    }
}
