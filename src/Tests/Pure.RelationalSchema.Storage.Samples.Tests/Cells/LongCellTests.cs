using Pure.RelationalSchema.Storage.Abstractions;
using Pure.RelationalSchema.Storage.Samples.Cells;

namespace Pure.RelationalSchema.Storage.Samples.Tests.Cells;

public sealed record LongCellTests
{
    [Fact]
    public void ValueIsMaxLong()
    {
        ICell cell = new LongCell();

        Assert.Equal("9223372036854775807", cell.Value.TextValue);
    }
}
