using System.Collections;
using Pure.RelationalSchema.HashCodes;
using Pure.RelationalSchema.Samples.Tables;
using Pure.RelationalSchema.Storage.Abstractions;
using Pure.RelationalSchema.Storage.HashCodes;
using Pure.RelationalSchema.Storage.Samples.Rows;
using Pure.RelationalSchema.Storage.Samples.TableDataSets;

namespace Pure.RelationalSchema.Storage.Samples.Tests.TableDataSets;

public sealed record ProductsTableDataSetTests
{
    [Fact]
    public void TableSchemaIsProductsTable()
    {
        IStoredTableDataSet dataSet = new ProductsTableDataSet();

        Assert.True(
            new TableHash(dataSet.TableSchema).SequenceEqual(
                new TableHash(new ProductsTable())
            )
        );
    }

    [Fact]
    public void RowsCountIs4()
    {
        IStoredTableDataSet dataSet = new ProductsTableDataSet();

        Assert.Equal(4, dataSet.Count());
    }

    [Fact]
    public void ContainsProductRow()
    {
        IStoredTableDataSet dataSet = new ProductsTableDataSet();

        Assert.Contains(
            (IEnumerable<IRow>)dataSet,
            row => new RowHash(row).SequenceEqual(new RowHash(new ProductRow()))
        );
    }

    [Fact]
    public void ContainsSecondProductRow()
    {
        IStoredTableDataSet dataSet = new ProductsTableDataSet();

        Assert.Contains(
            (IEnumerable<IRow>)dataSet,
            row => new RowHash(row).SequenceEqual(new RowHash(new SecondProductRow()))
        );
    }

    [Fact]
    public void ContainsThirdProductRow()
    {
        IStoredTableDataSet dataSet = new ProductsTableDataSet();

        Assert.Contains(
            (IEnumerable<IRow>)dataSet,
            row => new RowHash(row).SequenceEqual(new RowHash(new ThirdProductRow()))
        );
    }

    [Fact]
    public void ContainsFourthProductRow()
    {
        IStoredTableDataSet dataSet = new ProductsTableDataSet();

        Assert.Contains(
            (IEnumerable<IRow>)dataSet,
            row => new RowHash(row).SequenceEqual(new RowHash(new FourthProductRow()))
        );
    }

    [Fact]
    public void ElementTypeIsRowInterface()
    {
        IStoredTableDataSet dataSet = new ProductsTableDataSet();

        Assert.Equal(typeof(IRow), dataSet.ElementType);
    }

    [Fact]
    public void ExpressionIsNotNull()
    {
        IStoredTableDataSet dataSet = new ProductsTableDataSet();

        Assert.NotNull(dataSet.Expression);
    }

    [Fact]
    public void ProviderExecutesQuery()
    {
        IStoredTableDataSet dataSet = new ProductsTableDataSet();

        Assert.NotNull(dataSet.Provider);
        Assert.Equal(4, dataSet.ToArray().Length);
    }

    [Fact]
    public void NonGenericEnumeratorEnumeratesFourRows()
    {
        IStoredTableDataSet dataSet = new ProductsTableDataSet();

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
        IStoredTableDataSet dataSet = new ProductsTableDataSet();

        List<IRow> rows = [];

        await foreach (IRow row in dataSet)
        {
            rows.Add(row);
        }

        Assert.Equal(4, rows.Count);
    }
}
