using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.Authorization;
using System.Linq;

namespace VetTail.Conventions;

public class AuthorizeByDefaultConvention : IActionModelConvention
{
    public void Apply(ActionModel action)
    {
        if (this.ConventionMustApply(action))
        {
            AuthorizationPolicy policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
            action.Filters.Add(new AuthorizeFilter(policy));
        }

    }


    private bool ConventionMustApply(ActionModel action)
    {
        return !action.Attributes.Any(attribute => attribute.GetType().Equals(typeof(AuthorizeAttribute))) 
            && !action.Attributes.Any(attribute => attribute.GetType().Equals(typeof(AllowAnonymousAttribute)));
    }
}
