using System.Collections;
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
    public void CountIs11()
    {
        IStoredSchemaDataSet dataSet = new FullSchemaDataSet();

        Assert.Equal(11, dataSet.Count);
    }

    [Fact]
    public void ContainsKeyEmptyTable()
    {
        IStoredSchemaDataSet dataSet = new FullSchemaDataSet();

        Assert.True(dataSet.ContainsKey(new EmptyTable()));
    }

    [Fact]
    public void ContainsKeySingleColumnTable()
    {
        IStoredSchemaDataSet dataSet = new FullSchemaDataSet();

        Assert.True(dataSet.ContainsKey(new SingleColumnTable()));
    }

    [Fact]
    public void ContainsKeyTableWithoutIndexes()
    {
        IStoredSchemaDataSet dataSet = new FullSchemaDataSet();

        Assert.True(dataSet.ContainsKey(new TableWithoutIndexes()));
    }

    [Fact]
    public void ContainsKeyTableWithSingleIndex()
    {
        IStoredSchemaDataSet dataSet = new FullSchemaDataSet();

        Assert.True(dataSet.ContainsKey(new TableWithSingleIndex()));
    }

    [Fact]
    public void ContainsKeyTableWithIndexes()
    {
        IStoredSchemaDataSet dataSet = new FullSchemaDataSet();

        Assert.True(dataSet.ContainsKey(new TableWithIndexes()));
    }

    [Fact]
    public void ContainsKeyAllColumnTypesTable()
    {
        IStoredSchemaDataSet dataSet = new FullSchemaDataSet();

        Assert.True(dataSet.ContainsKey(new AllColumnTypesTable()));
    }

    [Fact]
    public void ContainsKeyUsersTable()
    {
        IStoredSchemaDataSet dataSet = new FullSchemaDataSet();

        Assert.True(dataSet.ContainsKey(new UsersTable()));
    }

    [Fact]
    public void ContainsKeyOrdersTable()
    {
        IStoredSchemaDataSet dataSet = new FullSchemaDataSet();

        Assert.True(dataSet.ContainsKey(new OrdersTable()));
    }

    [Fact]
    public void ContainsKeyProductsTable()
    {
        IStoredSchemaDataSet dataSet = new FullSchemaDataSet();

        Assert.True(dataSet.ContainsKey(new ProductsTable()));
    }

    [Fact]
    public void ContainsKeyOrderItemsTable()
    {
        IStoredSchemaDataSet dataSet = new FullSchemaDataSet();

        Assert.True(dataSet.ContainsKey(new OrderItemsTable()));
    }

    [Fact]
    public void ContainsKeyEmployeesTable()
    {
        IStoredSchemaDataSet dataSet = new FullSchemaDataSet();

        Assert.True(dataSet.ContainsKey(new EmployeesTable()));
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
    public void TryGetValueReturnsFalseForUnknownTable()
    {
        IStoredSchemaDataSet dataSet = new FullSchemaDataSet();

        Assert.False(dataSet.TryGetValue(new EmptyNameTable(), out _));
    }

    [Fact]
    public void GenericEnumeratorEnumeratesElevenEntries()
    {
        IStoredSchemaDataSet dataSet = new FullSchemaDataSet();

        Assert.Equal(11, dataSet.Count);
    }

    [Fact]
    public void NonGenericEnumeratorEnumeratesElevenEntries()
    {
        IStoredSchemaDataSet dataSet = new FullSchemaDataSet();

        IEnumerator enumerator = ((IEnumerable)dataSet).GetEnumerator();

        int count = 0;
        while (enumerator.MoveNext())
        {
            count++;
        }

        Assert.Equal(11, count);
    }
}
