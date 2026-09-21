using Pure.Collections.Generic;
using Pure.Primitives.Date;
using Pure.Primitives.Number;
using Pure.Primitives.Time;
using Pure.RelationalSchema.Abstractions.Column;
using Pure.RelationalSchema.HashCodes;
using Pure.RelationalSchema.Samples.Columns;
using Pure.RelationalSchema.Storage.Abstractions;
using Pure.RelationalSchema.Storage.Samples.Cells;
using DateTime = Pure.Primitives.DateTime.DateTime;
using Double = Pure.Primitives.Number.Double;
using Guid = Pure.Primitives.Guid.Guid;
using String = Pure.Primitives.String.String;

namespace Pure.RelationalSchema.Storage.Samples.Rows;

public sealed record SixthOrderRow : IRow
{
    public IReadOnlyDictionary<IColumn, ICell> Cells =>
        new Dictionary<KeyValuePair<IColumn, ICell>, IColumn, ICell>(
            [
                new KeyValuePair<IColumn, ICell>(
                    new OrderIdColumn(),
                    new InvariantCell(
                        new Guid(new System.Guid("0000006a-0000-0000-0000-000000000000"))
                    )
                ),
                new KeyValuePair<IColumn, ICell>(
                    new OrderTenantIdColumn(),
                    new InvariantCell(
                        new Guid(new System.Guid("00000386-0000-0000-0000-000000000000"))
                    )
                ),
                new KeyValuePair<IColumn, ICell>(
                    new OrderUserIdColumn(),
                    new InvariantCell(
                        new Guid(new System.Guid("00000004-0000-0000-0000-000000000000"))
                    )
                ),
                new KeyValuePair<IColumn, ICell>(
                    new OrderTotalColumn(),
                    new InvariantCell(new Double(100.50))
                ),
                new KeyValuePair<IColumn, ICell>(
                    new PlacedAtColumn(),
                    new InvariantCell(
                        new DateTime(
                            new Date(new UShort(6), new UShort(6), new UShort(2024)),
                            new Time(new UShort(15), new UShort(0), new UShort(0))
                        )
                    )
                ),
                new KeyValuePair<IColumn, ICell>(
                    new OrderStatusColumn(),
                    new InvariantCell(new String("pending"))
                ),
                new KeyValuePair<IColumn, ICell>(
                    new PlacedOnColumn(),
                    new InvariantCell(
                        new Date(new UShort(6), new UShort(6), new UShort(2024))
                    )
                ),
            ],
            pair => pair.Key,
            pair => pair.Value,
            column => new ColumnHash(column)
        );
}
