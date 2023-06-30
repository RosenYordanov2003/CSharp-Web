namespace TaskBoardCommon
{
    public static class EntityValidation
    {
        public static class TaskEntity
        {
            public const int TitleMinLength = 5;
            public const int TitleMaxLength = 70;
            public const int DescriptionMinLength = 10;
            public const int DescriptionMaxLength = 1000;
        }
        public static class BoardEntity
        {
            public const int NameMinLength = 3;
            public const int NameMaxLength = 30;
        }
    }
}
