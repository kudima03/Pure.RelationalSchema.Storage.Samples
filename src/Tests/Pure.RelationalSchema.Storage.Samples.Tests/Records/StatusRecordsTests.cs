using System.Collections;
using Pure.RelationalSchema.Samples.Columns;
using Pure.RelationalSchema.Storage.Abstractions;
using Pure.RelationalSchema.Storage.Samples.Cells;
using Pure.RelationalSchema.Storage.Samples.Records;
using Pure.RelationalSchema.Storage.Samples.TableDataSets;

namespace Pure.RelationalSchema.Storage.Samples.Tests.Records;

public sealed record StatusRecordsTests
{
    [Fact]
    public void CountIs4()
    {
        Assert.Equal(4, new StatusRecords().Count());
    }

    [Fact]
    public void MirrorsRowCount()
    {
        Assert.Equal(new StatusesTableDataSet().Count(), new StatusRecords().Count());
    }

    [Fact]
    public void NonGenericEnumeratorEnumeratesEveryRecord()
    {
        IEnumerator enumerator = ((IEnumerable)new StatusRecords()).GetEnumerator();

        int count = 0;
        while (enumerator.MoveNext())
        {
            _ = Assert.IsType<StatusRecord>(enumerator.Current);
            count++;
        }

        Assert.Equal(4, count);
    }

    [Fact]
    public void MirrorsStatusCodeText()
    {
        IRow[] rows = [.. new StatusesTableDataSet()];
        StatusRecord[] records = [.. new StatusRecords()];

        Assert.Equal(
            records.Select(record => new InvariantCellText(record.StatusCode).TextValue),
            rows.Select(row => row.Cells[new StatusCodeColumn()].Value.TextValue)
        );
    }

    [Fact]
    public void MirrorsStatusLabelText()
    {
        IRow[] rows = [.. new StatusesTableDataSet()];
        StatusRecord[] records = [.. new StatusRecords()];

        Assert.Equal(
            records.Select(record => new InvariantCellText(record.StatusLabel).TextValue),
            rows.Select(row => row.Cells[new StatusLabelColumn()].Value.TextValue)
        );
    }

    [Fact]
    public void MirrorsStatusIsFinalText()
    {
        IRow[] rows = [.. new StatusesTableDataSet()];
        StatusRecord[] records = [.. new StatusRecords()];

        Assert.Equal(
            records.Select(record =>
                new InvariantCellText(record.StatusIsFinal).TextValue
            ),
            rows.Select(row => row.Cells[new StatusIsFinalColumn()].Value.TextValue)
        );
    }
}
