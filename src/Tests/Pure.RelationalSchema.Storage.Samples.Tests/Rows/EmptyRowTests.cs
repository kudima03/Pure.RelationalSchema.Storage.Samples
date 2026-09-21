using Pure.RelationalSchema.Storage.Abstractions;
using Pure.RelationalSchema.Storage.Samples.Rows;

namespace Pure.RelationalSchema.Storage.Samples.Tests.Rows;

public sealed record EmptyRowTests
{
    [Fact]
    public void CellsCountIs0()
    {
        IRow row = new EmptyRow();

        Assert.Empty(row.Cells);
    }
}
