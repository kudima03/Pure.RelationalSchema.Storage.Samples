using System.Collections;
using Pure.RelationalSchema.Samples.Columns;
using Pure.RelationalSchema.Storage.Abstractions;
using Pure.RelationalSchema.Storage.Samples.Cells;
using Pure.RelationalSchema.Storage.Samples.Records;
using Pure.RelationalSchema.Storage.Samples.TableDataSets;

namespace Pure.RelationalSchema.Storage.Samples.Tests.Records;

public sealed record OrderRecordsTests
{
    [Fact]
    public void CountIs6()
    {
        Assert.Equal(6, new OrderRecords().Count());
    }

    [Fact]
    public void MirrorsRowCount()
    {
        Assert.Equal(new OrdersTableDataSet().Count(), new OrderRecords().Count());
    }

    [Fact]
    public void NonGenericEnumeratorEnumeratesEveryRecord()
    {
        IEnumerator enumerator = ((IEnumerable)new OrderRecords()).GetEnumerator();

        int count = 0;
        while (enumerator.MoveNext())
        {
            _ = Assert.IsType<OrderRecord>(enumerator.Current);
            count++;
        }

        Assert.Equal(6, count);
    }

    [Fact]
    public void MirrorsOrderIdText()
    {
        IRow[] rows = [.. new OrdersTableDataSet()];
        OrderRecord[] records = [.. new OrderRecords()];

        Assert.Equal(
            records.Select(record => new InvariantCellText(record.OrderId).TextValue),
            rows.Select(row => row.Cells[new OrderIdColumn()].Value.TextValue)
        );
    }

    [Fact]
    public void MirrorsOrderTenantIdText()
    {
        IRow[] rows = [.. new OrdersTableDataSet()];
        OrderRecord[] records = [.. new OrderRecords()];

        Assert.Equal(
            records.Select(record =>
                new InvariantCellText(record.OrderTenantId).TextValue
            ),
            rows.Select(row => row.Cells[new OrderTenantIdColumn()].Value.TextValue)
        );
    }

    [Fact]
    public void MirrorsOrderUserIdText()
    {
        IRow[] rows = [.. new OrdersTableDataSet()];
        OrderRecord[] records = [.. new OrderRecords()];

        Assert.Equal(
            records.Select(record => new InvariantCellText(record.OrderUserId).TextValue),
            rows.Select(row => row.Cells[new OrderUserIdColumn()].Value.TextValue)
        );
    }

    [Fact]
    public void MirrorsOrderTotalText()
    {
        IRow[] rows = [.. new OrdersTableDataSet()];
        OrderRecord[] records = [.. new OrderRecords()];

        Assert.Equal(
            records.Select(record => new InvariantCellText(record.OrderTotal).TextValue),
            rows.Select(row => row.Cells[new OrderTotalColumn()].Value.TextValue)
        );
    }

    [Fact]
    public void MirrorsPlacedAtText()
    {
        IRow[] rows = [.. new OrdersTableDataSet()];
        OrderRecord[] records = [.. new OrderRecords()];

        Assert.Equal(
            records.Select(record => new InvariantCellText(record.PlacedAt).TextValue),
            rows.Select(row => row.Cells[new PlacedAtColumn()].Value.TextValue)
        );
    }

    [Fact]
    public void MirrorsOrderStatusText()
    {
        IRow[] rows = [.. new OrdersTableDataSet()];
        OrderRecord[] records = [.. new OrderRecords()];

        Assert.Equal(
            records.Select(record => new InvariantCellText(record.OrderStatus).TextValue),
            rows.Select(row => row.Cells[new OrderStatusColumn()].Value.TextValue)
        );
    }

    [Fact]
    public void MirrorsPlacedOnText()
    {
        IRow[] rows = [.. new OrdersTableDataSet()];
        OrderRecord[] records = [.. new OrderRecords()];

        Assert.Equal(
            records.Select(record => new InvariantCellText(record.PlacedOn).TextValue),
            rows.Select(row => row.Cells[new PlacedOnColumn()].Value.TextValue)
        );
    }
}
