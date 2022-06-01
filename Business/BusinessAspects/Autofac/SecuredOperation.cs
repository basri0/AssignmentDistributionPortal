using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Core.Extensions.Concrete;

namespace Business.BusinessAspects.Autofac
{
    public class SecuredOperation : MethodInterception
    {
        private string[] Roles { get; }
        private IHttpContextAccessor HttpContextAccessor { get; }
        public SecuredOperation(string roles)
        {
            Roles = roles.ToLower().Trim().Split(',');
            HttpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
        }

        protected override void OnBefore(IInvocation invocation)
        {
            var claims = HttpContextAccessor.HttpContext.User.ClaimRoles();
            foreach (var role in Roles)
            {
                if (claims.Contains(role))
                {
                    return;
                }
            }
            throw new Exception("Yetkiniz yok!");
        }
    }
}
