using System;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using R5T.T0132;
using R5T.T0159;
using R5T.T0175;
using R5T.T0175.Extensions;
using R5T.T0192;


namespace R5T.L0038
{
    [FunctionalityMarker]
    public partial interface IApplicationContextOperator : IFunctionalityMarker
    {
        /// <summary>
        /// Copies <see cref="IApplicationContext"/> information 
        /// This is useful in constructing types that inherit from <see cref="ApplicationContext"/> and contain more information from instances of <see cref="IApplicationContext"/>.
        /// </summary>
        public void Copy_To(IApplicationContext source, ApplicationContext destination)
        {
            destination.ApplicationName = source.ApplicationName;
            destination.LocalRunSpecificDirectoryPath = source.LocalRunSpecificDirectoryPath;
            destination.Start = source.Start;
            destination.TextOutput = source.TextOutput;
        }

        public ITimestamp Get_Start()
        {
            var start = Instances.NowOperator.GetNow().ToTimestamp();
            return start;
        }

        public (IApplicationContext applicationContext, string humanOutputTextFilePath, string logFilePath) Get_ApplicationContext(IApplicationName applicationName)
        {
            var start = this.Get_Start();

            return this.Get_ApplicationContext(
                applicationName,
                start);
        }

        public (IApplicationContext applicationContext, string humanOutputTextFilePath, string logFilePath) Get_ApplicationContext(
            IApplicationName applicationName,
            ITimestamp start)
        {
            var localRunSpecificDirectoryPath = Instances.DirectoryPathOperator.Get_LocalRunSpecificDirectoryPath(
                applicationName,
                start);

            var (humanOutputTextFilePath, logFilePath) = this.Get_TextOutputFilePaths(localRunSpecificDirectoryPath);

            var textOutput = Instances.TextOutputOperator.Get_TextOutput(
                humanOutputTextFilePath,
                applicationName.Value,
                logFilePath);

            var output = new ApplicationContext
            {
                ApplicationName = applicationName,
                Start = start,
                TextOutput = textOutput,
                LocalRunSpecificDirectoryPath = localRunSpecificDirectoryPath,
            };

            return (output, humanOutputTextFilePath, logFilePath);
        }

        public (string humanOutputTextFilePath, string logFilePath) Get_TextOutputFilePaths(ILocalRunSpecificDirectoryPath localRunSpecificDirectoryPath)
        {
            var humanOutputTextFilePath = Instances.PathOperator.GetFilePath(localRunSpecificDirectoryPath.Value, "Human Output.txt");
            var logFilePath = Instances.PathOperator.GetFilePath(localRunSpecificDirectoryPath.Value, "Log.txt");

            return (humanOutputTextFilePath, logFilePath);
        }

        public async Task<(string humanOutputTextFilePath, string logFilePath)> In_ApplicationContext(
            IApplicationName applicationName,
            Func<IApplicationContext, Task> action)
        {
            var (applicationContext, humanOutputTextFilePath, logFilePath) = this.Get_ApplicationContext(applicationName);

            await action(applicationContext);

            if(applicationContext.TextOutput.Logger is IDisposable disposableLogger)
            {
                disposableLogger.Dispose();
            }

            return (humanOutputTextFilePath, logFilePath);
        }

        /// <summary>
        /// Gets an application context, only considering the application name and not its start time.
        /// </summary>
        public async Task<(string humanOutputTextFilePath, string logFilePath)> In_ApplicationContext_Undated(
            IApplicationName applicationName,
            Func<IApplicationContext, Task> action)
        {
            var start = Instances.Timestamps.Undated;

            var (applicationContext, humanOutputTextFilePath, logFilePath) = this.Get_ApplicationContext(
                applicationName,
                start);

            await action(applicationContext);

            if (applicationContext.TextOutput.Logger is IDisposable disposableLogger)
            {
                disposableLogger.Dispose();
            }

            return (humanOutputTextFilePath, logFilePath);
        }
    }
}
