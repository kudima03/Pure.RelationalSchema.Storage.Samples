using System.Collections;
using Pure.RelationalSchema.HashCodes;
using Pure.RelationalSchema.Samples.Tables;
using Pure.RelationalSchema.Storage.Abstractions;
using Pure.RelationalSchema.Storage.HashCodes;
using Pure.RelationalSchema.Storage.Samples.Rows;
using Pure.RelationalSchema.Storage.Samples.TableDataSets;

namespace Pure.RelationalSchema.Storage.Samples.Tests.TableDataSets;

public sealed record OrderItemsTableDataSetTests
{
    [Fact]
    public void TableSchemaIsOrderItemsTable()
    {
        IStoredTableDataSet dataSet = new OrderItemsTableDataSet();

        Assert.True(
            new TableHash(dataSet.TableSchema).SequenceEqual(
                new TableHash(new OrderItemsTable())
            )
        );
    }

    [Fact]
    public void RowsCountIs4()
    {
        IStoredTableDataSet dataSet = new OrderItemsTableDataSet();

        Assert.Equal(4, dataSet.Count());
    }

    [Fact]
    public void ContainsOrderItemRow()
    {
        IStoredTableDataSet dataSet = new OrderItemsTableDataSet();

        Assert.Contains(
            (IEnumerable<IRow>)dataSet,
            row => new RowHash(row).SequenceEqual(new RowHash(new OrderItemRow()))
        );
    }

    [Fact]
    public void ContainsSecondOrderItemRow()
    {
        IStoredTableDataSet dataSet = new OrderItemsTableDataSet();

        Assert.Contains(
            (IEnumerable<IRow>)dataSet,
            row => new RowHash(row).SequenceEqual(new RowHash(new SecondOrderItemRow()))
        );
    }

    [Fact]
    public void ContainsThirdOrderItemRow()
    {
        IStoredTableDataSet dataSet = new OrderItemsTableDataSet();

        Assert.Contains(
            (IEnumerable<IRow>)dataSet,
            row => new RowHash(row).SequenceEqual(new RowHash(new ThirdOrderItemRow()))
        );
    }

    [Fact]
    public void ContainsFourthOrderItemRow()
    {
        IStoredTableDataSet dataSet = new OrderItemsTableDataSet();

        Assert.Contains(
            (IEnumerable<IRow>)dataSet,
            row => new RowHash(row).SequenceEqual(new RowHash(new FourthOrderItemRow()))
        );
    }

    [Fact]
    public void ElementTypeIsRowInterface()
    {
        IStoredTableDataSet dataSet = new OrderItemsTableDataSet();

        Assert.Equal(typeof(IRow), dataSet.ElementType);
    }

    [Fact]
    public void ExpressionIsNotNull()
    {
        IStoredTableDataSet dataSet = new OrderItemsTableDataSet();

        Assert.NotNull(dataSet.Expression);
    }

    [Fact]
    public void ProviderExecutesQuery()
    {
        IStoredTableDataSet dataSet = new OrderItemsTableDataSet();

        Assert.NotNull(dataSet.Provider);
        Assert.Equal(4, dataSet.ToArray().Length);
    }

    [Fact]
    public void NonGenericEnumeratorEnumeratesFourRows()
    {
        IStoredTableDataSet dataSet = new OrderItemsTableDataSet();

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
        IStoredTableDataSet dataSet = new OrderItemsTableDataSet();

        List<IRow> rows = [];

        await foreach (IRow row in dataSet)
        {
            rows.Add(row);
        }

        Assert.Equal(4, rows.Count);
    }
}
