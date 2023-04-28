using System;

using R5T.T0178;
using R5T.T0179;


namespace R5T.L0037
{
    /// <summary>
    /// Strongly-types a string as an X.
    /// </summary>
    [StrongTypeMarker]
    public interface IX : IStrongTypeMarker,
        ITyped<string>
    {
    }
}
