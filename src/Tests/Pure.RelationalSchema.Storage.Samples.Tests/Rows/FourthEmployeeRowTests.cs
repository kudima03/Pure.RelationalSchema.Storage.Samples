using Pure.RelationalSchema.Samples.Columns;
using Pure.RelationalSchema.Storage.Abstractions;
using Pure.RelationalSchema.Storage.Samples.Rows;

namespace Pure.RelationalSchema.Storage.Samples.Tests.Rows;

public sealed record FourthEmployeeRowTests
{
    [Fact]
    public void CellsCountIs5()
    {
        IRow row = new FourthEmployeeRow();

        Assert.Equal(5, row.Cells.Count);
    }

    [Fact]
    public void CellsContainsEmployeeIdColumn()
    {
        IRow row = new FourthEmployeeRow();

        Assert.True(row.Cells.ContainsKey(new EmployeeIdColumn()));
    }

    [Fact]
    public void EmployeeIdCellHoldsExpectedText()
    {
        IRow row = new FourthEmployeeRow();

        Assert.Equal(
            "000002c0-0000-0000-0000-000000000000",
            row.Cells[new EmployeeIdColumn()].Value.TextValue
        );
    }

    [Fact]
    public void CellsContainsEmployeeNameColumn()
    {
        IRow row = new FourthEmployeeRow();

        Assert.True(row.Cells.ContainsKey(new EmployeeNameColumn()));
    }

    [Fact]
    public void EmployeeNameCellHoldsExpectedText()
    {
        IRow row = new FourthEmployeeRow();

        Assert.Equal("Jack", row.Cells[new EmployeeNameColumn()].Value.TextValue);
    }

    [Fact]
    public void CellsContainsEmployeeManagerIdColumn()
    {
        IRow row = new FourthEmployeeRow();

        Assert.True(row.Cells.ContainsKey(new EmployeeManagerIdColumn()));
    }

    [Fact]
    public void EmployeeManagerIdCellHoldsExpectedText()
    {
        IRow row = new FourthEmployeeRow();

        Assert.Equal(
            "000002be-0000-0000-0000-000000000000",
            row.Cells[new EmployeeManagerIdColumn()].Value.TextValue
        );
    }

    [Fact]
    public void CellsContainsEmployeeShiftStartColumn()
    {
        IRow row = new FourthEmployeeRow();

        Assert.True(row.Cells.ContainsKey(new EmployeeShiftStartColumn()));
    }

    [Fact]
    public void EmployeeShiftStartCellHoldsExpectedText()
    {
        IRow row = new FourthEmployeeRow();

        Assert.Equal(
            "08:00:00",
            row.Cells[new EmployeeShiftStartColumn()].Value.TextValue
        );
    }

    [Fact]
    public void CellsContainsEmployeeUserIdColumn()
    {
        IRow row = new FourthEmployeeRow();

        Assert.True(row.Cells.ContainsKey(new EmployeeUserIdColumn()));
    }

    [Fact]
    public void EmployeeUserIdCellHoldsExpectedText()
    {
        IRow row = new FourthEmployeeRow();

        Assert.Equal(
            "00000004-0000-0000-0000-000000000000",
            row.Cells[new EmployeeUserIdColumn()].Value.TextValue
        );
    }
}
