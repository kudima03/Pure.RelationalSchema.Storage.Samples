using Pure.RelationalSchema.Samples.Columns;
using Pure.RelationalSchema.Storage.Abstractions;
using Pure.RelationalSchema.Storage.Samples.Rows;

namespace Pure.RelationalSchema.Storage.Samples.Tests.Rows;

public sealed record OrderRowTests
{
    [Fact]
    public void CellsCountIs7()
    {
        IRow row = new OrderRow();

        Assert.Equal(7, row.Cells.Count);
    }

    [Fact]
    public void CellsContainsOrderIdColumn()
    {
        IRow row = new OrderRow();

        Assert.True(row.Cells.ContainsKey(new OrderIdColumn()));
    }

    [Fact]
    public void OrderIdCellHoldsExpectedText()
    {
        IRow row = new OrderRow();

        Assert.Equal(
            "00000065-0000-0000-0000-000000000000",
            row.Cells[new OrderIdColumn()].Value.TextValue
        );
    }

    [Fact]
    public void CellsContainsOrderTenantIdColumn()
    {
        IRow row = new OrderRow();

        Assert.True(row.Cells.ContainsKey(new OrderTenantIdColumn()));
    }

    [Fact]
    public void OrderTenantIdCellHoldsExpectedText()
    {
        IRow row = new OrderRow();

        Assert.Equal(
            "00000385-0000-0000-0000-000000000000",
            row.Cells[new OrderTenantIdColumn()].Value.TextValue
        );
    }

    [Fact]
    public void CellsContainsOrderUserIdColumn()
    {
        IRow row = new OrderRow();

        Assert.True(row.Cells.ContainsKey(new OrderUserIdColumn()));
    }

    [Fact]
    public void OrderUserIdCellHoldsExpectedText()
    {
        IRow row = new OrderRow();

        Assert.Equal(
            "00000001-0000-0000-0000-000000000000",
            row.Cells[new OrderUserIdColumn()].Value.TextValue
        );
    }

    [Fact]
    public void CellsContainsOrderTotalColumn()
    {
        IRow row = new OrderRow();

        Assert.True(row.Cells.ContainsKey(new OrderTotalColumn()));
    }

    [Fact]
    public void OrderTotalCellHoldsExpectedText()
    {
        IRow row = new OrderRow();

        Assert.Equal("100.5", row.Cells[new OrderTotalColumn()].Value.TextValue);
    }

    [Fact]
    public void CellsContainsPlacedAtColumn()
    {
        IRow row = new OrderRow();

        Assert.True(row.Cells.ContainsKey(new PlacedAtColumn()));
    }

    [Fact]
    public void PlacedAtCellHoldsExpectedText()
    {
        IRow row = new OrderRow();

        Assert.Equal(
            "2024-06-01T10:00:00",
            row.Cells[new PlacedAtColumn()].Value.TextValue
        );
    }

    [Fact]
    public void CellsContainsOrderStatusColumn()
    {
        IRow row = new OrderRow();

        Assert.True(row.Cells.ContainsKey(new OrderStatusColumn()));
    }

    [Fact]
    public void OrderStatusCellHoldsExpectedText()
    {
        IRow row = new OrderRow();

        Assert.Equal("shipped", row.Cells[new OrderStatusColumn()].Value.TextValue);
    }

    [Fact]
    public void CellsContainsPlacedOnColumn()
    {
        IRow row = new OrderRow();

        Assert.True(row.Cells.ContainsKey(new PlacedOnColumn()));
    }

    [Fact]
    public void PlacedOnCellHoldsExpectedText()
    {
        IRow row = new OrderRow();

        Assert.Equal("2024-06-01", row.Cells[new PlacedOnColumn()].Value.TextValue);
    }
}
