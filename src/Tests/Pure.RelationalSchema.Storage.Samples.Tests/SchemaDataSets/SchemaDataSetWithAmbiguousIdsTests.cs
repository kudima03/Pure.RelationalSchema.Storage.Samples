using System.Collections;
using Pure.RelationalSchema.Abstractions.Table;
using Pure.RelationalSchema.HashCodes;
using Pure.RelationalSchema.Samples.Schemas;
using Pure.RelationalSchema.Samples.Tables;
using Pure.RelationalSchema.Storage.Abstractions;
using Pure.RelationalSchema.Storage.HashCodes;
using Pure.RelationalSchema.Storage.Samples.SchemaDataSets;
using Pure.RelationalSchema.Storage.Samples.TableDataSets;

namespace Pure.RelationalSchema.Storage.Samples.Tests.SchemaDataSets;

public sealed record SchemaDataSetWithAmbiguousIdsTests
{
    [Fact]
    public void SchemaIsRelationalSchemaWithIndexes()
    {
        IStoredSchemaDataSet dataSet = new SchemaDataSetWithAmbiguousIds();

        Assert.True(
            new SchemaHash(dataSet.Schema).SequenceEqual(
                new SchemaHash(new RelationalSchemaWithIndexes())
            )
        );
    }

    [Fact]
    public void CountIs2()
    {
        IStoredSchemaDataSet dataSet = new SchemaDataSetWithAmbiguousIds();

        Assert.Equal(2, dataSet.Count);
    }

    [Fact]
    public void ContainsKeyTableWithSingleIndex()
    {
        IStoredSchemaDataSet dataSet = new SchemaDataSetWithAmbiguousIds();

        Assert.True(dataSet.ContainsKey(new TableWithSingleIndex()));
    }

    [Fact]
    public void KeysContainsTableWithSingleIndex()
    {
        IStoredSchemaDataSet dataSet = new SchemaDataSetWithAmbiguousIds();

        Assert.Contains(
            dataSet.Keys,
            table =>
                new TableHash(table).SequenceEqual(
                    new TableHash(new TableWithSingleIndex())
                )
        );
    }

    [Fact]
    public void ValuesContainsAmbiguousIdLookupTableDataSet()
    {
        IStoredSchemaDataSet dataSet = new SchemaDataSetWithAmbiguousIds();

        Assert.Contains(
            dataSet.Values,
            value =>
                new StoredTableDataSetHash(value).SequenceEqual(
                    new StoredTableDataSetHash(new AmbiguousIdLookupTableDataSet())
                )
        );
    }

    [Fact]
    public void IndexerReturnsAmbiguousIdLookupTableDataSet()
    {
        IStoredSchemaDataSet dataSet = new SchemaDataSetWithAmbiguousIds();

        Assert.True(
            new StoredTableDataSetHash(dataSet[new TableWithSingleIndex()]).SequenceEqual(
                new StoredTableDataSetHash(new AmbiguousIdLookupTableDataSet())
            )
        );
    }

    [Fact]
    public void TryGetValueReturnsTrueForTableWithSingleIndex()
    {
        IStoredSchemaDataSet dataSet = new SchemaDataSetWithAmbiguousIds();

        Assert.True(dataSet.TryGetValue(new TableWithSingleIndex(), out _));
    }

    [Fact]
    public void ContainsKeyTableWithIndexes()
    {
        IStoredSchemaDataSet dataSet = new SchemaDataSetWithAmbiguousIds();

        Assert.True(dataSet.ContainsKey(new TableWithIndexes()));
    }

    [Fact]
    public void KeysContainsTableWithIndexes()
    {
        IStoredSchemaDataSet dataSet = new SchemaDataSetWithAmbiguousIds();

        Assert.Contains(
            dataSet.Keys,
            table =>
                new TableHash(table).SequenceEqual(new TableHash(new TableWithIndexes()))
        );
    }

    [Fact]
    public void ValuesContainsAmbiguousIdTableDataSet()
    {
        IStoredSchemaDataSet dataSet = new SchemaDataSetWithAmbiguousIds();

        Assert.Contains(
            dataSet.Values,
            value =>
                new StoredTableDataSetHash(value).SequenceEqual(
                    new StoredTableDataSetHash(new AmbiguousIdTableDataSet())
                )
        );
    }

    [Fact]
    public void IndexerReturnsAmbiguousIdTableDataSet()
    {
        IStoredSchemaDataSet dataSet = new SchemaDataSetWithAmbiguousIds();

        Assert.True(
            new StoredTableDataSetHash(dataSet[new TableWithIndexes()]).SequenceEqual(
                new StoredTableDataSetHash(new AmbiguousIdTableDataSet())
            )
        );
    }

    [Fact]
    public void TryGetValueReturnsTrueForTableWithIndexes()
    {
        IStoredSchemaDataSet dataSet = new SchemaDataSetWithAmbiguousIds();

        Assert.True(dataSet.TryGetValue(new TableWithIndexes(), out _));
    }

    [Fact]
    public void TryGetValueReturnsFalseForUnknownTable()
    {
        IStoredSchemaDataSet dataSet = new SchemaDataSetWithAmbiguousIds();

        Assert.False(dataSet.TryGetValue(new EmptyNameTable(), out _));
    }

    [Fact]
    public void GenericEnumeratorEnumeratesTwoEntries()
    {
        IStoredSchemaDataSet dataSet = new SchemaDataSetWithAmbiguousIds();

        int count = 0;
        foreach (KeyValuePair<ITable, IStoredTableDataSet> entry in dataSet)
        {
            Assert.NotNull(entry.Value);
            count++;
        }

        Assert.Equal(2, count);
    }

    [Fact]
    public void NonGenericEnumeratorEnumeratesTwoEntries()
    {
        IStoredSchemaDataSet dataSet = new SchemaDataSetWithAmbiguousIds();

        IEnumerator enumerator = ((IEnumerable)dataSet).GetEnumerator();

        int count = 0;
        while (enumerator.MoveNext())
        {
            count++;
        }

        Assert.Equal(2, count);
    }
}
