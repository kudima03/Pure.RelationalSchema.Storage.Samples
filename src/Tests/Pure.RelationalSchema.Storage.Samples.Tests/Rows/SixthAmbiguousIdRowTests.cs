using Pure.RelationalSchema.Samples.Columns;
using Pure.RelationalSchema.Storage.Abstractions;
using Pure.RelationalSchema.Storage.Samples.Rows;

namespace Pure.RelationalSchema.Storage.Samples.Tests.Rows;

public sealed record SixthAmbiguousIdRowTests
{
    [Fact]
    public void CellsCountIs4()
    {
        IRow row = new SixthAmbiguousIdRow();

        Assert.Equal(4, row.Cells.Count);
    }

    [Fact]
    public void CellsContainsIdColumn()
    {
        IRow row = new SixthAmbiguousIdRow();

        Assert.True(row.Cells.ContainsKey(new IdColumn()));
    }

    [Fact]
    public void IdCellHoldsExpectedText()
    {
        IRow row = new SixthAmbiguousIdRow();

        Assert.Equal(
            "00000006-0000-0000-0000-000000000000",
            row.Cells[new IdColumn()].Value.TextValue
        );
    }

    [Fact]
    public void CellsContainsTenantIdColumn()
    {
        IRow row = new SixthAmbiguousIdRow();

        Assert.True(row.Cells.ContainsKey(new TenantIdColumn()));
    }

    [Fact]
    public void TenantIdCellHoldsExpectedText()
    {
        IRow row = new SixthAmbiguousIdRow();

        Assert.Equal(
            "000001f7-0000-0000-0000-000000000000",
            row.Cells[new TenantIdColumn()].Value.TextValue
        );
    }

    [Fact]
    public void CellsContainsNameColumn()
    {
        IRow row = new SixthAmbiguousIdRow();

        Assert.True(row.Cells.ContainsKey(new NameColumn()));
    }

    [Fact]
    public void NameCellHoldsExpectedText()
    {
        IRow row = new SixthAmbiguousIdRow();

        Assert.Equal("sixth_entry", row.Cells[new NameColumn()].Value.TextValue);
    }

    [Fact]
    public void CellsContainsCreatedAtColumn()
    {
        IRow row = new SixthAmbiguousIdRow();

        Assert.True(row.Cells.ContainsKey(new CreatedAtColumn()));
    }

    [Fact]
    public void CreatedAtCellHoldsExpectedText()
    {
        IRow row = new SixthAmbiguousIdRow();

        Assert.Equal(
            "2024-01-06T05:00:00",
            row.Cells[new CreatedAtColumn()].Value.TextValue
        );
    }
}
