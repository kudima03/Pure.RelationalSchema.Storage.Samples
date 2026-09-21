using System.Collections;
using System.Diagnostics.CodeAnalysis;
using Pure.Collections.Generic;
using Pure.RelationalSchema.Abstractions.Schema;
using Pure.RelationalSchema.Abstractions.Table;
using Pure.RelationalSchema.HashCodes;
using Pure.RelationalSchema.Storage.Abstractions;

namespace Pure.RelationalSchema.Storage.Samples.SchemaDataSets;

// The one schema data set in this catalogue that is not a named singleton: it
// pairs any schema with any table data sets, keyed by the table schema each one
// carries. Consumers need it for shapes no named sample can express - two data
// sets sharing a schema name, a schema holding a subset of its own tables.
public sealed record StoredSchemaDataSet : IStoredSchemaDataSet
{
    private readonly IReadOnlyDictionary<ITable, IStoredTableDataSet> _tablesDataSets;

    public StoredSchemaDataSet(
        ISchema schema,
        IEnumerable<IStoredTableDataSet> tablesDataSets
    )
    {
        Schema = schema;
        _tablesDataSets = new Dictionary<
            IStoredTableDataSet,
            ITable,
            IStoredTableDataSet
        >(
            [.. tablesDataSets],
            dataSet => dataSet.TableSchema,
            dataSet => dataSet,
            table => new TableHash(table)
        );
    }

    public ISchema Schema { get; }

    public IEnumerable<ITable> Keys => _tablesDataSets.Keys;

    public IEnumerable<IStoredTableDataSet> Values => _tablesDataSets.Values;

    public int Count => _tablesDataSets.Count;

    public IStoredTableDataSet this[ITable key] => _tablesDataSets[key];

    public bool ContainsKey(ITable key)
    {
        return _tablesDataSets.ContainsKey(key);
    }

    public bool TryGetValue(
        ITable key,
        [MaybeNullWhen(false)] out IStoredTableDataSet value
    )
    {
        return _tablesDataSets.TryGetValue(key, out value);
    }

    public IEnumerator<KeyValuePair<ITable, IStoredTableDataSet>> GetEnumerator()
    {
        return _tablesDataSets.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
