using Pure.RelationalSchema.Storage.Abstractions;
using Pure.RelationalSchema.Storage.Samples.Cells;

namespace Pure.RelationalSchema.Storage.Samples.Tests.Cells;

public sealed record EmptyCellTests
{
    [Fact]
    public void ValueIsEmpty()
    {
        ICell cell = new EmptyCell();

        Assert.Equal(string.Empty, cell.Value.TextValue);
    }
}
