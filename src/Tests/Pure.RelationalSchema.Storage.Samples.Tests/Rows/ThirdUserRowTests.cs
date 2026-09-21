using Pure.RelationalSchema.Samples.Columns;
using Pure.RelationalSchema.Storage.Abstractions;
using Pure.RelationalSchema.Storage.Samples.Rows;

namespace Pure.RelationalSchema.Storage.Samples.Tests.Rows;

public sealed record ThirdUserRowTests
{
    [Fact]
    public void CellsCountIs13()
    {
        IRow row = new ThirdUserRow();

        Assert.Equal(13, row.Cells.Count);
    }

    [Fact]
    public void CellsContainsUserIdColumn()
    {
        IRow row = new ThirdUserRow();

        Assert.True(row.Cells.ContainsKey(new UserIdColumn()));
    }

    [Fact]
    public void UserIdCellHoldsExpectedText()
    {
        IRow row = new ThirdUserRow();

        Assert.Equal(
            "00000003-0000-0000-0000-000000000000",
            row.Cells[new UserIdColumn()].Value.TextValue
        );
    }

    [Fact]
    public void CellsContainsUserTenantIdColumn()
    {
        IRow row = new ThirdUserRow();

        Assert.True(row.Cells.ContainsKey(new UserTenantIdColumn()));
    }

    [Fact]
    public void UserTenantIdCellHoldsExpectedText()
    {
        IRow row = new ThirdUserRow();

        Assert.Equal(
            "00000385-0000-0000-0000-000000000000",
            row.Cells[new UserTenantIdColumn()].Value.TextValue
        );
    }

    [Fact]
    public void CellsContainsUserNameColumn()
    {
        IRow row = new ThirdUserRow();

        Assert.True(row.Cells.ContainsKey(new UserNameColumn()));
    }

    [Fact]
    public void UserNameCellHoldsExpectedText()
    {
        IRow row = new ThirdUserRow();

        Assert.Equal("Cara", row.Cells[new UserNameColumn()].Value.TextValue);
    }

    [Fact]
    public void CellsContainsSignupDateColumn()
    {
        IRow row = new ThirdUserRow();

        Assert.True(row.Cells.ContainsKey(new SignupDateColumn()));
    }

    [Fact]
    public void SignupDateCellHoldsExpectedText()
    {
        IRow row = new ThirdUserRow();

        Assert.Equal("2019-07-10", row.Cells[new SignupDateColumn()].Value.TextValue);
    }

    [Fact]
    public void CellsContainsUserActiveColumn()
    {
        IRow row = new ThirdUserRow();

        Assert.True(row.Cells.ContainsKey(new UserActiveColumn()));
    }

    [Fact]
    public void UserActiveCellHoldsExpectedText()
    {
        IRow row = new ThirdUserRow();

        Assert.Equal("True", row.Cells[new UserActiveColumn()].Value.TextValue);
    }

    [Fact]
    public void CellsContainsLastLoginColumn()
    {
        IRow row = new ThirdUserRow();

        Assert.True(row.Cells.ContainsKey(new LastLoginColumn()));
    }

    [Fact]
    public void LastLoginCellHoldsExpectedText()
    {
        IRow row = new ThirdUserRow();

        Assert.Equal(
            "2024-05-30T14:00:00",
            row.Cells[new LastLoginColumn()].Value.TextValue
        );
    }

    [Fact]
    public void CellsContainsUserAgeColumn()
    {
        IRow row = new ThirdUserRow();

        Assert.True(row.Cells.ContainsKey(new UserAgeColumn()));
    }

    [Fact]
    public void UserAgeCellHoldsExpectedText()
    {
        IRow row = new ThirdUserRow();

        Assert.Equal("30", row.Cells[new UserAgeColumn()].Value.TextValue);
    }

    [Fact]
    public void CellsContainsShiftStartColumn()
    {
        IRow row = new ThirdUserRow();

        Assert.True(row.Cells.ContainsKey(new ShiftStartColumn()));
    }

    [Fact]
    public void ShiftStartCellHoldsExpectedText()
    {
        IRow row = new ThirdUserRow();

        Assert.Equal("09:00:00", row.Cells[new ShiftStartColumn()].Value.TextValue);
    }

    [Fact]
    public void CellsContainsUserScoreColumn()
    {
        IRow row = new ThirdUserRow();

        Assert.True(row.Cells.ContainsKey(new UserScoreColumn()));
    }

    [Fact]
    public void UserScoreCellHoldsExpectedText()
    {
        IRow row = new ThirdUserRow();

        Assert.Equal("30", row.Cells[new UserScoreColumn()].Value.TextValue);
    }

    [Fact]
    public void CellsContainsUserPrecisionValueColumn()
    {
        IRow row = new ThirdUserRow();

        Assert.True(row.Cells.ContainsKey(new UserPrecisionValueColumn()));
    }

    [Fact]
    public void UserPrecisionValueCellHoldsExpectedText()
    {
        IRow row = new ThirdUserRow();

        Assert.Equal("5E-324", row.Cells[new UserPrecisionValueColumn()].Value.TextValue);
    }

    [Fact]
    public void CellsContainsUserEdgeDateColumn()
    {
        IRow row = new ThirdUserRow();

        Assert.True(row.Cells.ContainsKey(new UserEdgeDateColumn()));
    }

    [Fact]
    public void UserEdgeDateCellHoldsExpectedText()
    {
        IRow row = new ThirdUserRow();

        Assert.Equal("2024-03-10", row.Cells[new UserEdgeDateColumn()].Value.TextValue);
    }

    [Fact]
    public void CellsContainsUserEdgeDateTimeColumn()
    {
        IRow row = new ThirdUserRow();

        Assert.True(row.Cells.ContainsKey(new UserEdgeDateTimeColumn()));
    }

    [Fact]
    public void UserEdgeDateTimeCellHoldsExpectedText()
    {
        IRow row = new ThirdUserRow();

        Assert.Equal(
            "2024-03-10T02:30:00",
            row.Cells[new UserEdgeDateTimeColumn()].Value.TextValue
        );
    }

    [Fact]
    public void CellsContainsUserEdgeTimeColumn()
    {
        IRow row = new ThirdUserRow();

        Assert.True(row.Cells.ContainsKey(new UserEdgeTimeColumn()));
    }

    [Fact]
    public void UserEdgeTimeCellHoldsExpectedText()
    {
        IRow row = new ThirdUserRow();

        Assert.Equal("02:30:00", row.Cells[new UserEdgeTimeColumn()].Value.TextValue);
    }
}
