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
                new KeyValuePair<IColumn, ICell>(new UserIdColumn(), new EmptyCell()),
                new KeyValuePair<IColumn, ICell>(
                    new UserTenantIdColumn(),
                    new EmptyCell()
                ),
                new KeyValuePair<IColumn, ICell>(new UserNameColumn(), new EmptyCell()),
                new KeyValuePair<IColumn, ICell>(new SignupDateColumn(), new EmptyCell()),
                new KeyValuePair<IColumn, ICell>(new UserActiveColumn(), new EmptyCell()),
                new KeyValuePair<IColumn, ICell>(new LastLoginColumn(), new EmptyCell()),
                new KeyValuePair<IColumn, ICell>(new UserAgeColumn(), new EmptyCell()),
                new KeyValuePair<IColumn, ICell>(new ShiftStartColumn(), new EmptyCell()),
                new KeyValuePair<IColumn, ICell>(new UserScoreColumn(), new EmptyCell()),
                new KeyValuePair<IColumn, ICell>(
                    new UserPrecisionValueColumn(),
                    new EmptyCell()
                ),
                new KeyValuePair<IColumn, ICell>(
                    new UserEdgeDateColumn(),
                    new EmptyCell()
                ),
                new KeyValuePair<IColumn, ICell>(
                    new UserEdgeDateTimeColumn(),
                    new EmptyCell()
                ),
                new KeyValuePair<IColumn, ICell>(
                    new UserEdgeTimeColumn(),
                    new EmptyCell()
                ),
            ],
            pair => pair.Key,
            pair => pair.Value,
            column => new ColumnHash(column)
        );
}
