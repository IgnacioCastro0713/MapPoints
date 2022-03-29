using Microsoft.AspNetCore.Authorization;

namespace API.Core.Attributes;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
public class AllowAnonymousAttribute : Attribute, IAllowAnonymous
{
}