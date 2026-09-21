using System.Collections;
using Pure.RelationalSchema.Samples.Columns;
using Pure.RelationalSchema.Storage.Abstractions;
using Pure.RelationalSchema.Storage.Samples.Cells;
using Pure.RelationalSchema.Storage.Samples.Records;
using Pure.RelationalSchema.Storage.Samples.TableDataSets;

namespace Pure.RelationalSchema.Storage.Samples.Tests.Records;

public sealed record OrderItemRecordsTests
{
    [Fact]
    public void CountIs4()
    {
        Assert.Equal(4, new OrderItemRecords().Count());
    }

    [Fact]
    public void MirrorsRowCount()
    {
        Assert.Equal(
            new OrderItemsTableDataSet().Count(),
            new OrderItemRecords().Count()
        );
    }

    [Fact]
    public void NonGenericEnumeratorEnumeratesEveryRecord()
    {
        IEnumerator enumerator = ((IEnumerable)new OrderItemRecords()).GetEnumerator();

        int count = 0;
        while (enumerator.MoveNext())
        {
            _ = Assert.IsType<OrderItemRecord>(enumerator.Current);
            count++;
        }

        Assert.Equal(4, count);
    }

    [Fact]
    public void MirrorsItemIdText()
    {
        IRow[] rows = [.. new OrderItemsTableDataSet()];
        OrderItemRecord[] records = [.. new OrderItemRecords()];

        Assert.Equal(
            records.Select(record => new InvariantCellText(record.ItemId).TextValue),
            rows.Select(row => row.Cells[new ItemIdColumn()].Value.TextValue)
        );
    }

    [Fact]
    public void MirrorsItemTenantIdText()
    {
        IRow[] rows = [.. new OrderItemsTableDataSet()];
        OrderItemRecord[] records = [.. new OrderItemRecords()];

        Assert.Equal(
            records.Select(record =>
                new InvariantCellText(record.ItemTenantId).TextValue
            ),
            rows.Select(row => row.Cells[new ItemTenantIdColumn()].Value.TextValue)
        );
    }

    [Fact]
    public void MirrorsItemOrderIdText()
    {
        IRow[] rows = [.. new OrderItemsTableDataSet()];
        OrderItemRecord[] records = [.. new OrderItemRecords()];

        Assert.Equal(
            records.Select(record => new InvariantCellText(record.ItemOrderId).TextValue),
            rows.Select(row => row.Cells[new ItemOrderIdColumn()].Value.TextValue)
        );
    }

    [Fact]
    public void MirrorsItemProductIdText()
    {
        IRow[] rows = [.. new OrderItemsTableDataSet()];
        OrderItemRecord[] records = [.. new OrderItemRecords()];

        Assert.Equal(
            records.Select(record =>
                new InvariantCellText(record.ItemProductId).TextValue
            ),
            rows.Select(row => row.Cells[new ItemProductIdColumn()].Value.TextValue)
        );
    }

    [Fact]
    public void MirrorsItemQtyText()
    {
        IRow[] rows = [.. new OrderItemsTableDataSet()];
        OrderItemRecord[] records = [.. new OrderItemRecords()];

        Assert.Equal(
            records.Select(record => new InvariantCellText(record.ItemQty).TextValue),
            rows.Select(row => row.Cells[new ItemQtyColumn()].Value.TextValue)
        );
    }
}
