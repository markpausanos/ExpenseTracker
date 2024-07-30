namespace ExpenseTracker.Infrastructure.Authentication
{
    public class JWTSettings
    {
        public const string SectionName = "JWTSettings";
        public string Secret { get; set; } = null!;
        public string Issuer { get; set; } = null!;
        public string Audience { get; set; } = null!;
        public int ExpiryInMinutes { get; set; }
    }
}
