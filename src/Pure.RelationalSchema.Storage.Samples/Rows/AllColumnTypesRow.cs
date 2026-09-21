using Pure.Collections.Generic;
using Pure.RelationalSchema.Abstractions.Column;
using Pure.RelationalSchema.HashCodes;
using Pure.RelationalSchema.Samples.Columns;
using Pure.RelationalSchema.Storage.Abstractions;
using Pure.RelationalSchema.Storage.Samples.Cells;

namespace Pure.RelationalSchema.Storage.Samples.Rows;

public sealed record AllColumnTypesRow : IRow
{
    public IReadOnlyDictionary<IColumn, ICell> Cells =>
        new Dictionary<KeyValuePair<IColumn, ICell>, IColumn, ICell>(
            [
                new KeyValuePair<IColumn, ICell>(new IdColumn(), new UuidCell()),
                new KeyValuePair<IColumn, ICell>(new NameColumn(), new TextCell()),
                new KeyValuePair<IColumn, ICell>(new AgeColumn(), new IntCell()),
                new KeyValuePair<IColumn, ICell>(new QuantityColumn(), new LongCell()),
                new KeyValuePair<IColumn, ICell>(new PriceColumn(), new DoubleCell()),
                new KeyValuePair<IColumn, ICell>(new IsActiveColumn(), new BoolCell()),
                new KeyValuePair<IColumn, ICell>(new BirthDateColumn(), new DateCell()),
                new KeyValuePair<IColumn, ICell>(new StartTimeColumn(), new TimeCell()),
                new KeyValuePair<IColumn, ICell>(
                    new CreatedAtColumn(),
                    new DateTimeCell()
                ),
                new KeyValuePair<IColumn, ICell>(new EmptyNameColumn(), new EmptyCell()),
            ],
            pair => pair.Key,
            pair => pair.Value,
            column => new ColumnHash(column)
        );
}
