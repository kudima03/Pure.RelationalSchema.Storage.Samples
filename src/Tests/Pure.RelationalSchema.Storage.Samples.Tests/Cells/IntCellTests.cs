using Pure.RelationalSchema.Storage.Abstractions;
using Pure.RelationalSchema.Storage.Samples.Cells;

namespace Pure.RelationalSchema.Storage.Samples.Tests.Cells;

public sealed record IntCellTests
{
    [Fact]
    public void ValueIs42()
    {
        ICell cell = new IntCell();

        Assert.Equal("42", cell.Value.TextValue);
    }
}
