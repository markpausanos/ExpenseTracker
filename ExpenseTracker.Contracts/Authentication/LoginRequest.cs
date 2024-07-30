namespace ExpenseTracker.Application.Authentication
{
    public record LoginRequest(
        string Email,
        string Password
    );
}