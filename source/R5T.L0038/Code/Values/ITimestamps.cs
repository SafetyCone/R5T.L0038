using System;

using R5T.T0131;
using R5T.T0175;
using R5T.T0175.Extensions;


namespace R5T.L0038
{
    [ValuesMarker]
    public partial interface ITimestamps : IValuesMarker
    {
        public ITimestamp Undated => Instances.DateTimeOperator.Get_Zero().ToTimestamp();
    }
}
