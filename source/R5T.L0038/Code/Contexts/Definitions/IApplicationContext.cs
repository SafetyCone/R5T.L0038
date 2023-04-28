using System;

using R5T.T0137;
using R5T.T0159;
using R5T.T0175;
using R5T.T0192;


namespace R5T.L0038
{
    [ContextDefinitionMarker]
    public interface IApplicationContext : IContextDefinitionMarker
    {
        public IApplicationName ApplicationName { get; }
        public ITimestamp Start { get; }

        public ITextOutput TextOutput { get; }

        public ILocalRunSpecificDirectoryPath LocalRunSpecificDirectoryPath { get; }
    }
}
