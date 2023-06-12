namespace Contacts.Common
{
    public class EntityValidation
    {
        public static class ApplicationUserEntity
        {
            public const int UserNameMinLength = 5;
            public const int UserNameMaxLength = 20;

            public const int EmailMinLength = 10;
            public const int EmailMaxLength = 60;

            public const int PasswordMinLength = 5;
            public const int PasswordMaxLength = 20;
        }
        public static class ContactEntity
        {
            public const int FirstNameMinLength = 2;
            public const int FirstNameMaxLength = 50;

            public const int LastNameMinLength = 5;
            public const int LastNameMaxLength = 50;

            public const int EmailMinLength = 10;
            public const int EmailMaxLength = 60;

            public const int PhoneNumberMinLength = 10;
            public const int PhoneNumberMaxLength = 13;
            public const string PhoneNumberRegex = @"^(\+359|0)(\-| |)\d{3}\2\d{2}\2\d{2}\2\d{2}$";

            public const string WebSiteRegex = @"^(www\.)[A-Za-z\d -]+\.bg$";
        }
    }
}