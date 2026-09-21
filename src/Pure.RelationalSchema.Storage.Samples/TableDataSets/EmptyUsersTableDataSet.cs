using System.Collections;
using System.Linq.Expressions;
using Pure.RelationalSchema.Abstractions.Table;
using Pure.RelationalSchema.Samples.Tables;
using Pure.RelationalSchema.Storage.Abstractions;

namespace Pure.RelationalSchema.Storage.Samples.TableDataSets;

public sealed record EmptyUsersTableDataSet : IStoredTableDataSet
{
    private readonly IQueryable<IRow> _rows;

    public EmptyUsersTableDataSet()
    {
        _rows = Array.Empty<IRow>().AsQueryable();
    }

    public ITable TableSchema => new UsersTable();

    public Type ElementType => _rows.ElementType;

    public Expression Expression => _rows.Expression;

    public IQueryProvider Provider => _rows.Provider;

    // Stryker disable once Block
    public async IAsyncEnumerator<IRow> GetAsyncEnumerator(
        CancellationToken cancellationToken = default
    )
    {
        // Stryker disable once Block
        foreach (IRow row in _rows)
        {
            // Stryker disable once Statement
            yield return row;
            // Stryker disable once Statement
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
