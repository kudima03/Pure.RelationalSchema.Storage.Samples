using System.Collections;
using System.Linq.Expressions;
using Pure.RelationalSchema.Abstractions.Table;
using Pure.RelationalSchema.Samples.Tables;
using Pure.RelationalSchema.Storage.Abstractions;
using Pure.RelationalSchema.Storage.Samples.Rows;

namespace Pure.RelationalSchema.Storage.Samples.TableDataSets;

// A users row whose every cell is empty - the all-NULL shape. The six-row
// UsersTableDataSet deliberately mixes NULL and non-NULL scores instead, which
// this data set cannot express.
public sealed record EmptyCellsUsersTableDataSet : IStoredTableDataSet
{
    private readonly IQueryable<IRow> _rows;

    private EmptyCellsUsersTableDataSet(IQueryable<IRow> rows)
    {
        _rows = rows;
    }

    public EmptyCellsUsersTableDataSet()
        : this(new IRow[] { new EmptyCellsUserRow() }.AsQueryable()) { }

    public ITable TableSchema => new UsersTable();

    public Type ElementType => _rows.ElementType;

    public Expression Expression => _rows.Expression;

    public IQueryProvider Provider => _rows.Provider;

    public IAsyncEnumerator<IRow> GetAsyncEnumerator(
        CancellationToken cancellationToken = default
    )
    {
        return new SynchronousAsyncRowEnumerator(_rows.GetEnumerator());
    }

    public IEnumerator<IRow> GetEnumerator()
    {
        return _rows.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
