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
using Guid = Pure.Primitives.Guid.Guid;

namespace Pure.RelationalSchema.Storage.Samples.Rows;

public sealed record LoginRow : IRow
{
    public IReadOnlyDictionary<IColumn, ICell> Cells =>
        new Dictionary<KeyValuePair<IColumn, ICell>, IColumn, ICell>(
            [
                new KeyValuePair<IColumn, ICell>(
                    new LoginIdColumn(),
                    new InvariantCell(
                        new Guid(new System.Guid("00000191-0000-0000-0000-000000000000"))
                    )
                ),
                new KeyValuePair<IColumn, ICell>(
                    new LoginUserIdColumn(),
                    new InvariantCell(
                        new Guid(new System.Guid("00000001-0000-0000-0000-000000000000"))
                    )
                ),
                new KeyValuePair<IColumn, ICell>(
                    new LoginAtColumn(),
                    new InvariantCell(
                        new DateTime(
                            new Date(new UShort(1), new UShort(6), new UShort(2024)),
                            new Time(new UShort(7), new UShort(0), new UShort(0))
                        )
                    )
                ),
            ],
            pair => pair.Key,
            pair => pair.Value,
            column => new ColumnHash(column)
        );
}
