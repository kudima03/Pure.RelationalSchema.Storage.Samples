using Pure.Primitives.Bool;
using Pure.Primitives.Date;
using Pure.Primitives.Number;
using Pure.Primitives.Time;
using Pure.RelationalSchema.Storage.Abstractions;
using Pure.RelationalSchema.Storage.Samples.Cells;
using DateTime = Pure.Primitives.DateTime.DateTime;
using Double = Pure.Primitives.Number.Double;
using Guid = Pure.Primitives.Guid.Guid;
using String = Pure.Primitives.String.String;

namespace Pure.RelationalSchema.Storage.Samples.Tests.Cells;

public sealed record InvariantCellTests
{
    [Fact]
    public void HoldsBool()
    {
        ICell cell = new InvariantCell(new False());

        Assert.Equal("False", cell.Value.TextValue);
    }

    [Fact]
    public void HoldsDouble()
    {
        ICell cell = new InvariantCell(new Double(4.5));

        Assert.Equal("4.5", cell.Value.TextValue);
    }

    [Fact]
    public void HoldsInt()
    {
        ICell cell = new InvariantCell(new Int(7));

        Assert.Equal("7", cell.Value.TextValue);
    }

    [Fact]
    public void HoldsLong()
    {
        ICell cell = new InvariantCell(new MinLong());

        Assert.Equal("-9223372036854775808", cell.Value.TextValue);
    }

    [Fact]
    public void HoldsGuid()
    {
        ICell cell = new InvariantCell(
            new Guid(new System.Guid("0f9e8d7c-6b5a-4938-8271-605f4e3d2c1b"))
        );

        Assert.Equal("0f9e8d7c-6b5a-4938-8271-605f4e3d2c1b", cell.Value.TextValue);
    }

    [Fact]
    public void HoldsDate()
    {
        ICell cell = new InvariantCell(
            new Date(new UShort(31), new UShort(12), new UShort(9999))
        );

        Assert.Equal("9999-12-31", cell.Value.TextValue);
    }

    [Fact]
    public void HoldsTime()
    {
        ICell cell = new InvariantCell(
            new Time(new UShort(0), new UShort(0), new UShort(0))
        );

        Assert.Equal("00:00:00", cell.Value.TextValue);
    }

    [Fact]
    public void HoldsDateTime()
    {
        ICell cell = new InvariantCell(
            new DateTime(
                new Date(new UShort(1), new UShort(1), new UShort(1)),
                new Time(new UShort(0), new UShort(0), new UShort(0))
            )
        );

        Assert.Equal("0001-01-01T00:00:00", cell.Value.TextValue);
    }

    [Fact]
    public void HoldsString()
    {
        ICell cell = new InvariantCell(new String("pending"));

        Assert.Equal("pending", cell.Value.TextValue);
    }
}
