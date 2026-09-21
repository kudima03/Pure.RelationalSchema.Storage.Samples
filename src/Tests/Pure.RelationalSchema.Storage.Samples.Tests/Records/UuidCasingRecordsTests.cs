using System.Collections;
using Pure.RelationalSchema.Samples.Columns;
using Pure.RelationalSchema.Storage.Abstractions;
using Pure.RelationalSchema.Storage.Samples.Cells;
using Pure.RelationalSchema.Storage.Samples.Records;
using Pure.RelationalSchema.Storage.Samples.TableDataSets;

namespace Pure.RelationalSchema.Storage.Samples.Tests.Records;

public sealed record UuidCasingRecordsTests
{
    [Fact]
    public void CountIs2()
    {
        Assert.Equal(2, new UuidCasingRecords().Count());
    }

    [Fact]
    public void MirrorsRowCount()
    {
        Assert.Equal(
            new UuidCasingTableDataSet().Count(),
            new UuidCasingRecords().Count()
        );
    }

    [Fact]
    public void NonGenericEnumeratorEnumeratesEveryRecord()
    {
        IEnumerator enumerator = ((IEnumerable)new UuidCasingRecords()).GetEnumerator();

        int count = 0;
        while (enumerator.MoveNext())
        {
            _ = Assert.IsType<UuidCasingRecord>(enumerator.Current);
            count++;
        }

        Assert.Equal(2, count);
    }

    [Fact]
    public void BothRowsShareOneLogicalId()
    {
        UuidCasingRecord[] records = [.. new UuidCasingRecords()];

        _ = Assert.Single(records.Select(record => record.Id).Distinct());
    }

    [Fact]
    public void MirrorsIdText()
    {
        IRow[] rows = [.. new UuidCasingTableDataSet()];
        UuidCasingRecord[] records = [.. new UuidCasingRecords()];

        Assert.Equal(
            records.Select(record => new InvariantCellText(record.IdText).TextValue),
            rows.Select(row => row.Cells[new IdColumn()].Value.TextValue)
        );
    }

    [Fact]
    public void MirrorsNameText()
    {
        IRow[] rows = [.. new UuidCasingTableDataSet()];
        UuidCasingRecord[] records = [.. new UuidCasingRecords()];

        Assert.Equal(
            records.Select(record => new InvariantCellText(record.Name).TextValue),
            rows.Select(row => row.Cells[new NameColumn()].Value.TextValue)
        );
    }

    [Fact]
    public void MirrorsCreatedAtText()
    {
        IRow[] rows = [.. new UuidCasingTableDataSet()];
        UuidCasingRecord[] records = [.. new UuidCasingRecords()];

        Assert.Equal(
            records.Select(record => new InvariantCellText(record.CreatedAt).TextValue),
            rows.Select(row => row.Cells[new CreatedAtColumn()].Value.TextValue)
        );
    }
}
