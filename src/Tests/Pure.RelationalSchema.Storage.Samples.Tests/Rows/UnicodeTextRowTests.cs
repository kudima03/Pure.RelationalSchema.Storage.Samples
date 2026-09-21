using Pure.RelationalSchema.Samples.Columns;
using Pure.RelationalSchema.Storage.Abstractions;
using Pure.RelationalSchema.Storage.HashCodes;
using Pure.RelationalSchema.Storage.Samples.Cells;
using Pure.RelationalSchema.Storage.Samples.Rows;

namespace Pure.RelationalSchema.Storage.Samples.Tests.Rows;

public sealed record UnicodeTextRowTests
{
    [Fact]
    public void CellsCountIs3()
    {
        IRow row = new UnicodeTextRow();

        Assert.Equal(3, row.Cells.Count);
    }

    [Fact]
    public void CellsContainsIdColumn()
    {
        IRow row = new UnicodeTextRow();

        Assert.True(row.Cells.ContainsKey(new IdColumn()));
    }

    [Fact]
    public void IdCellIsUuidCell()
    {
        IRow row = new UnicodeTextRow();

        Assert.True(
            new CellHash(row.Cells[new IdColumn()]).SequenceEqual(
                new CellHash(new UuidCell())
            )
        );
    }

    [Fact]
    public void CellsContainsNameColumn()
    {
        IRow row = new UnicodeTextRow();

        Assert.True(row.Cells.ContainsKey(new NameColumn()));
    }

    [Fact]
    public void NameCellIsUnicodeCell()
    {
        IRow row = new UnicodeTextRow();

        Assert.True(
            new CellHash(row.Cells[new NameColumn()]).SequenceEqual(
                new CellHash(new UnicodeCell())
            )
        );
    }

    [Fact]
    public void CellsContainsCreatedAtColumn()
    {
        IRow row = new UnicodeTextRow();

        Assert.True(row.Cells.ContainsKey(new CreatedAtColumn()));
    }

    [Fact]
    public void CreatedAtCellIsDateTimeCell()
    {
        IRow row = new UnicodeTextRow();

        Assert.True(
            new CellHash(row.Cells[new CreatedAtColumn()]).SequenceEqual(
                new CellHash(new DateTimeCell())
            )
        );
    }
}
