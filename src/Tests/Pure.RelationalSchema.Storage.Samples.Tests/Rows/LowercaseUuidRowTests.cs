using Pure.RelationalSchema.Samples.Columns;
using Pure.RelationalSchema.Storage.Abstractions;
using Pure.RelationalSchema.Storage.Samples.Rows;

namespace Pure.RelationalSchema.Storage.Samples.Tests.Rows;

public sealed record LowercaseUuidRowTests
{
    [Fact]
    public void CellsCountIs3()
    {
        IRow row = new LowercaseUuidRow();

        Assert.Equal(3, row.Cells.Count);
    }

    [Fact]
    public void CellsContainsIdColumn()
    {
        IRow row = new LowercaseUuidRow();

        Assert.True(row.Cells.ContainsKey(new IdColumn()));
    }

    [Fact]
    public void IdCellHoldsExpectedText()
    {
        IRow row = new LowercaseUuidRow();

        Assert.Equal(
            "0f9e8d7c-6b5a-4938-8271-605f4e3d2c1b",
            row.Cells[new IdColumn()].Value.TextValue
        );
    }

    [Fact]
    public void CellsContainsNameColumn()
    {
        IRow row = new LowercaseUuidRow();

        Assert.True(row.Cells.ContainsKey(new NameColumn()));
    }

    [Fact]
    public void NameCellHoldsExpectedText()
    {
        IRow row = new LowercaseUuidRow();

        Assert.Equal("lowercase", row.Cells[new NameColumn()].Value.TextValue);
    }

    [Fact]
    public void CellsContainsCreatedAtColumn()
    {
        IRow row = new LowercaseUuidRow();

        Assert.True(row.Cells.ContainsKey(new CreatedAtColumn()));
    }

    [Fact]
    public void CreatedAtCellHoldsExpectedText()
    {
        IRow row = new LowercaseUuidRow();

        Assert.Equal(
            "2024-01-01T00:00:00",
            row.Cells[new CreatedAtColumn()].Value.TextValue
        );
    }
}
