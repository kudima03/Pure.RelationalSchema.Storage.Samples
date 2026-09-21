using Pure.Primitives.Abstractions.String;
using Pure.Primitives.Number;
using Pure.Primitives.Time;
using Pure.RelationalSchema.Storage.Abstractions;
using String = Pure.Primitives.String.String;

namespace Pure.RelationalSchema.Storage.Samples.Cells;

public sealed record TimeCell : ICell
{
    public IString Value =>
        new String(new Time(new UShort(9), new UShort(30), new UShort(0)));
}
