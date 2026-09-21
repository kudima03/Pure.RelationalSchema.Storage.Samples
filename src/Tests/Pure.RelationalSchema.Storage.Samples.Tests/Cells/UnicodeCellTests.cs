using Pure.RelationalSchema.Storage.Abstractions;
using Pure.RelationalSchema.Storage.Samples.Cells;

namespace Pure.RelationalSchema.Storage.Samples.Tests.Cells;

public sealed record UnicodeCellTests
{
    [Fact]
    public void ValueIsUnicodeText()
    {
        ICell cell = new UnicodeCell();

        Assert.Equal("Ünïcödé — 日本語", cell.Value.TextValue);
    }
}
