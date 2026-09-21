using System.Collections;
using System.Linq.Expressions;
using Pure.RelationalSchema.Abstractions.Table;
using Pure.RelationalSchema.Samples.Tables;
using Pure.RelationalSchema.Storage.Abstractions;
using Pure.RelationalSchema.Storage.Samples.Rows;

namespace Pure.RelationalSchema.Storage.Samples.TableDataSets;

// The referenced side of the entity-qualification fixture. The fourth row is
// referenced by no row of AmbiguousIdTableDataSet, so an outer join has
// something to pad.
public sealed record AmbiguousIdLookupTableDataSet : IStoredTableDataSet
{
    private readonly IQueryable<IRow> _rows;

    public AmbiguousIdLookupTableDataSet()
    {
        _rows = new IRow[]
        {
            new FirstAmbiguousIdLookupRow(),
            new SecondAmbiguousIdLookupRow(),
            new ThirdAmbiguousIdLookupRow(),
            new FourthAmbiguousIdLookupRow(),
        }.AsQueryable();
    }

    public ITable TableSchema => new TableWithSingleIndex();

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
