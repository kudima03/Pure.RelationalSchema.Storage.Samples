using Pure.RelationalSchema.Samples.Columns;
using Pure.RelationalSchema.Storage.Abstractions;
using Pure.RelationalSchema.Storage.HashCodes;
using Pure.RelationalSchema.Storage.Samples.Cells;
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
    public void CellsContainsIdColumn()
    {
        IRow row = new OrderItemRow();

        Assert.True(row.Cells.ContainsKey(new IdColumn()));
    }

    [Fact]
    public void IdCellIsUuidCell()
    {
        IRow row = new OrderItemRow();

        Assert.True(
            new CellHash(row.Cells[new IdColumn()]).SequenceEqual(
                new CellHash(new UuidCell())
            )
        );
    }

    [Fact]
    public void CellsContainsTenantIdColumn()
    {
        IRow row = new OrderItemRow();

        Assert.True(row.Cells.ContainsKey(new TenantIdColumn()));
    }

    [Fact]
    public void TenantIdCellIsUuidCell()
    {
        IRow row = new OrderItemRow();

        Assert.True(
            new CellHash(row.Cells[new TenantIdColumn()]).SequenceEqual(
                new CellHash(new UuidCell())
            )
        );
    }

    [Fact]
    public void CellsContainsOrderIdColumn()
    {
        IRow row = new OrderItemRow();

        Assert.True(row.Cells.ContainsKey(new OrderIdColumn()));
    }

    [Fact]
    public void OrderIdCellIsUuidCell()
    {
        IRow row = new OrderItemRow();

        Assert.True(
            new CellHash(row.Cells[new OrderIdColumn()]).SequenceEqual(
                new CellHash(new UuidCell())
            )
        );
    }

    [Fact]
    public void CellsContainsProductIdColumn()
    {
        IRow row = new OrderItemRow();

        Assert.True(row.Cells.ContainsKey(new ProductIdColumn()));
    }

    [Fact]
    public void ProductIdCellIsUuidCell()
    {
        IRow row = new OrderItemRow();

        Assert.True(
            new CellHash(row.Cells[new ProductIdColumn()]).SequenceEqual(
                new CellHash(new UuidCell())
            )
        );
    }

    [Fact]
    public void CellsContainsQuantityColumn()
    {
        IRow row = new OrderItemRow();

        Assert.True(row.Cells.ContainsKey(new QuantityColumn()));
    }

    [Fact]
    public void QuantityCellIsLongCell()
    {
        IRow row = new OrderItemRow();

        Assert.True(
            new CellHash(row.Cells[new QuantityColumn()]).SequenceEqual(
                new CellHash(new LongCell())
            )
        );
    }
}
