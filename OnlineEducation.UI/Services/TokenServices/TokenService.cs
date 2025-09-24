using System.Security.Claims;

namespace OnlineEducation.UI.Services.TokenServices
{
    public class TokenService(IHttpContextAccessor _httpContextAccessor) : ITokenService
    {
        public string GetUserToken => _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "Token").Value;

        public int GetUserId => int.Parse(_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);

        public string GetUserRole => _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Role).Value;

        public string GetUserFullName => _httpContextAccessor.HttpContext.User.FindFirst("fullName").Value;
    }
}
