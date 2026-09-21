using System.Collections;
using Pure.RelationalSchema.HashCodes;
using Pure.RelationalSchema.Samples.Schemas;
using Pure.RelationalSchema.Samples.Tables;
using Pure.RelationalSchema.Storage.Abstractions;
using Pure.RelationalSchema.Storage.HashCodes;
using Pure.RelationalSchema.Storage.Samples.SchemaDataSets;
using Pure.RelationalSchema.Storage.Samples.TableDataSets;

namespace Pure.RelationalSchema.Storage.Samples.Tests.SchemaDataSets;

public sealed record SchemaDataSetWithSelfReferencingTableTests
{
    [Fact]
    public void SchemaIsRelationalSchemaWithSelfReferencingTable()
    {
        IStoredSchemaDataSet dataSet = new SchemaDataSetWithSelfReferencingTable();

        Assert.True(
            new SchemaHash(dataSet.Schema).SequenceEqual(
                new SchemaHash(new RelationalSchemaWithSelfReferencingTable())
            )
        );
    }

    [Fact]
    public void CountIs1()
    {
        IStoredSchemaDataSet dataSet = new SchemaDataSetWithSelfReferencingTable();

        _ = Assert.Single(dataSet);

        int count = dataSet.Count;

        Assert.Equal(1, count);
    }

    [Fact]
    public void ContainsKeyEmployeesTable()
    {
        IStoredSchemaDataSet dataSet = new SchemaDataSetWithSelfReferencingTable();

        Assert.True(dataSet.ContainsKey(new EmployeesTable()));
    }

    [Fact]
    public void KeysContainsEmployeesTable()
    {
        IStoredSchemaDataSet dataSet = new SchemaDataSetWithSelfReferencingTable();

        Assert.Contains(
            dataSet.Keys,
            table =>
                new TableHash(table).SequenceEqual(new TableHash(new EmployeesTable()))
        );
    }

    [Fact]
    public void ValuesContainsEmployeesTableDataSet()
    {
        IStoredSchemaDataSet dataSet = new SchemaDataSetWithSelfReferencingTable();

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
        IStoredSchemaDataSet dataSet = new SchemaDataSetWithSelfReferencingTable();

        Assert.True(
            new StoredTableDataSetHash(dataSet[new EmployeesTable()]).SequenceEqual(
                new StoredTableDataSetHash(new EmployeesTableDataSet())
            )
        );
    }

    [Fact]
    public void TryGetValueReturnsTrueForEmployeesTable()
    {
        IStoredSchemaDataSet dataSet = new SchemaDataSetWithSelfReferencingTable();

        Assert.True(dataSet.TryGetValue(new EmployeesTable(), out _));
    }

    [Fact]
    public void TryGetValueReturnsFalseForUnknownTable()
    {
        IStoredSchemaDataSet dataSet = new SchemaDataSetWithSelfReferencingTable();

        Assert.False(dataSet.TryGetValue(new EmptyNameTable(), out _));
    }

    [Fact]
    public void GenericEnumeratorEnumeratesOneEntry()
    {
        IStoredSchemaDataSet dataSet = new SchemaDataSetWithSelfReferencingTable();

        _ = Assert.Single(dataSet);
    }

    [Fact]
    public void NonGenericEnumeratorEnumeratesOneEntry()
    {
        IStoredSchemaDataSet dataSet = new SchemaDataSetWithSelfReferencingTable();

        IEnumerator enumerator = ((IEnumerable)dataSet).GetEnumerator();

        Assert.True(enumerator.MoveNext());
        Assert.False(enumerator.MoveNext());
    }
}
