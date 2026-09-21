using Pure.RelationalSchema.Samples.Columns;
using Pure.RelationalSchema.Storage.Abstractions;
using Pure.RelationalSchema.Storage.HashCodes;
using Pure.RelationalSchema.Storage.Samples.Cells;
using Pure.RelationalSchema.Storage.Samples.Rows;

namespace Pure.RelationalSchema.Storage.Samples.Tests.Rows;

public sealed record TableWithSingleIndexRowTests
{
    [Fact]
    public void CellsCountIs2()
    {
        IRow row = new TableWithSingleIndexRow();

        Assert.Equal(2, row.Cells.Count);
    }

    [Fact]
    public void CellsContainsIdColumn()
    {
        IRow row = new TableWithSingleIndexRow();

        Assert.True(row.Cells.ContainsKey(new IdColumn()));
    }

    [Fact]
    public void IdCellIsUuidCell()
    {
        IRow row = new TableWithSingleIndexRow();

        Assert.True(
            new CellHash(row.Cells[new IdColumn()]).SequenceEqual(
                new CellHash(new UuidCell())
            )
        );
    }

    [Fact]
    public void CellsContainsNameColumn()
    {
        IRow row = new TableWithSingleIndexRow();

        Assert.True(row.Cells.ContainsKey(new NameColumn()));
    }

    [Fact]
    public void NameCellIsTextCell()
    {
        IRow row = new TableWithSingleIndexRow();

        Assert.True(
            new CellHash(row.Cells[new NameColumn()]).SequenceEqual(
                new CellHash(new TextCell())
            )
        );
    }
}
