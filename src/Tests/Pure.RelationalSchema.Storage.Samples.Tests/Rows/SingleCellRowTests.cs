using Pure.RelationalSchema.Samples.Columns;
using Pure.RelationalSchema.Storage.Abstractions;
using Pure.RelationalSchema.Storage.HashCodes;
using Pure.RelationalSchema.Storage.Samples.Cells;
using Pure.RelationalSchema.Storage.Samples.Rows;

namespace Pure.RelationalSchema.Storage.Samples.Tests.Rows;

public sealed record SingleCellRowTests
{
    [Fact]
    public void CellsCountIs1()
    {
        IRow row = new SingleCellRow();

        _ = Assert.Single(row.Cells);
    }

    [Fact]
    public void CellsContainsIdColumn()
    {
        IRow row = new SingleCellRow();

        Assert.True(row.Cells.ContainsKey(new IdColumn()));
    }

    [Fact]
    public void IdCellIsUuidCell()
    {
        IRow row = new SingleCellRow();

        Assert.True(
            new CellHash(row.Cells[new IdColumn()]).SequenceEqual(
                new CellHash(new UuidCell())
            )
        );
    }
}
