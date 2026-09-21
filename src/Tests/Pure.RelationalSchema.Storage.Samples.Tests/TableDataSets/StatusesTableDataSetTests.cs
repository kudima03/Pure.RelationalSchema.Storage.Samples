using System.Collections;
using Pure.RelationalSchema.HashCodes;
using Pure.RelationalSchema.Samples.Tables;
using Pure.RelationalSchema.Storage.Abstractions;
using Pure.RelationalSchema.Storage.HashCodes;
using Pure.RelationalSchema.Storage.Samples.Rows;
using Pure.RelationalSchema.Storage.Samples.TableDataSets;

namespace Pure.RelationalSchema.Storage.Samples.Tests.TableDataSets;

public sealed record StatusesTableDataSetTests
{
    [Fact]
    public void TableSchemaIsStatusesTable()
    {
        IStoredTableDataSet dataSet = new StatusesTableDataSet();

        Assert.True(
            new TableHash(dataSet.TableSchema).SequenceEqual(
                new TableHash(new StatusesTable())
            )
        );
    }

    [Fact]
    public void RowsCountIs4()
    {
        IStoredTableDataSet dataSet = new StatusesTableDataSet();

        Assert.Equal(4, dataSet.Count());
    }

    [Fact]
    public void ContainsStatusRow()
    {
        IStoredTableDataSet dataSet = new StatusesTableDataSet();

        Assert.Contains(
            (IEnumerable<IRow>)dataSet,
            row => new RowHash(row).SequenceEqual(new RowHash(new StatusRow()))
        );
    }

    [Fact]
    public void ContainsSecondStatusRow()
    {
        IStoredTableDataSet dataSet = new StatusesTableDataSet();

        Assert.Contains(
            (IEnumerable<IRow>)dataSet,
            row => new RowHash(row).SequenceEqual(new RowHash(new SecondStatusRow()))
        );
    }

    [Fact]
    public void ContainsThirdStatusRow()
    {
        IStoredTableDataSet dataSet = new StatusesTableDataSet();

        Assert.Contains(
            (IEnumerable<IRow>)dataSet,
            row => new RowHash(row).SequenceEqual(new RowHash(new ThirdStatusRow()))
        );
    }

    [Fact]
    public void ContainsFourthStatusRow()
    {
        IStoredTableDataSet dataSet = new StatusesTableDataSet();

        Assert.Contains(
            (IEnumerable<IRow>)dataSet,
            row => new RowHash(row).SequenceEqual(new RowHash(new FourthStatusRow()))
        );
    }

    [Fact]
    public void ElementTypeIsRowInterface()
    {
        IStoredTableDataSet dataSet = new StatusesTableDataSet();

        Assert.Equal(typeof(IRow), dataSet.ElementType);
    }

    [Fact]
    public void ExpressionIsNotNull()
    {
        IStoredTableDataSet dataSet = new StatusesTableDataSet();

        Assert.NotNull(dataSet.Expression);
    }

    [Fact]
    public void ProviderExecutesQuery()
    {
        IStoredTableDataSet dataSet = new StatusesTableDataSet();

        Assert.NotNull(dataSet.Provider);
        Assert.Equal(4, dataSet.ToArray().Length);
    }

    [Fact]
    public void NonGenericEnumeratorEnumeratesFourRows()
    {
        IStoredTableDataSet dataSet = new StatusesTableDataSet();

        IEnumerator enumerator = ((IEnumerable)dataSet).GetEnumerator();

        int count = 0;
        while (enumerator.MoveNext())
        {
            count++;
        }

        Assert.Equal(4, count);
    }

    [Fact]
    public async Task AsyncEnumerationYieldsFourRows()
    {
        IStoredTableDataSet dataSet = new StatusesTableDataSet();

        List<IRow> rows = [];

        await foreach (IRow row in dataSet)
        {
            rows.Add(row);
        }

        Assert.Equal(4, rows.Count);
    }
}
