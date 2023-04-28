using System;


namespace R5T.L0038
{
    public class ApplicationContextOperator : IApplicationContextOperator
    {
        #region Infrastructure

        public static IApplicationContextOperator Instance { get; } = new ApplicationContextOperator();


        private ApplicationContextOperator()
        {
        }

        #endregion
    }
}
