using Pure.RelationalSchema.Samples.Columns;
using Pure.RelationalSchema.Storage.Abstractions;
using Pure.RelationalSchema.Storage.Samples.Rows;

namespace Pure.RelationalSchema.Storage.Samples.Tests.Rows;

public sealed record SecondEmployeeRowTests
{
    [Fact]
    public void CellsCountIs5()
    {
        IRow row = new SecondEmployeeRow();

        Assert.Equal(5, row.Cells.Count);
    }

    [Fact]
    public void CellsContainsEmployeeIdColumn()
    {
        IRow row = new SecondEmployeeRow();

        Assert.True(row.Cells.ContainsKey(new EmployeeIdColumn()));
    }

    [Fact]
    public void EmployeeIdCellHoldsExpectedText()
    {
        IRow row = new SecondEmployeeRow();

        Assert.Equal(
            "000002be-0000-0000-0000-000000000000",
            row.Cells[new EmployeeIdColumn()].Value.TextValue
        );
    }

    [Fact]
    public void CellsContainsEmployeeNameColumn()
    {
        IRow row = new SecondEmployeeRow();

        Assert.True(row.Cells.ContainsKey(new EmployeeNameColumn()));
    }

    [Fact]
    public void EmployeeNameCellHoldsExpectedText()
    {
        IRow row = new SecondEmployeeRow();

        Assert.Equal("Hank", row.Cells[new EmployeeNameColumn()].Value.TextValue);
    }

    [Fact]
    public void CellsContainsEmployeeManagerIdColumn()
    {
        IRow row = new SecondEmployeeRow();

        Assert.True(row.Cells.ContainsKey(new EmployeeManagerIdColumn()));
    }

    [Fact]
    public void EmployeeManagerIdCellHoldsExpectedText()
    {
        IRow row = new SecondEmployeeRow();

        Assert.Equal(
            "000002bd-0000-0000-0000-000000000000",
            row.Cells[new EmployeeManagerIdColumn()].Value.TextValue
        );
    }

    [Fact]
    public void CellsContainsEmployeeShiftStartColumn()
    {
        IRow row = new SecondEmployeeRow();

        Assert.True(row.Cells.ContainsKey(new EmployeeShiftStartColumn()));
    }

    [Fact]
    public void EmployeeShiftStartCellHoldsExpectedText()
    {
        IRow row = new SecondEmployeeRow();

        Assert.Equal(
            "10:00:00",
            row.Cells[new EmployeeShiftStartColumn()].Value.TextValue
        );
    }

    [Fact]
    public void CellsContainsEmployeeUserIdColumn()
    {
        IRow row = new SecondEmployeeRow();

        Assert.True(row.Cells.ContainsKey(new EmployeeUserIdColumn()));
    }

    [Fact]
    public void EmployeeUserIdCellHoldsExpectedText()
    {
        IRow row = new SecondEmployeeRow();

        Assert.Equal(
            "00000002-0000-0000-0000-000000000000",
            row.Cells[new EmployeeUserIdColumn()].Value.TextValue
        );
    }
}
