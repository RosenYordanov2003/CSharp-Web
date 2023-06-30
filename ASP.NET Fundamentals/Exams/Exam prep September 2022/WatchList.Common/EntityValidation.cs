namespace WatchList.Common
{
    public static class EntityValidation
    {
        public static class GenreEntity
        {
            public const int GenreMinLenght = 5;
            public const int GenreMaxLenght = 50;
        }
        public static class MovieEntity
        {
            public const int MovieTitleMinLength = 10;
            public const int MovieTitleMaxLength = 50;

            public const int MovieDirectorNameMinLength = 5;
            public const int MovieDirectorNameMaxLength = 50;

            public const string MovieRatingMinValue = "0.00";
            public const string MovieRatingMaxValue = "10.00";
        }
        public static class UserEntity
        {
            public const int UsernameMinLength = 5;
            public const int UsernameMaxLength = 20;

            public const int UserEmailMinLength = 10;
            public const int UserEmailMaxLength = 60;

            public const int UserPasswordMinLength = 5;
            public const int UserPasswordMaxLength = 20;
        }
    }
}