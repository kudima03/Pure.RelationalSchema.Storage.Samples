using System.Collections;
using System.Linq.Expressions;
using Pure.RelationalSchema.Abstractions.Table;
using Pure.RelationalSchema.Samples.Tables;
using Pure.RelationalSchema.Storage.Abstractions;
using Pure.RelationalSchema.Storage.Samples.Rows;

namespace Pure.RelationalSchema.Storage.Samples.TableDataSets;

// Four logins in the audit domain, referencing user 1 twice, user 2 once and
// user 5 once; users 3, 4 and 6 have none.
public sealed record LoginsTableDataSet : IStoredTableDataSet
{
    private readonly IQueryable<IRow> _rows;

    private LoginsTableDataSet(IQueryable<IRow> rows)
    {
        _rows = rows;
    }

    private static IQueryable<IRow> Rows =>
        new IRow[]
        {
            new LoginRow(),
            new SecondLoginRow(),
            new ThirdLoginRow(),
            new FourthLoginRow(),
        }.AsQueryable();

    public LoginsTableDataSet()
        : this(Rows) { }

    public ITable TableSchema => new LoginsTable();

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
