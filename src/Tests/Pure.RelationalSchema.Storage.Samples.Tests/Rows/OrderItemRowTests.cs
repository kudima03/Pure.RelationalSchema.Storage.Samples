using Pure.RelationalSchema.Samples.Columns;
using Pure.RelationalSchema.Storage.Abstractions;
using Pure.RelationalSchema.Storage.Samples.Rows;

namespace Pure.RelationalSchema.Storage.Samples.Tests.Rows;

public sealed record OrderItemRowTests
{
    [Fact]
    public void CellsCountIs5()
    {
        IRow row = new OrderItemRow();

        Assert.Equal(5, row.Cells.Count);
    }

    [Fact]
    public void CellsContainsItemIdColumn()
    {
        IRow row = new OrderItemRow();

        Assert.True(row.Cells.ContainsKey(new ItemIdColumn()));
    }

    [Fact]
    public void ItemIdCellHoldsExpectedText()
    {
        IRow row = new OrderItemRow();

        Assert.Equal(
            "0000012d-0000-0000-0000-000000000000",
            row.Cells[new ItemIdColumn()].Value.TextValue
        );
    }

    [Fact]
    public void CellsContainsItemTenantIdColumn()
    {
        IRow row = new OrderItemRow();

        Assert.True(row.Cells.ContainsKey(new ItemTenantIdColumn()));
    }

    [Fact]
    public void ItemTenantIdCellHoldsExpectedText()
    {
        IRow row = new OrderItemRow();

        Assert.Equal(
            "00000385-0000-0000-0000-000000000000",
            row.Cells[new ItemTenantIdColumn()].Value.TextValue
        );
    }

    [Fact]
    public void CellsContainsItemOrderIdColumn()
    {
        IRow row = new OrderItemRow();

        Assert.True(row.Cells.ContainsKey(new ItemOrderIdColumn()));
    }

    [Fact]
    public void ItemOrderIdCellHoldsExpectedText()
    {
        IRow row = new OrderItemRow();

        Assert.Equal(
            "00000065-0000-0000-0000-000000000000",
            row.Cells[new ItemOrderIdColumn()].Value.TextValue
        );
    }

    [Fact]
    public void CellsContainsItemProductIdColumn()
    {
        IRow row = new OrderItemRow();

        Assert.True(row.Cells.ContainsKey(new ItemProductIdColumn()));
    }

    [Fact]
    public void ItemProductIdCellHoldsExpectedText()
    {
        IRow row = new OrderItemRow();

        Assert.Equal(
            "000000c9-0000-0000-0000-000000000000",
            row.Cells[new ItemProductIdColumn()].Value.TextValue
        );
    }

    [Fact]
    public void CellsContainsItemQtyColumn()
    {
        IRow row = new OrderItemRow();

        Assert.True(row.Cells.ContainsKey(new ItemQtyColumn()));
    }

    [Fact]
    public void ItemQtyCellHoldsExpectedText()
    {
        IRow row = new OrderItemRow();

        Assert.Equal("2", row.Cells[new ItemQtyColumn()].Value.TextValue);
    }
}
