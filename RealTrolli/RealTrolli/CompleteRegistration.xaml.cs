using Plugin.DeviceInfo;
using Plugin.Geolocator;
using RealTrolli.BeanClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RealTrolli
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CompleteRegistration : ContentPage
	{
		public CompleteRegistration (string phone)
		{
			InitializeComponent ();
            phoneNumber = phone;
        }


        static HttpClient _client = new HttpClient();
        static string phoneNumber = "";

        public async void signUp_button(object sender, EventArgs e)
        {
            if (checkTextField())
            {
                var deviceId = CrossDeviceInfo.Current.Id;
                // string simNumber = "";
                // string deviceIdJson = "";
                // var content = await _client.GetStringAsync(url);

                // List<Dictionary<string, object>> posts = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(content);

                // foreach (Dictionary<string, object> i in posts)
                // {

                //     Dictionary<string, object> post = JsonConvert.DeserializeObject<Dictionary<string, object>>(Convert.ToString(i["properties"]));
                //     deviceIdJson = Convert.ToString(post["deviceId"]);
                //      if (deviceIdJson == deviceId)
                //      {
                //       simNumber = Convert.ToString(post["simNumber"]);
                //     }
                // }


                string name = fullName.Text;
                string emailId = email.Text;
                string subrubs = subrub.Text;
                var statesPickers = statesPicker.Items[statesPicker.SelectedIndex];
                string states = statesPickers;
                string postCodes = postCode.Text;
                string country = "Australia";
                string userType = "Client";
<<<<<<< HEAD
                
=======
                try
                {
>>>>>>> 7c169c09e5f31ca728e476772ccef86f2ce5fc3d
                    var locator = CrossGeolocator.Current;
                    locator.DesiredAccuracy = 50;

                    var position = await locator.GetPositionAsync();

                    string latitude = "" + position.Latitude;
                    string longitude = ""+ position.Longitude;

<<<<<<< HEAD
                     SignupBean bean = new SignupBean
=======
                    /* SignupBean bean = new SignupBean
>>>>>>> 7c169c09e5f31ca728e476772ccef86f2ce5fc3d
                                         {
                                             name = name,
                                             email = emailId,
                                             subrub = subrubs,
                                             states = states,
                                             postCodes = postCodes,
                                             country = country,
                                             userType = userType,
                                             phoneNumber = phoneNumber,
                                             deviceId = deviceId,
                                             latitude = latitude,
                                             longitude = longitude
                                         };

                     ApiCalling callApi = new ApiCalling();
<<<<<<< HEAD
                      callApi.signupPost(bean);
                    //string postUrl = "https://trolli-194513.appspot.com/registration?fullName=" + name + "&simNumber=" + phoneNumber + "&suburb=" + subrubs + "&state=" + states + "&postCode=" + postCodes + "&country=" + country + "&email=" + emailId + "&userType=" + userType + "&latitude=" + latitude + "&longitude=" + longitude + "&deviceId=" + deviceId;
                   // await _client.PostAsync("https://trolli-194513.appspot.com/registration?fullName=" + name + "&simNumber=" + phoneNumber + "&suburb=" + subrubs + "&state=" + states + "&postCode=" + postCodes + "&country=" + country + "&email=" + emailId + "&userType=" + userType + "&latitude=" + latitude + "&longitude=" + longitude + "&deviceId=" + deviceId, null);
=======
                      callApi.signupPost(bean);*/
                    //string postUrl = "https://trolli-194513.appspot.com/registration?fullName=" + name + "&simNumber=" + phoneNumber + "&suburb=" + subrubs + "&state=" + states + "&postCode=" + postCodes + "&country=" + country + "&email=" + emailId + "&userType=" + userType + "&latitude=" + latitude + "&longitude=" + longitude + "&deviceId=" + deviceId;
                    await _client.PostAsync("https://trolli-194513.appspot.com/registration?fullName=" + name + "&simNumber=" + phoneNumber + "&suburb=" + subrub + "&state=" + states + "&postCode=" + postCodes + "&country=" + country + "&email=" + email + "&userType=" + userType + "&latitude=" + latitude + "&longitude=" + longitude + "&deviceId=" + deviceId, null);
>>>>>>> 7c169c09e5f31ca728e476772ccef86f2ce5fc3d

                    Application.Current.Properties["id"] = deviceId;
                    Application.Current.Properties["phoneNumber"] = phoneNumber;
                    //   OneSignal.Current.StartInit("8b4dd468-c131-476c-9567-b7bd4341c273")
                    //    .EndInit();




                    await Navigation.PushAsync(new ClientMainPage(name));
<<<<<<< HEAD
                
=======
                }
                catch (Exception ex) {
                    await DisplayAlert("Error", "Please Try Again", "Ok");
                }
>>>>>>> 7c169c09e5f31ca728e476772ccef86f2ce5fc3d
            }
        }

        public bool checkTextField()
        {
            bool check = true;
            string text = "";
            if (fullName.Text == "")
            {
                check = false;
                text += "\n Enter Your Full Name";
            }

            if (email.Text == "")
            {
                check = false;
                text += "\n Enter Your Email";
            }

            if (subrub.Text == "")
            {
                check = false;
                text += "\n Enter Your Subrub";
            }


            if (postCode.Text == "")
            {
                check = false;
                text += "\n Enter Your Postal Code";
            }

            if (!check)
            {
                DisplayAlert("Some Think Missing", "Text Field Missing \n" + text, "OK");
            }

            return check;

        }
    }
}