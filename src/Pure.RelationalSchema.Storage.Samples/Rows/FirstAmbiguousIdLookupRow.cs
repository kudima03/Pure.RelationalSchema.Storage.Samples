using Pure.Collections.Generic;
using Pure.RelationalSchema.Abstractions.Column;
using Pure.RelationalSchema.HashCodes;
using Pure.RelationalSchema.Samples.Columns;
using Pure.RelationalSchema.Storage.Abstractions;
using Pure.RelationalSchema.Storage.Samples.Cells;
using Guid = Pure.Primitives.Guid.Guid;
using String = Pure.Primitives.String.String;

namespace Pure.RelationalSchema.Storage.Samples.Rows;

public sealed record FirstAmbiguousIdLookupRow : IRow
{
    public IReadOnlyDictionary<IColumn, ICell> Cells =>
        new Dictionary<KeyValuePair<IColumn, ICell>, IColumn, ICell>(
            [
                new KeyValuePair<IColumn, ICell>(
                    new IdColumn(),
                    new InvariantCell(
                        new Guid(new System.Guid("000001f5-0000-0000-0000-000000000000"))
                    )
                ),
                new KeyValuePair<IColumn, ICell>(
                    new NameColumn(),
                    new InvariantCell(new String("Welder"))
                ),
            ],
            pair => pair.Key,
            pair => pair.Value,
            column => new ColumnHash(column)
        );
}
