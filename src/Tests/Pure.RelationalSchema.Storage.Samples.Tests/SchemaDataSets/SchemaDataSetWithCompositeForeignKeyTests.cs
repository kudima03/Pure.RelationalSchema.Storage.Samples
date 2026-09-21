using System.Collections;
using Pure.RelationalSchema.HashCodes;
using Pure.RelationalSchema.Samples.Schemas;
using Pure.RelationalSchema.Samples.Tables;
using Pure.RelationalSchema.Storage.Abstractions;
using Pure.RelationalSchema.Storage.HashCodes;
using Pure.RelationalSchema.Storage.Samples.SchemaDataSets;
using Pure.RelationalSchema.Storage.Samples.TableDataSets;

namespace Pure.RelationalSchema.Storage.Samples.Tests.SchemaDataSets;

public sealed record SchemaDataSetWithCompositeForeignKeyTests
{
    [Fact]
    public void SchemaIsRelationalSchemaWithCompositeForeignKey()
    {
        IStoredSchemaDataSet dataSet = new SchemaDataSetWithCompositeForeignKey();

        Assert.True(
            new SchemaHash(dataSet.Schema).SequenceEqual(
                new SchemaHash(new RelationalSchemaWithCompositeForeignKey())
            )
        );
    }

    [Fact]
    public void CountIs2()
    {
        IStoredSchemaDataSet dataSet = new SchemaDataSetWithCompositeForeignKey();

        Assert.Equal(2, dataSet.Count);
    }

    [Fact]
    public void ContainsKeyOrdersTable()
    {
        IStoredSchemaDataSet dataSet = new SchemaDataSetWithCompositeForeignKey();

        Assert.True(dataSet.ContainsKey(new OrdersTable()));
    }

    [Fact]
    public void ContainsKeyOrderItemsTable()
    {
        IStoredSchemaDataSet dataSet = new SchemaDataSetWithCompositeForeignKey();

        Assert.True(dataSet.ContainsKey(new OrderItemsTable()));
    }

    [Fact]
    public void KeysContainsOrdersTable()
    {
        IStoredSchemaDataSet dataSet = new SchemaDataSetWithCompositeForeignKey();

        Assert.Contains(
            dataSet.Keys,
            table => new TableHash(table).SequenceEqual(new TableHash(new OrdersTable()))
        );
    }

    [Fact]
    public void ValuesContainsOrdersTableDataSet()
    {
        IStoredSchemaDataSet dataSet = new SchemaDataSetWithCompositeForeignKey();

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
        IStoredSchemaDataSet dataSet = new SchemaDataSetWithCompositeForeignKey();

        Assert.True(
            new StoredTableDataSetHash(dataSet[new OrdersTable()]).SequenceEqual(
                new StoredTableDataSetHash(new OrdersTableDataSet())
            )
        );
    }

    [Fact]
    public void IndexerReturnsOrderItemsTableDataSet()
    {
        IStoredSchemaDataSet dataSet = new SchemaDataSetWithCompositeForeignKey();

        Assert.True(
            new StoredTableDataSetHash(dataSet[new OrderItemsTable()]).SequenceEqual(
                new StoredTableDataSetHash(new OrderItemsTableDataSet())
            )
        );
    }

    [Fact]
    public void TryGetValueReturnsTrueForOrdersTable()
    {
        IStoredSchemaDataSet dataSet = new SchemaDataSetWithCompositeForeignKey();

        Assert.True(dataSet.TryGetValue(new OrdersTable(), out _));
    }

    [Fact]
    public void TryGetValueReturnsFalseForUnknownTable()
    {
        IStoredSchemaDataSet dataSet = new SchemaDataSetWithCompositeForeignKey();

        Assert.False(dataSet.TryGetValue(new EmptyNameTable(), out _));
    }

    [Fact]
    public void GenericEnumeratorEnumeratesTwoEntries()
    {
        IStoredSchemaDataSet dataSet = new SchemaDataSetWithCompositeForeignKey();

        Assert.Equal(2, dataSet.Count);
    }

    [Fact]
    public void NonGenericEnumeratorEnumeratesTwoEntries()
    {
        IStoredSchemaDataSet dataSet = new SchemaDataSetWithCompositeForeignKey();

        IEnumerator enumerator = ((IEnumerable)dataSet).GetEnumerator();

        int count = 0;
        while (enumerator.MoveNext())
        {
            count++;
        }

        Assert.Equal(2, count);
    }
}
