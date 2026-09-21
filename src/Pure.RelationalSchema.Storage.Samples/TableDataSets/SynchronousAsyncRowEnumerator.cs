using Pure.RelationalSchema.Storage.Abstractions;

namespace Pure.RelationalSchema.Storage.Samples.TableDataSets;

internal sealed class SynchronousAsyncRowEnumerator(IEnumerator<IRow> enumerator)
    : IAsyncEnumerator<IRow>
{
    private readonly IEnumerator<IRow> _enumerator = enumerator;

    public IRow Current => _enumerator.Current;

    public ValueTask<bool> MoveNextAsync()
    {
        return ValueTask.FromResult(_enumerator.MoveNext());
    }

    public ValueTask DisposeAsync()
    {
        _enumerator.Dispose();
        return ValueTask.CompletedTask;
    }
}
