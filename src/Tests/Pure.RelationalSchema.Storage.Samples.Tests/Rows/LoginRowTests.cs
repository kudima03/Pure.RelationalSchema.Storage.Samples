using Pure.RelationalSchema.Samples.Columns;
using Pure.RelationalSchema.Storage.Abstractions;
using Pure.RelationalSchema.Storage.Samples.Rows;

namespace Pure.RelationalSchema.Storage.Samples.Tests.Rows;

public sealed record LoginRowTests
{
    [Fact]
    public void CellsCountIs3()
    {
        IRow row = new LoginRow();

        Assert.Equal(3, row.Cells.Count);
    }

    [Fact]
    public void CellsContainsLoginIdColumn()
    {
        IRow row = new LoginRow();

        Assert.True(row.Cells.ContainsKey(new LoginIdColumn()));
    }

    [Fact]
    public void LoginIdCellHoldsExpectedText()
    {
        IRow row = new LoginRow();

        Assert.Equal(
            "00000191-0000-0000-0000-000000000000",
            row.Cells[new LoginIdColumn()].Value.TextValue
        );
    }

    [Fact]
    public void CellsContainsLoginUserIdColumn()
    {
        IRow row = new LoginRow();

        Assert.True(row.Cells.ContainsKey(new LoginUserIdColumn()));
    }

    [Fact]
    public void LoginUserIdCellHoldsExpectedText()
    {
        IRow row = new LoginRow();

        Assert.Equal(
            "00000001-0000-0000-0000-000000000000",
            row.Cells[new LoginUserIdColumn()].Value.TextValue
        );
    }

    [Fact]
    public void CellsContainsLoginAtColumn()
    {
        IRow row = new LoginRow();

        Assert.True(row.Cells.ContainsKey(new LoginAtColumn()));
    }

    [Fact]
    public void LoginAtCellHoldsExpectedText()
    {
        IRow row = new LoginRow();

        Assert.Equal(
            "2024-06-01T07:00:00",
            row.Cells[new LoginAtColumn()].Value.TextValue
        );
    }
}
