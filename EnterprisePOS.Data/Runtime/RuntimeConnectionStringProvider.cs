using System;

namespace EnterprisePOS.Data.Runtime
{
    public static class RuntimeConnectionStringProvider
    {
        private static readonly object SyncLock = new object();

        private static string _runtimeConnectionString;

        public static void Set(string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
                throw new ArgumentException(
                    "Connection string is required.",
                    nameof(connectionString));

            lock (SyncLock)
            {
                _runtimeConnectionString = connectionString;
            }
        }

        public static string GetOrDefault()
        {
            lock (SyncLock)
            {
                return string.IsNullOrWhiteSpace(_runtimeConnectionString)
                    ? Properties.Settings.Default.EnterprisePOSConnectionString
                    : _runtimeConnectionString;
            }
        }
    }
}
