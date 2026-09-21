using System.Collections;
using Pure.RelationalSchema.HashCodes;
using Pure.RelationalSchema.Samples.Schemas;
using Pure.RelationalSchema.Samples.Tables;
using Pure.RelationalSchema.Storage.Abstractions;
using Pure.RelationalSchema.Storage.HashCodes;
using Pure.RelationalSchema.Storage.Samples.SchemaDataSets;
using Pure.RelationalSchema.Storage.Samples.TableDataSets;

namespace Pure.RelationalSchema.Storage.Samples.Tests.SchemaDataSets;

public sealed record SchemaDataSetWithIndexesTests
{
    [Fact]
    public void SchemaIsRelationalSchemaWithIndexes()
    {
        IStoredSchemaDataSet dataSet = new SchemaDataSetWithIndexes();

        Assert.True(
            new SchemaHash(dataSet.Schema).SequenceEqual(
                new SchemaHash(new RelationalSchemaWithIndexes())
            )
        );
    }

    [Fact]
    public void CountIs2()
    {
        IStoredSchemaDataSet dataSet = new SchemaDataSetWithIndexes();

        Assert.Equal(2, dataSet.Count);
    }

    [Fact]
    public void ContainsKeyTableWithSingleIndex()
    {
        IStoredSchemaDataSet dataSet = new SchemaDataSetWithIndexes();

        Assert.True(dataSet.ContainsKey(new TableWithSingleIndex()));
    }

    [Fact]
    public void ContainsKeyTableWithIndexes()
    {
        IStoredSchemaDataSet dataSet = new SchemaDataSetWithIndexes();

        Assert.True(dataSet.ContainsKey(new TableWithIndexes()));
    }

    [Fact]
    public void KeysContainsTableWithSingleIndex()
    {
        IStoredSchemaDataSet dataSet = new SchemaDataSetWithIndexes();

        Assert.Contains(
            dataSet.Keys,
            table =>
                new TableHash(table).SequenceEqual(
                    new TableHash(new TableWithSingleIndex())
                )
        );
    }

    [Fact]
    public void ValuesContainsTableWithSingleIndexDataSet()
    {
        IStoredSchemaDataSet dataSet = new SchemaDataSetWithIndexes();

        Assert.Contains(
            dataSet.Values,
            value =>
                new StoredTableDataSetHash(value).SequenceEqual(
                    new StoredTableDataSetHash(new TableWithSingleIndexDataSet())
                )
        );
    }

    [Fact]
    public void IndexerReturnsTableWithSingleIndexDataSet()
    {
        IStoredSchemaDataSet dataSet = new SchemaDataSetWithIndexes();

        Assert.True(
            new StoredTableDataSetHash(dataSet[new TableWithSingleIndex()]).SequenceEqual(
                new StoredTableDataSetHash(new TableWithSingleIndexDataSet())
            )
        );
    }

    [Fact]
    public void IndexerReturnsTableWithIndexesDataSet()
    {
        IStoredSchemaDataSet dataSet = new SchemaDataSetWithIndexes();

        Assert.True(
            new StoredTableDataSetHash(dataSet[new TableWithIndexes()]).SequenceEqual(
                new StoredTableDataSetHash(new TableWithIndexesDataSet())
            )
        );
    }

    [Fact]
    public void TryGetValueReturnsTrueForTableWithSingleIndex()
    {
        IStoredSchemaDataSet dataSet = new SchemaDataSetWithIndexes();

        Assert.True(dataSet.TryGetValue(new TableWithSingleIndex(), out _));
    }

    [Fact]
    public void TryGetValueReturnsFalseForUnknownTable()
    {
        IStoredSchemaDataSet dataSet = new SchemaDataSetWithIndexes();

        Assert.False(dataSet.TryGetValue(new EmptyNameTable(), out _));
    }

    [Fact]
    public void GenericEnumeratorEnumeratesTwoEntries()
    {
        IStoredSchemaDataSet dataSet = new SchemaDataSetWithIndexes();

        Assert.Equal(2, dataSet.Count);
    }

    [Fact]
    public void NonGenericEnumeratorEnumeratesTwoEntries()
    {
        IStoredSchemaDataSet dataSet = new SchemaDataSetWithIndexes();

        IEnumerator enumerator = ((IEnumerable)dataSet).GetEnumerator();

        int count = 0;
        while (enumerator.MoveNext())
        {
            count++;
        }

        Assert.Equal(2, count);
    }
}
