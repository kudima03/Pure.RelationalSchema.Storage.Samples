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
    public void RowsCountIs4()
    {
        IStoredTableDataSet dataSet = new EmployeesTableDataSet();

        Assert.Equal(4, dataSet.Count());
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
    public void ContainsSecondEmployeeRow()
    {
        IStoredTableDataSet dataSet = new EmployeesTableDataSet();

        Assert.Contains(
            (IEnumerable<IRow>)dataSet,
            row => new RowHash(row).SequenceEqual(new RowHash(new SecondEmployeeRow()))
        );
    }

    [Fact]
    public void ContainsThirdEmployeeRow()
    {
        IStoredTableDataSet dataSet = new EmployeesTableDataSet();

        Assert.Contains(
            (IEnumerable<IRow>)dataSet,
            row => new RowHash(row).SequenceEqual(new RowHash(new ThirdEmployeeRow()))
        );
    }

    [Fact]
    public void ContainsFourthEmployeeRow()
    {
        IStoredTableDataSet dataSet = new EmployeesTableDataSet();

        Assert.Contains(
            (IEnumerable<IRow>)dataSet,
            row => new RowHash(row).SequenceEqual(new RowHash(new FourthEmployeeRow()))
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
        Assert.Equal(4, dataSet.ToArray().Length);
    }

    [Fact]
    public void NonGenericEnumeratorEnumeratesFourRows()
    {
        IStoredTableDataSet dataSet = new EmployeesTableDataSet();

        IEnumerator enumerator = ((IEnumerable)dataSet).GetEnumerator();

        int count = 0;
        while (enumerator.MoveNext())
        {
            count++;
        }

        Assert.Equal(4, count);
    }

    [Fact]
    public async Task AsyncEnumerationYieldsFourRows()
    {
        IStoredTableDataSet dataSet = new EmployeesTableDataSet();

        List<IRow> rows = [];

        await foreach (IRow row in dataSet)
        {
            rows.Add(row);
        }

        Assert.Equal(4, rows.Count);
    }
}
