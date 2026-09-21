using System.Collections;
using Pure.RelationalSchema.Samples.Columns;
using Pure.RelationalSchema.Storage.Abstractions;
using Pure.RelationalSchema.Storage.Samples.Cells;
using Pure.RelationalSchema.Storage.Samples.Records;
using Pure.RelationalSchema.Storage.Samples.TableDataSets;

namespace Pure.RelationalSchema.Storage.Samples.Tests.Records;

public sealed record AmbiguousIdRecordsTests
{
    [Fact]
    public void CountIs6()
    {
        Assert.Equal(6, new AmbiguousIdRecords().Count());
    }

    [Fact]
    public void MirrorsRowCount()
    {
        Assert.Equal(
            new AmbiguousIdTableDataSet().Count(),
            new AmbiguousIdRecords().Count()
        );
    }

    [Fact]
    public void NonGenericEnumeratorEnumeratesEveryRecord()
    {
        IEnumerator enumerator = ((IEnumerable)new AmbiguousIdRecords()).GetEnumerator();

        int count = 0;
        while (enumerator.MoveNext())
        {
            _ = Assert.IsType<AmbiguousIdRecord>(enumerator.Current);
            count++;
        }

        Assert.Equal(6, count);
    }

    [Fact]
    public void MirrorsIdText()
    {
        IRow[] rows = [.. new AmbiguousIdTableDataSet()];
        AmbiguousIdRecord[] records = [.. new AmbiguousIdRecords()];

        Assert.Equal(
            records.Select(record => new InvariantCellText(record.Id).TextValue),
            rows.Select(row => row.Cells[new IdColumn()].Value.TextValue)
        );
    }

    [Fact]
    public void MirrorsTenantIdText()
    {
        IRow[] rows = [.. new AmbiguousIdTableDataSet()];
        AmbiguousIdRecord[] records = [.. new AmbiguousIdRecords()];

        Assert.Equal(
            records.Select(record => new InvariantCellText(record.TenantId).TextValue),
            rows.Select(row => row.Cells[new TenantIdColumn()].Value.TextValue)
        );
    }

    [Fact]
    public void MirrorsNameText()
    {
        IRow[] rows = [.. new AmbiguousIdTableDataSet()];
        AmbiguousIdRecord[] records = [.. new AmbiguousIdRecords()];

        Assert.Equal(
            records.Select(record => new InvariantCellText(record.Name).TextValue),
            rows.Select(row => row.Cells[new NameColumn()].Value.TextValue)
        );
    }

    [Fact]
    public void MirrorsCreatedAtText()
    {
        IRow[] rows = [.. new AmbiguousIdTableDataSet()];
        AmbiguousIdRecord[] records = [.. new AmbiguousIdRecords()];

        Assert.Equal(
            records.Select(record => new InvariantCellText(record.CreatedAt).TextValue),
            rows.Select(row => row.Cells[new CreatedAtColumn()].Value.TextValue)
        );
    }
}
