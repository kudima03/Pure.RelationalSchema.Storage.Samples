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

public sealed record EmployeeRow : IRow
{
    public IReadOnlyDictionary<IColumn, ICell> Cells =>
        new Dictionary<KeyValuePair<IColumn, ICell>, IColumn, ICell>(
            [
                new KeyValuePair<IColumn, ICell>(
                    new EmployeeIdColumn(),
                    new InvariantCell(
                        new Guid(new System.Guid("000002bd-0000-0000-0000-000000000000"))
                    )
                ),
                new KeyValuePair<IColumn, ICell>(
                    new EmployeeNameColumn(),
                    new InvariantCell(new String("Grace"))
                ),
                new KeyValuePair<IColumn, ICell>(
                    new EmployeeManagerIdColumn(),
                    new EmptyCell()
                ),
                new KeyValuePair<IColumn, ICell>(
                    new EmployeeShiftStartColumn(),
                    new InvariantCell(
                        new Time(new UShort(9), new UShort(0), new UShort(0))
                    )
                ),
                new KeyValuePair<IColumn, ICell>(
                    new EmployeeUserIdColumn(),
                    new InvariantCell(
                        new Guid(new System.Guid("00000001-0000-0000-0000-000000000000"))
                    )
                ),
            ],
            pair => pair.Key,
            pair => pair.Value,
            column => new ColumnHash(column)
        );
}
