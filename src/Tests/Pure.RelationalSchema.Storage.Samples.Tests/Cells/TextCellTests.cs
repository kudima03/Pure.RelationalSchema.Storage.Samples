using Pure.RelationalSchema.Storage.Abstractions;
using Pure.RelationalSchema.Storage.Samples.Cells;

namespace Pure.RelationalSchema.Storage.Samples.Tests.Cells;

public sealed record TextCellTests
{
    [Fact]
    public void ValueIsSampleText()
    {
        ICell cell = new TextCell();

        Assert.Equal("sample_text", cell.Value.TextValue);
    }
}
