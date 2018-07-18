namespace Focus.Infrastructure
{
    public static class AppSetting
    {
        public const string AuthUrl = "http://localhost:5001";
        public const string ApiUrl  = "http://localhost:5002";
        public const string WebUrl  = "http://localhost:5003";

        public const string SqlConnectionString = "Server = (localdb)\\MSSQLLocalDB; Database = FocusDb; Trusted_Connection = True";
        //public const string SqlConnectionString = "Server=.;Database=FocusDb;Trusted_Connection=True";

        public const string DisplayName = "Focus管理系统";
        public const string ClientSecret = "Focus.Secret";
        public const string ApiName = "Focus.Api";
    }
}
