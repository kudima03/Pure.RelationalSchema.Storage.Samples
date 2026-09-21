using System.Collections;
using Pure.RelationalSchema.HashCodes;
using Pure.RelationalSchema.Samples.Tables;
using Pure.RelationalSchema.Storage.Abstractions;
using Pure.RelationalSchema.Storage.HashCodes;
using Pure.RelationalSchema.Storage.Samples.Rows;
using Pure.RelationalSchema.Storage.Samples.TableDataSets;

namespace Pure.RelationalSchema.Storage.Samples.Tests.TableDataSets;

public sealed record OrdersTableDataSetTests
{
    [Fact]
    public void TableSchemaIsOrdersTable()
    {
        IStoredTableDataSet dataSet = new OrdersTableDataSet();

        Assert.True(
            new TableHash(dataSet.TableSchema).SequenceEqual(
                new TableHash(new OrdersTable())
            )
        );
    }

    [Fact]
    public void RowsCountIs6()
    {
        IStoredTableDataSet dataSet = new OrdersTableDataSet();

        Assert.Equal(6, dataSet.Count());
    }

    [Fact]
    public void ContainsOrderRow()
    {
        IStoredTableDataSet dataSet = new OrdersTableDataSet();

        Assert.Contains(
            (IEnumerable<IRow>)dataSet,
            row => new RowHash(row).SequenceEqual(new RowHash(new OrderRow()))
        );
    }

    [Fact]
    public void ContainsSecondOrderRow()
    {
        IStoredTableDataSet dataSet = new OrdersTableDataSet();

        Assert.Contains(
            (IEnumerable<IRow>)dataSet,
            row => new RowHash(row).SequenceEqual(new RowHash(new SecondOrderRow()))
        );
    }

    [Fact]
    public void ContainsThirdOrderRow()
    {
        IStoredTableDataSet dataSet = new OrdersTableDataSet();

        Assert.Contains(
            (IEnumerable<IRow>)dataSet,
            row => new RowHash(row).SequenceEqual(new RowHash(new ThirdOrderRow()))
        );
    }

    [Fact]
    public void ContainsFourthOrderRow()
    {
        IStoredTableDataSet dataSet = new OrdersTableDataSet();

        Assert.Contains(
            (IEnumerable<IRow>)dataSet,
            row => new RowHash(row).SequenceEqual(new RowHash(new FourthOrderRow()))
        );
    }

    [Fact]
    public void ContainsFifthOrderRow()
    {
        IStoredTableDataSet dataSet = new OrdersTableDataSet();

        Assert.Contains(
            (IEnumerable<IRow>)dataSet,
            row => new RowHash(row).SequenceEqual(new RowHash(new FifthOrderRow()))
        );
    }

    [Fact]
    public void ContainsSixthOrderRow()
    {
        IStoredTableDataSet dataSet = new OrdersTableDataSet();

        Assert.Contains(
            (IEnumerable<IRow>)dataSet,
            row => new RowHash(row).SequenceEqual(new RowHash(new SixthOrderRow()))
        );
    }

    [Fact]
    public void ElementTypeIsRowInterface()
    {
        IStoredTableDataSet dataSet = new OrdersTableDataSet();

        Assert.Equal(typeof(IRow), dataSet.ElementType);
    }

    [Fact]
    public void ExpressionIsNotNull()
    {
        IStoredTableDataSet dataSet = new OrdersTableDataSet();

        Assert.NotNull(dataSet.Expression);
    }

    [Fact]
    public void ProviderExecutesQuery()
    {
        IStoredTableDataSet dataSet = new OrdersTableDataSet();

        Assert.NotNull(dataSet.Provider);
        Assert.Equal(6, dataSet.ToArray().Length);
    }

    [Fact]
    public void NonGenericEnumeratorEnumeratesSixRows()
    {
        IStoredTableDataSet dataSet = new OrdersTableDataSet();

        IEnumerator enumerator = ((IEnumerable)dataSet).GetEnumerator();

        int count = 0;
        while (enumerator.MoveNext())
        {
            count++;
        }

        Assert.Equal(6, count);
    }

    [Fact]
    public async Task AsyncEnumerationYieldsSixRows()
    {
        IStoredTableDataSet dataSet = new OrdersTableDataSet();

        List<IRow> rows = [];

        await foreach (IRow row in dataSet)
        {
            rows.Add(row);
        }

        Assert.Equal(6, rows.Count);
    }
}
