using System.Collections;
using System.Linq.Expressions;
using Pure.RelationalSchema.Abstractions.Table;
using Pure.RelationalSchema.Samples.Tables;
using Pure.RelationalSchema.Storage.Abstractions;
using Pure.RelationalSchema.Storage.Samples.Rows;

namespace Pure.RelationalSchema.Storage.Samples.TableDataSets;

// The referencing side of the entity-qualification fixture: both this data set
// and AmbiguousIdLookupTableDataSet carry columns literally named `id` and
// `name`, joined on table_with_indexes.tenant_id = table_with_single_index.id,
// so a bare field reference across the two is genuinely ambiguous.
public sealed record AmbiguousIdTableDataSet : IStoredTableDataSet
{
    private readonly IQueryable<IRow> _rows;

    public AmbiguousIdTableDataSet()
    {
        _rows = new IRow[]
        {
            new FirstAmbiguousIdRow(),
            new SecondAmbiguousIdRow(),
            new ThirdAmbiguousIdRow(),
            new FourthAmbiguousIdRow(),
            new FifthAmbiguousIdRow(),
            new SixthAmbiguousIdRow(),
        }.AsQueryable();
    }

    public ITable TableSchema => new TableWithIndexes();

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
