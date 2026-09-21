using System.Collections;
using System.Globalization;
using Pure.Primitives.Abstractions.Bool;
using Pure.Primitives.Abstractions.Char;
using Pure.Primitives.Abstractions.Date;
using Pure.Primitives.Abstractions.DateTime;
using Pure.Primitives.Abstractions.Guid;
using Pure.Primitives.Abstractions.Number;
using Pure.Primitives.Abstractions.String;
using Pure.Primitives.Abstractions.Time;
using Pure.Primitives.String;
using String = Pure.Primitives.String.String;

namespace Pure.RelationalSchema.Storage.Samples.Cells;

// Renders a primitive as the canonical, culture-independent text a stored cell
// holds: True/False, invariant round-trippable doubles, yyyy-MM-dd dates,
// yyyy-MM-ddTHH:mm:ss datetimes, HH:mm:ss times and lowercase uuids. The
// Pure.Primitives String conversions are culture- and format-dependent
// (1/15/1990, 9:30:0.0.0), which no TryParse-based reader can consume, so every
// cell in this catalogue renders through this type instead. It is public so a
// consumer can build expected values exactly the way a sample built its stored
// ones.
public sealed record InvariantCellText : IString
{
    private readonly IString _text;

    public InvariantCellText(IBool value)
    {
        _text = new String(value.BoolValue ? bool.TrueString : bool.FalseString);
    }

    public InvariantCellText(INumber<double> value)
    {
        _text = new String(value.NumberValue.ToString(CultureInfo.InvariantCulture));
    }

    public InvariantCellText(INumber<int> value)
    {
        _text = new String(value.NumberValue.ToString(CultureInfo.InvariantCulture));
    }

    public InvariantCellText(INumber<long> value)
    {
        _text = new String(value.NumberValue.ToString(CultureInfo.InvariantCulture));
    }

    public InvariantCellText(IGuid value)
    {
        _text = new String(value.GuidValue.ToString());
    }

    public InvariantCellText(IDate value)
    {
        _text = new String(DateText(value));
    }

    public InvariantCellText(ITime value)
    {
        _text = new String(TimeText(value));
    }

    public InvariantCellText(IDateTime value)
    {
        _text = new String($"{DateText(value)}T{TimeText(value)}");
    }

    public InvariantCellText(IString value)
    {
        _text = value;
    }

    // The overloads below take plain .NET values rather than Pure.Primitives
    // ones. The samples themselves never use them - a sample always wraps the
    // matching Pure type - but a consumer holding the typed mirrors of
    // Pure.RelationalSchema.Storage.Samples.Records needs to render an expected
    // value exactly the way the stored one was rendered, and those mirrors are
    // plain .NET values by design.
    public InvariantCellText(bool value)
    {
        _text = new String(value ? bool.TrueString : bool.FalseString);
    }

    public InvariantCellText(double value)
    {
        _text = new String(value.ToString(CultureInfo.InvariantCulture));
    }

    public InvariantCellText(double? value)
    {
        _text = value.HasValue
            ? new String(value.Value.ToString(CultureInfo.InvariantCulture))
            : new EmptyString();
    }

    public InvariantCellText(Guid value)
    {
        _text = new String(value.ToString());
    }

    public InvariantCellText(Guid? value)
    {
        _text = value.HasValue ? new String(value.Value.ToString()) : new EmptyString();
    }

    public InvariantCellText(DateOnly value)
    {
        _text = new String(value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture));
    }

    public InvariantCellText(TimeOnly value)
    {
        _text = new String(value.ToString("HH:mm:ss", CultureInfo.InvariantCulture));
    }

    public InvariantCellText(DateTime value)
    {
        _text = new String(
            value.ToString("yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture)
        );
    }

    public InvariantCellText(string value)
    {
        _text = new String(value);
    }

    public string TextValue => _text.TextValue;

    public IEnumerator<IChar> GetEnumerator()
    {
        return _text.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    private static string DateText(IDate value)
    {
        return string.Create(
            CultureInfo.InvariantCulture,
            $"{value.Year.NumberValue:D4}-{value.Month.NumberValue:D2}-{value.Day.NumberValue:D2}"
        );
    }

    private static string TimeText(ITime value)
    {
        return string.Create(
            CultureInfo.InvariantCulture,
            $"{value.Hour.NumberValue:D2}:{value.Minute.NumberValue:D2}:{value.Second.NumberValue:D2}"
        );
    }
}
