using Pure.RelationalSchema.Samples.Columns;
using Pure.RelationalSchema.Storage.Abstractions;
using Pure.RelationalSchema.Storage.HashCodes;
using Pure.RelationalSchema.Storage.Samples.Cells;
using Pure.RelationalSchema.Storage.Samples.Rows;

namespace Pure.RelationalSchema.Storage.Samples.Tests.Rows;

public sealed record EmployeeRowTests
{
    [Fact]
    public void CellsCountIs4()
    {
        IRow row = new EmployeeRow();

        Assert.Equal(4, row.Cells.Count);
    }

    [Fact]
    public void CellsContainsIdColumn()
    {
        IRow row = new EmployeeRow();

        Assert.True(row.Cells.ContainsKey(new IdColumn()));
    }

    [Fact]
    public void IdCellIsUuidCell()
    {
        IRow row = new EmployeeRow();

        Assert.True(
            new CellHash(row.Cells[new IdColumn()]).SequenceEqual(
                new CellHash(new UuidCell())
            )
        );
    }

    [Fact]
    public void CellsContainsNameColumn()
    {
        IRow row = new EmployeeRow();

        Assert.True(row.Cells.ContainsKey(new NameColumn()));
    }

    [Fact]
    public void NameCellIsTextCell()
    {
        IRow row = new EmployeeRow();

        Assert.True(
            new CellHash(row.Cells[new NameColumn()]).SequenceEqual(
                new CellHash(new TextCell())
            )
        );
    }

    [Fact]
    public void CellsContainsManagerIdColumn()
    {
        IRow row = new EmployeeRow();

        Assert.True(row.Cells.ContainsKey(new ManagerIdColumn()));
    }

    [Fact]
    public void ManagerIdCellIsUuidCell()
    {
        IRow row = new EmployeeRow();

        Assert.True(
            new CellHash(row.Cells[new ManagerIdColumn()]).SequenceEqual(
                new CellHash(new UuidCell())
            )
        );
    }

    [Fact]
    public void CellsContainsStartTimeColumn()
    {
        IRow row = new EmployeeRow();

        Assert.True(row.Cells.ContainsKey(new StartTimeColumn()));
    }

    [Fact]
    public void StartTimeCellIsTimeCell()
    {
        IRow row = new EmployeeRow();

        Assert.True(
            new CellHash(row.Cells[new StartTimeColumn()]).SequenceEqual(
                new CellHash(new TimeCell())
            )
        );
    }
}
