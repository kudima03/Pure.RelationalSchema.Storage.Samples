using Pure.Primitives.Abstractions.String;
using Pure.Primitives.Date;
using Pure.Primitives.Number;
using Pure.Primitives.Time;
using Pure.RelationalSchema.Storage.Abstractions;
using DateTime = Pure.Primitives.DateTime.DateTime;
using String = Pure.Primitives.String.String;

namespace Pure.RelationalSchema.Storage.Samples.Cells;

public sealed record DateTimeCell : ICell
{
    public IString Value =>
        new String(
            new DateTime(
                new Date(new UShort(15), new UShort(1), new UShort(2024)),
                new Time(new UShort(9), new UShort(30), new UShort(0))
            )
        );
}
