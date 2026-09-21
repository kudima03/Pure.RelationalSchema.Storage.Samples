using Pure.RelationalSchema.Storage.Abstractions;
using Pure.RelationalSchema.Storage.Samples.Cells;

namespace Pure.RelationalSchema.Storage.Samples.Tests.Cells;

public sealed record DateTimeCellTests
{
    [Fact]
    public void ValueIsDateTime()
    {
        ICell cell = new DateTimeCell();

        Assert.Equal("2024-01-15T09:30:00", cell.Value.TextValue);
    }
}
