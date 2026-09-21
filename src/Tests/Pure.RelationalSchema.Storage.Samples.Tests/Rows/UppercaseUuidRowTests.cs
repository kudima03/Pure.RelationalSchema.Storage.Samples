using Pure.RelationalSchema.Samples.Columns;
using Pure.RelationalSchema.Storage.Abstractions;
using Pure.RelationalSchema.Storage.Samples.Rows;

namespace Pure.RelationalSchema.Storage.Samples.Tests.Rows;

public sealed record UppercaseUuidRowTests
{
    [Fact]
    public void CellsCountIs3()
    {
        IRow row = new UppercaseUuidRow();

        Assert.Equal(3, row.Cells.Count);
    }

    [Fact]
    public void CellsContainsIdColumn()
    {
        IRow row = new UppercaseUuidRow();

        Assert.True(row.Cells.ContainsKey(new IdColumn()));
    }

    [Fact]
    public void IdCellHoldsExpectedText()
    {
        IRow row = new UppercaseUuidRow();

        Assert.Equal(
            "0F9E8D7C-6B5A-4938-8271-605F4E3D2C1B",
            row.Cells[new IdColumn()].Value.TextValue
        );
    }

    [Fact]
    public void CellsContainsNameColumn()
    {
        IRow row = new UppercaseUuidRow();

        Assert.True(row.Cells.ContainsKey(new NameColumn()));
    }

    [Fact]
    public void NameCellHoldsExpectedText()
    {
        IRow row = new UppercaseUuidRow();

        Assert.Equal("uppercase", row.Cells[new NameColumn()].Value.TextValue);
    }

    [Fact]
    public void CellsContainsCreatedAtColumn()
    {
        IRow row = new UppercaseUuidRow();

        Assert.True(row.Cells.ContainsKey(new CreatedAtColumn()));
    }

    [Fact]
    public void CreatedAtCellHoldsExpectedText()
    {
        IRow row = new UppercaseUuidRow();

        Assert.Equal(
            "2024-01-02T00:00:00",
            row.Cells[new CreatedAtColumn()].Value.TextValue
        );
    }
}
