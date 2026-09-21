using System.Collections;
using Pure.RelationalSchema.HashCodes;
using Pure.RelationalSchema.Samples.Tables;
using Pure.RelationalSchema.Storage.Abstractions;
using Pure.RelationalSchema.Storage.HashCodes;
using Pure.RelationalSchema.Storage.Samples.Rows;
using Pure.RelationalSchema.Storage.Samples.TableDataSets;

namespace Pure.RelationalSchema.Storage.Samples.Tests.TableDataSets;

public sealed record UuidCasingTableDataSetTests
{
    [Fact]
    public void TableSchemaIsTableWithoutIndexes()
    {
        IStoredTableDataSet dataSet = new UuidCasingTableDataSet();

        Assert.True(
            new TableHash(dataSet.TableSchema).SequenceEqual(
                new TableHash(new TableWithoutIndexes())
            )
        );
    }

    [Fact]
    public void RowsCountIs2()
    {
        IStoredTableDataSet dataSet = new UuidCasingTableDataSet();

        Assert.Equal(2, dataSet.Count());
    }

    [Fact]
    public void ContainsLowercaseUuidRow()
    {
        IStoredTableDataSet dataSet = new UuidCasingTableDataSet();

        Assert.Contains(
            (IEnumerable<IRow>)dataSet,
            row => new RowHash(row).SequenceEqual(new RowHash(new LowercaseUuidRow()))
        );
    }

    [Fact]
    public void ContainsUppercaseUuidRow()
    {
        IStoredTableDataSet dataSet = new UuidCasingTableDataSet();

        Assert.Contains(
            (IEnumerable<IRow>)dataSet,
            row => new RowHash(row).SequenceEqual(new RowHash(new UppercaseUuidRow()))
        );
    }

    [Fact]
    public void ElementTypeIsRowInterface()
    {
        IStoredTableDataSet dataSet = new UuidCasingTableDataSet();

        Assert.Equal(typeof(IRow), dataSet.ElementType);
    }

    [Fact]
    public void ExpressionIsNotNull()
    {
        IStoredTableDataSet dataSet = new UuidCasingTableDataSet();

        Assert.NotNull(dataSet.Expression);
    }

    [Fact]
    public void ProviderExecutesQuery()
    {
        IStoredTableDataSet dataSet = new UuidCasingTableDataSet();

        Assert.NotNull(dataSet.Provider);
        Assert.Equal(2, dataSet.ToArray().Length);
    }

    [Fact]
    public void NonGenericEnumeratorEnumeratesTwoRows()
    {
        IStoredTableDataSet dataSet = new UuidCasingTableDataSet();

        IEnumerator enumerator = ((IEnumerable)dataSet).GetEnumerator();

        int count = 0;
        while (enumerator.MoveNext())
        {
            count++;
        }

        Assert.Equal(2, count);
    }

    [Fact]
    public async Task AsyncEnumerationYieldsTwoRows()
    {
        IStoredTableDataSet dataSet = new UuidCasingTableDataSet();

        List<IRow> rows = [];

        await foreach (IRow row in dataSet)
        {
            rows.Add(row);
        }

        Assert.Equal(2, rows.Count);
    }
}
