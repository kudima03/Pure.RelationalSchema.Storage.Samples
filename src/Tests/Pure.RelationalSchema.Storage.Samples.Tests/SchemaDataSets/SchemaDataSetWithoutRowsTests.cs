using System.Collections;
using Pure.RelationalSchema.HashCodes;
using Pure.RelationalSchema.Samples.Schemas;
using Pure.RelationalSchema.Samples.Tables;
using Pure.RelationalSchema.Storage.Abstractions;
using Pure.RelationalSchema.Storage.HashCodes;
using Pure.RelationalSchema.Storage.Samples.SchemaDataSets;
using Pure.RelationalSchema.Storage.Samples.TableDataSets;

namespace Pure.RelationalSchema.Storage.Samples.Tests.SchemaDataSets;

public sealed record SchemaDataSetWithoutRowsTests
{
    [Fact]
    public void SchemaIsRelationalSchemaWithoutForeignKeys()
    {
        IStoredSchemaDataSet dataSet = new SchemaDataSetWithoutRows();

        Assert.True(
            new SchemaHash(dataSet.Schema).SequenceEqual(
                new SchemaHash(new RelationalSchemaWithoutForeignKeys())
            )
        );
    }

    [Fact]
    public void CountIs3()
    {
        IStoredSchemaDataSet dataSet = new SchemaDataSetWithoutRows();

        Assert.Equal(3, dataSet.Count);
    }

    [Fact]
    public void ContainsKeyEmptyTable()
    {
        IStoredSchemaDataSet dataSet = new SchemaDataSetWithoutRows();

        Assert.True(dataSet.ContainsKey(new EmptyTable()));
    }

    [Fact]
    public void ContainsKeySingleColumnTable()
    {
        IStoredSchemaDataSet dataSet = new SchemaDataSetWithoutRows();

        Assert.True(dataSet.ContainsKey(new SingleColumnTable()));
    }

    [Fact]
    public void ContainsKeyTableWithoutIndexes()
    {
        IStoredSchemaDataSet dataSet = new SchemaDataSetWithoutRows();

        Assert.True(dataSet.ContainsKey(new TableWithoutIndexes()));
    }

    [Fact]
    public void KeysContainsEmptyTable()
    {
        IStoredSchemaDataSet dataSet = new SchemaDataSetWithoutRows();

        Assert.Contains(
            dataSet.Keys,
            table => new TableHash(table).SequenceEqual(new TableHash(new EmptyTable()))
        );
    }

    [Fact]
    public void ValuesContainsEmptyTableDataSet()
    {
        IStoredSchemaDataSet dataSet = new SchemaDataSetWithoutRows();

        Assert.Contains(
            dataSet.Values,
            value =>
                new StoredTableDataSetHash(value).SequenceEqual(
                    new StoredTableDataSetHash(new EmptyTableDataSet())
                )
        );
    }

    [Fact]
    public void IndexerReturnsEmptyTableDataSet()
    {
        IStoredSchemaDataSet dataSet = new SchemaDataSetWithoutRows();

        Assert.True(
            new StoredTableDataSetHash(dataSet[new EmptyTable()]).SequenceEqual(
                new StoredTableDataSetHash(new EmptyTableDataSet())
            )
        );
    }

    [Fact]
    public void IndexerReturnsEmptySingleColumnTableDataSet()
    {
        IStoredSchemaDataSet dataSet = new SchemaDataSetWithoutRows();

        Assert.True(
            new StoredTableDataSetHash(dataSet[new SingleColumnTable()]).SequenceEqual(
                new StoredTableDataSetHash(new EmptySingleColumnTableDataSet())
            )
        );
    }

    [Fact]
    public void IndexerReturnsEmptyTableWithoutIndexesDataSet()
    {
        IStoredSchemaDataSet dataSet = new SchemaDataSetWithoutRows();

        Assert.True(
            new StoredTableDataSetHash(dataSet[new TableWithoutIndexes()]).SequenceEqual(
                new StoredTableDataSetHash(new EmptyTableWithoutIndexesDataSet())
            )
        );
    }

    [Fact]
    public void TryGetValueReturnsTrueForEmptyTable()
    {
        IStoredSchemaDataSet dataSet = new SchemaDataSetWithoutRows();

        Assert.True(dataSet.TryGetValue(new EmptyTable(), out _));
    }

    [Fact]
    public void TryGetValueReturnsFalseForUnknownTable()
    {
        IStoredSchemaDataSet dataSet = new SchemaDataSetWithoutRows();

        Assert.False(dataSet.TryGetValue(new EmptyNameTable(), out _));
    }

    [Fact]
    public void GenericEnumeratorEnumeratesThreeEntries()
    {
        IStoredSchemaDataSet dataSet = new SchemaDataSetWithoutRows();

        Assert.Equal(3, dataSet.Count);
    }

    [Fact]
    public void NonGenericEnumeratorEnumeratesThreeEntries()
    {
        IStoredSchemaDataSet dataSet = new SchemaDataSetWithoutRows();

        IEnumerator enumerator = ((IEnumerable)dataSet).GetEnumerator();

        int count = 0;
        while (enumerator.MoveNext())
        {
            count++;
        }

        Assert.Equal(3, count);
    }
}
