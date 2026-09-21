using Pure.Collections.Generic;
using Pure.Primitives.Bool;
using Pure.RelationalSchema.Abstractions.Column;
using Pure.RelationalSchema.HashCodes;
using Pure.RelationalSchema.Samples.Columns;
using Pure.RelationalSchema.Storage.Abstractions;
using Pure.RelationalSchema.Storage.Samples.Cells;
using String = Pure.Primitives.String.String;

namespace Pure.RelationalSchema.Storage.Samples.Rows;

public sealed record StatusRow : IRow
{
    public IReadOnlyDictionary<IColumn, ICell> Cells =>
        new Dictionary<KeyValuePair<IColumn, ICell>, IColumn, ICell>(
            [
                new KeyValuePair<IColumn, ICell>(
                    new StatusCodeColumn(),
                    new InvariantCell(new String("shipped"))
                ),
                new KeyValuePair<IColumn, ICell>(
                    new StatusLabelColumn(),
                    new InvariantCell(new String("Shipped"))
                ),
                new KeyValuePair<IColumn, ICell>(
                    new StatusIsFinalColumn(),
                    new InvariantCell(new True())
                ),
            ],
            pair => pair.Key,
            pair => pair.Value,
            column => new ColumnHash(column)
        );
}
