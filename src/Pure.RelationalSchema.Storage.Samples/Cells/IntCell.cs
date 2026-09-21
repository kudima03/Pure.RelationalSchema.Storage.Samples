using Pure.Primitives.Abstractions.String;
using Pure.Primitives.Number;
using Pure.RelationalSchema.Storage.Abstractions;

namespace Pure.RelationalSchema.Storage.Samples.Cells;

public sealed record IntCell : ICell
{
    public IString Value => new InvariantCellText(new Int(42));
}
