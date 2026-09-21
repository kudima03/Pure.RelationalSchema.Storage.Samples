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

public sealed record AuditSchemaDataSetTests
{
    [Fact]
    public void SchemaIsAuditRelationalSchema()
    {
        IStoredSchemaDataSet dataSet = new AuditSchemaDataSet();

        Assert.True(
            new SchemaHash(dataSet.Schema).SequenceEqual(
                new SchemaHash(new AuditRelationalSchema())
            )
        );
    }

    [Fact]
    public void CountIs1()
    {
        IStoredSchemaDataSet dataSet = new AuditSchemaDataSet();

        int count = dataSet.Count;

        _ = Assert.Single(dataSet);
        Assert.Equal(1, count);
    }

    [Fact]
    public void ContainsKeyLoginsTable()
    {
        IStoredSchemaDataSet dataSet = new AuditSchemaDataSet();

        Assert.True(dataSet.ContainsKey(new LoginsTable()));
    }

    [Fact]
    public void KeysContainsLoginsTable()
    {
        IStoredSchemaDataSet dataSet = new AuditSchemaDataSet();

        Assert.Contains(
            dataSet.Keys,
            table => new TableHash(table).SequenceEqual(new TableHash(new LoginsTable()))
        );
    }

    [Fact]
    public void ValuesContainsLoginsTableDataSet()
    {
        IStoredSchemaDataSet dataSet = new AuditSchemaDataSet();

        Assert.Contains(
            dataSet.Values,
            value =>
                new StoredTableDataSetHash(value).SequenceEqual(
                    new StoredTableDataSetHash(new LoginsTableDataSet())
                )
        );
    }

    [Fact]
    public void IndexerReturnsLoginsTableDataSet()
    {
        IStoredSchemaDataSet dataSet = new AuditSchemaDataSet();

        Assert.True(
            new StoredTableDataSetHash(dataSet[new LoginsTable()]).SequenceEqual(
                new StoredTableDataSetHash(new LoginsTableDataSet())
            )
        );
    }

    [Fact]
    public void TryGetValueReturnsTrueForLoginsTable()
    {
        IStoredSchemaDataSet dataSet = new AuditSchemaDataSet();

        Assert.True(dataSet.TryGetValue(new LoginsTable(), out _));
    }

    [Fact]
    public void TryGetValueReturnsFalseForUnknownTable()
    {
        IStoredSchemaDataSet dataSet = new AuditSchemaDataSet();

        Assert.False(dataSet.TryGetValue(new EmptyNameTable(), out _));
    }

    [Fact]
    public void GenericEnumeratorEnumeratesOneEntry()
    {
        IStoredSchemaDataSet dataSet = new AuditSchemaDataSet();

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
        IStoredSchemaDataSet dataSet = new AuditSchemaDataSet();

        IEnumerator enumerator = ((IEnumerable)dataSet).GetEnumerator();

        int count = 0;
        while (enumerator.MoveNext())
        {
            count++;
        }

        Assert.Equal(1, count);
    }
}
