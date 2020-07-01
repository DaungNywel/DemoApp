using System;
using System.Collections.Generic;
using System.Text;

namespace SampleApp.Helpers
{
    public class Constants
    {
        public static bool IsiPhoneX = false;
        public static bool onIphoneX;
        public readonly static string AuthyAPIKey = "i8Bo1aYosW2DQgeDV8EQpqHjGdgkJ6m5";
        public readonly static string AuthyBaseURL = "https://api.authy.com/";

        public readonly static string AddUserURL = "protected/json/users/new";
        public readonly static string SendOTPURL = "protected/json/sms";
        public readonly static string VerifyTokenURL = "protected/json/verify";
    }
}
