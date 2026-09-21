using Pure.Collections.Generic;
using Pure.Primitives.Number;
using Pure.Primitives.Time;
using Pure.RelationalSchema.Abstractions.Column;
using Pure.RelationalSchema.HashCodes;
using Pure.RelationalSchema.Samples.Columns;
using Pure.RelationalSchema.Storage.Abstractions;
using Pure.RelationalSchema.Storage.Samples.Cells;
using Guid = Pure.Primitives.Guid.Guid;
using String = Pure.Primitives.String.String;

namespace Pure.RelationalSchema.Storage.Samples.Rows;

public sealed record FourthEmployeeRow : IRow
{
    public IReadOnlyDictionary<IColumn, ICell> Cells =>
        new Dictionary<KeyValuePair<IColumn, ICell>, IColumn, ICell>(
            [
                new KeyValuePair<IColumn, ICell>(
                    new EmployeeIdColumn(),
                    new InvariantCell(
                        new Guid(new System.Guid("000002c0-0000-0000-0000-000000000000"))
                    )
                ),
                new KeyValuePair<IColumn, ICell>(
                    new EmployeeNameColumn(),
                    new InvariantCell(new String("Jack"))
                ),
                new KeyValuePair<IColumn, ICell>(
                    new EmployeeManagerIdColumn(),
                    new InvariantCell(
                        new Guid(new System.Guid("000002be-0000-0000-0000-000000000000"))
                    )
                ),
                new KeyValuePair<IColumn, ICell>(
                    new EmployeeShiftStartColumn(),
                    new InvariantCell(
                        new Time(new UShort(8), new UShort(0), new UShort(0))
                    )
                ),
                new KeyValuePair<IColumn, ICell>(
                    new EmployeeUserIdColumn(),
                    new InvariantCell(
                        new Guid(new System.Guid("00000004-0000-0000-0000-000000000000"))
                    )
                ),
            ],
            pair => pair.Key,
            pair => pair.Value,
            column => new ColumnHash(column)
        );
}
