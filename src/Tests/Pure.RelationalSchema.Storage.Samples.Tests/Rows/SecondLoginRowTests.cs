using Pure.RelationalSchema.Samples.Columns;
using Pure.RelationalSchema.Storage.Abstractions;
using Pure.RelationalSchema.Storage.Samples.Rows;

namespace Pure.RelationalSchema.Storage.Samples.Tests.Rows;

public sealed record SecondLoginRowTests
{
    [Fact]
    public void CellsCountIs3()
    {
        IRow row = new SecondLoginRow();

        Assert.Equal(3, row.Cells.Count);
    }

    [Fact]
    public void CellsContainsLoginIdColumn()
    {
        IRow row = new SecondLoginRow();

        Assert.True(row.Cells.ContainsKey(new LoginIdColumn()));
    }

    [Fact]
    public void LoginIdCellHoldsExpectedText()
    {
        IRow row = new SecondLoginRow();

        Assert.Equal(
            "00000192-0000-0000-0000-000000000000",
            row.Cells[new LoginIdColumn()].Value.TextValue
        );
    }

    [Fact]
    public void CellsContainsLoginUserIdColumn()
    {
        IRow row = new SecondLoginRow();

        Assert.True(row.Cells.ContainsKey(new LoginUserIdColumn()));
    }

    [Fact]
    public void LoginUserIdCellHoldsExpectedText()
    {
        IRow row = new SecondLoginRow();

        Assert.Equal(
            "00000001-0000-0000-0000-000000000000",
            row.Cells[new LoginUserIdColumn()].Value.TextValue
        );
    }

    [Fact]
    public void CellsContainsLoginAtColumn()
    {
        IRow row = new SecondLoginRow();

        Assert.True(row.Cells.ContainsKey(new LoginAtColumn()));
    }

    [Fact]
    public void LoginAtCellHoldsExpectedText()
    {
        IRow row = new SecondLoginRow();

        Assert.Equal(
            "2024-06-02T07:30:00",
            row.Cells[new LoginAtColumn()].Value.TextValue
        );
    }
}
