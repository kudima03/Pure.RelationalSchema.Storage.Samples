using System.Collections;
using System.Linq.Expressions;
using Pure.RelationalSchema.Abstractions.Table;
using Pure.RelationalSchema.Samples.Tables;
using Pure.RelationalSchema.Storage.Abstractions;
using Pure.RelationalSchema.Storage.Samples.Rows;

namespace Pure.RelationalSchema.Storage.Samples.TableDataSets;

// Six orders over four of the six users (user 1 twice, user 2 once, user 3
// twice, user 4 once); users 5 and 6 have none, so an outer join has unmatched
// rows on the users side. order_total repeats (100.5 twice) for DISTINCT, and
// the statuses are lowercase ASCII so ordinal ordering is collation-independent.
public sealed record OrdersTableDataSet : IStoredTableDataSet
{
    private readonly IQueryable<IRow> _rows;

    private OrdersTableDataSet(IQueryable<IRow> rows)
    {
        _rows = rows;
    }

    private static IQueryable<IRow> Rows =>
        new IRow[]
        {
            new OrderRow(),
            new SecondOrderRow(),
            new ThirdOrderRow(),
            new FourthOrderRow(),
            new FifthOrderRow(),
            new SixthOrderRow(),
        }.AsQueryable();

    public OrdersTableDataSet()
        : this(Rows) { }

    public ITable TableSchema => new OrdersTable();

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
