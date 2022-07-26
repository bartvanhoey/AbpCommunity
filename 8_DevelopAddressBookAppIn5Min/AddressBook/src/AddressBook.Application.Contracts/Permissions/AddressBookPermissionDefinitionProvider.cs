using AddressBook.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace AddressBook.Permissions;

public class AddressBookPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(AddressBookPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(AddressBookPermissions.MyPermission1, L("Permission:MyPermission1"));

        var contactPermission = myGroup.AddPermission(AddressBookPermissions.Contact.Default, L("Permission:Contact"));
        contactPermission.AddChild(AddressBookPermissions.Contact.Create, L("Permission:Create"));
        contactPermission.AddChild(AddressBookPermissions.Contact.Update, L("Permission:Update"));
        contactPermission.AddChild(AddressBookPermissions.Contact.Delete, L("Permission:Delete"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<AddressBookResource>(name);
    }
}
