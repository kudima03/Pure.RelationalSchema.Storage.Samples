using Pure.Collections.Generic;
using Pure.Primitives.Bool;
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

public sealed record ThirdUserRow : IRow
{
    public IReadOnlyDictionary<IColumn, ICell> Cells =>
        new Dictionary<KeyValuePair<IColumn, ICell>, IColumn, ICell>(
            [
                new KeyValuePair<IColumn, ICell>(
                    new UserIdColumn(),
                    new InvariantCell(
                        new Guid(new System.Guid("00000003-0000-0000-0000-000000000000"))
                    )
                ),
                new KeyValuePair<IColumn, ICell>(
                    new UserTenantIdColumn(),
                    new InvariantCell(
                        new Guid(new System.Guid("00000385-0000-0000-0000-000000000000"))
                    )
                ),
                new KeyValuePair<IColumn, ICell>(
                    new UserNameColumn(),
                    new InvariantCell(new String("Cara"))
                ),
                new KeyValuePair<IColumn, ICell>(
                    new SignupDateColumn(),
                    new InvariantCell(
                        new Date(new UShort(10), new UShort(7), new UShort(2019))
                    )
                ),
                new KeyValuePair<IColumn, ICell>(
                    new UserActiveColumn(),
                    new InvariantCell(new True())
                ),
                new KeyValuePair<IColumn, ICell>(
                    new LastLoginColumn(),
                    new InvariantCell(
                        new DateTime(
                            new Date(new UShort(30), new UShort(5), new UShort(2024)),
                            new Time(new UShort(14), new UShort(0), new UShort(0))
                        )
                    )
                ),
                new KeyValuePair<IColumn, ICell>(
                    new UserAgeColumn(),
                    new InvariantCell(new Double(30))
                ),
                new KeyValuePair<IColumn, ICell>(
                    new ShiftStartColumn(),
                    new InvariantCell(
                        new Time(new UShort(9), new UShort(0), new UShort(0))
                    )
                ),
                new KeyValuePair<IColumn, ICell>(
                    new UserScoreColumn(),
                    new InvariantCell(new Double(30))
                ),
                new KeyValuePair<IColumn, ICell>(
                    new UserPrecisionValueColumn(),
                    new InvariantCell(new Double(double.Epsilon))
                ),
                new KeyValuePair<IColumn, ICell>(
                    new UserEdgeDateColumn(),
                    new InvariantCell(
                        new Date(new UShort(10), new UShort(3), new UShort(2024))
                    )
                ),
                new KeyValuePair<IColumn, ICell>(
                    new UserEdgeDateTimeColumn(),
                    new InvariantCell(
                        new DateTime(
                            new Date(new UShort(10), new UShort(3), new UShort(2024)),
                            new Time(new UShort(2), new UShort(30), new UShort(0))
                        )
                    )
                ),
                new KeyValuePair<IColumn, ICell>(
                    new UserEdgeTimeColumn(),
                    new InvariantCell(
                        new Time(new UShort(2), new UShort(30), new UShort(0))
                    )
                ),
            ],
            pair => pair.Key,
            pair => pair.Value,
            column => new ColumnHash(column)
        );
}
