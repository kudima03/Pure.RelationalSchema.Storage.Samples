using System.Collections;
using Pure.RelationalSchema.HashCodes;
using Pure.RelationalSchema.Samples.Schemas;
using Pure.RelationalSchema.Samples.Tables;
using Pure.RelationalSchema.Storage.Abstractions;
using Pure.RelationalSchema.Storage.Samples.SchemaDataSets;

namespace Pure.RelationalSchema.Storage.Samples.Tests.SchemaDataSets;

public sealed record EmptySchemaDataSetTests
{
    [Fact]
    public void SchemaIsEmptyRelationalSchema()
    {
        IStoredSchemaDataSet dataSet = new EmptySchemaDataSet();

        Assert.True(
            new SchemaHash(dataSet.Schema).SequenceEqual(
                new SchemaHash(new EmptyRelationalSchema())
            )
        );
    }

    [Fact]
    public void CountIs0()
    {
        IStoredSchemaDataSet dataSet = new EmptySchemaDataSet();

        Assert.Empty(dataSet);

        int count = dataSet.Count;

        Assert.Equal(0, count);
    }

    [Fact]
    public void KeysIsEmpty()
    {
        IStoredSchemaDataSet dataSet = new EmptySchemaDataSet();

        Assert.Empty(dataSet.Keys);
    }

    [Fact]
    public void ValuesIsEmpty()
    {
        IStoredSchemaDataSet dataSet = new EmptySchemaDataSet();

        Assert.Empty(dataSet.Values);
    }

    [Fact]
    public void IndexerThrowsForUnknownTable()
    {
        IStoredSchemaDataSet dataSet = new EmptySchemaDataSet();

        _ = Assert.Throws<NotSupportedException>(() => dataSet[new EmptyNameTable()]);
    }

    [Fact]
    public void TryGetValueReturnsFalseForUnknownTable()
    {
        IStoredSchemaDataSet dataSet = new EmptySchemaDataSet();

        Assert.False(dataSet.TryGetValue(new EmptyNameTable(), out _));
    }

    [Fact]
    public void ContainsKeyReturnsFalseForUnknownTable()
    {
        IStoredSchemaDataSet dataSet = new EmptySchemaDataSet();

        Assert.False(dataSet.ContainsKey(new EmptyNameTable()));
    }

    [Fact]
    public void GenericEnumeratorEnumeratesNoEntries()
    {
        IStoredSchemaDataSet dataSet = new EmptySchemaDataSet();

        Assert.Empty(dataSet);
    }

    [Fact]
    public void NonGenericEnumeratorEnumeratesNoEntries()
    {
        IStoredSchemaDataSet dataSet = new EmptySchemaDataSet();

        IEnumerator enumerator = ((IEnumerable)dataSet).GetEnumerator();

        Assert.False(enumerator.MoveNext());
    }
}
