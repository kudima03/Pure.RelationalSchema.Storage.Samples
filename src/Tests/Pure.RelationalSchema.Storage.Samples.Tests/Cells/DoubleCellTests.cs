using Pure.RelationalSchema.Storage.Abstractions;
using Pure.RelationalSchema.Storage.Samples.Cells;

namespace Pure.RelationalSchema.Storage.Samples.Tests.Cells;

public sealed record DoubleCellTests
{
    [Fact]
    public void ValueIs19Point99()
    {
        ICell cell = new DoubleCell();

        Assert.Equal("19.99", cell.Value.TextValue);
    }
}
