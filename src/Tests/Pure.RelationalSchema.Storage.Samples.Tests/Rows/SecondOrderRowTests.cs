using Pure.RelationalSchema.Samples.Columns;
using Pure.RelationalSchema.Storage.Abstractions;
using Pure.RelationalSchema.Storage.Samples.Rows;

namespace Pure.RelationalSchema.Storage.Samples.Tests.Rows;

public sealed record SecondOrderRowTests
{
    [Fact]
    public void CellsCountIs7()
    {
        IRow row = new SecondOrderRow();

        Assert.Equal(7, row.Cells.Count);
    }

    [Fact]
    public void CellsContainsOrderIdColumn()
    {
        IRow row = new SecondOrderRow();

        Assert.True(row.Cells.ContainsKey(new OrderIdColumn()));
    }

    [Fact]
    public void OrderIdCellHoldsExpectedText()
    {
        IRow row = new SecondOrderRow();

        Assert.Equal(
            "00000066-0000-0000-0000-000000000000",
            row.Cells[new OrderIdColumn()].Value.TextValue
        );
    }

    [Fact]
    public void CellsContainsOrderTenantIdColumn()
    {
        IRow row = new SecondOrderRow();

        Assert.True(row.Cells.ContainsKey(new OrderTenantIdColumn()));
    }

    [Fact]
    public void OrderTenantIdCellHoldsExpectedText()
    {
        IRow row = new SecondOrderRow();

        Assert.Equal(
            "00000385-0000-0000-0000-000000000000",
            row.Cells[new OrderTenantIdColumn()].Value.TextValue
        );
    }

    [Fact]
    public void CellsContainsOrderUserIdColumn()
    {
        IRow row = new SecondOrderRow();

        Assert.True(row.Cells.ContainsKey(new OrderUserIdColumn()));
    }

    [Fact]
    public void OrderUserIdCellHoldsExpectedText()
    {
        IRow row = new SecondOrderRow();

        Assert.Equal(
            "00000001-0000-0000-0000-000000000000",
            row.Cells[new OrderUserIdColumn()].Value.TextValue
        );
    }

    [Fact]
    public void CellsContainsOrderTotalColumn()
    {
        IRow row = new SecondOrderRow();

        Assert.True(row.Cells.ContainsKey(new OrderTotalColumn()));
    }

    [Fact]
    public void OrderTotalCellHoldsExpectedText()
    {
        IRow row = new SecondOrderRow();

        Assert.Equal("50", row.Cells[new OrderTotalColumn()].Value.TextValue);
    }

    [Fact]
    public void CellsContainsPlacedAtColumn()
    {
        IRow row = new SecondOrderRow();

        Assert.True(row.Cells.ContainsKey(new PlacedAtColumn()));
    }

    [Fact]
    public void PlacedAtCellHoldsExpectedText()
    {
        IRow row = new SecondOrderRow();

        Assert.Equal(
            "2024-06-02T11:00:00",
            row.Cells[new PlacedAtColumn()].Value.TextValue
        );
    }

    [Fact]
    public void CellsContainsOrderStatusColumn()
    {
        IRow row = new SecondOrderRow();

        Assert.True(row.Cells.ContainsKey(new OrderStatusColumn()));
    }

    [Fact]
    public void OrderStatusCellHoldsExpectedText()
    {
        IRow row = new SecondOrderRow();

        Assert.Equal("pending", row.Cells[new OrderStatusColumn()].Value.TextValue);
    }

    [Fact]
    public void CellsContainsPlacedOnColumn()
    {
        IRow row = new SecondOrderRow();

        Assert.True(row.Cells.ContainsKey(new PlacedOnColumn()));
    }

    [Fact]
    public void PlacedOnCellHoldsExpectedText()
    {
        IRow row = new SecondOrderRow();

        Assert.Equal("2024-06-02", row.Cells[new PlacedOnColumn()].Value.TextValue);
    }
}
