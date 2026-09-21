using Pure.Primitives.Abstractions.String;
using Pure.Primitives.Bool;
using Pure.RelationalSchema.Storage.Abstractions;

namespace Pure.RelationalSchema.Storage.Samples.Cells;

public sealed record BoolCell : ICell
{
    public IString Value => new InvariantCellText(new True());
}
