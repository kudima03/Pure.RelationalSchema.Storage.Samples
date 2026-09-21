using System.Collections;
using Pure.RelationalSchema.HashCodes;
using Pure.RelationalSchema.Samples.Schemas;
using Pure.RelationalSchema.Samples.Tables;
using Pure.RelationalSchema.Storage.Abstractions;
using Pure.RelationalSchema.Storage.HashCodes;
using Pure.RelationalSchema.Storage.Samples.SchemaDataSets;
using Pure.RelationalSchema.Storage.Samples.TableDataSets;

namespace Pure.RelationalSchema.Storage.Samples.Tests.SchemaDataSets;

public sealed record SchemaDataSetWithForeignKeysTests
{
    [Fact]
    public void SchemaIsRelationalSchemaWithForeignKeys()
    {
        IStoredSchemaDataSet dataSet = new SchemaDataSetWithForeignKeys();

        Assert.True(
            new SchemaHash(dataSet.Schema).SequenceEqual(
                new SchemaHash(new RelationalSchemaWithForeignKeys())
            )
        );
    }

    [Fact]
    public void CountIs2()
    {
        IStoredSchemaDataSet dataSet = new SchemaDataSetWithForeignKeys();

        Assert.Equal(2, dataSet.Count);
    }

    [Fact]
    public void ContainsKeyUsersTable()
    {
        IStoredSchemaDataSet dataSet = new SchemaDataSetWithForeignKeys();

        Assert.True(dataSet.ContainsKey(new UsersTable()));
    }

    [Fact]
    public void ContainsKeyOrdersTable()
    {
        IStoredSchemaDataSet dataSet = new SchemaDataSetWithForeignKeys();

        Assert.True(dataSet.ContainsKey(new OrdersTable()));
    }

    [Fact]
    public void KeysContainsUsersTable()
    {
        IStoredSchemaDataSet dataSet = new SchemaDataSetWithForeignKeys();

        Assert.Contains(
            dataSet.Keys,
            table => new TableHash(table).SequenceEqual(new TableHash(new UsersTable()))
        );
    }

    [Fact]
    public void ValuesContainsUsersTableDataSet()
    {
        IStoredSchemaDataSet dataSet = new SchemaDataSetWithForeignKeys();

        Assert.Contains(
            dataSet.Values,
            value =>
                new StoredTableDataSetHash(value).SequenceEqual(
                    new StoredTableDataSetHash(new UsersTableDataSet())
                )
        );
    }

    [Fact]
    public void IndexerReturnsUsersTableDataSet()
    {
        IStoredSchemaDataSet dataSet = new SchemaDataSetWithForeignKeys();

        Assert.True(
            new StoredTableDataSetHash(dataSet[new UsersTable()]).SequenceEqual(
                new StoredTableDataSetHash(new UsersTableDataSet())
            )
        );
    }

    [Fact]
    public void IndexerReturnsOrdersTableDataSet()
    {
        IStoredSchemaDataSet dataSet = new SchemaDataSetWithForeignKeys();

        Assert.True(
            new StoredTableDataSetHash(dataSet[new OrdersTable()]).SequenceEqual(
                new StoredTableDataSetHash(new OrdersTableDataSet())
            )
        );
    }

    [Fact]
    public void TryGetValueReturnsTrueForUsersTable()
    {
        IStoredSchemaDataSet dataSet = new SchemaDataSetWithForeignKeys();

        Assert.True(dataSet.TryGetValue(new UsersTable(), out _));
    }

    [Fact]
    public void TryGetValueReturnsFalseForUnknownTable()
    {
        IStoredSchemaDataSet dataSet = new SchemaDataSetWithForeignKeys();

        Assert.False(dataSet.TryGetValue(new EmptyNameTable(), out _));
    }

    [Fact]
    public void GenericEnumeratorEnumeratesTwoEntries()
    {
        IStoredSchemaDataSet dataSet = new SchemaDataSetWithForeignKeys();

        Assert.Equal(2, dataSet.Count);
    }

    [Fact]
    public void NonGenericEnumeratorEnumeratesTwoEntries()
    {
        IStoredSchemaDataSet dataSet = new SchemaDataSetWithForeignKeys();

        IEnumerator enumerator = ((IEnumerable)dataSet).GetEnumerator();

        int count = 0;
        while (enumerator.MoveNext())
        {
            count++;
        }

        Assert.Equal(2, count);
    }
}
