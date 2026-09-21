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
    public void CountIs5()
    {
        IStoredSchemaDataSet dataSet = new SchemaDataSetWithForeignKeys();

        Assert.Equal(5, dataSet.Count);
    }

    [Fact]
    public void ContainsKeyUsersTable()
    {
        IStoredSchemaDataSet dataSet = new SchemaDataSetWithForeignKeys();

        Assert.True(dataSet.ContainsKey(new UsersTable()));
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
    public void TryGetValueReturnsTrueForUsersTable()
    {
        IStoredSchemaDataSet dataSet = new SchemaDataSetWithForeignKeys();

        Assert.True(dataSet.TryGetValue(new UsersTable(), out _));
    }

    [Fact]
    public void ContainsKeyOrdersTable()
    {
        IStoredSchemaDataSet dataSet = new SchemaDataSetWithForeignKeys();

        Assert.True(dataSet.ContainsKey(new OrdersTable()));
    }

    [Fact]
    public void KeysContainsOrdersTable()
    {
        IStoredSchemaDataSet dataSet = new SchemaDataSetWithForeignKeys();

        Assert.Contains(
            dataSet.Keys,
            table => new TableHash(table).SequenceEqual(new TableHash(new OrdersTable()))
        );
    }

    [Fact]
    public void ValuesContainsOrdersTableDataSet()
    {
        IStoredSchemaDataSet dataSet = new SchemaDataSetWithForeignKeys();

        Assert.Contains(
            dataSet.Values,
            value =>
                new StoredTableDataSetHash(value).SequenceEqual(
                    new StoredTableDataSetHash(new OrdersTableDataSet())
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
    public void TryGetValueReturnsTrueForOrdersTable()
    {
        IStoredSchemaDataSet dataSet = new SchemaDataSetWithForeignKeys();

        Assert.True(dataSet.TryGetValue(new OrdersTable(), out _));
    }

    [Fact]
    public void ContainsKeyProductsTable()
    {
        IStoredSchemaDataSet dataSet = new SchemaDataSetWithForeignKeys();

        Assert.True(dataSet.ContainsKey(new ProductsTable()));
    }

    [Fact]
    public void KeysContainsProductsTable()
    {
        IStoredSchemaDataSet dataSet = new SchemaDataSetWithForeignKeys();

        Assert.Contains(
            dataSet.Keys,
            table =>
                new TableHash(table).SequenceEqual(new TableHash(new ProductsTable()))
        );
    }

    [Fact]
    public void ValuesContainsProductsTableDataSet()
    {
        IStoredSchemaDataSet dataSet = new SchemaDataSetWithForeignKeys();

        Assert.Contains(
            dataSet.Values,
            value =>
                new StoredTableDataSetHash(value).SequenceEqual(
                    new StoredTableDataSetHash(new ProductsTableDataSet())
                )
        );
    }

    [Fact]
    public void IndexerReturnsProductsTableDataSet()
    {
        IStoredSchemaDataSet dataSet = new SchemaDataSetWithForeignKeys();

        Assert.True(
            new StoredTableDataSetHash(dataSet[new ProductsTable()]).SequenceEqual(
                new StoredTableDataSetHash(new ProductsTableDataSet())
            )
        );
    }

    [Fact]
    public void TryGetValueReturnsTrueForProductsTable()
    {
        IStoredSchemaDataSet dataSet = new SchemaDataSetWithForeignKeys();

        Assert.True(dataSet.TryGetValue(new ProductsTable(), out _));
    }

    [Fact]
    public void ContainsKeyOrderItemsTable()
    {
        IStoredSchemaDataSet dataSet = new SchemaDataSetWithForeignKeys();

        Assert.True(dataSet.ContainsKey(new OrderItemsTable()));
    }

    [Fact]
    public void KeysContainsOrderItemsTable()
    {
        IStoredSchemaDataSet dataSet = new SchemaDataSetWithForeignKeys();

        Assert.Contains(
            dataSet.Keys,
            table =>
                new TableHash(table).SequenceEqual(new TableHash(new OrderItemsTable()))
        );
    }

    [Fact]
    public void ValuesContainsOrderItemsTableDataSet()
    {
        IStoredSchemaDataSet dataSet = new SchemaDataSetWithForeignKeys();

        Assert.Contains(
            dataSet.Values,
            value =>
                new StoredTableDataSetHash(value).SequenceEqual(
                    new StoredTableDataSetHash(new OrderItemsTableDataSet())
                )
        );
    }

    [Fact]
    public void IndexerReturnsOrderItemsTableDataSet()
    {
        IStoredSchemaDataSet dataSet = new SchemaDataSetWithForeignKeys();

        Assert.True(
            new StoredTableDataSetHash(dataSet[new OrderItemsTable()]).SequenceEqual(
                new StoredTableDataSetHash(new OrderItemsTableDataSet())
            )
        );
    }

    [Fact]
    public void TryGetValueReturnsTrueForOrderItemsTable()
    {
        IStoredSchemaDataSet dataSet = new SchemaDataSetWithForeignKeys();

        Assert.True(dataSet.TryGetValue(new OrderItemsTable(), out _));
    }

    [Fact]
    public void ContainsKeyEmployeesTable()
    {
        IStoredSchemaDataSet dataSet = new SchemaDataSetWithForeignKeys();

        Assert.True(dataSet.ContainsKey(new EmployeesTable()));
    }

    [Fact]
    public void KeysContainsEmployeesTable()
    {
        IStoredSchemaDataSet dataSet = new SchemaDataSetWithForeignKeys();

        Assert.Contains(
            dataSet.Keys,
            table =>
                new TableHash(table).SequenceEqual(new TableHash(new EmployeesTable()))
        );
    }

    [Fact]
    public void ValuesContainsEmployeesTableDataSet()
    {
        IStoredSchemaDataSet dataSet = new SchemaDataSetWithForeignKeys();

        Assert.Contains(
            dataSet.Values,
            value =>
                new StoredTableDataSetHash(value).SequenceEqual(
                    new StoredTableDataSetHash(new EmployeesTableDataSet())
                )
        );
    }

    [Fact]
    public void IndexerReturnsEmployeesTableDataSet()
    {
        IStoredSchemaDataSet dataSet = new SchemaDataSetWithForeignKeys();

        Assert.True(
            new StoredTableDataSetHash(dataSet[new EmployeesTable()]).SequenceEqual(
                new StoredTableDataSetHash(new EmployeesTableDataSet())
            )
        );
    }

    [Fact]
    public void TryGetValueReturnsTrueForEmployeesTable()
    {
        IStoredSchemaDataSet dataSet = new SchemaDataSetWithForeignKeys();

        Assert.True(dataSet.TryGetValue(new EmployeesTable(), out _));
    }

    [Fact]
    public void TryGetValueReturnsFalseForUnknownTable()
    {
        IStoredSchemaDataSet dataSet = new SchemaDataSetWithForeignKeys();

        Assert.False(dataSet.TryGetValue(new EmptyNameTable(), out _));
    }

    [Fact]
    public void GenericEnumeratorEnumeratesFiveEntries()
    {
        IStoredSchemaDataSet dataSet = new SchemaDataSetWithForeignKeys();

        int count = 0;
        foreach (KeyValuePair<ITable, IStoredTableDataSet> entry in dataSet)
        {
            Assert.NotNull(entry.Value);
            count++;
        }

        Assert.Equal(5, count);
    }

    [Fact]
    public void NonGenericEnumeratorEnumeratesFiveEntries()
    {
        IStoredSchemaDataSet dataSet = new SchemaDataSetWithForeignKeys();

        IEnumerator enumerator = ((IEnumerable)dataSet).GetEnumerator();

        int count = 0;
        while (enumerator.MoveNext())
        {
            count++;
        }

        Assert.Equal(5, count);
    }
}
