using Pure.Primitives.Abstractions.String;
using Pure.RelationalSchema.Storage.Abstractions;
using String = Pure.Primitives.String.String;

namespace Pure.RelationalSchema.Storage.Samples.Cells;

public sealed record DoubleCell : ICell
{
    public IString Value => new String("19.99");
}
