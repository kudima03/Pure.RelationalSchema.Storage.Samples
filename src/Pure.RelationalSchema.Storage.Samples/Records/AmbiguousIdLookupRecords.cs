using System.Collections;

namespace Pure.RelationalSchema.Storage.Samples.Records;

// The four rows of AmbiguousIdLookupTableDataSet, as plain .NET values.
public sealed record AmbiguousIdLookupRecords : IEnumerable<AmbiguousIdLookupRecord>
{
    private static IEnumerable<AmbiguousIdLookupRecord> Records =>
        [
            new AmbiguousIdLookupRecord(
                new Guid("000001f5-0000-0000-0000-000000000000"),
                "Welder"
            ),
            new AmbiguousIdLookupRecord(
                new Guid("000001f6-0000-0000-0000-000000000000"),
                "Fitter"
            ),
            new AmbiguousIdLookupRecord(
                new Guid("000001f7-0000-0000-0000-000000000000"),
                "Painter"
            ),
            new AmbiguousIdLookupRecord(
                new Guid("000001f8-0000-0000-0000-000000000000"),
                "Rigger"
            ),
        ];

    public IEnumerator<AmbiguousIdLookupRecord> GetEnumerator()
    {
        return Records.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
