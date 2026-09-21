using System.Collections;
using Pure.RelationalSchema.HashCodes;
using Pure.RelationalSchema.Samples.Schemas;
using Pure.RelationalSchema.Samples.Tables;
using Pure.RelationalSchema.Storage.Abstractions;
using Pure.RelationalSchema.Storage.HashCodes;
using Pure.RelationalSchema.Storage.Samples.SchemaDataSets;
using Pure.RelationalSchema.Storage.Samples.TableDataSets;

namespace Pure.RelationalSchema.Storage.Samples.Tests.SchemaDataSets;

public sealed record SingleTableSchemaDataSetTests
{
    [Fact]
    public void SchemaIsSingleTableRelationalSchema()
    {
        IStoredSchemaDataSet dataSet = new SingleTableSchemaDataSet();

        Assert.True(
            new SchemaHash(dataSet.Schema).SequenceEqual(
                new SchemaHash(new SingleTableRelationalSchema())
            )
        );
    }

    [Fact]
    public void CountIs1()
    {
        IStoredSchemaDataSet dataSet = new SingleTableSchemaDataSet();

        _ = Assert.Single(dataSet);

        int count = dataSet.Count;

        Assert.Equal(1, count);
    }

    [Fact]
    public void ContainsKeySingleColumnTable()
    {
        IStoredSchemaDataSet dataSet = new SingleTableSchemaDataSet();

        Assert.True(dataSet.ContainsKey(new SingleColumnTable()));
    }

    [Fact]
    public void KeysContainsSingleColumnTable()
    {
        IStoredSchemaDataSet dataSet = new SingleTableSchemaDataSet();

        Assert.Contains(
            dataSet.Keys,
            table =>
                new TableHash(table).SequenceEqual(new TableHash(new SingleColumnTable()))
        );
    }

    [Fact]
    public void ValuesContainsSingleRowTableDataSet()
    {
        IStoredSchemaDataSet dataSet = new SingleTableSchemaDataSet();

        Assert.Contains(
            dataSet.Values,
            value =>
                new StoredTableDataSetHash(value).SequenceEqual(
                    new StoredTableDataSetHash(new SingleRowTableDataSet())
                )
        );
    }

    [Fact]
    public void IndexerReturnsSingleRowTableDataSet()
    {
        IStoredSchemaDataSet dataSet = new SingleTableSchemaDataSet();

        Assert.True(
            new StoredTableDataSetHash(dataSet[new SingleColumnTable()]).SequenceEqual(
                new StoredTableDataSetHash(new SingleRowTableDataSet())
            )
        );
    }

    [Fact]
    public void TryGetValueReturnsTrueForSingleColumnTable()
    {
        IStoredSchemaDataSet dataSet = new SingleTableSchemaDataSet();

        Assert.True(dataSet.TryGetValue(new SingleColumnTable(), out _));
    }

    [Fact]
    public void TryGetValueReturnsFalseForUnknownTable()
    {
        IStoredSchemaDataSet dataSet = new SingleTableSchemaDataSet();

        Assert.False(dataSet.TryGetValue(new EmptyNameTable(), out _));
    }

    [Fact]
    public void GenericEnumeratorEnumeratesOneEntry()
    {
        IStoredSchemaDataSet dataSet = new SingleTableSchemaDataSet();

        _ = Assert.Single(dataSet);
    }

    [Fact]
    public void NonGenericEnumeratorEnumeratesOneEntry()
    {
        IStoredSchemaDataSet dataSet = new SingleTableSchemaDataSet();

        IEnumerator enumerator = ((IEnumerable)dataSet).GetEnumerator();

        Assert.True(enumerator.MoveNext());
        Assert.False(enumerator.MoveNext());
    }
}
