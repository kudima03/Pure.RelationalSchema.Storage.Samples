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

public sealed record UuidCasingSchemaDataSetTests
{
    [Fact]
    public void SchemaIsRelationalSchemaWithoutForeignKeys()
    {
        IStoredSchemaDataSet dataSet = new UuidCasingSchemaDataSet();

        Assert.True(
            new SchemaHash(dataSet.Schema).SequenceEqual(
                new SchemaHash(new RelationalSchemaWithoutForeignKeys())
            )
        );
    }

    [Fact]
    public void CountIs1()
    {
        IStoredSchemaDataSet dataSet = new UuidCasingSchemaDataSet();

        int count = dataSet.Count;

        _ = Assert.Single(dataSet);
        Assert.Equal(1, count);
    }

    [Fact]
    public void ContainsKeyTableWithoutIndexes()
    {
        IStoredSchemaDataSet dataSet = new UuidCasingSchemaDataSet();

        Assert.True(dataSet.ContainsKey(new TableWithoutIndexes()));
    }

    [Fact]
    public void KeysContainsTableWithoutIndexes()
    {
        IStoredSchemaDataSet dataSet = new UuidCasingSchemaDataSet();

        Assert.Contains(
            dataSet.Keys,
            table =>
                new TableHash(table).SequenceEqual(
                    new TableHash(new TableWithoutIndexes())
                )
        );
    }

    [Fact]
    public void ValuesContainsUuidCasingTableDataSet()
    {
        IStoredSchemaDataSet dataSet = new UuidCasingSchemaDataSet();

        Assert.Contains(
            dataSet.Values,
            value =>
                new StoredTableDataSetHash(value).SequenceEqual(
                    new StoredTableDataSetHash(new UuidCasingTableDataSet())
                )
        );
    }

    [Fact]
    public void IndexerReturnsUuidCasingTableDataSet()
    {
        IStoredSchemaDataSet dataSet = new UuidCasingSchemaDataSet();

        Assert.True(
            new StoredTableDataSetHash(dataSet[new TableWithoutIndexes()]).SequenceEqual(
                new StoredTableDataSetHash(new UuidCasingTableDataSet())
            )
        );
    }

    [Fact]
    public void TryGetValueReturnsTrueForTableWithoutIndexes()
    {
        IStoredSchemaDataSet dataSet = new UuidCasingSchemaDataSet();

        Assert.True(dataSet.TryGetValue(new TableWithoutIndexes(), out _));
    }

    [Fact]
    public void TryGetValueReturnsFalseForUnknownTable()
    {
        IStoredSchemaDataSet dataSet = new UuidCasingSchemaDataSet();

        Assert.False(dataSet.TryGetValue(new EmptyNameTable(), out _));
    }

    [Fact]
    public void GenericEnumeratorEnumeratesOneEntry()
    {
        IStoredSchemaDataSet dataSet = new UuidCasingSchemaDataSet();

        int count = 0;
        foreach (KeyValuePair<ITable, IStoredTableDataSet> entry in dataSet)
        {
            Assert.NotNull(entry.Value);
            count++;
        }

        Assert.Equal(1, count);
    }

    [Fact]
    public void NonGenericEnumeratorEnumeratesOneEntry()
    {
        IStoredSchemaDataSet dataSet = new UuidCasingSchemaDataSet();

        IEnumerator enumerator = ((IEnumerable)dataSet).GetEnumerator();

        int count = 0;
        while (enumerator.MoveNext())
        {
            count++;
        }

        Assert.Equal(1, count);
    }
}
