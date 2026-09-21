using Pure.Collections.Generic;
using Pure.RelationalSchema.Abstractions.Column;
using Pure.RelationalSchema.HashCodes;
using Pure.RelationalSchema.Samples.Columns;
using Pure.RelationalSchema.Storage.Abstractions;
using Pure.RelationalSchema.Storage.Samples.Cells;
using Double = Pure.Primitives.Number.Double;
using Guid = Pure.Primitives.Guid.Guid;

namespace Pure.RelationalSchema.Storage.Samples.Rows;

public sealed record FourthOrderItemRow : IRow
{
    public IReadOnlyDictionary<IColumn, ICell> Cells =>
        new Dictionary<KeyValuePair<IColumn, ICell>, IColumn, ICell>(
            [
                new KeyValuePair<IColumn, ICell>(
                    new ItemIdColumn(),
                    new InvariantCell(
                        new Guid(new System.Guid("00000130-0000-0000-0000-000000000000"))
                    )
                ),
                new KeyValuePair<IColumn, ICell>(
                    new ItemTenantIdColumn(),
                    new InvariantCell(
                        new Guid(new System.Guid("00000386-0000-0000-0000-000000000000"))
                    )
                ),
                new KeyValuePair<IColumn, ICell>(
                    new ItemOrderIdColumn(),
                    new InvariantCell(
                        new Guid(new System.Guid("00000069-0000-0000-0000-000000000000"))
                    )
                ),
                new KeyValuePair<IColumn, ICell>(
                    new ItemProductIdColumn(),
                    new InvariantCell(
                        new Guid(new System.Guid("000000c9-0000-0000-0000-000000000000"))
                    )
                ),
                new KeyValuePair<IColumn, ICell>(
                    new ItemQtyColumn(),
                    new InvariantCell(new Double(3))
                ),
            ],
            pair => pair.Key,
            pair => pair.Value,
            column => new ColumnHash(column)
        );
}
