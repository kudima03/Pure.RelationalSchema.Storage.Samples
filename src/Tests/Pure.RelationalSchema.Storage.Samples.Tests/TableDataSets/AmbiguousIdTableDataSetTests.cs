using System.Collections;
using Pure.RelationalSchema.HashCodes;
using Pure.RelationalSchema.Samples.Tables;
using Pure.RelationalSchema.Storage.Abstractions;
using Pure.RelationalSchema.Storage.HashCodes;
using Pure.RelationalSchema.Storage.Samples.Rows;
using Pure.RelationalSchema.Storage.Samples.TableDataSets;

namespace Pure.RelationalSchema.Storage.Samples.Tests.TableDataSets;

public sealed record AmbiguousIdTableDataSetTests
{
    [Fact]
    public void TableSchemaIsTableWithIndexes()
    {
        IStoredTableDataSet dataSet = new AmbiguousIdTableDataSet();

        Assert.True(
            new TableHash(dataSet.TableSchema).SequenceEqual(
                new TableHash(new TableWithIndexes())
            )
        );
    }

    [Fact]
    public void RowsCountIs6()
    {
        IStoredTableDataSet dataSet = new AmbiguousIdTableDataSet();

        Assert.Equal(6, dataSet.Count());
    }

    [Fact]
    public void ContainsFirstAmbiguousIdRow()
    {
        IStoredTableDataSet dataSet = new AmbiguousIdTableDataSet();

        Assert.Contains(
            (IEnumerable<IRow>)dataSet,
            row => new RowHash(row).SequenceEqual(new RowHash(new FirstAmbiguousIdRow()))
        );
    }

    [Fact]
    public void ContainsSecondAmbiguousIdRow()
    {
        IStoredTableDataSet dataSet = new AmbiguousIdTableDataSet();

        Assert.Contains(
            (IEnumerable<IRow>)dataSet,
            row => new RowHash(row).SequenceEqual(new RowHash(new SecondAmbiguousIdRow()))
        );
    }

    [Fact]
    public void ContainsThirdAmbiguousIdRow()
    {
        IStoredTableDataSet dataSet = new AmbiguousIdTableDataSet();

        Assert.Contains(
            (IEnumerable<IRow>)dataSet,
            row => new RowHash(row).SequenceEqual(new RowHash(new ThirdAmbiguousIdRow()))
        );
    }

    [Fact]
    public void ContainsFourthAmbiguousIdRow()
    {
        IStoredTableDataSet dataSet = new AmbiguousIdTableDataSet();

        Assert.Contains(
            (IEnumerable<IRow>)dataSet,
            row => new RowHash(row).SequenceEqual(new RowHash(new FourthAmbiguousIdRow()))
        );
    }

    [Fact]
    public void ContainsFifthAmbiguousIdRow()
    {
        IStoredTableDataSet dataSet = new AmbiguousIdTableDataSet();

        Assert.Contains(
            (IEnumerable<IRow>)dataSet,
            row => new RowHash(row).SequenceEqual(new RowHash(new FifthAmbiguousIdRow()))
        );
    }

    [Fact]
    public void ContainsSixthAmbiguousIdRow()
    {
        IStoredTableDataSet dataSet = new AmbiguousIdTableDataSet();

        Assert.Contains(
            (IEnumerable<IRow>)dataSet,
            row => new RowHash(row).SequenceEqual(new RowHash(new SixthAmbiguousIdRow()))
        );
    }

    [Fact]
    public void ElementTypeIsRowInterface()
    {
        IStoredTableDataSet dataSet = new AmbiguousIdTableDataSet();

        Assert.Equal(typeof(IRow), dataSet.ElementType);
    }

    [Fact]
    public void ExpressionIsNotNull()
    {
        IStoredTableDataSet dataSet = new AmbiguousIdTableDataSet();

        Assert.NotNull(dataSet.Expression);
    }

    [Fact]
    public void ProviderExecutesQuery()
    {
        IStoredTableDataSet dataSet = new AmbiguousIdTableDataSet();

        Assert.NotNull(dataSet.Provider);
        Assert.Equal(6, dataSet.ToArray().Length);
    }

    [Fact]
    public void NonGenericEnumeratorEnumeratesSixRows()
    {
        IStoredTableDataSet dataSet = new AmbiguousIdTableDataSet();

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
        IStoredTableDataSet dataSet = new AmbiguousIdTableDataSet();

        List<IRow> rows = [];

        await foreach (IRow row in dataSet)
        {
            rows.Add(row);
        }

        Assert.Equal(6, rows.Count);
    }
}
