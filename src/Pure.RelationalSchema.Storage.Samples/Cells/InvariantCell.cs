using Pure.Primitives.Abstractions.Bool;
using Pure.Primitives.Abstractions.Date;
using Pure.Primitives.Abstractions.DateTime;
using Pure.Primitives.Abstractions.Guid;
using Pure.Primitives.Abstractions.Number;
using Pure.Primitives.Abstractions.String;
using Pure.Primitives.Abstractions.Time;
using Pure.RelationalSchema.Storage.Abstractions;

namespace Pure.RelationalSchema.Storage.Samples.Cells;

// A cell holding an arbitrary primitive rendered as invariant text. The named
// cell samples cover one value per shape; the query-grade rows need a distinct
// value per row, so they build their cells through this type instead.
public sealed record InvariantCell : ICell
{
    public InvariantCell(IBool value)
    {
        Value = new InvariantCellText(value);
    }

    public InvariantCell(INumber<double> value)
    {
        Value = new InvariantCellText(value);
    }

    public InvariantCell(INumber<int> value)
    {
        Value = new InvariantCellText(value);
    }

    public InvariantCell(INumber<long> value)
    {
        Value = new InvariantCellText(value);
    }

    public InvariantCell(IGuid value)
    {
        Value = new InvariantCellText(value);
    }

    public InvariantCell(IDate value)
    {
        Value = new InvariantCellText(value);
    }

    public InvariantCell(ITime value)
    {
        Value = new InvariantCellText(value);
    }

    public InvariantCell(IDateTime value)
    {
        Value = new InvariantCellText(value);
    }

    public InvariantCell(IString value)
    {
        Value = new InvariantCellText(value);
    }

    public IString Value { get; }
}
