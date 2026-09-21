using Pure.Collections.Generic;
using Pure.RelationalSchema.Abstractions.Column;
using Pure.RelationalSchema.HashCodes;
using Pure.RelationalSchema.Samples.Columns;
using Pure.RelationalSchema.Storage.Abstractions;
using Pure.RelationalSchema.Storage.Samples.Cells;

namespace Pure.RelationalSchema.Storage.Samples.Rows;

public sealed record OrderRow : IRow
{
    public IReadOnlyDictionary<IColumn, ICell> Cells =>
        new Dictionary<KeyValuePair<IColumn, ICell>, IColumn, ICell>(
            [
                new KeyValuePair<IColumn, ICell>(new IdColumn(), new UuidCell()),
                new KeyValuePair<IColumn, ICell>(new TenantIdColumn(), new UuidCell()),
                new KeyValuePair<IColumn, ICell>(new UserIdColumn(), new UuidCell()),
                new KeyValuePair<IColumn, ICell>(new PriceColumn(), new DoubleCell()),
                new KeyValuePair<IColumn, ICell>(
                    new CreatedAtColumn(),
                    new DateTimeCell()
                ),
            ],
            pair => pair.Key,
            pair => pair.Value,
            column => new ColumnHash(column)
        );
}
