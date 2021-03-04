using Microsoft.AspNetCore.Authorization;

namespace testcase.API.Models
{
    public class Policies
    {
        public const string User = "User";
        public static AuthorizationPolicy UserPolicy()
        {
            return new AuthorizationPolicyBuilder().RequireAuthenticatedUser().RequireRole(User).Build();
        }
    }
}
