using Pure.RelationalSchema.Samples.Columns;
using Pure.RelationalSchema.Storage.Abstractions;
using Pure.RelationalSchema.Storage.Samples.Rows;

namespace Pure.RelationalSchema.Storage.Samples.Tests.Rows;

public sealed record SecondAmbiguousIdLookupRowTests
{
    [Fact]
    public void CellsCountIs2()
    {
        IRow row = new SecondAmbiguousIdLookupRow();

        Assert.Equal(2, row.Cells.Count);
    }

    [Fact]
    public void CellsContainsIdColumn()
    {
        IRow row = new SecondAmbiguousIdLookupRow();

        Assert.True(row.Cells.ContainsKey(new IdColumn()));
    }

    [Fact]
    public void IdCellHoldsExpectedText()
    {
        IRow row = new SecondAmbiguousIdLookupRow();

        Assert.Equal(
            "000001f6-0000-0000-0000-000000000000",
            row.Cells[new IdColumn()].Value.TextValue
        );
    }

    [Fact]
    public void CellsContainsNameColumn()
    {
        IRow row = new SecondAmbiguousIdLookupRow();

        Assert.True(row.Cells.ContainsKey(new NameColumn()));
    }

    [Fact]
    public void NameCellHoldsExpectedText()
    {
        IRow row = new SecondAmbiguousIdLookupRow();

        Assert.Equal("Fitter", row.Cells[new NameColumn()].Value.TextValue);
    }
}
