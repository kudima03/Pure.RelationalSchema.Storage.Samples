using Pure.RelationalSchema.Samples.Columns;
using Pure.RelationalSchema.Storage.Abstractions;
using Pure.RelationalSchema.Storage.Samples.Rows;

namespace Pure.RelationalSchema.Storage.Samples.Tests.Rows;

public sealed record SixthUserRowTests
{
    [Fact]
    public void CellsCountIs13()
    {
        IRow row = new SixthUserRow();

        Assert.Equal(13, row.Cells.Count);
    }

    [Fact]
    public void CellsContainsUserIdColumn()
    {
        IRow row = new SixthUserRow();

        Assert.True(row.Cells.ContainsKey(new UserIdColumn()));
    }

    [Fact]
    public void UserIdCellHoldsExpectedText()
    {
        IRow row = new SixthUserRow();

        Assert.Equal(
            "00000006-0000-0000-0000-000000000000",
            row.Cells[new UserIdColumn()].Value.TextValue
        );
    }

    [Fact]
    public void CellsContainsUserTenantIdColumn()
    {
        IRow row = new SixthUserRow();

        Assert.True(row.Cells.ContainsKey(new UserTenantIdColumn()));
    }

    [Fact]
    public void UserTenantIdCellHoldsExpectedText()
    {
        IRow row = new SixthUserRow();

        Assert.Equal(
            "00000386-0000-0000-0000-000000000000",
            row.Cells[new UserTenantIdColumn()].Value.TextValue
        );
    }

    [Fact]
    public void CellsContainsUserNameColumn()
    {
        IRow row = new SixthUserRow();

        Assert.True(row.Cells.ContainsKey(new UserNameColumn()));
    }

    [Fact]
    public void UserNameCellHoldsExpectedText()
    {
        IRow row = new SixthUserRow();

        Assert.Equal("Fay", row.Cells[new UserNameColumn()].Value.TextValue);
    }

    [Fact]
    public void CellsContainsSignupDateColumn()
    {
        IRow row = new SixthUserRow();

        Assert.True(row.Cells.ContainsKey(new SignupDateColumn()));
    }

    [Fact]
    public void SignupDateCellHoldsExpectedText()
    {
        IRow row = new SixthUserRow();

        Assert.Equal("2020-01-15", row.Cells[new SignupDateColumn()].Value.TextValue);
    }

    [Fact]
    public void CellsContainsUserActiveColumn()
    {
        IRow row = new SixthUserRow();

        Assert.True(row.Cells.ContainsKey(new UserActiveColumn()));
    }

    [Fact]
    public void UserActiveCellHoldsExpectedText()
    {
        IRow row = new SixthUserRow();

        Assert.Equal("True", row.Cells[new UserActiveColumn()].Value.TextValue);
    }

    [Fact]
    public void CellsContainsLastLoginColumn()
    {
        IRow row = new SixthUserRow();

        Assert.True(row.Cells.ContainsKey(new LastLoginColumn()));
    }

    [Fact]
    public void LastLoginCellHoldsExpectedText()
    {
        IRow row = new SixthUserRow();

        Assert.Equal(
            "2024-06-01T08:30:00",
            row.Cells[new LastLoginColumn()].Value.TextValue
        );
    }

    [Fact]
    public void CellsContainsUserAgeColumn()
    {
        IRow row = new SixthUserRow();

        Assert.True(row.Cells.ContainsKey(new UserAgeColumn()));
    }

    [Fact]
    public void UserAgeCellHoldsExpectedText()
    {
        IRow row = new SixthUserRow();

        Assert.Equal("28", row.Cells[new UserAgeColumn()].Value.TextValue);
    }

    [Fact]
    public void CellsContainsShiftStartColumn()
    {
        IRow row = new SixthUserRow();

        Assert.True(row.Cells.ContainsKey(new ShiftStartColumn()));
    }

    [Fact]
    public void ShiftStartCellHoldsExpectedText()
    {
        IRow row = new SixthUserRow();

        Assert.Equal("09:00:00", row.Cells[new ShiftStartColumn()].Value.TextValue);
    }

    [Fact]
    public void CellsContainsUserScoreColumn()
    {
        IRow row = new SixthUserRow();

        Assert.True(row.Cells.ContainsKey(new UserScoreColumn()));
    }

    [Fact]
    public void UserScoreCellHoldsExpectedText()
    {
        IRow row = new SixthUserRow();

        Assert.Equal("28", row.Cells[new UserScoreColumn()].Value.TextValue);
    }

    [Fact]
    public void CellsContainsUserPrecisionValueColumn()
    {
        IRow row = new SixthUserRow();

        Assert.True(row.Cells.ContainsKey(new UserPrecisionValueColumn()));
    }

    [Fact]
    public void UserPrecisionValueCellHoldsExpectedText()
    {
        IRow row = new SixthUserRow();

        Assert.Equal(
            "123456789.123456",
            row.Cells[new UserPrecisionValueColumn()].Value.TextValue
        );
    }

    [Fact]
    public void CellsContainsUserEdgeDateColumn()
    {
        IRow row = new SixthUserRow();

        Assert.True(row.Cells.ContainsKey(new UserEdgeDateColumn()));
    }

    [Fact]
    public void UserEdgeDateCellHoldsExpectedText()
    {
        IRow row = new SixthUserRow();

        Assert.Equal("9999-12-31", row.Cells[new UserEdgeDateColumn()].Value.TextValue);
    }

    [Fact]
    public void CellsContainsUserEdgeDateTimeColumn()
    {
        IRow row = new SixthUserRow();

        Assert.True(row.Cells.ContainsKey(new UserEdgeDateTimeColumn()));
    }

    [Fact]
    public void UserEdgeDateTimeCellHoldsExpectedText()
    {
        IRow row = new SixthUserRow();

        Assert.Equal(
            "9999-12-31T23:59:59",
            row.Cells[new UserEdgeDateTimeColumn()].Value.TextValue
        );
    }

    [Fact]
    public void CellsContainsUserEdgeTimeColumn()
    {
        IRow row = new SixthUserRow();

        Assert.True(row.Cells.ContainsKey(new UserEdgeTimeColumn()));
    }

    [Fact]
    public void UserEdgeTimeCellHoldsExpectedText()
    {
        IRow row = new SixthUserRow();

        Assert.Equal("23:59:59", row.Cells[new UserEdgeTimeColumn()].Value.TextValue);
    }
}
