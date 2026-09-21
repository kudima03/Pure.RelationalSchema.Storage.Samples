using Pure.RelationalSchema.Storage.Abstractions;
using Pure.RelationalSchema.Storage.Samples.Cells;

namespace Pure.RelationalSchema.Storage.Samples.Tests.Cells;

public sealed record BoolCellTests
{
    [Fact]
    public void ValueIsTrue()
    {
        ICell cell = new BoolCell();

        Assert.Equal("True", cell.Value.TextValue);
    }
}
