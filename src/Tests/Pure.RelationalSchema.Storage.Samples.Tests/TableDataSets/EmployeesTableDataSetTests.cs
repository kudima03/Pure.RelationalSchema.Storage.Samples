using System.Collections;
using Pure.RelationalSchema.HashCodes;
using Pure.RelationalSchema.Samples.Tables;
using Pure.RelationalSchema.Storage.Abstractions;
using Pure.RelationalSchema.Storage.HashCodes;
using Pure.RelationalSchema.Storage.Samples.Rows;
using Pure.RelationalSchema.Storage.Samples.TableDataSets;

namespace Pure.RelationalSchema.Storage.Samples.Tests.TableDataSets;

public sealed record EmployeesTableDataSetTests
{
    [Fact]
    public void TableSchemaIsEmployeesTable()
    {
        IStoredTableDataSet dataSet = new EmployeesTableDataSet();

        Assert.True(
            new TableHash(dataSet.TableSchema).SequenceEqual(
                new TableHash(new EmployeesTable())
            )
        );
    }

    [Fact]
    public void RowsCountIs1()
    {
        IStoredTableDataSet dataSet = new EmployeesTableDataSet();

        _ = Assert.Single((IEnumerable<IRow>)dataSet);
    }

    [Fact]
    public void ContainsEmployeeRow()
    {
        IStoredTableDataSet dataSet = new EmployeesTableDataSet();

        Assert.Contains(
            (IEnumerable<IRow>)dataSet,
            row => new RowHash(row).SequenceEqual(new RowHash(new EmployeeRow()))
        );
    }

    [Fact]
    public void ElementTypeIsRowInterface()
    {
        IStoredTableDataSet dataSet = new EmployeesTableDataSet();

        Assert.Equal(typeof(IRow), dataSet.ElementType);
    }

    [Fact]
    public void ExpressionIsNotNull()
    {
        IStoredTableDataSet dataSet = new EmployeesTableDataSet();

        Assert.NotNull(dataSet.Expression);
    }

    [Fact]
    public void ProviderExecutesQuery()
    {
        IStoredTableDataSet dataSet = new EmployeesTableDataSet();

        Assert.NotNull(dataSet.Provider);
        _ = Assert.Single(dataSet.ToArray());
    }

    [Fact]
    public void NonGenericEnumeratorEnumeratesOneRow()
    {
        IStoredTableDataSet dataSet = new EmployeesTableDataSet();

        IEnumerator enumerator = ((IEnumerable)dataSet).GetEnumerator();

        Assert.True(enumerator.MoveNext());
        Assert.False(enumerator.MoveNext());
    }

    [Fact]
    public async Task AsyncEnumerationYieldsOneRow()
    {
        IStoredTableDataSet dataSet = new EmployeesTableDataSet();

        List<IRow> rows = [];

        await foreach (IRow row in dataSet)
        {
            rows.Add(row);
        }

        _ = Assert.Single(rows);
    }
}
