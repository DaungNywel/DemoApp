using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Net;
using System.Collections.Specialized;
using System.IO;
using System.Web;

namespace SampleApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TestOTP : ContentPage
    {
		string randomNumber;
        public TestOTP()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
			//String result;
			string apiKey = "bWxqS3zgK0I-lWGkeWylU1k1dgDOyICu7hjxgRkWrV";
			//string apiKey = "CmFCt/2HXZU-QMRNVcdZwGzGcC4Nyg15X5WeixqXHy";
			string numbers = entryPhone.Text; // in a comma seperated list
			
			string send = "TSN";
			Random random = new Random();
			randomNumber = random.Next(1000,9999).ToString();
			string message = "Your OTP is "+randomNumber+"This code is for Adely only.";
			String url = "https://api.txtlocal.com/send/?apikey=" + apiKey + "&numbers=" + numbers + "&message=" + message + "&sender=" + send;
			//refer to parameters to complete correct url string
			string message1 = HttpUtility.UrlEncode(message);
			using(var wb=new WebClient())
			{
				byte[] response = wb.UploadValues("https://api.txtlocal.com/send/", new NameValueCollection()
				{
					{"apikey","bWxqS3zgK0I-lWGkeWylU1k1dgDOyICu7hjxgRkWrV" },
					{"numbers",entryPhone.Text },
					{"message",message1 },
					{"sender","TSN" }
				});
				string result = System.Text.Encoding.UTF8.GetString(response);
			}
			
			//StreamWriter myWriter = null;
			//HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create(url);

			//objRequest.Method = "POST";
			//objRequest.ContentLength = Encoding.UTF8.GetByteCount(url);
			//objRequest.ContentType = "application/x-www-form-urlencoded";
			//try
			//{
			//	myWriter = new StreamWriter(objRequest.GetRequestStream());
			//	myWriter.Write(url);
			//}
			//catch (Exception ex)
			//{
			//	App.Current.MainPage.DisplayAlert("Alert",ex.Message,"OK");
			//}
			//finally
			//{
			//	myWriter.Close();
			//}

			//HttpWebResponse objResponse = (HttpWebResponse)objRequest.GetResponse();
			//using (StreamReader sr = new StreamReader(objResponse.GetResponseStream()))
			//{
				//result = sr.ReadToEnd();
			//	// Close and clean up the StreamReader
			//	sr.Close();
			//}
			App.Current.MainPage.DisplayAlert("Alert","OTP send successfully!", "OK");
		}
    }
}