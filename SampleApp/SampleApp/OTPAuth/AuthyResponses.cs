using System;
using System.Collections.Generic;
using System.Text;

namespace SampleApp.OTPAuth
{
    public class AuthyUserResponse
    {
        public string Message { get; set; }
        public AuthyUser User { get; set; }
        public bool Success { get; set; }
    }

    public class AuthyUser
    {
        public long Id { get; set; }
    }
    public class AuthyOTPResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public string Cellphone { get; set; }
    }
    public class AuthyVerifyResponse
    {
        public string Message { get; set; }
        public string Token { get; set; }
        public string Success { get; set; }
        public AuthyDevice Device { get; set; }
    }
    public class CompanyUser
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Cellphone { get; set; }
        public string CountryCode { get; set; }
    }
    public class AuthyDevice
    {
        public string City { get; set; }
        public string Country { get; set; }
        public string Ip { get; set; }
        public string Region { get; set; }
        public string Registration_city { get; set; }
        public string Registration_country { get; set; }
        public int? Registration_device_id { get; set; }
        public string Registration_ip { get; set; }
        public string Registration_method { get; set; }
        public string Registration_region { get; set; }
        public string Os_type { get; set; }
        public object Last_account_recovery_at { get; set; }
        public int? Id { get; set; }
        public int? Registration_date { get; set; }
    }
}
