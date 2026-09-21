using Pure.RelationalSchema.Storage.Abstractions;
using Pure.RelationalSchema.Storage.Samples.Cells;

namespace Pure.RelationalSchema.Storage.Samples.Tests.Cells;

public sealed record DateCellTests
{
    [Fact]
    public void ValueIsDate()
    {
        ICell cell = new DateCell();

        Assert.Equal("1/15/1990", cell.Value.TextValue);
    }
}
