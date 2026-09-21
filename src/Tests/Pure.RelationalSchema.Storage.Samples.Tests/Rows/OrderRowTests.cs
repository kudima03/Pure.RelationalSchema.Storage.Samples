using Pure.RelationalSchema.Samples.Columns;
using Pure.RelationalSchema.Storage.Abstractions;
using Pure.RelationalSchema.Storage.HashCodes;
using Pure.RelationalSchema.Storage.Samples.Cells;
using Pure.RelationalSchema.Storage.Samples.Rows;

namespace Pure.RelationalSchema.Storage.Samples.Tests.Rows;

public sealed record OrderRowTests
{
    [Fact]
    public void CellsCountIs5()
    {
        IRow row = new OrderRow();

        Assert.Equal(5, row.Cells.Count);
    }

    [Fact]
    public void CellsContainsIdColumn()
    {
        IRow row = new OrderRow();

        Assert.True(row.Cells.ContainsKey(new IdColumn()));
    }

    [Fact]
    public void IdCellIsUuidCell()
    {
        IRow row = new OrderRow();

        Assert.True(
            new CellHash(row.Cells[new IdColumn()]).SequenceEqual(
                new CellHash(new UuidCell())
            )
        );
    }

    [Fact]
    public void CellsContainsTenantIdColumn()
    {
        IRow row = new OrderRow();

        Assert.True(row.Cells.ContainsKey(new TenantIdColumn()));
    }

    [Fact]
    public void TenantIdCellIsUuidCell()
    {
        IRow row = new OrderRow();

        Assert.True(
            new CellHash(row.Cells[new TenantIdColumn()]).SequenceEqual(
                new CellHash(new UuidCell())
            )
        );
    }

    [Fact]
    public void CellsContainsUserIdColumn()
    {
        IRow row = new OrderRow();

        Assert.True(row.Cells.ContainsKey(new UserIdColumn()));
    }

    [Fact]
    public void UserIdCellIsUuidCell()
    {
        IRow row = new OrderRow();

        Assert.True(
            new CellHash(row.Cells[new UserIdColumn()]).SequenceEqual(
                new CellHash(new UuidCell())
            )
        );
    }

    [Fact]
    public void CellsContainsPriceColumn()
    {
        IRow row = new OrderRow();

        Assert.True(row.Cells.ContainsKey(new PriceColumn()));
    }

    [Fact]
    public void PriceCellIsDoubleCell()
    {
        IRow row = new OrderRow();

        Assert.True(
            new CellHash(row.Cells[new PriceColumn()]).SequenceEqual(
                new CellHash(new DoubleCell())
            )
        );
    }

    [Fact]
    public void CellsContainsCreatedAtColumn()
    {
        IRow row = new OrderRow();

        Assert.True(row.Cells.ContainsKey(new CreatedAtColumn()));
    }

    [Fact]
    public void CreatedAtCellIsDateTimeCell()
    {
        IRow row = new OrderRow();

        Assert.True(
            new CellHash(row.Cells[new CreatedAtColumn()]).SequenceEqual(
                new CellHash(new DateTimeCell())
            )
        );
    }
}
