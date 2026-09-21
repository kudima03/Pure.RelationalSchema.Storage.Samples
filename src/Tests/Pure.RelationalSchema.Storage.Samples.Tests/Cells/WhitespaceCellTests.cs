using Pure.RelationalSchema.Storage.Abstractions;
using Pure.RelationalSchema.Storage.Samples.Cells;

namespace Pure.RelationalSchema.Storage.Samples.Tests.Cells;

public sealed record WhitespaceCellTests
{
    [Fact]
    public void ValueIsSingleSpace()
    {
        ICell cell = new WhitespaceCell();

        Assert.Equal(" ", cell.Value.TextValue);
    }
}
