using Pure.RelationalSchema.Storage.Abstractions;
using Pure.RelationalSchema.Storage.Samples.Cells;

namespace Pure.RelationalSchema.Storage.Samples.Tests.Cells;

public sealed record DateTimeCellTests
{
    [Fact]
    public void ValueIsDateTime()
    {
        ICell cell = new DateTimeCell();

        Assert.Equal("1/15/2024 9:30:0.0.0", cell.Value.TextValue);
    }
}
