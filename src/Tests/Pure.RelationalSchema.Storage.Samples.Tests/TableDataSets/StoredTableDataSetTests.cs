using System.Collections;
using Pure.RelationalSchema.HashCodes;
using Pure.RelationalSchema.Samples.Tables;
using Pure.RelationalSchema.Storage.Abstractions;
using Pure.RelationalSchema.Storage.HashCodes;
using Pure.RelationalSchema.Storage.Samples.Rows;
using Pure.RelationalSchema.Storage.Samples.TableDataSets;

namespace Pure.RelationalSchema.Storage.Samples.Tests.TableDataSets;

public sealed record StoredTableDataSetTests
{
    [Fact]
    public void TableSchemaIsTheGivenTable()
    {
        IStoredTableDataSet dataSet = new StoredTableDataSet(
            new UsersTable(),
            [new UserRow()]
        );

        Assert.True(
            new TableHash(dataSet.TableSchema).SequenceEqual(
                new TableHash(new UsersTable())
            )
        );
    }

    [Fact]
    public void HoldsTheGivenRows()
    {
        IStoredTableDataSet dataSet = new StoredTableDataSet(
            new UsersTable(),
            [new UserRow(), new SecondUserRow()]
        );

        Assert.Equal(2, dataSet.Count());
    }

    [Fact]
    public void ContainsTheGivenRow()
    {
        IStoredTableDataSet dataSet = new StoredTableDataSet(
            new UsersTable(),
            [new SecondUserRow()]
        );

        Assert.Contains(
            (IEnumerable<IRow>)dataSet,
            row => new RowHash(row).SequenceEqual(new RowHash(new SecondUserRow()))
        );
    }

    [Fact]
    public void AcceptsNoRows()
    {
        IStoredTableDataSet dataSet = new StoredTableDataSet(new UsersTable(), []);

        Assert.Empty((IEnumerable<IRow>)dataSet);
    }

    [Fact]
    public void AcceptsARowThatDoesNotMatchTheTableSchema()
    {
        IStoredTableDataSet dataSet = new StoredTableDataSet(
            new UsersTable(),
            [new EmptyRow()]
        );

        IRow row = Assert.Single((IEnumerable<IRow>)dataSet);

        Assert.Empty(row.Cells);
    }

    [Fact]
    public void ElementTypeIsRowInterface()
    {
        IStoredTableDataSet dataSet = new StoredTableDataSet(
            new UsersTable(),
            [new UserRow()]
        );

        Assert.Equal(typeof(IRow), dataSet.ElementType);
    }

    [Fact]
    public void ExpressionIsNotNull()
    {
        IStoredTableDataSet dataSet = new StoredTableDataSet(
            new UsersTable(),
            [new UserRow()]
        );

        Assert.NotNull(dataSet.Expression);
    }

    [Fact]
    public void ProviderExecutesQuery()
    {
        IStoredTableDataSet dataSet = new StoredTableDataSet(
            new UsersTable(),
            [new UserRow(), new SecondUserRow()]
        );

        Assert.NotNull(dataSet.Provider);
        Assert.Equal(2, dataSet.ToArray().Length);
    }

    [Fact]
    public void NonGenericEnumeratorEnumeratesTwoRows()
    {
        IStoredTableDataSet dataSet = new StoredTableDataSet(
            new UsersTable(),
            [new UserRow(), new SecondUserRow()]
        );

        IEnumerator enumerator = ((IEnumerable)dataSet).GetEnumerator();

        int count = 0;
        while (enumerator.MoveNext())
        {
            count++;
        }

        Assert.Equal(2, count);
    }

    [Fact]
    public async Task AsyncEnumerationYieldsTwoRows()
    {
        IStoredTableDataSet dataSet = new StoredTableDataSet(
            new UsersTable(),
            [new UserRow(), new SecondUserRow()]
        );

        List<IRow> rows = [];

        await foreach (IRow row in dataSet)
        {
            rows.Add(row);
        }

        Assert.Equal(2, rows.Count);
    }
}
