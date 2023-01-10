namespace models
{
    public static class AppSettings
    {
        public const string CONNECTION_STRINGS_SECTION = "ConnectionStrings";
        public const string MSSQL_DB = "mssql";
        public static string ConnectionString { get; set; }
    }
}