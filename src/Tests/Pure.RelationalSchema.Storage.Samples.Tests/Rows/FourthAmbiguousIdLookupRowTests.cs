using Pure.RelationalSchema.Samples.Columns;
using Pure.RelationalSchema.Storage.Abstractions;
using Pure.RelationalSchema.Storage.Samples.Rows;

namespace Pure.RelationalSchema.Storage.Samples.Tests.Rows;

public sealed record FourthAmbiguousIdLookupRowTests
{
    [Fact]
    public void CellsCountIs2()
    {
        IRow row = new FourthAmbiguousIdLookupRow();

        Assert.Equal(2, row.Cells.Count);
    }

    [Fact]
    public void CellsContainsIdColumn()
    {
        IRow row = new FourthAmbiguousIdLookupRow();

        Assert.True(row.Cells.ContainsKey(new IdColumn()));
    }

    [Fact]
    public void IdCellHoldsExpectedText()
    {
        IRow row = new FourthAmbiguousIdLookupRow();

        Assert.Equal(
            "000001f8-0000-0000-0000-000000000000",
            row.Cells[new IdColumn()].Value.TextValue
        );
    }

    [Fact]
    public void CellsContainsNameColumn()
    {
        IRow row = new FourthAmbiguousIdLookupRow();

        Assert.True(row.Cells.ContainsKey(new NameColumn()));
    }

    [Fact]
    public void NameCellHoldsExpectedText()
    {
        IRow row = new FourthAmbiguousIdLookupRow();

        Assert.Equal("Rigger", row.Cells[new NameColumn()].Value.TextValue);
    }
}
