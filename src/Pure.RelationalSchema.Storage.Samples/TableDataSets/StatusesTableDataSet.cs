using System.Collections;
using System.Linq.Expressions;
using Pure.RelationalSchema.Abstractions.Table;
using Pure.RelationalSchema.Samples.Tables;
using Pure.RelationalSchema.Storage.Abstractions;
using Pure.RelationalSchema.Storage.Samples.Rows;

namespace Pure.RelationalSchema.Storage.Samples.TableDataSets;

// The four order statuses. Only three of them are used by an order - refunded
// is referenced by none, so the outbound cross-domain join
// (orders.order_status -> statuses.status_code) has an unmatched row on the
// referenced side.
public sealed record StatusesTableDataSet : IStoredTableDataSet
{
    private readonly IQueryable<IRow> _rows;

    public StatusesTableDataSet()
    {
        _rows = new IRow[]
        {
            new StatusRow(),
            new SecondStatusRow(),
            new ThirdStatusRow(),
            new FourthStatusRow(),
        }.AsQueryable();
    }

    public ITable TableSchema => new StatusesTable();

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
