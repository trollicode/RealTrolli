using Newtonsoft.Json;
using Plugin.DeviceInfo;
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
    public partial class WelcomeTrolliPage : ContentPage
    {
        public WelcomeTrolliPage()
        {
            InitializeComponent();
            CheckDeviceId();
        }

        private static string url = "https://trolli-194513.appspot.com/registration";
        static HttpClient _client = new HttpClient();


        public async void CheckDeviceId()
        {
            string deviceIdJson = "";
            bool check = true;
            var deviceId = CrossDeviceInfo.Current.Id;
            var content = await _client.GetStringAsync(url);
            if (Application.Current.Properties.ContainsKey("phoneNumber"))
            {

                List<Dictionary<string, object>> posts = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(content);

                foreach (Dictionary<string, object> i in posts)
                {

                    Dictionary<string, object> post = JsonConvert.DeserializeObject<Dictionary<string, object>>(Convert.ToString(i["properties"]));
                    deviceIdJson = Convert.ToString(post["deviceId"]);
                    if (deviceIdJson == deviceId)
                    {
                        check = false;



                        await Navigation.PushAsync(new ClientMainPage(Convert.ToString(post["fullName"])));

                    }
                }
            }
            else
            {
                await Navigation.PushAsync(new Registrations());
            }

            if (check)
            {
                
            }
        }
    }
}