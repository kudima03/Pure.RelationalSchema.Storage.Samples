using System.Collections;
using Pure.RelationalSchema.HashCodes;
using Pure.RelationalSchema.Samples.Tables;
using Pure.RelationalSchema.Storage.Abstractions;
using Pure.RelationalSchema.Storage.HashCodes;
using Pure.RelationalSchema.Storage.Samples.Rows;
using Pure.RelationalSchema.Storage.Samples.TableDataSets;

namespace Pure.RelationalSchema.Storage.Samples.Tests.TableDataSets;

public sealed record AllColumnTypesTableDataSetTests
{
    [Fact]
    public void TableSchemaIsAllColumnTypesTable()
    {
        IStoredTableDataSet dataSet = new AllColumnTypesTableDataSet();

        Assert.True(
            new TableHash(dataSet.TableSchema).SequenceEqual(
                new TableHash(new AllColumnTypesTable())
            )
        );
    }

    [Fact]
    public void RowsCountIs1()
    {
        IStoredTableDataSet dataSet = new AllColumnTypesTableDataSet();

        _ = Assert.Single((IEnumerable<IRow>)dataSet);
    }

    [Fact]
    public void ContainsAllColumnTypesRow()
    {
        IStoredTableDataSet dataSet = new AllColumnTypesTableDataSet();

        Assert.Contains(
            (IEnumerable<IRow>)dataSet,
            row => new RowHash(row).SequenceEqual(new RowHash(new AllColumnTypesRow()))
        );
    }

    [Fact]
    public void ElementTypeIsRowInterface()
    {
        IStoredTableDataSet dataSet = new AllColumnTypesTableDataSet();

        Assert.Equal(typeof(IRow), dataSet.ElementType);
    }

    [Fact]
    public void ExpressionIsNotNull()
    {
        IStoredTableDataSet dataSet = new AllColumnTypesTableDataSet();

        Assert.NotNull(dataSet.Expression);
    }

    [Fact]
    public void ProviderExecutesQuery()
    {
        IStoredTableDataSet dataSet = new AllColumnTypesTableDataSet();

        Assert.NotNull(dataSet.Provider);
        _ = Assert.Single(dataSet.ToArray());
    }

    [Fact]
    public void NonGenericEnumeratorEnumeratesOneRow()
    {
        IStoredTableDataSet dataSet = new AllColumnTypesTableDataSet();

        IEnumerator enumerator = ((IEnumerable)dataSet).GetEnumerator();

        Assert.True(enumerator.MoveNext());
        Assert.False(enumerator.MoveNext());
    }

    [Fact]
    public async Task AsyncEnumerationYieldsOneRow()
    {
        IStoredTableDataSet dataSet = new AllColumnTypesTableDataSet();

        List<IRow> rows = [];

        await foreach (IRow row in dataSet)
        {
            rows.Add(row);
        }

        _ = Assert.Single(rows);
    }
}
