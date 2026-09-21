using Pure.Primitives.Abstractions.String;
using Pure.Primitives.Date;
using Pure.Primitives.Number;
using Pure.RelationalSchema.Storage.Abstractions;
using String = Pure.Primitives.String.String;

namespace Pure.RelationalSchema.Storage.Samples.Cells;

public sealed record DateCell : ICell
{
    public IString Value =>
        new String(new Date(new UShort(15), new UShort(1), new UShort(1990)));
}
