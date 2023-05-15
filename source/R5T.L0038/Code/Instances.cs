using System;


namespace R5T.L0038
{
    public static class Instances
    {
        public static F0000.IDateTimeOperator DateTimeOperator => F0000.DateTimeOperator.Instance;
        public static F0126.IDirectoryPathOperator DirectoryPathOperator => F0126.DirectoryPathOperator.Instance;
        public static F0000.INowOperator NowOperator => F0000.NowOperator.Instance;
        public static F0002.IPathOperator PathOperator => F0002.PathOperator.Instance;
        public static T0159.F000.ITextOutputOperator TextOutputOperator => T0159.F000.TextOutputOperator.Instance;
        public static ITimestamps Timestamps => L0038.Timestamps.Instance;
    }
}