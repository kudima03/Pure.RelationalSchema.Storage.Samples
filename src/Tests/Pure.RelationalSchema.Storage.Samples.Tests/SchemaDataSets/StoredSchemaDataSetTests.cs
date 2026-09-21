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

public sealed record StoredSchemaDataSetTests
{
    [Fact]
    public void SchemaIsTheGivenSchema()
    {
        IStoredSchemaDataSet dataSet = new StoredSchemaDataSet(
            new AuditRelationalSchema(),
            [new LoginsTableDataSet()]
        );

        Assert.True(
            new SchemaHash(dataSet.Schema).SequenceEqual(
                new SchemaHash(new AuditRelationalSchema())
            )
        );
    }

    [Fact]
    public void CountIsTheGivenDataSetCount()
    {
        IStoredSchemaDataSet dataSet = new StoredSchemaDataSet(
            new FullRelationalSchema(),
            [new UsersTableDataSet(), new OrdersTableDataSet()]
        );

        Assert.Equal(2, dataSet.Count);
    }

    [Fact]
    public void AcceptsNoDataSets()
    {
        IStoredSchemaDataSet dataSet = new StoredSchemaDataSet(
            new EmptyRelationalSchema(),
            []
        );

        Assert.Empty(dataSet);
    }

    [Fact]
    public void KeysAreTheTableSchemasOfTheGivenDataSets()
    {
        IStoredSchemaDataSet dataSet = new StoredSchemaDataSet(
            new AuditRelationalSchema(),
            [new LoginsTableDataSet()]
        );

        ITable key = Assert.Single(dataSet.Keys);

        Assert.True(new TableHash(key).SequenceEqual(new TableHash(new LoginsTable())));
    }

    [Fact]
    public void ValuesAreTheGivenDataSets()
    {
        IStoredSchemaDataSet dataSet = new StoredSchemaDataSet(
            new AuditRelationalSchema(),
            [new LoginsTableDataSet()]
        );

        IStoredTableDataSet value = Assert.Single(dataSet.Values);

        Assert.True(
            new StoredTableDataSetHash(value).SequenceEqual(
                new StoredTableDataSetHash(new LoginsTableDataSet())
            )
        );
    }

    [Fact]
    public void ContainsKeyTheGivenTable()
    {
        IStoredSchemaDataSet dataSet = new StoredSchemaDataSet(
            new AuditRelationalSchema(),
            [new LoginsTableDataSet()]
        );

        Assert.True(dataSet.ContainsKey(new LoginsTable()));
    }

    [Fact]
    public void IndexerReturnsTheGivenDataSet()
    {
        IStoredSchemaDataSet dataSet = new StoredSchemaDataSet(
            new AuditRelationalSchema(),
            [new LoginsTableDataSet()]
        );

        Assert.True(
            new StoredTableDataSetHash(dataSet[new LoginsTable()]).SequenceEqual(
                new StoredTableDataSetHash(new LoginsTableDataSet())
            )
        );
    }

    [Fact]
    public void TryGetValueReturnsTrueForTheGivenTable()
    {
        IStoredSchemaDataSet dataSet = new StoredSchemaDataSet(
            new AuditRelationalSchema(),
            [new LoginsTableDataSet()]
        );

        Assert.True(dataSet.TryGetValue(new LoginsTable(), out _));
    }

    [Fact]
    public void TryGetValueReturnsFalseForUnknownTable()
    {
        IStoredSchemaDataSet dataSet = new StoredSchemaDataSet(
            new AuditRelationalSchema(),
            [new LoginsTableDataSet()]
        );

        Assert.False(dataSet.TryGetValue(new EmptyNameTable(), out _));
    }

    [Fact]
    public void TwoInstancesCanShareOneSchemaName()
    {
        IStoredSchemaDataSet first = new StoredSchemaDataSet(
            new AuditRelationalSchema(),
            [new LoginsTableDataSet()]
        );
        IStoredSchemaDataSet second = new StoredSchemaDataSet(
            new AuditRelationalSchema(),
            []
        );

        Assert.Equal(first.Schema.Name.TextValue, second.Schema.Name.TextValue);
        Assert.NotEqual(first.Count, second.Count);
    }

    [Fact]
    public void GenericEnumeratorEnumeratesOneEntry()
    {
        IStoredSchemaDataSet dataSet = new StoredSchemaDataSet(
            new AuditRelationalSchema(),
            [new LoginsTableDataSet()]
        );

        KeyValuePair<ITable, IStoredTableDataSet> entry = Assert.Single(dataSet);

        Assert.NotNull(entry.Value);
    }

    [Fact]
    public void NonGenericEnumeratorEnumeratesOneEntry()
    {
        IStoredSchemaDataSet dataSet = new StoredSchemaDataSet(
            new AuditRelationalSchema(),
            [new LoginsTableDataSet()]
        );

        IEnumerator enumerator = ((IEnumerable)dataSet).GetEnumerator();

        int count = 0;
        while (enumerator.MoveNext())
        {
            count++;
        }

        Assert.Equal(1, count);
    }
}
