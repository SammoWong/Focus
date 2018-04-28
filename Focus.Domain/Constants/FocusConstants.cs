using System;
using System.Collections.Generic;
using System.Text;

namespace Focus.Domain.Constants
{
    public static class FocusConstants
    {
        public class Validation
        {
            public class ModelValidator
            {
                public const int MaxAccountNameLength = 20;
                public const int MaxRealNameLength = 20;
                public const int MaxEmailStringLength = 50;
                public const int MinPasswordLength = 6;
                public const int MaxPasswordLength = 20;
            }

            public class EntityValidator
            {
                public const int GeneralStringLength = 50;
                public const int GeneralLongerStringLength = 128;
                public const int GeneralLongestStringLength = 256;
                public const int GeneralEntityNameLength = 50;
                public const int GeneralDescriptionLength = 512;
                public const int GuidStringLength = 36;
                public const int EmailStringLength = 50;
                public const int EncryptedPasswordLength = 64;
                public const int SaltStringLength = 64;
                public const int MobileStringLength = 11;
                public const int IdCardStringLength = 20;
                public const int UrlStringLength = 1024;
                public const int PathStringLength = 512;
                public const int OneThousandTextContentLength = 1000;
                public const int TwoThousandTextContentLength = 2000;
                public const int LongTextContentLength = 20000;
            }
        }
    }
}
