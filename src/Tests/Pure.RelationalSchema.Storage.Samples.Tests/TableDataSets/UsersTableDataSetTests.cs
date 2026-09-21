using System.Collections;
using Pure.RelationalSchema.HashCodes;
using Pure.RelationalSchema.Samples.Tables;
using Pure.RelationalSchema.Storage.Abstractions;
using Pure.RelationalSchema.Storage.HashCodes;
using Pure.RelationalSchema.Storage.Samples.Rows;
using Pure.RelationalSchema.Storage.Samples.TableDataSets;

namespace Pure.RelationalSchema.Storage.Samples.Tests.TableDataSets;

public sealed record UsersTableDataSetTests
{
    [Fact]
    public void TableSchemaIsUsersTable()
    {
        IStoredTableDataSet dataSet = new UsersTableDataSet();

        Assert.True(
            new TableHash(dataSet.TableSchema).SequenceEqual(
                new TableHash(new UsersTable())
            )
        );
    }

    [Fact]
    public void RowsCountIs2()
    {
        IStoredTableDataSet dataSet = new UsersTableDataSet();

        Assert.Equal(2, dataSet.Count());
    }

    [Fact]
    public void ContainsUserRow()
    {
        IStoredTableDataSet dataSet = new UsersTableDataSet();

        Assert.Contains(
            (IEnumerable<IRow>)dataSet,
            row => new RowHash(row).SequenceEqual(new RowHash(new UserRow()))
        );
    }

    [Fact]
    public void ContainsEmptyCellsUserRow()
    {
        IStoredTableDataSet dataSet = new UsersTableDataSet();

        Assert.Contains(
            (IEnumerable<IRow>)dataSet,
            row => new RowHash(row).SequenceEqual(new RowHash(new EmptyCellsUserRow()))
        );
    }

    [Fact]
    public void ElementTypeIsRowInterface()
    {
        IStoredTableDataSet dataSet = new UsersTableDataSet();

        Assert.Equal(typeof(IRow), dataSet.ElementType);
    }

    [Fact]
    public void ExpressionIsNotNull()
    {
        IStoredTableDataSet dataSet = new UsersTableDataSet();

        Assert.NotNull(dataSet.Expression);
    }

    [Fact]
    public void ProviderExecutesQuery()
    {
        IStoredTableDataSet dataSet = new UsersTableDataSet();

        Assert.NotNull(dataSet.Provider);
        Assert.Equal(2, dataSet.ToArray().Length);
    }

    [Fact]
    public void NonGenericEnumeratorEnumeratesTwoRows()
    {
        IStoredTableDataSet dataSet = new UsersTableDataSet();

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
        IStoredTableDataSet dataSet = new UsersTableDataSet();

        List<IRow> rows = [];

        await foreach (IRow row in dataSet)
        {
            rows.Add(row);
        }

        Assert.Equal(2, rows.Count);
    }
}
