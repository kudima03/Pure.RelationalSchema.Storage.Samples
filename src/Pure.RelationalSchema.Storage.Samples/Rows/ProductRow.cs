using Pure.Collections.Generic;
using Pure.Primitives.Bool;
using Pure.RelationalSchema.Abstractions.Column;
using Pure.RelationalSchema.HashCodes;
using Pure.RelationalSchema.Samples.Columns;
using Pure.RelationalSchema.Storage.Abstractions;
using Pure.RelationalSchema.Storage.Samples.Cells;
using Double = Pure.Primitives.Number.Double;
using Guid = Pure.Primitives.Guid.Guid;
using String = Pure.Primitives.String.String;

namespace Pure.RelationalSchema.Storage.Samples.Rows;

public sealed record ProductRow : IRow
{
    public IReadOnlyDictionary<IColumn, ICell> Cells =>
        new Dictionary<KeyValuePair<IColumn, ICell>, IColumn, ICell>(
            [
                new KeyValuePair<IColumn, ICell>(
                    new ProductIdColumn(),
                    new InvariantCell(
                        new Guid(new System.Guid("000000c9-0000-0000-0000-000000000000"))
                    )
                ),
                new KeyValuePair<IColumn, ICell>(
                    new ProductNameColumn(),
                    new InvariantCell(new String("Widget"))
                ),
                new KeyValuePair<IColumn, ICell>(
                    new ProductDescriptionColumn(),
                    new InvariantCell(new String("Basic widget"))
                ),
                new KeyValuePair<IColumn, ICell>(
                    new ProductPriceColumn(),
                    new InvariantCell(new Double(9.99))
                ),
                new KeyValuePair<IColumn, ICell>(
                    new ProductInStockColumn(),
                    new InvariantCell(new True())
                ),
            ],
            pair => pair.Key,
            pair => pair.Value,
            column => new ColumnHash(column)
        );
}
