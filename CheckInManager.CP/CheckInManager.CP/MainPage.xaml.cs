using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using CheckInManager.CP.Model;
using Newtonsoft.Json;
using System.Net.Http;



namespace CheckInManager.CP
{
	public partial class MainPage : ContentPage
	{
        private string username = "";
        private string password = "";
        private Login creds;
        private string WasSuccessful;

        public MainPage()
		{
			InitializeComponent();
           
        }


        private async void btnLogin_Clicked(object sender, EventArgs e)
        {

            if (txtUserName.Text != "" && txtPassword.Text != "")
            {
                username = txtUserName.Text;
                password = txtPassword.Text;

                creds = new Login();
                creds.UserName = username;
                creds.Password = password;
                await SendLoginAttempt();

                if (WasSuccessful == "true")
                {
                    await Navigation.PushAsync(new MealPage());
                }
                else
                {
                    string message = "Invalid User Id or Password.";
                    await DisplayAlert("Login", message, "OK");
                }
            }

        }

        async Task SendLoginAttempt()
        {
            var client = new HttpClient();

            string serializedLogin = JsonConvert.SerializeObject(creds);

            var content = new StringContent(serializedLogin);
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            HttpResponseMessage response;
            response = await client.PostAsync("https://lfguestwebapi.azurewebsites.net/api/Attempt", content);
            if(response.IsSuccessStatusCode)
            {
                WasSuccessful = "true";
            }
            else
            {
                WasSuccessful = "false";
            }
        }
    }
}
