using Pure.RelationalSchema.Samples.Columns;
using Pure.RelationalSchema.Storage.Abstractions;
using Pure.RelationalSchema.Storage.HashCodes;
using Pure.RelationalSchema.Storage.Samples.Cells;
using Pure.RelationalSchema.Storage.Samples.Rows;

namespace Pure.RelationalSchema.Storage.Samples.Tests.Rows;

public sealed record TableWithIndexesRowTests
{
    [Fact]
    public void CellsCountIs4()
    {
        IRow row = new TableWithIndexesRow();

        Assert.Equal(4, row.Cells.Count);
    }

    [Fact]
    public void CellsContainsIdColumn()
    {
        IRow row = new TableWithIndexesRow();

        Assert.True(row.Cells.ContainsKey(new IdColumn()));
    }

    [Fact]
    public void IdCellIsUuidCell()
    {
        IRow row = new TableWithIndexesRow();

        Assert.True(
            new CellHash(row.Cells[new IdColumn()]).SequenceEqual(
                new CellHash(new UuidCell())
            )
        );
    }

    [Fact]
    public void CellsContainsTenantIdColumn()
    {
        IRow row = new TableWithIndexesRow();

        Assert.True(row.Cells.ContainsKey(new TenantIdColumn()));
    }

    [Fact]
    public void TenantIdCellIsUuidCell()
    {
        IRow row = new TableWithIndexesRow();

        Assert.True(
            new CellHash(row.Cells[new TenantIdColumn()]).SequenceEqual(
                new CellHash(new UuidCell())
            )
        );
    }

    [Fact]
    public void CellsContainsNameColumn()
    {
        IRow row = new TableWithIndexesRow();

        Assert.True(row.Cells.ContainsKey(new NameColumn()));
    }

    [Fact]
    public void NameCellIsTextCell()
    {
        IRow row = new TableWithIndexesRow();

        Assert.True(
            new CellHash(row.Cells[new NameColumn()]).SequenceEqual(
                new CellHash(new TextCell())
            )
        );
    }

    [Fact]
    public void CellsContainsCreatedAtColumn()
    {
        IRow row = new TableWithIndexesRow();

        Assert.True(row.Cells.ContainsKey(new CreatedAtColumn()));
    }

    [Fact]
    public void CreatedAtCellIsDateTimeCell()
    {
        IRow row = new TableWithIndexesRow();

        Assert.True(
            new CellHash(row.Cells[new CreatedAtColumn()]).SequenceEqual(
                new CellHash(new DateTimeCell())
            )
        );
    }
}
