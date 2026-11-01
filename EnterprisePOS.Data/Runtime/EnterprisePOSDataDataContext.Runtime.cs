namespace EnterprisePOS.Data
{
    public partial class EnterprisePOSDataDataContext
    {
        partial void OnCreated()
        {
            string connectionString =
                Runtime.RuntimeConnectionStringProvider.GetOrDefault();

            if (Connection != null &&
                !string.IsNullOrWhiteSpace(connectionString) &&
                Connection.ConnectionString != connectionString)
            {
                Connection.ConnectionString = connectionString;
            }
        }
    }
}
