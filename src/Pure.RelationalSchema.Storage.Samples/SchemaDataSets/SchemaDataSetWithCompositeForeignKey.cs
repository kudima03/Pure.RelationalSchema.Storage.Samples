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

public sealed record SchemaDataSetWithCompositeForeignKey : IStoredSchemaDataSet
{
    public ISchema Schema => new RelationalSchemaWithCompositeForeignKey();

    private static IReadOnlyDictionary<ITable, IStoredTableDataSet> TablesDataSets =>
        new Dictionary<
            KeyValuePair<ITable, IStoredTableDataSet>,
            ITable,
            IStoredTableDataSet
        >(
            [
                new KeyValuePair<ITable, IStoredTableDataSet>(
                    new OrdersTable(),
                    new OrdersTableDataSet()
                ),
                new KeyValuePair<ITable, IStoredTableDataSet>(
                    new OrderItemsTable(),
                    new OrderItemsTableDataSet()
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
