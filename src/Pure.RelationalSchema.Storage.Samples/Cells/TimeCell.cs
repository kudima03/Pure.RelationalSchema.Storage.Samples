using Pure.Primitives.Abstractions.String;
using Pure.Primitives.Number;
using Pure.Primitives.Time;
using Pure.RelationalSchema.Storage.Abstractions;

namespace Pure.RelationalSchema.Storage.Samples.Cells;

public sealed record TimeCell : ICell
{
    public IString Value =>
        new InvariantCellText(new Time(new UShort(9), new UShort(30), new UShort(0)));
}
