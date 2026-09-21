using Pure.RelationalSchema.Samples.Columns;
using Pure.RelationalSchema.Storage.Abstractions;
using Pure.RelationalSchema.Storage.HashCodes;
using Pure.RelationalSchema.Storage.Samples.Cells;
using Pure.RelationalSchema.Storage.Samples.Rows;

namespace Pure.RelationalSchema.Storage.Samples.Tests.Rows;

public sealed record AllColumnTypesRowTests
{
    [Fact]
    public void CellsCountIs10()
    {
        IRow row = new AllColumnTypesRow();

        Assert.Equal(10, row.Cells.Count);
    }

    [Fact]
    public void CellsContainsIdColumn()
    {
        IRow row = new AllColumnTypesRow();

        Assert.True(row.Cells.ContainsKey(new IdColumn()));
    }

    [Fact]
    public void IdCellIsUuidCell()
    {
        IRow row = new AllColumnTypesRow();

        Assert.True(
            new CellHash(row.Cells[new IdColumn()]).SequenceEqual(
                new CellHash(new UuidCell())
            )
        );
    }

    [Fact]
    public void CellsContainsNameColumn()
    {
        IRow row = new AllColumnTypesRow();

        Assert.True(row.Cells.ContainsKey(new NameColumn()));
    }

    [Fact]
    public void NameCellIsTextCell()
    {
        IRow row = new AllColumnTypesRow();

        Assert.True(
            new CellHash(row.Cells[new NameColumn()]).SequenceEqual(
                new CellHash(new TextCell())
            )
        );
    }

    [Fact]
    public void CellsContainsAgeColumn()
    {
        IRow row = new AllColumnTypesRow();

        Assert.True(row.Cells.ContainsKey(new AgeColumn()));
    }

    [Fact]
    public void AgeCellIsIntCell()
    {
        IRow row = new AllColumnTypesRow();

        Assert.True(
            new CellHash(row.Cells[new AgeColumn()]).SequenceEqual(
                new CellHash(new IntCell())
            )
        );
    }

    [Fact]
    public void CellsContainsQuantityColumn()
    {
        IRow row = new AllColumnTypesRow();

        Assert.True(row.Cells.ContainsKey(new QuantityColumn()));
    }

    [Fact]
    public void QuantityCellIsLongCell()
    {
        IRow row = new AllColumnTypesRow();

        Assert.True(
            new CellHash(row.Cells[new QuantityColumn()]).SequenceEqual(
                new CellHash(new LongCell())
            )
        );
    }

    [Fact]
    public void CellsContainsPriceColumn()
    {
        IRow row = new AllColumnTypesRow();

        Assert.True(row.Cells.ContainsKey(new PriceColumn()));
    }

    [Fact]
    public void PriceCellIsDoubleCell()
    {
        IRow row = new AllColumnTypesRow();

        Assert.True(
            new CellHash(row.Cells[new PriceColumn()]).SequenceEqual(
                new CellHash(new DoubleCell())
            )
        );
    }

    [Fact]
    public void CellsContainsIsActiveColumn()
    {
        IRow row = new AllColumnTypesRow();

        Assert.True(row.Cells.ContainsKey(new IsActiveColumn()));
    }

    [Fact]
    public void IsActiveCellIsBoolCell()
    {
        IRow row = new AllColumnTypesRow();

        Assert.True(
            new CellHash(row.Cells[new IsActiveColumn()]).SequenceEqual(
                new CellHash(new BoolCell())
            )
        );
    }

    [Fact]
    public void CellsContainsBirthDateColumn()
    {
        IRow row = new AllColumnTypesRow();

        Assert.True(row.Cells.ContainsKey(new BirthDateColumn()));
    }

    [Fact]
    public void BirthDateCellIsDateCell()
    {
        IRow row = new AllColumnTypesRow();

        Assert.True(
            new CellHash(row.Cells[new BirthDateColumn()]).SequenceEqual(
                new CellHash(new DateCell())
            )
        );
    }

    [Fact]
    public void CellsContainsStartTimeColumn()
    {
        IRow row = new AllColumnTypesRow();

        Assert.True(row.Cells.ContainsKey(new StartTimeColumn()));
    }

    [Fact]
    public void StartTimeCellIsTimeCell()
    {
        IRow row = new AllColumnTypesRow();

        Assert.True(
            new CellHash(row.Cells[new StartTimeColumn()]).SequenceEqual(
                new CellHash(new TimeCell())
            )
        );
    }

    [Fact]
    public void CellsContainsCreatedAtColumn()
    {
        IRow row = new AllColumnTypesRow();

        Assert.True(row.Cells.ContainsKey(new CreatedAtColumn()));
    }

    [Fact]
    public void CreatedAtCellIsDateTimeCell()
    {
        IRow row = new AllColumnTypesRow();

        Assert.True(
            new CellHash(row.Cells[new CreatedAtColumn()]).SequenceEqual(
                new CellHash(new DateTimeCell())
            )
        );
    }

    [Fact]
    public void CellsContainsEmptyNameColumn()
    {
        IRow row = new AllColumnTypesRow();

        Assert.True(row.Cells.ContainsKey(new EmptyNameColumn()));
    }

    [Fact]
    public void EmptyNameCellIsEmptyCell()
    {
        IRow row = new AllColumnTypesRow();

        Assert.True(
            new CellHash(row.Cells[new EmptyNameColumn()]).SequenceEqual(
                new CellHash(new EmptyCell())
            )
        );
    }
}
