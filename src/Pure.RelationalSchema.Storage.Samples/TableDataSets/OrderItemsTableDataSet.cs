using System.Collections;
using System.Linq.Expressions;
using Pure.RelationalSchema.Abstractions.Table;
using Pure.RelationalSchema.Samples.Tables;
using Pure.RelationalSchema.Storage.Abstractions;
using Pure.RelationalSchema.Storage.Samples.Rows;

namespace Pure.RelationalSchema.Storage.Samples.TableDataSets;

// Four items over orders 101, 101, 103 and 105 and products 201, 202, 203 and
// 201 - deliberately neither 1:1 nor uniform, so join cardinality is testable.
public sealed record OrderItemsTableDataSet : IStoredTableDataSet
{
    private readonly IQueryable<IRow> _rows;

    private OrderItemsTableDataSet(IQueryable<IRow> rows)
    {
        _rows = rows;
    }

    private static IQueryable<IRow> Rows =>
        new IRow[]
        {
            new OrderItemRow(),
            new SecondOrderItemRow(),
            new ThirdOrderItemRow(),
            new FourthOrderItemRow(),
        }.AsQueryable();

    public OrderItemsTableDataSet()
        : this(Rows) { }

    public ITable TableSchema => new OrderItemsTable();

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
