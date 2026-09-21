using Pure.RelationalSchema.Samples.Columns;
using Pure.RelationalSchema.Storage.Abstractions;
using Pure.RelationalSchema.Storage.Samples.Rows;

namespace Pure.RelationalSchema.Storage.Samples.Tests.Rows;

public sealed record FourthProductRowTests
{
    [Fact]
    public void CellsCountIs5()
    {
        IRow row = new FourthProductRow();

        Assert.Equal(5, row.Cells.Count);
    }

    [Fact]
    public void CellsContainsProductIdColumn()
    {
        IRow row = new FourthProductRow();

        Assert.True(row.Cells.ContainsKey(new ProductIdColumn()));
    }

    [Fact]
    public void ProductIdCellHoldsExpectedText()
    {
        IRow row = new FourthProductRow();

        Assert.Equal(
            "000000cc-0000-0000-0000-000000000000",
            row.Cells[new ProductIdColumn()].Value.TextValue
        );
    }

    [Fact]
    public void CellsContainsProductNameColumn()
    {
        IRow row = new FourthProductRow();

        Assert.True(row.Cells.ContainsKey(new ProductNameColumn()));
    }

    [Fact]
    public void ProductNameCellHoldsExpectedText()
    {
        IRow row = new FourthProductRow();

        Assert.Equal("Deluxe", row.Cells[new ProductNameColumn()].Value.TextValue);
    }

    [Fact]
    public void CellsContainsProductDescriptionColumn()
    {
        IRow row = new FourthProductRow();

        Assert.True(row.Cells.ContainsKey(new ProductDescriptionColumn()));
    }

    [Fact]
    public void ProductDescriptionCellHoldsExpectedText()
    {
        IRow row = new FourthProductRow();

        Assert.Equal(
            "Deluxe bundle",
            row.Cells[new ProductDescriptionColumn()].Value.TextValue
        );
    }

    [Fact]
    public void CellsContainsProductPriceColumn()
    {
        IRow row = new FourthProductRow();

        Assert.True(row.Cells.ContainsKey(new ProductPriceColumn()));
    }

    [Fact]
    public void ProductPriceCellHoldsExpectedText()
    {
        IRow row = new FourthProductRow();

        Assert.Equal("250", row.Cells[new ProductPriceColumn()].Value.TextValue);
    }

    [Fact]
    public void CellsContainsProductInStockColumn()
    {
        IRow row = new FourthProductRow();

        Assert.True(row.Cells.ContainsKey(new ProductInStockColumn()));
    }

    [Fact]
    public void ProductInStockCellHoldsExpectedText()
    {
        IRow row = new FourthProductRow();

        Assert.Equal("True", row.Cells[new ProductInStockColumn()].Value.TextValue);
    }
}
