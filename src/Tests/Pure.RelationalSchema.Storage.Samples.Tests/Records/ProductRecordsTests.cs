using System.Collections;
using Pure.RelationalSchema.Samples.Columns;
using Pure.RelationalSchema.Storage.Abstractions;
using Pure.RelationalSchema.Storage.Samples.Cells;
using Pure.RelationalSchema.Storage.Samples.Records;
using Pure.RelationalSchema.Storage.Samples.TableDataSets;

namespace Pure.RelationalSchema.Storage.Samples.Tests.Records;

public sealed record ProductRecordsTests
{
    [Fact]
    public void CountIs4()
    {
        Assert.Equal(4, new ProductRecords().Count());
    }

    [Fact]
    public void MirrorsRowCount()
    {
        Assert.Equal(new ProductsTableDataSet().Count(), new ProductRecords().Count());
    }

    [Fact]
    public void NonGenericEnumeratorEnumeratesEveryRecord()
    {
        IEnumerator enumerator = ((IEnumerable)new ProductRecords()).GetEnumerator();

        int count = 0;
        while (enumerator.MoveNext())
        {
            _ = Assert.IsType<ProductRecord>(enumerator.Current);
            count++;
        }

        Assert.Equal(4, count);
    }

    [Fact]
    public void MirrorsProductIdText()
    {
        IRow[] rows = [.. new ProductsTableDataSet()];
        ProductRecord[] records = [.. new ProductRecords()];

        Assert.Equal(
            records.Select(record => new InvariantCellText(record.ProductId).TextValue),
            rows.Select(row => row.Cells[new ProductIdColumn()].Value.TextValue)
        );
    }

    [Fact]
    public void MirrorsProductNameText()
    {
        IRow[] rows = [.. new ProductsTableDataSet()];
        ProductRecord[] records = [.. new ProductRecords()];

        Assert.Equal(
            records.Select(record => new InvariantCellText(record.ProductName).TextValue),
            rows.Select(row => row.Cells[new ProductNameColumn()].Value.TextValue)
        );
    }

    [Fact]
    public void MirrorsProductDescriptionText()
    {
        IRow[] rows = [.. new ProductsTableDataSet()];
        ProductRecord[] records = [.. new ProductRecords()];

        Assert.Equal(
            records.Select(record =>
                new InvariantCellText(record.ProductDescription).TextValue
            ),
            rows.Select(row => row.Cells[new ProductDescriptionColumn()].Value.TextValue)
        );
    }

    [Fact]
    public void MirrorsProductPriceText()
    {
        IRow[] rows = [.. new ProductsTableDataSet()];
        ProductRecord[] records = [.. new ProductRecords()];

        Assert.Equal(
            records.Select(record =>
                new InvariantCellText(record.ProductPrice).TextValue
            ),
            rows.Select(row => row.Cells[new ProductPriceColumn()].Value.TextValue)
        );
    }

    [Fact]
    public void MirrorsProductInStockText()
    {
        IRow[] rows = [.. new ProductsTableDataSet()];
        ProductRecord[] records = [.. new ProductRecords()];

        Assert.Equal(
            records.Select(record =>
                new InvariantCellText(record.ProductInStock).TextValue
            ),
            rows.Select(row => row.Cells[new ProductInStockColumn()].Value.TextValue)
        );
    }
}
