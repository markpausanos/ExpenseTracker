using ExpenseTracker.Application.Common.Interfaces.Authentication;

namespace ExpenseTracker.Application.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IJWTTokenGenerator _jwtTokenGenerator;

        public AuthenticationService(IJWTTokenGenerator jwtTokenGenerator)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public AuthenticationResult Login(string email, string password)
        {
            Guid guid = Guid.NewGuid();

            var firstNameDummy = "John";
            var lastNameDummy = "Doe";

            var token = _jwtTokenGenerator.GenerateToken(guid, firstNameDummy, lastNameDummy);

            return new AuthenticationResult(guid, "John", "Doe", email, token);
        }

        public AuthenticationResult Register(string firstName, string lastName, string email, string password)
        {
           var token = _jwtTokenGenerator.GenerateToken(Guid.NewGuid(), firstName, lastName);

            return new AuthenticationResult(
                Guid.NewGuid(), 
                firstName, 
                lastName, 
                email, 
                token
            );
        }
    }
}
