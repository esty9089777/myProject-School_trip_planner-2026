using Microsoft.AspNetCore.Authorization;
using Repository.Interfaces;
using Service.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Service.Authorization
{
    public class OwnershipHandler : AuthorizationHandler<SameAuthorRequirement, IOwnable>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
                                                       SameAuthorRequirement requirement,
                                                       IOwnable resource)
        {
            if (context.User.IsInRole("Admin"))
            {
                context.Succeed(requirement);
                return Task.CompletedTask;
            }

            var userIdClaim = context.User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim != null && int.TryParse(userIdClaim.Value, out int userId))
            {
                if (resource.CreatorId == userId)
                {
                    context.Succeed(requirement);
                }
            }

            return Task.CompletedTask;
        }
    }
}
