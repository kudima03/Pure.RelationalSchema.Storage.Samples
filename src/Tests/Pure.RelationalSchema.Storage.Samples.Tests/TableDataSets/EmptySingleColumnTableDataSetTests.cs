using System.Collections;
using Pure.RelationalSchema.HashCodes;
using Pure.RelationalSchema.Samples.Tables;
using Pure.RelationalSchema.Storage.Abstractions;
using Pure.RelationalSchema.Storage.Samples.TableDataSets;

namespace Pure.RelationalSchema.Storage.Samples.Tests.TableDataSets;

public sealed record EmptySingleColumnTableDataSetTests
{
    [Fact]
    public void TableSchemaIsSingleColumnTable()
    {
        IStoredTableDataSet dataSet = new EmptySingleColumnTableDataSet();

        Assert.True(
            new TableHash(dataSet.TableSchema).SequenceEqual(
                new TableHash(new SingleColumnTable())
            )
        );
    }

    [Fact]
    public void RowsAreEmpty()
    {
        IStoredTableDataSet dataSet = new EmptySingleColumnTableDataSet();

        Assert.Empty((IEnumerable<IRow>)dataSet);
    }

    [Fact]
    public void ElementTypeIsRowInterface()
    {
        IStoredTableDataSet dataSet = new EmptySingleColumnTableDataSet();

        Assert.Equal(typeof(IRow), dataSet.ElementType);
    }

    [Fact]
    public void ExpressionIsNotNull()
    {
        IStoredTableDataSet dataSet = new EmptySingleColumnTableDataSet();

        Assert.NotNull(dataSet.Expression);
    }

    [Fact]
    public void ProviderExecutesQuery()
    {
        IStoredTableDataSet dataSet = new EmptySingleColumnTableDataSet();

        Assert.NotNull(dataSet.Provider);
        Assert.Empty(dataSet.ToArray());
    }

    [Fact]
    public void NonGenericEnumeratorEnumeratesNoRows()
    {
        IStoredTableDataSet dataSet = new EmptySingleColumnTableDataSet();

        IEnumerator enumerator = ((IEnumerable)dataSet).GetEnumerator();

        Assert.False(enumerator.MoveNext());
    }

    [Fact]
    public async Task AsyncEnumerationYieldsNoRows()
    {
        IStoredTableDataSet dataSet = new EmptySingleColumnTableDataSet();

        List<IRow> rows = [];

        await foreach (IRow row in dataSet)
        {
            rows.Add(row);
        }

        Assert.Empty(rows);
    }
}
