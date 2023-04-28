using System;

using R5T.T0178;
using R5T.T0179;


namespace R5T.L0037
{
    /// <inheritdoc cref="IX"/>
    [StrongTypeImplementationMarker]
    public class X : TypedBase<string>, IStrongTypeMarker,
        IX
    {
        public X(string value)
            : base(value)
        {
        }
    }
}
