using System.Collections;
using Pure.RelationalSchema.HashCodes;
using Pure.RelationalSchema.Samples.Tables;
using Pure.RelationalSchema.Storage.Abstractions;
using Pure.RelationalSchema.Storage.Samples.TableDataSets;

namespace Pure.RelationalSchema.Storage.Samples.Tests.TableDataSets;

public sealed record EmptyUsersTableDataSetTests
{
    [Fact]
    public void TableSchemaIsUsersTable()
    {
        IStoredTableDataSet dataSet = new EmptyUsersTableDataSet();

        Assert.True(
            new TableHash(dataSet.TableSchema).SequenceEqual(
                new TableHash(new UsersTable())
            )
        );
    }

    [Fact]
    public void RowsAreEmpty()
    {
        IStoredTableDataSet dataSet = new EmptyUsersTableDataSet();

        Assert.Empty((IEnumerable<IRow>)dataSet);
    }

    [Fact]
    public void ElementTypeIsRowInterface()
    {
        IStoredTableDataSet dataSet = new EmptyUsersTableDataSet();

        Assert.Equal(typeof(IRow), dataSet.ElementType);
    }

    [Fact]
    public void ExpressionIsNotNull()
    {
        IStoredTableDataSet dataSet = new EmptyUsersTableDataSet();

        Assert.NotNull(dataSet.Expression);
    }

    [Fact]
    public void ProviderExecutesQuery()
    {
        IStoredTableDataSet dataSet = new EmptyUsersTableDataSet();

        Assert.NotNull(dataSet.Provider);
        Assert.Empty(dataSet.ToArray());
    }

    [Fact]
    public void NonGenericEnumeratorEnumeratesNoRows()
    {
        IStoredTableDataSet dataSet = new EmptyUsersTableDataSet();

        IEnumerator enumerator = ((IEnumerable)dataSet).GetEnumerator();

        Assert.False(enumerator.MoveNext());
    }

    [Fact]
    public async Task AsyncEnumerationYieldsNoRows()
    {
        IStoredTableDataSet dataSet = new EmptyUsersTableDataSet();

        List<IRow> rows = [];

        await foreach (IRow row in dataSet)
        {
            rows.Add(row);
        }

        Assert.Empty(rows);
    }
}
