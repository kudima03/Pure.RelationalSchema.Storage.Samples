using System.Collections;
using System.Linq.Expressions;
using Pure.RelationalSchema.Abstractions.Table;
using Pure.RelationalSchema.Samples.Tables;
using Pure.RelationalSchema.Storage.Abstractions;
using Pure.RelationalSchema.Storage.Samples.Rows;

namespace Pure.RelationalSchema.Storage.Samples.TableDataSets;

// The six users the query-grade fixture is written against. Three properties
// are load-bearing:
//   - ages and scores repeat (30 twice, 25 twice), so GROUP BY produces real
//     groups rather than one row per user;
//   - Ann, Cara and Fay have user_score == user_age, Eve has a real mismatch
//     and Bob and Dan are NULL, so a failed match is attributable to a
//     mismatch or to NULL, never to both;
//   - Fay repeats Ann's signup_date, last_login and shift_start, so each of
//     those columns is discriminating for DISTINCT over its own type.
// user_precision_value carries the numeric extremes and user_edge_* the
// calendar extremes, so a round trip through cell text is covered at the
// boundaries as well as in the middle.
public sealed record UsersTableDataSet : IStoredTableDataSet
{
    private readonly IQueryable<IRow> _rows;

    public UsersTableDataSet()
    {
        _rows = new IRow[]
        {
            new UserRow(),
            new SecondUserRow(),
            new ThirdUserRow(),
            new FourthUserRow(),
            new FifthUserRow(),
            new SixthUserRow(),
        }.AsQueryable();
    }

    public ITable TableSchema => new UsersTable();

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
