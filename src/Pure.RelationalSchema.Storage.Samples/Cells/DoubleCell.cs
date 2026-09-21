using Pure.Primitives.Abstractions.String;
using Pure.RelationalSchema.Storage.Abstractions;
using Double = Pure.Primitives.Number.Double;
using String = Pure.Primitives.String.String;

namespace Pure.RelationalSchema.Storage.Samples.Cells;

public sealed record DoubleCell : ICell
{
    public IString Value => new String(new Double(19.99));
}
