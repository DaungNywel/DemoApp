using RestSharp;
using SampleApp.Helpers;
using SampleApp.OTPAuth;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SampleApp.ViewModel
{
    public class SignUpViewModel : BaseViewModel
    {
        private CompanyUser _companyUser;

        public CompanyUser CompanyUser
        {
            get { return _companyUser; }
            set { _companyUser = value; OnPropertyChanged(); }
        }

        private AuthyUserResponse _authyUserResponse;

        public AuthyUserResponse AuthyUserResponse
        {
            get { return _authyUserResponse; }
            set { _authyUserResponse = value; OnPropertyChanged(); }
        }

        private AuthyOTPResponse _authyOTPResponse;

        public AuthyOTPResponse AuthyOTPResponse
        {
            get { return _authyOTPResponse; }
            set { _authyOTPResponse = value; OnPropertyChanged(); }
        }

        private AuthyVerifyResponse _authyVerifyResponse;

        public AuthyVerifyResponse AuthyVerifyResponse
        {
            get { return _authyVerifyResponse; }
            set { _authyVerifyResponse = value; OnPropertyChanged(); }
        }

        private long _token;

        public long Token
        {
            get { return _token; }
            set { _token = value; OnPropertyChanged(); }
        }

        private bool _needsVerification;

        public bool NeedsVerification
        {
            get { return _needsVerification; }
            set { _needsVerification = value; OnPropertyChanged(); }
        }

        public ICommand SignUpCommand { private set; get; }
        public ICommand VerifyTokenCommand { private set; get; }
        public ICommand sendSMS { private set; get; }

        public SignUpViewModel()
        {
            SignUpCommand = new Command(async () => await SignUp());
            VerifyTokenCommand = new Command(async () => await VerifyToken());
            sendSMS = new Command(SendMessage);
            CompanyUser = new CompanyUser();
        }

        private async void SendMessage(object obj)
        {
            RestClient client = new RestClient("https://api.authy.com/protected/json/phones/verification");

            RestSharp.RestRequest request = new RestSharp.RestRequest("start", RestSharp.Method.POST);
           // numcheck = Numero.Text.Trim();
            request.AddHeader("Content-Type", "application/json");
            request.RequestFormat = RestSharp.DataFormat.Json;
            string este = "{\"api_key\":\"" + Constants.AuthyAPIKey + "\",\"via\":\"sms\"," + "\"country_code\":95," + "\"phone_number\":" + CompanyUser.Cellphone + ",\"locale\":\"es\"}";

            request.AddParameter("text/json", este, RestSharp.ParameterType.RequestBody);
            RestSharp.IRestResponse response = await client.ExecuteTaskAsync(request);

           var respuesta = response.Content;
            Console.WriteLine(respuesta);
        }

        async Task SignUp()
        {
            AuthyUserResponse = await AuthyService.AddUser(CompanyUser);

            if (AuthyUserResponse != null)
            {
                AuthyOTPResponse = await AuthyService.SendOTP(AuthyUserResponse.User.Id);

                if (AuthyOTPResponse != null)
                    NeedsVerification = AuthyOTPResponse.Success;
            }
        }

        async Task VerifyToken()
        {
            AuthyVerifyResponse = await AuthyService.VerifyToken(Token, AuthyUserResponse.User.Id);
        }
    }
}
