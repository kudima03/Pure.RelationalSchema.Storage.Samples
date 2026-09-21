using System.Collections;
using Pure.RelationalSchema.HashCodes;
using Pure.RelationalSchema.Samples.Schemas;
using Pure.RelationalSchema.Samples.Tables;
using Pure.RelationalSchema.Storage.Abstractions;
using Pure.RelationalSchema.Storage.HashCodes;
using Pure.RelationalSchema.Storage.Samples.SchemaDataSets;
using Pure.RelationalSchema.Storage.Samples.TableDataSets;

namespace Pure.RelationalSchema.Storage.Samples.Tests.SchemaDataSets;

public sealed record SchemaDataSetWithAllColumnTypesTests
{
    [Fact]
    public void SchemaIsRelationalSchemaWithAllColumnTypes()
    {
        IStoredSchemaDataSet dataSet = new SchemaDataSetWithAllColumnTypes();

        Assert.True(
            new SchemaHash(dataSet.Schema).SequenceEqual(
                new SchemaHash(new RelationalSchemaWithAllColumnTypes())
            )
        );
    }

    [Fact]
    public void CountIs1()
    {
        IStoredSchemaDataSet dataSet = new SchemaDataSetWithAllColumnTypes();

        _ = Assert.Single(dataSet);

        int count = dataSet.Count;

        Assert.Equal(1, count);
    }

    [Fact]
    public void ContainsKeyAllColumnTypesTable()
    {
        IStoredSchemaDataSet dataSet = new SchemaDataSetWithAllColumnTypes();

        Assert.True(dataSet.ContainsKey(new AllColumnTypesTable()));
    }

    [Fact]
    public void KeysContainsAllColumnTypesTable()
    {
        IStoredSchemaDataSet dataSet = new SchemaDataSetWithAllColumnTypes();

        Assert.Contains(
            dataSet.Keys,
            table =>
                new TableHash(table).SequenceEqual(
                    new TableHash(new AllColumnTypesTable())
                )
        );
    }

    [Fact]
    public void ValuesContainsAllColumnTypesTableDataSet()
    {
        IStoredSchemaDataSet dataSet = new SchemaDataSetWithAllColumnTypes();

        Assert.Contains(
            dataSet.Values,
            value =>
                new StoredTableDataSetHash(value).SequenceEqual(
                    new StoredTableDataSetHash(new AllColumnTypesTableDataSet())
                )
        );
    }

    [Fact]
    public void IndexerReturnsAllColumnTypesTableDataSet()
    {
        IStoredSchemaDataSet dataSet = new SchemaDataSetWithAllColumnTypes();

        Assert.True(
            new StoredTableDataSetHash(dataSet[new AllColumnTypesTable()]).SequenceEqual(
                new StoredTableDataSetHash(new AllColumnTypesTableDataSet())
            )
        );
    }

    [Fact]
    public void TryGetValueReturnsTrueForAllColumnTypesTable()
    {
        IStoredSchemaDataSet dataSet = new SchemaDataSetWithAllColumnTypes();

        Assert.True(dataSet.TryGetValue(new AllColumnTypesTable(), out _));
    }

    [Fact]
    public void TryGetValueReturnsFalseForUnknownTable()
    {
        IStoredSchemaDataSet dataSet = new SchemaDataSetWithAllColumnTypes();

        Assert.False(dataSet.TryGetValue(new EmptyNameTable(), out _));
    }

    [Fact]
    public void GenericEnumeratorEnumeratesOneEntry()
    {
        IStoredSchemaDataSet dataSet = new SchemaDataSetWithAllColumnTypes();

        _ = Assert.Single(dataSet);
    }

    [Fact]
    public void NonGenericEnumeratorEnumeratesOneEntry()
    {
        IStoredSchemaDataSet dataSet = new SchemaDataSetWithAllColumnTypes();

        IEnumerator enumerator = ((IEnumerable)dataSet).GetEnumerator();

        Assert.True(enumerator.MoveNext());
        Assert.False(enumerator.MoveNext());
    }
}
