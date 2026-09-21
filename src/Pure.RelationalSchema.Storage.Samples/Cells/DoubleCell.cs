using Pure.Primitives.Abstractions.String;
using Pure.RelationalSchema.Storage.Abstractions;
using Double = Pure.Primitives.Number.Double;

namespace Pure.RelationalSchema.Storage.Samples.Cells;

public sealed record DoubleCell : ICell
{
    public IString Value => new InvariantCellText(new Double(19.99));
}
