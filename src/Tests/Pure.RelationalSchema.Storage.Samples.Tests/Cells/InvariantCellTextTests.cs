using System.Collections;
using Pure.Primitives.Abstractions.Char;
using Pure.Primitives.Abstractions.String;
using Pure.Primitives.Bool;
using Pure.Primitives.Date;
using Pure.Primitives.Number;
using Pure.Primitives.Time;
using Pure.RelationalSchema.Storage.Samples.Cells;
using DateTime = Pure.Primitives.DateTime.DateTime;
using Double = Pure.Primitives.Number.Double;
using Guid = Pure.Primitives.Guid.Guid;
using String = Pure.Primitives.String.String;

namespace Pure.RelationalSchema.Storage.Samples.Tests.Cells;

public sealed record InvariantCellTextTests
{
    [Fact]
    public void RendersTrue()
    {
        IString text = new InvariantCellText(new True());

        Assert.Equal("True", text.TextValue);
    }

    [Fact]
    public void RendersFalse()
    {
        IString text = new InvariantCellText(new False());

        Assert.Equal("False", text.TextValue);
    }

    [Fact]
    public void RendersDouble()
    {
        IString text = new InvariantCellText(new Double(19.99));

        Assert.Equal("19.99", text.TextValue);
    }

    [Fact]
    public void RendersMaxDouble()
    {
        IString text = new InvariantCellText(new MaxDouble());

        Assert.Equal("1.7976931348623157E+308", text.TextValue);
    }

    [Fact]
    public void RendersInt()
    {
        IString text = new InvariantCellText(new Int(-42));

        Assert.Equal("-42", text.TextValue);
    }

    [Fact]
    public void RendersLong()
    {
        IString text = new InvariantCellText(new MaxLong());

        Assert.Equal("9223372036854775807", text.TextValue);
    }

    [Fact]
    public void RendersGuidLowercase()
    {
        IString text = new InvariantCellText(
            new Guid(new System.Guid("0F9E8D7C-6B5A-4938-8271-605F4E3D2C1B"))
        );

        Assert.Equal("0f9e8d7c-6b5a-4938-8271-605f4e3d2c1b", text.TextValue);
    }

    [Fact]
    public void RendersDateAsIsoDate()
    {
        IString text = new InvariantCellText(
            new Date(new UShort(5), new UShort(3), new UShort(1990))
        );

        Assert.Equal("1990-03-05", text.TextValue);
    }

    [Fact]
    public void RendersTimeAsIsoTime()
    {
        IString text = new InvariantCellText(
            new Time(new UShort(9), new UShort(5), new UShort(7))
        );

        Assert.Equal("09:05:07", text.TextValue);
    }

    [Fact]
    public void RendersDateTimeAsIsoDateTime()
    {
        IString text = new InvariantCellText(
            new DateTime(
                new Date(new UShort(5), new UShort(3), new UShort(1990)),
                new Time(new UShort(9), new UShort(5), new UShort(7))
            )
        );

        Assert.Equal("1990-03-05T09:05:07", text.TextValue);
    }

    [Fact]
    public void RendersStringUnchanged()
    {
        IString text = new InvariantCellText(new String("sample_text"));

        Assert.Equal("sample_text", text.TextValue);
    }

    [Fact]
    public void RendersPlainBool()
    {
        IString text = new InvariantCellText(false);

        Assert.Equal("False", text.TextValue);
    }

    [Fact]
    public void RendersPlainDouble()
    {
        IString text = new InvariantCellText(123456789.123456);

        Assert.Equal("123456789.123456", text.TextValue);
    }

    [Fact]
    public void RendersPresentNullableDouble()
    {
        IString text = new InvariantCellText((double?)4.5);

        Assert.Equal("4.5", text.TextValue);
    }

    [Fact]
    public void RendersAbsentNullableDoubleAsEmpty()
    {
        IString text = new InvariantCellText((double?)null);

        Assert.Equal(string.Empty, text.TextValue);
    }

    [Fact]
    public void RendersPlainGuidLowercase()
    {
        IString text = new InvariantCellText(
            new System.Guid("0F9E8D7C-6B5A-4938-8271-605F4E3D2C1B")
        );

        Assert.Equal("0f9e8d7c-6b5a-4938-8271-605f4e3d2c1b", text.TextValue);
    }

    [Fact]
    public void RendersPresentNullableGuid()
    {
        IString text = new InvariantCellText(
            (System.Guid?)new System.Guid("0f9e8d7c-6b5a-4938-8271-605f4e3d2c1b")
        );

        Assert.Equal("0f9e8d7c-6b5a-4938-8271-605f4e3d2c1b", text.TextValue);
    }

    [Fact]
    public void RendersAbsentNullableGuidAsEmpty()
    {
        IString text = new InvariantCellText((System.Guid?)null);

        Assert.Equal(string.Empty, text.TextValue);
    }

    [Fact]
    public void RendersDateOnly()
    {
        IString text = new InvariantCellText(new DateOnly(1, 1, 1));

        Assert.Equal("0001-01-01", text.TextValue);
    }

    [Fact]
    public void RendersTimeOnly()
    {
        IString text = new InvariantCellText(new TimeOnly(23, 59, 59));

        Assert.Equal("23:59:59", text.TextValue);
    }

    [Fact]
    public void RendersSystemDateTime()
    {
        IString text = new InvariantCellText(
            new System.DateTime(9999, 12, 31, 23, 59, 59)
        );

        Assert.Equal("9999-12-31T23:59:59", text.TextValue);
    }

    [Fact]
    public void RendersPlainStringUnchanged()
    {
        IString text = new InvariantCellText("shipped");

        Assert.Equal("shipped", text.TextValue);
    }

    [Fact]
    public void RendersEmptyPlainStringAsEmpty()
    {
        IString text = new InvariantCellText(string.Empty);

        Assert.Equal(string.Empty, text.TextValue);
    }

    [Fact]
    public void EnumeratesCharacters()
    {
        IString text = new InvariantCellText(new True());

        Assert.Equal(4, text.Count());
    }

    [Fact]
    public void NonGenericEnumeratorEnumeratesCharacters()
    {
        IString text = new InvariantCellText(new True());

        IEnumerator enumerator = ((IEnumerable)text).GetEnumerator();

        int count = 0;
        while (enumerator.MoveNext())
        {
            _ = Assert.IsType<IChar>(enumerator.Current, exactMatch: false);
            count++;
        }

        Assert.Equal(4, count);
    }
}
