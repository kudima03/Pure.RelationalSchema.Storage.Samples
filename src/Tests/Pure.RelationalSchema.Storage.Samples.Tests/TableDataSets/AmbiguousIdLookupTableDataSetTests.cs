using System.Collections;
using Pure.RelationalSchema.HashCodes;
using Pure.RelationalSchema.Samples.Tables;
using Pure.RelationalSchema.Storage.Abstractions;
using Pure.RelationalSchema.Storage.HashCodes;
using Pure.RelationalSchema.Storage.Samples.Rows;
using Pure.RelationalSchema.Storage.Samples.TableDataSets;

namespace Pure.RelationalSchema.Storage.Samples.Tests.TableDataSets;

public sealed record AmbiguousIdLookupTableDataSetTests
{
    [Fact]
    public void TableSchemaIsTableWithSingleIndex()
    {
        IStoredTableDataSet dataSet = new AmbiguousIdLookupTableDataSet();

        Assert.True(
            new TableHash(dataSet.TableSchema).SequenceEqual(
                new TableHash(new TableWithSingleIndex())
            )
        );
    }

    [Fact]
    public void RowsCountIs4()
    {
        IStoredTableDataSet dataSet = new AmbiguousIdLookupTableDataSet();

        Assert.Equal(4, dataSet.Count());
    }

    [Fact]
    public void ContainsFirstAmbiguousIdLookupRow()
    {
        IStoredTableDataSet dataSet = new AmbiguousIdLookupTableDataSet();

        Assert.Contains(
            (IEnumerable<IRow>)dataSet,
            row =>
                new RowHash(row).SequenceEqual(
                    new RowHash(new FirstAmbiguousIdLookupRow())
                )
        );
    }

    [Fact]
    public void ContainsSecondAmbiguousIdLookupRow()
    {
        IStoredTableDataSet dataSet = new AmbiguousIdLookupTableDataSet();

        Assert.Contains(
            (IEnumerable<IRow>)dataSet,
            row =>
                new RowHash(row).SequenceEqual(
                    new RowHash(new SecondAmbiguousIdLookupRow())
                )
        );
    }

    [Fact]
    public void ContainsThirdAmbiguousIdLookupRow()
    {
        IStoredTableDataSet dataSet = new AmbiguousIdLookupTableDataSet();

        Assert.Contains(
            (IEnumerable<IRow>)dataSet,
            row =>
                new RowHash(row).SequenceEqual(
                    new RowHash(new ThirdAmbiguousIdLookupRow())
                )
        );
    }

    [Fact]
    public void ContainsFourthAmbiguousIdLookupRow()
    {
        IStoredTableDataSet dataSet = new AmbiguousIdLookupTableDataSet();

        Assert.Contains(
            (IEnumerable<IRow>)dataSet,
            row =>
                new RowHash(row).SequenceEqual(
                    new RowHash(new FourthAmbiguousIdLookupRow())
                )
        );
    }

    [Fact]
    public void ElementTypeIsRowInterface()
    {
        IStoredTableDataSet dataSet = new AmbiguousIdLookupTableDataSet();

        Assert.Equal(typeof(IRow), dataSet.ElementType);
    }

    [Fact]
    public void ExpressionIsNotNull()
    {
        IStoredTableDataSet dataSet = new AmbiguousIdLookupTableDataSet();

        Assert.NotNull(dataSet.Expression);
    }

    [Fact]
    public void ProviderExecutesQuery()
    {
        IStoredTableDataSet dataSet = new AmbiguousIdLookupTableDataSet();

        Assert.NotNull(dataSet.Provider);
        Assert.Equal(4, dataSet.ToArray().Length);
    }

    [Fact]
    public void NonGenericEnumeratorEnumeratesFourRows()
    {
        IStoredTableDataSet dataSet = new AmbiguousIdLookupTableDataSet();

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
        IStoredTableDataSet dataSet = new AmbiguousIdLookupTableDataSet();

        List<IRow> rows = [];

        await foreach (IRow row in dataSet)
        {
            rows.Add(row);
        }

        Assert.Equal(4, rows.Count);
    }
}
