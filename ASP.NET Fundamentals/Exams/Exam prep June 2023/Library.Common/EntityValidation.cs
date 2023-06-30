namespace Library.Common
{
    public class EntityValidation
    {
        public static class BookEntity
        {
            public const int TitleMinLength = 10;
            public const int TitleMaxLength = 50;

            public const int AuthorMinLength = 5;
            public const int AuthorMaxLength = 50;

            public const int DescriptionMinLength = 5;
            public const int DescriptionMaxLength = 5000;
        }
        public static class CategoryEntity
        {
            public const int NameMinLength = 5;
            public const int NameMaxLength = 50;
        }
    }
}