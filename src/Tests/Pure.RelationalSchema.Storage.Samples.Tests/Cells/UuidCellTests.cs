using Pure.RelationalSchema.Storage.Abstractions;
using Pure.RelationalSchema.Storage.Samples.Cells;

namespace Pure.RelationalSchema.Storage.Samples.Tests.Cells;

public sealed record UuidCellTests
{
    [Fact]
    public void ValueIsUuid()
    {
        ICell cell = new UuidCell();

        Assert.Equal("1f0c4b2a-9d3e-4c7b-8a15-6e2d0f9b7c43", cell.Value.TextValue);
    }
}
