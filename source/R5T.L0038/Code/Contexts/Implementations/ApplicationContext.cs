using System;

using R5T.T0137;
using R5T.T0159;
using R5T.T0175;
using R5T.T0192;


namespace R5T.L0038
{
    [ContextImplementationMarker]
    public class ApplicationContext : IContextImplementationMarker,
        IApplicationContext
    {
        public IApplicationName ApplicationName { get; set; }
        public ITimestamp Start { get; set; }

        public ITextOutput TextOutput { get; set; }

        public ILocalRunSpecificDirectoryPath LocalRunSpecificDirectoryPath { get; set; }
    }
}
