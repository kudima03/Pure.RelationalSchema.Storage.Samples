using System.Collections;

namespace Pure.RelationalSchema.Storage.Samples.Records;

// The four products of ProductsTableDataSet, as plain .NET values.
public sealed record ProductRecords : IEnumerable<ProductRecord>
{
    private static IEnumerable<ProductRecord> Records =>
        [
            new ProductRecord(
                new Guid("000000c9-0000-0000-0000-000000000000"),
                "Widget",
                "Basic widget",
                9.99,
                true
            ),
            new ProductRecord(
                new Guid("000000ca-0000-0000-0000-000000000000"),
                "Gadget",
                "Premium gadget",
                19.99,
                false
            ),
            new ProductRecord(
                new Guid("000000cb-0000-0000-0000-000000000000"),
                "Gizmo",
                "Compact gizmo",
                4.50,
                true
            ),
            new ProductRecord(
                new Guid("000000cc-0000-0000-0000-000000000000"),
                "Deluxe",
                "Deluxe bundle",
                250,
                true
            ),
        ];

    public IEnumerator<ProductRecord> GetEnumerator()
    {
        return Records.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
