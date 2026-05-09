using Common.Dto;
using Repository.Entities;
using System.Security.Claims;

namespace myProject_trips.Extensions
{
    public static class IdentityExtensions
    {
        public static int GetUserId(this ClaimsPrincipal user)
        {
            var idClaim = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return int.TryParse(idClaim, out var id) ? id : 0;
        }

        public static string GetUserRole(this ClaimsPrincipal user)
        {
            return user.FindFirst(ClaimTypes.Role)?.Value;
        }

        public static UserDto GetUserDetails(this ClaimsPrincipal user)
        {
            if (!user.Identity.IsAuthenticated) return null;

            return new UserDto()
            {
                UserId = user.GetUserId(),
                UserName = user.FindFirst(ClaimTypes.NameIdentifier)?.Value,
                UserPhoneNumber = user.FindFirst(ClaimTypes.MobilePhone)?.Value,
                UserEmail = user.FindFirst(ClaimTypes.Email)?.Value,
                Role = Enum.TryParse<UserRoleEnum>(user.GetUserRole(), out var r) 
                    ? r.ToString() 
                    : UserRoleEnum.User.ToString()

            };
        }
    }
}
