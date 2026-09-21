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

public sealed record FullSchemaDataSetTests
{
    [Fact]
    public void SchemaIsFullRelationalSchema()
    {
        IStoredSchemaDataSet dataSet = new FullSchemaDataSet();

        Assert.True(
            new SchemaHash(dataSet.Schema).SequenceEqual(
                new SchemaHash(new FullRelationalSchema())
            )
        );
    }

    [Fact]
    public void CountIs13()
    {
        IStoredSchemaDataSet dataSet = new FullSchemaDataSet();

        Assert.Equal(13, dataSet.Count);
    }

    [Fact]
    public void ContainsKeyEmptyTable()
    {
        IStoredSchemaDataSet dataSet = new FullSchemaDataSet();

        Assert.True(dataSet.ContainsKey(new EmptyTable()));
    }

    [Fact]
    public void KeysContainsEmptyTable()
    {
        IStoredSchemaDataSet dataSet = new FullSchemaDataSet();

        Assert.Contains(
            dataSet.Keys,
            table => new TableHash(table).SequenceEqual(new TableHash(new EmptyTable()))
        );
    }

    [Fact]
    public void ValuesContainsEmptyTableDataSet()
    {
        IStoredSchemaDataSet dataSet = new FullSchemaDataSet();

        Assert.Contains(
            dataSet.Values,
            value =>
                new StoredTableDataSetHash(value).SequenceEqual(
                    new StoredTableDataSetHash(new EmptyTableDataSet())
                )
        );
    }

    [Fact]
    public void IndexerReturnsEmptyTableDataSet()
    {
        IStoredSchemaDataSet dataSet = new FullSchemaDataSet();

        Assert.True(
            new StoredTableDataSetHash(dataSet[new EmptyTable()]).SequenceEqual(
                new StoredTableDataSetHash(new EmptyTableDataSet())
            )
        );
    }

    [Fact]
    public void TryGetValueReturnsTrueForEmptyTable()
    {
        IStoredSchemaDataSet dataSet = new FullSchemaDataSet();

        Assert.True(dataSet.TryGetValue(new EmptyTable(), out _));
    }

    [Fact]
    public void ContainsKeySingleColumnTable()
    {
        IStoredSchemaDataSet dataSet = new FullSchemaDataSet();

        Assert.True(dataSet.ContainsKey(new SingleColumnTable()));
    }

    [Fact]
    public void KeysContainsSingleColumnTable()
    {
        IStoredSchemaDataSet dataSet = new FullSchemaDataSet();

        Assert.Contains(
            dataSet.Keys,
            table =>
                new TableHash(table).SequenceEqual(new TableHash(new SingleColumnTable()))
        );
    }

    [Fact]
    public void ValuesContainsSingleRowTableDataSet()
    {
        IStoredSchemaDataSet dataSet = new FullSchemaDataSet();

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
        IStoredSchemaDataSet dataSet = new FullSchemaDataSet();

        Assert.True(
            new StoredTableDataSetHash(dataSet[new SingleColumnTable()]).SequenceEqual(
                new StoredTableDataSetHash(new SingleRowTableDataSet())
            )
        );
    }

    [Fact]
    public void TryGetValueReturnsTrueForSingleColumnTable()
    {
        IStoredSchemaDataSet dataSet = new FullSchemaDataSet();

        Assert.True(dataSet.TryGetValue(new SingleColumnTable(), out _));
    }

    [Fact]
    public void ContainsKeyTableWithoutIndexes()
    {
        IStoredSchemaDataSet dataSet = new FullSchemaDataSet();

        Assert.True(dataSet.ContainsKey(new TableWithoutIndexes()));
    }

    [Fact]
    public void KeysContainsTableWithoutIndexes()
    {
        IStoredSchemaDataSet dataSet = new FullSchemaDataSet();

        Assert.Contains(
            dataSet.Keys,
            table =>
                new TableHash(table).SequenceEqual(
                    new TableHash(new TableWithoutIndexes())
                )
        );
    }

    [Fact]
    public void ValuesContainsTableWithoutIndexesDataSet()
    {
        IStoredSchemaDataSet dataSet = new FullSchemaDataSet();

        Assert.Contains(
            dataSet.Values,
            value =>
                new StoredTableDataSetHash(value).SequenceEqual(
                    new StoredTableDataSetHash(new TableWithoutIndexesDataSet())
                )
        );
    }

    [Fact]
    public void IndexerReturnsTableWithoutIndexesDataSet()
    {
        IStoredSchemaDataSet dataSet = new FullSchemaDataSet();

        Assert.True(
            new StoredTableDataSetHash(dataSet[new TableWithoutIndexes()]).SequenceEqual(
                new StoredTableDataSetHash(new TableWithoutIndexesDataSet())
            )
        );
    }

    [Fact]
    public void TryGetValueReturnsTrueForTableWithoutIndexes()
    {
        IStoredSchemaDataSet dataSet = new FullSchemaDataSet();

        Assert.True(dataSet.TryGetValue(new TableWithoutIndexes(), out _));
    }

    [Fact]
    public void ContainsKeyTableWithSingleIndex()
    {
        IStoredSchemaDataSet dataSet = new FullSchemaDataSet();

        Assert.True(dataSet.ContainsKey(new TableWithSingleIndex()));
    }

    [Fact]
    public void KeysContainsTableWithSingleIndex()
    {
        IStoredSchemaDataSet dataSet = new FullSchemaDataSet();

        Assert.Contains(
            dataSet.Keys,
            table =>
                new TableHash(table).SequenceEqual(
                    new TableHash(new TableWithSingleIndex())
                )
        );
    }

    [Fact]
    public void ValuesContainsTableWithSingleIndexDataSet()
    {
        IStoredSchemaDataSet dataSet = new FullSchemaDataSet();

        Assert.Contains(
            dataSet.Values,
            value =>
                new StoredTableDataSetHash(value).SequenceEqual(
                    new StoredTableDataSetHash(new TableWithSingleIndexDataSet())
                )
        );
    }

    [Fact]
    public void IndexerReturnsTableWithSingleIndexDataSet()
    {
        IStoredSchemaDataSet dataSet = new FullSchemaDataSet();

        Assert.True(
            new StoredTableDataSetHash(dataSet[new TableWithSingleIndex()]).SequenceEqual(
                new StoredTableDataSetHash(new TableWithSingleIndexDataSet())
            )
        );
    }

    [Fact]
    public void TryGetValueReturnsTrueForTableWithSingleIndex()
    {
        IStoredSchemaDataSet dataSet = new FullSchemaDataSet();

        Assert.True(dataSet.TryGetValue(new TableWithSingleIndex(), out _));
    }

    [Fact]
    public void ContainsKeyTableWithIndexes()
    {
        IStoredSchemaDataSet dataSet = new FullSchemaDataSet();

        Assert.True(dataSet.ContainsKey(new TableWithIndexes()));
    }

    [Fact]
    public void KeysContainsTableWithIndexes()
    {
        IStoredSchemaDataSet dataSet = new FullSchemaDataSet();

        Assert.Contains(
            dataSet.Keys,
            table =>
                new TableHash(table).SequenceEqual(new TableHash(new TableWithIndexes()))
        );
    }

    [Fact]
    public void ValuesContainsTableWithIndexesDataSet()
    {
        IStoredSchemaDataSet dataSet = new FullSchemaDataSet();

        Assert.Contains(
            dataSet.Values,
            value =>
                new StoredTableDataSetHash(value).SequenceEqual(
                    new StoredTableDataSetHash(new TableWithIndexesDataSet())
                )
        );
    }

    [Fact]
    public void IndexerReturnsTableWithIndexesDataSet()
    {
        IStoredSchemaDataSet dataSet = new FullSchemaDataSet();

        Assert.True(
            new StoredTableDataSetHash(dataSet[new TableWithIndexes()]).SequenceEqual(
                new StoredTableDataSetHash(new TableWithIndexesDataSet())
            )
        );
    }

    [Fact]
    public void TryGetValueReturnsTrueForTableWithIndexes()
    {
        IStoredSchemaDataSet dataSet = new FullSchemaDataSet();

        Assert.True(dataSet.TryGetValue(new TableWithIndexes(), out _));
    }

    [Fact]
    public void ContainsKeyAllColumnTypesTable()
    {
        IStoredSchemaDataSet dataSet = new FullSchemaDataSet();

        Assert.True(dataSet.ContainsKey(new AllColumnTypesTable()));
    }

    [Fact]
    public void KeysContainsAllColumnTypesTable()
    {
        IStoredSchemaDataSet dataSet = new FullSchemaDataSet();

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
        IStoredSchemaDataSet dataSet = new FullSchemaDataSet();

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
        IStoredSchemaDataSet dataSet = new FullSchemaDataSet();

        Assert.True(
            new StoredTableDataSetHash(dataSet[new AllColumnTypesTable()]).SequenceEqual(
                new StoredTableDataSetHash(new AllColumnTypesTableDataSet())
            )
        );
    }

    [Fact]
    public void TryGetValueReturnsTrueForAllColumnTypesTable()
    {
        IStoredSchemaDataSet dataSet = new FullSchemaDataSet();

        Assert.True(dataSet.TryGetValue(new AllColumnTypesTable(), out _));
    }

    [Fact]
    public void ContainsKeyUsersTable()
    {
        IStoredSchemaDataSet dataSet = new FullSchemaDataSet();

        Assert.True(dataSet.ContainsKey(new UsersTable()));
    }

    [Fact]
    public void KeysContainsUsersTable()
    {
        IStoredSchemaDataSet dataSet = new FullSchemaDataSet();

        Assert.Contains(
            dataSet.Keys,
            table => new TableHash(table).SequenceEqual(new TableHash(new UsersTable()))
        );
    }

    [Fact]
    public void ValuesContainsUsersTableDataSet()
    {
        IStoredSchemaDataSet dataSet = new FullSchemaDataSet();

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
        IStoredSchemaDataSet dataSet = new FullSchemaDataSet();

        Assert.True(
            new StoredTableDataSetHash(dataSet[new UsersTable()]).SequenceEqual(
                new StoredTableDataSetHash(new UsersTableDataSet())
            )
        );
    }

    [Fact]
    public void TryGetValueReturnsTrueForUsersTable()
    {
        IStoredSchemaDataSet dataSet = new FullSchemaDataSet();

        Assert.True(dataSet.TryGetValue(new UsersTable(), out _));
    }

    [Fact]
    public void ContainsKeyOrdersTable()
    {
        IStoredSchemaDataSet dataSet = new FullSchemaDataSet();

        Assert.True(dataSet.ContainsKey(new OrdersTable()));
    }

    [Fact]
    public void KeysContainsOrdersTable()
    {
        IStoredSchemaDataSet dataSet = new FullSchemaDataSet();

        Assert.Contains(
            dataSet.Keys,
            table => new TableHash(table).SequenceEqual(new TableHash(new OrdersTable()))
        );
    }

    [Fact]
    public void ValuesContainsOrdersTableDataSet()
    {
        IStoredSchemaDataSet dataSet = new FullSchemaDataSet();

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
        IStoredSchemaDataSet dataSet = new FullSchemaDataSet();

        Assert.True(
            new StoredTableDataSetHash(dataSet[new OrdersTable()]).SequenceEqual(
                new StoredTableDataSetHash(new OrdersTableDataSet())
            )
        );
    }

    [Fact]
    public void TryGetValueReturnsTrueForOrdersTable()
    {
        IStoredSchemaDataSet dataSet = new FullSchemaDataSet();

        Assert.True(dataSet.TryGetValue(new OrdersTable(), out _));
    }

    [Fact]
    public void ContainsKeyProductsTable()
    {
        IStoredSchemaDataSet dataSet = new FullSchemaDataSet();

        Assert.True(dataSet.ContainsKey(new ProductsTable()));
    }

    [Fact]
    public void KeysContainsProductsTable()
    {
        IStoredSchemaDataSet dataSet = new FullSchemaDataSet();

        Assert.Contains(
            dataSet.Keys,
            table =>
                new TableHash(table).SequenceEqual(new TableHash(new ProductsTable()))
        );
    }

    [Fact]
    public void ValuesContainsProductsTableDataSet()
    {
        IStoredSchemaDataSet dataSet = new FullSchemaDataSet();

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
        IStoredSchemaDataSet dataSet = new FullSchemaDataSet();

        Assert.True(
            new StoredTableDataSetHash(dataSet[new ProductsTable()]).SequenceEqual(
                new StoredTableDataSetHash(new ProductsTableDataSet())
            )
        );
    }

    [Fact]
    public void TryGetValueReturnsTrueForProductsTable()
    {
        IStoredSchemaDataSet dataSet = new FullSchemaDataSet();

        Assert.True(dataSet.TryGetValue(new ProductsTable(), out _));
    }

    [Fact]
    public void ContainsKeyOrderItemsTable()
    {
        IStoredSchemaDataSet dataSet = new FullSchemaDataSet();

        Assert.True(dataSet.ContainsKey(new OrderItemsTable()));
    }

    [Fact]
    public void KeysContainsOrderItemsTable()
    {
        IStoredSchemaDataSet dataSet = new FullSchemaDataSet();

        Assert.Contains(
            dataSet.Keys,
            table =>
                new TableHash(table).SequenceEqual(new TableHash(new OrderItemsTable()))
        );
    }

    [Fact]
    public void ValuesContainsOrderItemsTableDataSet()
    {
        IStoredSchemaDataSet dataSet = new FullSchemaDataSet();

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
        IStoredSchemaDataSet dataSet = new FullSchemaDataSet();

        Assert.True(
            new StoredTableDataSetHash(dataSet[new OrderItemsTable()]).SequenceEqual(
                new StoredTableDataSetHash(new OrderItemsTableDataSet())
            )
        );
    }

    [Fact]
    public void TryGetValueReturnsTrueForOrderItemsTable()
    {
        IStoredSchemaDataSet dataSet = new FullSchemaDataSet();

        Assert.True(dataSet.TryGetValue(new OrderItemsTable(), out _));
    }

    [Fact]
    public void ContainsKeyEmployeesTable()
    {
        IStoredSchemaDataSet dataSet = new FullSchemaDataSet();

        Assert.True(dataSet.ContainsKey(new EmployeesTable()));
    }

    [Fact]
    public void KeysContainsEmployeesTable()
    {
        IStoredSchemaDataSet dataSet = new FullSchemaDataSet();

        Assert.Contains(
            dataSet.Keys,
            table =>
                new TableHash(table).SequenceEqual(new TableHash(new EmployeesTable()))
        );
    }

    [Fact]
    public void ValuesContainsEmployeesTableDataSet()
    {
        IStoredSchemaDataSet dataSet = new FullSchemaDataSet();

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
        IStoredSchemaDataSet dataSet = new FullSchemaDataSet();

        Assert.True(
            new StoredTableDataSetHash(dataSet[new EmployeesTable()]).SequenceEqual(
                new StoredTableDataSetHash(new EmployeesTableDataSet())
            )
        );
    }

    [Fact]
    public void TryGetValueReturnsTrueForEmployeesTable()
    {
        IStoredSchemaDataSet dataSet = new FullSchemaDataSet();

        Assert.True(dataSet.TryGetValue(new EmployeesTable(), out _));
    }

    [Fact]
    public void ContainsKeyLoginsTable()
    {
        IStoredSchemaDataSet dataSet = new FullSchemaDataSet();

        Assert.True(dataSet.ContainsKey(new LoginsTable()));
    }

    [Fact]
    public void KeysContainsLoginsTable()
    {
        IStoredSchemaDataSet dataSet = new FullSchemaDataSet();

        Assert.Contains(
            dataSet.Keys,
            table => new TableHash(table).SequenceEqual(new TableHash(new LoginsTable()))
        );
    }

    [Fact]
    public void ValuesContainsLoginsTableDataSet()
    {
        IStoredSchemaDataSet dataSet = new FullSchemaDataSet();

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
        IStoredSchemaDataSet dataSet = new FullSchemaDataSet();

        Assert.True(
            new StoredTableDataSetHash(dataSet[new LoginsTable()]).SequenceEqual(
                new StoredTableDataSetHash(new LoginsTableDataSet())
            )
        );
    }

    [Fact]
    public void TryGetValueReturnsTrueForLoginsTable()
    {
        IStoredSchemaDataSet dataSet = new FullSchemaDataSet();

        Assert.True(dataSet.TryGetValue(new LoginsTable(), out _));
    }

    [Fact]
    public void ContainsKeyStatusesTable()
    {
        IStoredSchemaDataSet dataSet = new FullSchemaDataSet();

        Assert.True(dataSet.ContainsKey(new StatusesTable()));
    }

    [Fact]
    public void KeysContainsStatusesTable()
    {
        IStoredSchemaDataSet dataSet = new FullSchemaDataSet();

        Assert.Contains(
            dataSet.Keys,
            table =>
                new TableHash(table).SequenceEqual(new TableHash(new StatusesTable()))
        );
    }

    [Fact]
    public void ValuesContainsStatusesTableDataSet()
    {
        IStoredSchemaDataSet dataSet = new FullSchemaDataSet();

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
        IStoredSchemaDataSet dataSet = new FullSchemaDataSet();

        Assert.True(
            new StoredTableDataSetHash(dataSet[new StatusesTable()]).SequenceEqual(
                new StoredTableDataSetHash(new StatusesTableDataSet())
            )
        );
    }

    [Fact]
    public void TryGetValueReturnsTrueForStatusesTable()
    {
        IStoredSchemaDataSet dataSet = new FullSchemaDataSet();

        Assert.True(dataSet.TryGetValue(new StatusesTable(), out _));
    }

    [Fact]
    public void TryGetValueReturnsFalseForUnknownTable()
    {
        IStoredSchemaDataSet dataSet = new FullSchemaDataSet();

        Assert.False(dataSet.TryGetValue(new EmptyNameTable(), out _));
    }

    [Fact]
    public void GenericEnumeratorEnumeratesThirteenEntries()
    {
        IStoredSchemaDataSet dataSet = new FullSchemaDataSet();

        int count = 0;
        foreach (KeyValuePair<ITable, IStoredTableDataSet> entry in dataSet)
        {
            Assert.NotNull(entry.Value);
            count++;
        }

        Assert.Equal(13, count);
    }

    [Fact]
    public void NonGenericEnumeratorEnumeratesThirteenEntries()
    {
        IStoredSchemaDataSet dataSet = new FullSchemaDataSet();

        IEnumerator enumerator = ((IEnumerable)dataSet).GetEnumerator();

        int count = 0;
        while (enumerator.MoveNext())
        {
            count++;
        }

        Assert.Equal(13, count);
    }
}
