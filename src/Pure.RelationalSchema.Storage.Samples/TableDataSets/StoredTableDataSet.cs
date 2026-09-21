using System.Collections;
using System.Linq.Expressions;
using Pure.RelationalSchema.Abstractions.Table;
using Pure.RelationalSchema.Storage.Abstractions;

namespace Pure.RelationalSchema.Storage.Samples.TableDataSets;

// The one table data set in this catalogue that is not a named singleton: it
// pairs any table schema with any rows. Consumers need it for shapes no named
// sample can express - a deliberately malformed cell, a row set assembled per
// test - without depending on a storage implementation package.
public sealed record StoredTableDataSet : IStoredTableDataSet
{
    private readonly IQueryable<IRow> _rows;

    public StoredTableDataSet(ITable tableSchema, IEnumerable<IRow> rows)
    {
        TableSchema = tableSchema;
        _rows = rows.ToArray().AsQueryable();
    }

    public ITable TableSchema { get; }

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
