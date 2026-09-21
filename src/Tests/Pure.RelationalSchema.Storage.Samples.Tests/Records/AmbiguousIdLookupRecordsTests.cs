using System.Collections;
using Pure.RelationalSchema.Samples.Columns;
using Pure.RelationalSchema.Storage.Abstractions;
using Pure.RelationalSchema.Storage.Samples.Cells;
using Pure.RelationalSchema.Storage.Samples.Records;
using Pure.RelationalSchema.Storage.Samples.TableDataSets;

namespace Pure.RelationalSchema.Storage.Samples.Tests.Records;

public sealed record AmbiguousIdLookupRecordsTests
{
    [Fact]
    public void CountIs4()
    {
        Assert.Equal(4, new AmbiguousIdLookupRecords().Count());
    }

    [Fact]
    public void MirrorsRowCount()
    {
        Assert.Equal(
            new AmbiguousIdLookupTableDataSet().Count(),
            new AmbiguousIdLookupRecords().Count()
        );
    }

    [Fact]
    public void NonGenericEnumeratorEnumeratesEveryRecord()
    {
        IEnumerator enumerator = (
            (IEnumerable)new AmbiguousIdLookupRecords()
        ).GetEnumerator();

        int count = 0;
        while (enumerator.MoveNext())
        {
            _ = Assert.IsType<AmbiguousIdLookupRecord>(enumerator.Current);
            count++;
        }

        Assert.Equal(4, count);
    }

    [Fact]
    public void MirrorsIdText()
    {
        IRow[] rows = [.. new AmbiguousIdLookupTableDataSet()];
        AmbiguousIdLookupRecord[] records = [.. new AmbiguousIdLookupRecords()];

        Assert.Equal(
            records.Select(record => new InvariantCellText(record.Id).TextValue),
            rows.Select(row => row.Cells[new IdColumn()].Value.TextValue)
        );
    }

    [Fact]
    public void MirrorsNameText()
    {
        IRow[] rows = [.. new AmbiguousIdLookupTableDataSet()];
        AmbiguousIdLookupRecord[] records = [.. new AmbiguousIdLookupRecords()];

        Assert.Equal(
            records.Select(record => new InvariantCellText(record.Name).TextValue),
            rows.Select(row => row.Cells[new NameColumn()].Value.TextValue)
        );
    }
}
