using Pure.RelationalSchema.Samples.Columns;
using Pure.RelationalSchema.Storage.Abstractions;
using Pure.RelationalSchema.Storage.HashCodes;
using Pure.RelationalSchema.Storage.Samples.Cells;
using Pure.RelationalSchema.Storage.Samples.Rows;

namespace Pure.RelationalSchema.Storage.Samples.Tests.Rows;

public sealed record UserRowTests
{
    [Fact]
    public void CellsCountIs6()
    {
        IRow row = new UserRow();

        Assert.Equal(6, row.Cells.Count);
    }

    [Fact]
    public void CellsContainsIdColumn()
    {
        IRow row = new UserRow();

        Assert.True(row.Cells.ContainsKey(new IdColumn()));
    }

    [Fact]
    public void IdCellIsUuidCell()
    {
        IRow row = new UserRow();

        Assert.True(
            new CellHash(row.Cells[new IdColumn()]).SequenceEqual(
                new CellHash(new UuidCell())
            )
        );
    }

    [Fact]
    public void CellsContainsTenantIdColumn()
    {
        IRow row = new UserRow();

        Assert.True(row.Cells.ContainsKey(new TenantIdColumn()));
    }

    [Fact]
    public void TenantIdCellIsUuidCell()
    {
        IRow row = new UserRow();

        Assert.True(
            new CellHash(row.Cells[new TenantIdColumn()]).SequenceEqual(
                new CellHash(new UuidCell())
            )
        );
    }

    [Fact]
    public void CellsContainsNameColumn()
    {
        IRow row = new UserRow();

        Assert.True(row.Cells.ContainsKey(new NameColumn()));
    }

    [Fact]
    public void NameCellIsTextCell()
    {
        IRow row = new UserRow();

        Assert.True(
            new CellHash(row.Cells[new NameColumn()]).SequenceEqual(
                new CellHash(new TextCell())
            )
        );
    }

    [Fact]
    public void CellsContainsBirthDateColumn()
    {
        IRow row = new UserRow();

        Assert.True(row.Cells.ContainsKey(new BirthDateColumn()));
    }

    [Fact]
    public void BirthDateCellIsDateCell()
    {
        IRow row = new UserRow();

        Assert.True(
            new CellHash(row.Cells[new BirthDateColumn()]).SequenceEqual(
                new CellHash(new DateCell())
            )
        );
    }

    [Fact]
    public void CellsContainsIsActiveColumn()
    {
        IRow row = new UserRow();

        Assert.True(row.Cells.ContainsKey(new IsActiveColumn()));
    }

    [Fact]
    public void IsActiveCellIsBoolCell()
    {
        IRow row = new UserRow();

        Assert.True(
            new CellHash(row.Cells[new IsActiveColumn()]).SequenceEqual(
                new CellHash(new BoolCell())
            )
        );
    }

    [Fact]
    public void CellsContainsCreatedAtColumn()
    {
        IRow row = new UserRow();

        Assert.True(row.Cells.ContainsKey(new CreatedAtColumn()));
    }

    [Fact]
    public void CreatedAtCellIsDateTimeCell()
    {
        IRow row = new UserRow();

        Assert.True(
            new CellHash(row.Cells[new CreatedAtColumn()]).SequenceEqual(
                new CellHash(new DateTimeCell())
            )
        );
    }
}
