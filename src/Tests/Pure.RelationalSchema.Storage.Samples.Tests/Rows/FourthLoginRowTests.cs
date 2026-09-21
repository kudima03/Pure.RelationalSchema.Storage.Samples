using Pure.RelationalSchema.Samples.Columns;
using Pure.RelationalSchema.Storage.Abstractions;
using Pure.RelationalSchema.Storage.Samples.Rows;

namespace Pure.RelationalSchema.Storage.Samples.Tests.Rows;

public sealed record FourthLoginRowTests
{
    [Fact]
    public void CellsCountIs3()
    {
        IRow row = new FourthLoginRow();

        Assert.Equal(3, row.Cells.Count);
    }

    [Fact]
    public void CellsContainsLoginIdColumn()
    {
        IRow row = new FourthLoginRow();

        Assert.True(row.Cells.ContainsKey(new LoginIdColumn()));
    }

    [Fact]
    public void LoginIdCellHoldsExpectedText()
    {
        IRow row = new FourthLoginRow();

        Assert.Equal(
            "00000194-0000-0000-0000-000000000000",
            row.Cells[new LoginIdColumn()].Value.TextValue
        );
    }

    [Fact]
    public void CellsContainsLoginUserIdColumn()
    {
        IRow row = new FourthLoginRow();

        Assert.True(row.Cells.ContainsKey(new LoginUserIdColumn()));
    }

    [Fact]
    public void LoginUserIdCellHoldsExpectedText()
    {
        IRow row = new FourthLoginRow();

        Assert.Equal(
            "00000005-0000-0000-0000-000000000000",
            row.Cells[new LoginUserIdColumn()].Value.TextValue
        );
    }

    [Fact]
    public void CellsContainsLoginAtColumn()
    {
        IRow row = new FourthLoginRow();

        Assert.True(row.Cells.ContainsKey(new LoginAtColumn()));
    }

    [Fact]
    public void LoginAtCellHoldsExpectedText()
    {
        IRow row = new FourthLoginRow();

        Assert.Equal(
            "2024-06-04T06:45:00",
            row.Cells[new LoginAtColumn()].Value.TextValue
        );
    }
}
