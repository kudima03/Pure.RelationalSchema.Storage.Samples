using Pure.RelationalSchema.Samples.Columns;
using Pure.RelationalSchema.Storage.Abstractions;
using Pure.RelationalSchema.Storage.Samples.Rows;

namespace Pure.RelationalSchema.Storage.Samples.Tests.Rows;

public sealed record ThirdOrderRowTests
{
    [Fact]
    public void CellsCountIs7()
    {
        IRow row = new ThirdOrderRow();

        Assert.Equal(7, row.Cells.Count);
    }

    [Fact]
    public void CellsContainsOrderIdColumn()
    {
        IRow row = new ThirdOrderRow();

        Assert.True(row.Cells.ContainsKey(new OrderIdColumn()));
    }

    [Fact]
    public void OrderIdCellHoldsExpectedText()
    {
        IRow row = new ThirdOrderRow();

        Assert.Equal(
            "00000067-0000-0000-0000-000000000000",
            row.Cells[new OrderIdColumn()].Value.TextValue
        );
    }

    [Fact]
    public void CellsContainsOrderTenantIdColumn()
    {
        IRow row = new ThirdOrderRow();

        Assert.True(row.Cells.ContainsKey(new OrderTenantIdColumn()));
    }

    [Fact]
    public void OrderTenantIdCellHoldsExpectedText()
    {
        IRow row = new ThirdOrderRow();

        Assert.Equal(
            "00000385-0000-0000-0000-000000000000",
            row.Cells[new OrderTenantIdColumn()].Value.TextValue
        );
    }

    [Fact]
    public void CellsContainsOrderUserIdColumn()
    {
        IRow row = new ThirdOrderRow();

        Assert.True(row.Cells.ContainsKey(new OrderUserIdColumn()));
    }

    [Fact]
    public void OrderUserIdCellHoldsExpectedText()
    {
        IRow row = new ThirdOrderRow();

        Assert.Equal(
            "00000002-0000-0000-0000-000000000000",
            row.Cells[new OrderUserIdColumn()].Value.TextValue
        );
    }

    [Fact]
    public void CellsContainsOrderTotalColumn()
    {
        IRow row = new ThirdOrderRow();

        Assert.True(row.Cells.ContainsKey(new OrderTotalColumn()));
    }

    [Fact]
    public void OrderTotalCellHoldsExpectedText()
    {
        IRow row = new ThirdOrderRow();

        Assert.Equal("200", row.Cells[new OrderTotalColumn()].Value.TextValue);
    }

    [Fact]
    public void CellsContainsPlacedAtColumn()
    {
        IRow row = new ThirdOrderRow();

        Assert.True(row.Cells.ContainsKey(new PlacedAtColumn()));
    }

    [Fact]
    public void PlacedAtCellHoldsExpectedText()
    {
        IRow row = new ThirdOrderRow();

        Assert.Equal(
            "2024-06-03T12:00:00",
            row.Cells[new PlacedAtColumn()].Value.TextValue
        );
    }

    [Fact]
    public void CellsContainsOrderStatusColumn()
    {
        IRow row = new ThirdOrderRow();

        Assert.True(row.Cells.ContainsKey(new OrderStatusColumn()));
    }

    [Fact]
    public void OrderStatusCellHoldsExpectedText()
    {
        IRow row = new ThirdOrderRow();

        Assert.Equal("shipped", row.Cells[new OrderStatusColumn()].Value.TextValue);
    }

    [Fact]
    public void CellsContainsPlacedOnColumn()
    {
        IRow row = new ThirdOrderRow();

        Assert.True(row.Cells.ContainsKey(new PlacedOnColumn()));
    }

    [Fact]
    public void PlacedOnCellHoldsExpectedText()
    {
        IRow row = new ThirdOrderRow();

        Assert.Equal("2024-06-03", row.Cells[new PlacedOnColumn()].Value.TextValue);
    }
}
