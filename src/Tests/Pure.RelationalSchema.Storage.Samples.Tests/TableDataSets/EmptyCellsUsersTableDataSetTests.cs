using System.Collections;
using Pure.RelationalSchema.HashCodes;
using Pure.RelationalSchema.Samples.Tables;
using Pure.RelationalSchema.Storage.Abstractions;
using Pure.RelationalSchema.Storage.HashCodes;
using Pure.RelationalSchema.Storage.Samples.Rows;
using Pure.RelationalSchema.Storage.Samples.TableDataSets;

namespace Pure.RelationalSchema.Storage.Samples.Tests.TableDataSets;

public sealed record EmptyCellsUsersTableDataSetTests
{
    [Fact]
    public void TableSchemaIsUsersTable()
    {
        IStoredTableDataSet dataSet = new EmptyCellsUsersTableDataSet();

        Assert.True(
            new TableHash(dataSet.TableSchema).SequenceEqual(
                new TableHash(new UsersTable())
            )
        );
    }

    [Fact]
    public void RowsCountIs1()
    {
        IStoredTableDataSet dataSet = new EmptyCellsUsersTableDataSet();

        _ = Assert.Single((IEnumerable<IRow>)dataSet);
    }

    [Fact]
    public void ContainsEmptyCellsUserRow()
    {
        IStoredTableDataSet dataSet = new EmptyCellsUsersTableDataSet();

        Assert.Contains(
            (IEnumerable<IRow>)dataSet,
            row => new RowHash(row).SequenceEqual(new RowHash(new EmptyCellsUserRow()))
        );
    }

    [Fact]
    public void ElementTypeIsRowInterface()
    {
        IStoredTableDataSet dataSet = new EmptyCellsUsersTableDataSet();

        Assert.Equal(typeof(IRow), dataSet.ElementType);
    }

    [Fact]
    public void ExpressionIsNotNull()
    {
        IStoredTableDataSet dataSet = new EmptyCellsUsersTableDataSet();

        Assert.NotNull(dataSet.Expression);
    }

    [Fact]
    public void ProviderExecutesQuery()
    {
        IStoredTableDataSet dataSet = new EmptyCellsUsersTableDataSet();

        Assert.NotNull(dataSet.Provider);
        _ = Assert.Single(dataSet.ToArray());
    }

    [Fact]
    public void NonGenericEnumeratorEnumeratesOneRow()
    {
        IStoredTableDataSet dataSet = new EmptyCellsUsersTableDataSet();

        IEnumerator enumerator = ((IEnumerable)dataSet).GetEnumerator();

        int count = 0;
        while (enumerator.MoveNext())
        {
            count++;
        }

        Assert.Equal(1, count);
    }

    [Fact]
    public async Task AsyncEnumerationYieldsOneRow()
    {
        IStoredTableDataSet dataSet = new EmptyCellsUsersTableDataSet();

        List<IRow> rows = [];

        await foreach (IRow row in dataSet)
        {
            rows.Add(row);
        }

        _ = Assert.Single(rows);
    }
}
