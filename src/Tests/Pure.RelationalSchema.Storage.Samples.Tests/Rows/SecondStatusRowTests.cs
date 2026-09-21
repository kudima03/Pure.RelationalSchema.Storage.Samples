using Pure.RelationalSchema.Samples.Columns;
using Pure.RelationalSchema.Storage.Abstractions;
using Pure.RelationalSchema.Storage.Samples.Rows;

namespace Pure.RelationalSchema.Storage.Samples.Tests.Rows;

public sealed record SecondStatusRowTests
{
    [Fact]
    public void CellsCountIs3()
    {
        IRow row = new SecondStatusRow();

        Assert.Equal(3, row.Cells.Count);
    }

    [Fact]
    public void CellsContainsStatusCodeColumn()
    {
        IRow row = new SecondStatusRow();

        Assert.True(row.Cells.ContainsKey(new StatusCodeColumn()));
    }

    [Fact]
    public void StatusCodeCellHoldsExpectedText()
    {
        IRow row = new SecondStatusRow();

        Assert.Equal("pending", row.Cells[new StatusCodeColumn()].Value.TextValue);
    }

    [Fact]
    public void CellsContainsStatusLabelColumn()
    {
        IRow row = new SecondStatusRow();

        Assert.True(row.Cells.ContainsKey(new StatusLabelColumn()));
    }

    [Fact]
    public void StatusLabelCellHoldsExpectedText()
    {
        IRow row = new SecondStatusRow();

        Assert.Equal("Pending", row.Cells[new StatusLabelColumn()].Value.TextValue);
    }

    [Fact]
    public void CellsContainsStatusIsFinalColumn()
    {
        IRow row = new SecondStatusRow();

        Assert.True(row.Cells.ContainsKey(new StatusIsFinalColumn()));
    }

    [Fact]
    public void StatusIsFinalCellHoldsExpectedText()
    {
        IRow row = new SecondStatusRow();

        Assert.Equal("False", row.Cells[new StatusIsFinalColumn()].Value.TextValue);
    }
}
