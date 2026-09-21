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
using String = Pure.Primitives.String.String;

namespace Pure.RelationalSchema.Storage.Samples.Rows;

public sealed record UppercaseUuidRow : IRow
{
    public IReadOnlyDictionary<IColumn, ICell> Cells =>
        new Dictionary<KeyValuePair<IColumn, ICell>, IColumn, ICell>(
            [
                new KeyValuePair<IColumn, ICell>(
                    new IdColumn(),
                    new InvariantCell(new String("0F9E8D7C-6B5A-4938-8271-605F4E3D2C1B"))
                ),
                new KeyValuePair<IColumn, ICell>(
                    new NameColumn(),
                    new InvariantCell(new String("uppercase"))
                ),
                new KeyValuePair<IColumn, ICell>(
                    new CreatedAtColumn(),
                    new InvariantCell(
                        new DateTime(
                            new Date(new UShort(2), new UShort(1), new UShort(2024)),
                            new Time(new UShort(0), new UShort(0), new UShort(0))
                        )
                    )
                ),
            ],
            pair => pair.Key,
            pair => pair.Value,
            column => new ColumnHash(column)
        );
}
