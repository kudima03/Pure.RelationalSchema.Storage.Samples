using Pure.RelationalSchema.Samples.Columns;
using Pure.RelationalSchema.Storage.Abstractions;
using Pure.RelationalSchema.Storage.Samples.Rows;

namespace Pure.RelationalSchema.Storage.Samples.Tests.Rows;

public sealed record FirstAmbiguousIdRowTests
{
    [Fact]
    public void CellsCountIs4()
    {
        IRow row = new FirstAmbiguousIdRow();

        Assert.Equal(4, row.Cells.Count);
    }

    [Fact]
    public void CellsContainsIdColumn()
    {
        IRow row = new FirstAmbiguousIdRow();

        Assert.True(row.Cells.ContainsKey(new IdColumn()));
    }

    [Fact]
    public void IdCellHoldsExpectedText()
    {
        IRow row = new FirstAmbiguousIdRow();

        Assert.Equal(
            "00000001-0000-0000-0000-000000000000",
            row.Cells[new IdColumn()].Value.TextValue
        );
    }

    [Fact]
    public void CellsContainsTenantIdColumn()
    {
        IRow row = new FirstAmbiguousIdRow();

        Assert.True(row.Cells.ContainsKey(new TenantIdColumn()));
    }

    [Fact]
    public void TenantIdCellHoldsExpectedText()
    {
        IRow row = new FirstAmbiguousIdRow();

        Assert.Equal(
            "000001f5-0000-0000-0000-000000000000",
            row.Cells[new TenantIdColumn()].Value.TextValue
        );
    }

    [Fact]
    public void CellsContainsNameColumn()
    {
        IRow row = new FirstAmbiguousIdRow();

        Assert.True(row.Cells.ContainsKey(new NameColumn()));
    }

    [Fact]
    public void NameCellHoldsExpectedText()
    {
        IRow row = new FirstAmbiguousIdRow();

        Assert.Equal("first_entry", row.Cells[new NameColumn()].Value.TextValue);
    }

    [Fact]
    public void CellsContainsCreatedAtColumn()
    {
        IRow row = new FirstAmbiguousIdRow();

        Assert.True(row.Cells.ContainsKey(new CreatedAtColumn()));
    }

    [Fact]
    public void CreatedAtCellHoldsExpectedText()
    {
        IRow row = new FirstAmbiguousIdRow();

        Assert.Equal(
            "2024-01-01T00:00:00",
            row.Cells[new CreatedAtColumn()].Value.TextValue
        );
    }
}
