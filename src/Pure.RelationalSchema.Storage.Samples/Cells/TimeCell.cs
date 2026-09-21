using Pure.Primitives.Abstractions.String;
using Pure.RelationalSchema.Storage.Abstractions;
using String = Pure.Primitives.String.String;

namespace Pure.RelationalSchema.Storage.Samples.Cells;

public sealed record TimeCell : ICell
{
    public IString Value => new String("9:30:0.0.0");
}
