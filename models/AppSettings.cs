namespace models
{
    public static class AppSettings
    {
        // ConnectionStrings section in appsettings.json
        public const string CONNECTION_STRINGS_SECTION_KEY = "ConnectionStrings";
        public const string MSSQL_KEY = "mssql";

        // Authorization section in appsettings.json
        public const string AUTHORIZATION_SECTION = "Authorization";
        public const string AUTHORIZATION_SECRET_KEY = "secretKey";
        public const string AUTHORIZATION_JWT_ISSUER_KEY = "issuer";
        public const string AUTHORIZATION_JWT_AUDIENCE_KEY = "audience";

        // appsettings.json values
        public static string ConnectionString { get; set; }
        public static string AuthorizationSecretKey { get; set; }
        public static string AuthorizationIssuer { get; set; }
        public static string AuthorizationAudience { get; set; }
    }
}