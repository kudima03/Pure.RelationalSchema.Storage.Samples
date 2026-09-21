using System.Collections;
using System.Linq.Expressions;
using Pure.RelationalSchema.Abstractions.Table;
using Pure.RelationalSchema.Samples.Tables;
using Pure.RelationalSchema.Storage.Abstractions;
using Pure.RelationalSchema.Storage.Samples.Rows;

namespace Pure.RelationalSchema.Storage.Samples.TableDataSets;

public sealed record ProductsTableDataSet : IStoredTableDataSet
{
    private readonly IQueryable<IRow> _rows;

    private ProductsTableDataSet(IQueryable<IRow> rows)
    {
        _rows = rows;
    }

    private static IQueryable<IRow> Rows =>
        new IRow[]
        {
            new ProductRow(),
            new SecondProductRow(),
            new ThirdProductRow(),
            new FourthProductRow(),
        }.AsQueryable();

    public ProductsTableDataSet()
        : this(Rows) { }

    public ITable TableSchema => new ProductsTable();

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
