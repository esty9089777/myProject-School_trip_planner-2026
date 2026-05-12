using Microsoft.AspNetCore.Authorization;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Extensions
{
    public class SameAuthorRequirement : IAuthorizationRequirement { }
}
