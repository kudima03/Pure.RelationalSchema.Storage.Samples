using Pure.RelationalSchema.Samples.Columns;
using Pure.RelationalSchema.Storage.Abstractions;
using Pure.RelationalSchema.Storage.Samples.Rows;

namespace Pure.RelationalSchema.Storage.Samples.Tests.Rows;

public sealed record EmployeeRowTests
{
    [Fact]
    public void CellsCountIs5()
    {
        IRow row = new EmployeeRow();

        Assert.Equal(5, row.Cells.Count);
    }

    [Fact]
    public void CellsContainsEmployeeIdColumn()
    {
        IRow row = new EmployeeRow();

        Assert.True(row.Cells.ContainsKey(new EmployeeIdColumn()));
    }

    [Fact]
    public void EmployeeIdCellHoldsExpectedText()
    {
        IRow row = new EmployeeRow();

        Assert.Equal(
            "000002bd-0000-0000-0000-000000000000",
            row.Cells[new EmployeeIdColumn()].Value.TextValue
        );
    }

    [Fact]
    public void CellsContainsEmployeeNameColumn()
    {
        IRow row = new EmployeeRow();

        Assert.True(row.Cells.ContainsKey(new EmployeeNameColumn()));
    }

    [Fact]
    public void EmployeeNameCellHoldsExpectedText()
    {
        IRow row = new EmployeeRow();

        Assert.Equal("Grace", row.Cells[new EmployeeNameColumn()].Value.TextValue);
    }

    [Fact]
    public void CellsContainsEmployeeManagerIdColumn()
    {
        IRow row = new EmployeeRow();

        Assert.True(row.Cells.ContainsKey(new EmployeeManagerIdColumn()));
    }

    [Fact]
    public void EmployeeManagerIdCellHoldsExpectedText()
    {
        IRow row = new EmployeeRow();

        Assert.Equal(
            string.Empty,
            row.Cells[new EmployeeManagerIdColumn()].Value.TextValue
        );
    }

    [Fact]
    public void CellsContainsEmployeeShiftStartColumn()
    {
        IRow row = new EmployeeRow();

        Assert.True(row.Cells.ContainsKey(new EmployeeShiftStartColumn()));
    }

    [Fact]
    public void EmployeeShiftStartCellHoldsExpectedText()
    {
        IRow row = new EmployeeRow();

        Assert.Equal(
            "09:00:00",
            row.Cells[new EmployeeShiftStartColumn()].Value.TextValue
        );
    }

    [Fact]
    public void CellsContainsEmployeeUserIdColumn()
    {
        IRow row = new EmployeeRow();

        Assert.True(row.Cells.ContainsKey(new EmployeeUserIdColumn()));
    }

    [Fact]
    public void EmployeeUserIdCellHoldsExpectedText()
    {
        IRow row = new EmployeeRow();

        Assert.Equal(
            "00000001-0000-0000-0000-000000000000",
            row.Cells[new EmployeeUserIdColumn()].Value.TextValue
        );
    }
}
