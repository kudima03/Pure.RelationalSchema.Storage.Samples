using Pure.Primitives.Abstractions.String;
using Pure.Primitives.Number;
using Pure.RelationalSchema.Storage.Abstractions;
using String = Pure.Primitives.String.String;

namespace Pure.RelationalSchema.Storage.Samples.Cells;

public sealed record LongCell : ICell
{
    public IString Value => new String(new MaxLong());
}
