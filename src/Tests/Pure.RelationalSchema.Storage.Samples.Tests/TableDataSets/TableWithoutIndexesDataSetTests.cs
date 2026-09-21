using System.Collections;
using Pure.RelationalSchema.HashCodes;
using Pure.RelationalSchema.Samples.Tables;
using Pure.RelationalSchema.Storage.Abstractions;
using Pure.RelationalSchema.Storage.HashCodes;
using Pure.RelationalSchema.Storage.Samples.Rows;
using Pure.RelationalSchema.Storage.Samples.TableDataSets;

namespace Pure.RelationalSchema.Storage.Samples.Tests.TableDataSets;

public sealed record TableWithoutIndexesDataSetTests
{
    [Fact]
    public void TableSchemaIsTableWithoutIndexes()
    {
        IStoredTableDataSet dataSet = new TableWithoutIndexesDataSet();

        Assert.True(
            new TableHash(dataSet.TableSchema).SequenceEqual(
                new TableHash(new TableWithoutIndexes())
            )
        );
    }

    [Fact]
    public void RowsCountIs1()
    {
        IStoredTableDataSet dataSet = new TableWithoutIndexesDataSet();

        _ = Assert.Single((IEnumerable<IRow>)dataSet);
    }

    [Fact]
    public void ContainsUnicodeTextRow()
    {
        IStoredTableDataSet dataSet = new TableWithoutIndexesDataSet();

        Assert.Contains(
            (IEnumerable<IRow>)dataSet,
            row => new RowHash(row).SequenceEqual(new RowHash(new UnicodeTextRow()))
        );
    }

    [Fact]
    public void ElementTypeIsRowInterface()
    {
        IStoredTableDataSet dataSet = new TableWithoutIndexesDataSet();

        Assert.Equal(typeof(IRow), dataSet.ElementType);
    }

    [Fact]
    public void ExpressionIsNotNull()
    {
        IStoredTableDataSet dataSet = new TableWithoutIndexesDataSet();

        Assert.NotNull(dataSet.Expression);
    }

    [Fact]
    public void ProviderExecutesQuery()
    {
        IStoredTableDataSet dataSet = new TableWithoutIndexesDataSet();

        Assert.NotNull(dataSet.Provider);
        _ = Assert.Single(dataSet.ToArray());
    }

    [Fact]
    public void NonGenericEnumeratorEnumeratesOneRow()
    {
        IStoredTableDataSet dataSet = new TableWithoutIndexesDataSet();

        IEnumerator enumerator = ((IEnumerable)dataSet).GetEnumerator();

        Assert.True(enumerator.MoveNext());
        Assert.False(enumerator.MoveNext());
    }

    [Fact]
    public async Task AsyncEnumerationYieldsOneRow()
    {
        IStoredTableDataSet dataSet = new TableWithoutIndexesDataSet();

        List<IRow> rows = [];

        await foreach (IRow row in dataSet)
        {
            rows.Add(row);
        }

        _ = Assert.Single(rows);
    }
}
