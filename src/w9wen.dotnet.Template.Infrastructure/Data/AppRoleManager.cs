using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using w9wen.dotnet.Template.Core.Entities;

namespace w9wen.dotnet.Template.Infrastructure.Data
{
  public class AppRoleManager : RoleManager<AppRoleEntity>
  {
    private readonly AppUserManager _appUserManager;

    public AppRoleManager(IRoleStore<AppRoleEntity> store,
                          IEnumerable<IRoleValidator<AppRoleEntity>> roleValidators,
                          ILookupNormalizer keyNormalizer,
                          IdentityErrorDescriber errors,
                          ILogger<RoleManager<AppRoleEntity>> logger,
                          AppUserManager appUserManager) : base(store,
                                                                roleValidators,
                                                                keyNormalizer,
                                                                errors,
                                                                logger)
    {
      this._appUserManager = appUserManager;
    }

    public override async Task<IdentityResult> CreateAsync(AppRoleEntity role)
    {
      var userName = this._appUserManager.CurrentName ?? "System";
      var now = DateTime.UtcNow;

      role.CreatedUser = userName;
      role.CreatedDateTime = now;
      role.UpdatedUser = userName;
      role.UpdatedDateTime = now;
      role.ValidFlag = true;

      return await base.CreateAsync(role);
    }
  }
}