using System;


namespace R5T.L0038
{
    public class Timestamps : ITimestamps
    {
        #region Infrastructure

        public static ITimestamps Instance { get; } = new Timestamps();


        private Timestamps()
        {
        }

        #endregion
    }
}
