using Pure.RelationalSchema.Samples.Columns;
using Pure.RelationalSchema.Storage.Abstractions;
using Pure.RelationalSchema.Storage.HashCodes;
using Pure.RelationalSchema.Storage.Samples.Cells;
using Pure.RelationalSchema.Storage.Samples.Rows;

namespace Pure.RelationalSchema.Storage.Samples.Tests.Rows;

public sealed record ProductRowTests
{
    [Fact]
    public void CellsCountIs4()
    {
        IRow row = new ProductRow();

        Assert.Equal(4, row.Cells.Count);
    }

    [Fact]
    public void CellsContainsIdColumn()
    {
        IRow row = new ProductRow();

        Assert.True(row.Cells.ContainsKey(new IdColumn()));
    }

    [Fact]
    public void IdCellIsUuidCell()
    {
        IRow row = new ProductRow();

        Assert.True(
            new CellHash(row.Cells[new IdColumn()]).SequenceEqual(
                new CellHash(new UuidCell())
            )
        );
    }

    [Fact]
    public void CellsContainsNameColumn()
    {
        IRow row = new ProductRow();

        Assert.True(row.Cells.ContainsKey(new NameColumn()));
    }

    [Fact]
    public void NameCellIsTextCell()
    {
        IRow row = new ProductRow();

        Assert.True(
            new CellHash(row.Cells[new NameColumn()]).SequenceEqual(
                new CellHash(new TextCell())
            )
        );
    }

    [Fact]
    public void CellsContainsDescriptionColumn()
    {
        IRow row = new ProductRow();

        Assert.True(row.Cells.ContainsKey(new DescriptionColumn()));
    }

    [Fact]
    public void DescriptionCellIsTextCell()
    {
        IRow row = new ProductRow();

        Assert.True(
            new CellHash(row.Cells[new DescriptionColumn()]).SequenceEqual(
                new CellHash(new TextCell())
            )
        );
    }

    [Fact]
    public void CellsContainsPriceColumn()
    {
        IRow row = new ProductRow();

        Assert.True(row.Cells.ContainsKey(new PriceColumn()));
    }

    [Fact]
    public void PriceCellIsDoubleCell()
    {
        IRow row = new ProductRow();

        Assert.True(
            new CellHash(row.Cells[new PriceColumn()]).SequenceEqual(
                new CellHash(new DoubleCell())
            )
        );
    }
}
