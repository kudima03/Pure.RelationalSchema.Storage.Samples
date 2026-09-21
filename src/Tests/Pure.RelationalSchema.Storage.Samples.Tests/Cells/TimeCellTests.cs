using Pure.RelationalSchema.Storage.Abstractions;
using Pure.RelationalSchema.Storage.Samples.Cells;

namespace Pure.RelationalSchema.Storage.Samples.Tests.Cells;

public sealed record TimeCellTests
{
    [Fact]
    public void ValueIsTime()
    {
        ICell cell = new TimeCell();

        Assert.Equal("09:30:00", cell.Value.TextValue);
    }
}
