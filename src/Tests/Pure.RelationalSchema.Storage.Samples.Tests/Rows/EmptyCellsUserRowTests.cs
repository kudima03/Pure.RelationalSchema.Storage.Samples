using Pure.RelationalSchema.Samples.Columns;
using Pure.RelationalSchema.Storage.Abstractions;
using Pure.RelationalSchema.Storage.HashCodes;
using Pure.RelationalSchema.Storage.Samples.Cells;
using Pure.RelationalSchema.Storage.Samples.Rows;

namespace Pure.RelationalSchema.Storage.Samples.Tests.Rows;

public sealed record EmptyCellsUserRowTests
{
    [Fact]
    public void CellsCountIs6()
    {
        IRow row = new EmptyCellsUserRow();

        Assert.Equal(6, row.Cells.Count);
    }

    [Fact]
    public void CellsContainsIdColumn()
    {
        IRow row = new EmptyCellsUserRow();

        Assert.True(row.Cells.ContainsKey(new IdColumn()));
    }

    [Fact]
    public void IdCellIsEmptyCell()
    {
        IRow row = new EmptyCellsUserRow();

        Assert.True(
            new CellHash(row.Cells[new IdColumn()]).SequenceEqual(
                new CellHash(new EmptyCell())
            )
        );
    }

    [Fact]
    public void CellsContainsTenantIdColumn()
    {
        IRow row = new EmptyCellsUserRow();

        Assert.True(row.Cells.ContainsKey(new TenantIdColumn()));
    }

    [Fact]
    public void TenantIdCellIsEmptyCell()
    {
        IRow row = new EmptyCellsUserRow();

        Assert.True(
            new CellHash(row.Cells[new TenantIdColumn()]).SequenceEqual(
                new CellHash(new EmptyCell())
            )
        );
    }

    [Fact]
    public void CellsContainsNameColumn()
    {
        IRow row = new EmptyCellsUserRow();

        Assert.True(row.Cells.ContainsKey(new NameColumn()));
    }

    [Fact]
    public void NameCellIsEmptyCell()
    {
        IRow row = new EmptyCellsUserRow();

        Assert.True(
            new CellHash(row.Cells[new NameColumn()]).SequenceEqual(
                new CellHash(new EmptyCell())
            )
        );
    }

    [Fact]
    public void CellsContainsBirthDateColumn()
    {
        IRow row = new EmptyCellsUserRow();

        Assert.True(row.Cells.ContainsKey(new BirthDateColumn()));
    }

    [Fact]
    public void BirthDateCellIsEmptyCell()
    {
        IRow row = new EmptyCellsUserRow();

        Assert.True(
            new CellHash(row.Cells[new BirthDateColumn()]).SequenceEqual(
                new CellHash(new EmptyCell())
            )
        );
    }

    [Fact]
    public void CellsContainsIsActiveColumn()
    {
        IRow row = new EmptyCellsUserRow();

        Assert.True(row.Cells.ContainsKey(new IsActiveColumn()));
    }

    [Fact]
    public void IsActiveCellIsEmptyCell()
    {
        IRow row = new EmptyCellsUserRow();

        Assert.True(
            new CellHash(row.Cells[new IsActiveColumn()]).SequenceEqual(
                new CellHash(new EmptyCell())
            )
        );
    }

    [Fact]
    public void CellsContainsCreatedAtColumn()
    {
        IRow row = new EmptyCellsUserRow();

        Assert.True(row.Cells.ContainsKey(new CreatedAtColumn()));
    }

    [Fact]
    public void CreatedAtCellIsEmptyCell()
    {
        IRow row = new EmptyCellsUserRow();

        Assert.True(
            new CellHash(row.Cells[new CreatedAtColumn()]).SequenceEqual(
                new CellHash(new EmptyCell())
            )
        );
    }
}
