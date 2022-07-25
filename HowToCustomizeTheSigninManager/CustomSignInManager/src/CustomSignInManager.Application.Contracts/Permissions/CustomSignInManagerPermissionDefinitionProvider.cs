using CustomSignInManager.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace CustomSignInManager.Permissions;

public class CustomSignInManagerPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(CustomSignInManagerPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(CustomSignInManagerPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<CustomSignInManagerResource>(name);
    }
}
