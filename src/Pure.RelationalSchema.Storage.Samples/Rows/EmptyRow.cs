using Pure.RelationalSchema.Abstractions.Column;
using Pure.RelationalSchema.Storage.Abstractions;

namespace Pure.RelationalSchema.Storage.Samples.Rows;

public sealed record EmptyRow : IRow
{
    public IReadOnlyDictionary<IColumn, ICell> Cells => new Dictionary<IColumn, ICell>();
}
