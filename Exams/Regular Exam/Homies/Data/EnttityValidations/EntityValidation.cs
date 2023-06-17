namespace Homies.Data.EnttityValidations
{
    public static class EntityValidation
    {
        public class EventEntity
        {
            public const int NameMinLength = 5;
            public const int NameMaxLength = 20;

            public const int DescriptionMinLength = 15;
            public const int DescriptionMaxLength = 150;
        }
        public class TypeEntity
        {
            public const int NameMinLength = 5;
            public const int NameMaxLength = 15;
        }
    }
}
