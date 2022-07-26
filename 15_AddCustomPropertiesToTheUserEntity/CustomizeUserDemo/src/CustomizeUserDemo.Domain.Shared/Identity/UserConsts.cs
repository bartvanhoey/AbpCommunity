using System;

namespace CustomizeUserDemo.Domain.Shared.Identity
{
    public static class UserConsts
    {
        public const string TitlePropertyName = "Title";
        public const string ReputationPropertyName = "Reputation";
        public const int MaxTitleLength = 64;
        public const double MaxReputationValue = 1_000;
        public const double MinReputationValue = 1;
    }
}
