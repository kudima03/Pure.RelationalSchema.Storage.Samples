using Pure.Primitives.Abstractions.String;
using Pure.RelationalSchema.Storage.Abstractions;
using Guid = Pure.Primitives.Guid.Guid;
using String = Pure.Primitives.String.String;

namespace Pure.RelationalSchema.Storage.Samples.Cells;

public sealed record UuidCell : ICell
{
    public IString Value =>
        new String(new Guid(new System.Guid("1f0c4b2a-9d3e-4c7b-8a15-6e2d0f9b7c43")));
}
