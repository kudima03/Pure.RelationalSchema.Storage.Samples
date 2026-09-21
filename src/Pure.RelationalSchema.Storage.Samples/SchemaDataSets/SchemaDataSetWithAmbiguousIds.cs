using System.Collections;
using System.Diagnostics.CodeAnalysis;
using Pure.Collections.Generic;
using Pure.RelationalSchema.Abstractions.Schema;
using Pure.RelationalSchema.Abstractions.Table;
using Pure.RelationalSchema.HashCodes;
using Pure.RelationalSchema.Samples.Schemas;
using Pure.RelationalSchema.Samples.Tables;
using Pure.RelationalSchema.Storage.Abstractions;
using Pure.RelationalSchema.Storage.Samples.TableDataSets;

namespace Pure.RelationalSchema.Storage.Samples.SchemaDataSets;

// Both relations carry columns literally named `id` and `name`, so a field
// reference across them only resolves once it is entity-qualified. This is the
// counterpart of SchemaDataSetWithForeignKeys, whose names are all unique.
public sealed record SchemaDataSetWithAmbiguousIds : IStoredSchemaDataSet
{
    public ISchema Schema => new RelationalSchemaWithIndexes();

    private static IReadOnlyDictionary<ITable, IStoredTableDataSet> TablesDataSets =>
        new Dictionary<
            KeyValuePair<ITable, IStoredTableDataSet>,
            ITable,
            IStoredTableDataSet
        >(
            [
                new KeyValuePair<ITable, IStoredTableDataSet>(
                    new TableWithSingleIndex(),
                    new AmbiguousIdLookupTableDataSet()
                ),
                new KeyValuePair<ITable, IStoredTableDataSet>(
                    new TableWithIndexes(),
                    new AmbiguousIdTableDataSet()
                ),
            ],
            pair => pair.Key,
            pair => pair.Value,
            table => new TableHash(table)
        );

    public IEnumerable<ITable> Keys => TablesDataSets.Keys;

    public IEnumerable<IStoredTableDataSet> Values => TablesDataSets.Values;

    public int Count => TablesDataSets.Count;

    public IStoredTableDataSet this[ITable key] => TablesDataSets[key];

    public bool ContainsKey(ITable key)
    {
        return TablesDataSets.ContainsKey(key);
    }

    public bool TryGetValue(
        ITable key,
        [MaybeNullWhen(false)] out IStoredTableDataSet value
    )
    {
        return TablesDataSets.TryGetValue(key, out value);
    }

    public IEnumerator<KeyValuePair<ITable, IStoredTableDataSet>> GetEnumerator()
    {
        return TablesDataSets.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
