using Pure.Collections.Generic;
using Pure.RelationalSchema.Abstractions.Column;
using Pure.RelationalSchema.HashCodes;
using Pure.RelationalSchema.Samples.Columns;
using Pure.RelationalSchema.Storage.Abstractions;
using Pure.RelationalSchema.Storage.Samples.Cells;

namespace Pure.RelationalSchema.Storage.Samples.Rows;

public sealed record EmptyCellsUserRow : IRow
{
    public IReadOnlyDictionary<IColumn, ICell> Cells =>
        new Dictionary<KeyValuePair<IColumn, ICell>, IColumn, ICell>(
            [
                new KeyValuePair<IColumn, ICell>(new IdColumn(), new EmptyCell()),
                new KeyValuePair<IColumn, ICell>(new TenantIdColumn(), new EmptyCell()),
                new KeyValuePair<IColumn, ICell>(new NameColumn(), new EmptyCell()),
                new KeyValuePair<IColumn, ICell>(new BirthDateColumn(), new EmptyCell()),
                new KeyValuePair<IColumn, ICell>(new IsActiveColumn(), new EmptyCell()),
                new KeyValuePair<IColumn, ICell>(new CreatedAtColumn(), new EmptyCell()),
            ],
            pair => pair.Key,
            pair => pair.Value,
            column => new ColumnHash(column)
        );
}
