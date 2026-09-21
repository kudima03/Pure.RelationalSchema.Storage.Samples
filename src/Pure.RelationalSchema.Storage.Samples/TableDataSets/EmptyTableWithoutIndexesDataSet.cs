using System.Collections;
using System.Linq.Expressions;
using Pure.RelationalSchema.Abstractions.Table;
using Pure.RelationalSchema.Samples.Tables;
using Pure.RelationalSchema.Storage.Abstractions;

namespace Pure.RelationalSchema.Storage.Samples.TableDataSets;

public sealed record EmptyTableWithoutIndexesDataSet : IStoredTableDataSet
{
    private readonly IQueryable<IRow> _rows;

    private EmptyTableWithoutIndexesDataSet(IQueryable<IRow> rows)
    {
        _rows = rows;
    }

    public EmptyTableWithoutIndexesDataSet()
        : this(Array.Empty<IRow>().AsQueryable()) { }

    public ITable TableSchema => new TableWithoutIndexes();

    public Type ElementType => _rows.ElementType;

    public Expression Expression => _rows.Expression;

    public IQueryProvider Provider => _rows.Provider;

    public async IAsyncEnumerator<IRow> GetAsyncEnumerator(
        CancellationToken cancellationToken = default
    )
    {
        foreach (IRow row in _rows)
        {
            yield return row;
            await Task.CompletedTask;
        }
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
