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

public sealed record RefsSchemaDataSetTests
{
    [Fact]
    public void SchemaIsRefsRelationalSchema()
    {
        IStoredSchemaDataSet dataSet = new RefsSchemaDataSet();

        Assert.True(
            new SchemaHash(dataSet.Schema).SequenceEqual(
                new SchemaHash(new RefsRelationalSchema())
            )
        );
    }

    [Fact]
    public void CountIs1()
    {
        IStoredSchemaDataSet dataSet = new RefsSchemaDataSet();

        int count = dataSet.Count;

        _ = Assert.Single(dataSet);
        Assert.Equal(1, count);
    }

    [Fact]
    public void ContainsKeyStatusesTable()
    {
        IStoredSchemaDataSet dataSet = new RefsSchemaDataSet();

        Assert.True(dataSet.ContainsKey(new StatusesTable()));
    }

    [Fact]
    public void KeysContainsStatusesTable()
    {
        IStoredSchemaDataSet dataSet = new RefsSchemaDataSet();

        Assert.Contains(
            dataSet.Keys,
            table =>
                new TableHash(table).SequenceEqual(new TableHash(new StatusesTable()))
        );
    }

    [Fact]
    public void ValuesContainsStatusesTableDataSet()
    {
        IStoredSchemaDataSet dataSet = new RefsSchemaDataSet();

        Assert.Contains(
            dataSet.Values,
            value =>
                new StoredTableDataSetHash(value).SequenceEqual(
                    new StoredTableDataSetHash(new StatusesTableDataSet())
                )
        );
    }

    [Fact]
    public void IndexerReturnsStatusesTableDataSet()
    {
        IStoredSchemaDataSet dataSet = new RefsSchemaDataSet();

        Assert.True(
            new StoredTableDataSetHash(dataSet[new StatusesTable()]).SequenceEqual(
                new StoredTableDataSetHash(new StatusesTableDataSet())
            )
        );
    }

    [Fact]
    public void TryGetValueReturnsTrueForStatusesTable()
    {
        IStoredSchemaDataSet dataSet = new RefsSchemaDataSet();

        Assert.True(dataSet.TryGetValue(new StatusesTable(), out _));
    }

    [Fact]
    public void TryGetValueReturnsFalseForUnknownTable()
    {
        IStoredSchemaDataSet dataSet = new RefsSchemaDataSet();

        Assert.False(dataSet.TryGetValue(new EmptyNameTable(), out _));
    }

    [Fact]
    public void GenericEnumeratorEnumeratesOneEntry()
    {
        IStoredSchemaDataSet dataSet = new RefsSchemaDataSet();

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
        IStoredSchemaDataSet dataSet = new RefsSchemaDataSet();

        IEnumerator enumerator = ((IEnumerable)dataSet).GetEnumerator();

        int count = 0;
        while (enumerator.MoveNext())
        {
            count++;
        }

        Assert.Equal(1, count);
    }
}
