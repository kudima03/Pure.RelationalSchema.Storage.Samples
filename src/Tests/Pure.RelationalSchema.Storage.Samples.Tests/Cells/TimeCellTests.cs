using Pure.RelationalSchema.Storage.Abstractions;
using Pure.RelationalSchema.Storage.Samples.Cells;

namespace Pure.RelationalSchema.Storage.Samples.Tests.Cells;

public sealed record TimeCellTests
{
    [Fact]
    public void ValueIsTime()
    {
        ICell cell = new TimeCell();

        Assert.Equal("9:30:0.0.0", cell.Value.TextValue);
    }
}
