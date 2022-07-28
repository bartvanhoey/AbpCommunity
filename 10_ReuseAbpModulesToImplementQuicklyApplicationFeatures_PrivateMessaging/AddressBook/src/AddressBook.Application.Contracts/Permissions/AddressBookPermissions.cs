namespace AddressBook.Permissions
{
    public static class AddressBookPermissions
    {
        public const string GroupName = "AddressBook";

        //Add your own permission names. Example:
        //public const string MyPermission1 = GroupName + ".MyPermission1";

        public class Contact
        {
            public const string Default = GroupName + ".Contact";
            public const string Update = Default + ".Update";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
        }
    }
}
