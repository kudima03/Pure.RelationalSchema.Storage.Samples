using Pure.Primitives.Abstractions.String;
using Pure.RelationalSchema.Storage.Abstractions;
using String = Pure.Primitives.String.String;

namespace Pure.RelationalSchema.Storage.Samples.Cells;

public sealed record DateTimeCell : ICell
{
    public IString Value => new String("1/15/2024 9:30:0.0.0");
}
