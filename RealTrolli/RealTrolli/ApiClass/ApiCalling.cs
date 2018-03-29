using RealTrolli.BeanClass;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Xamarin.Forms.Internals;

namespace RealTrolli
{
    class ApiCalling
    {
        static HttpClient _client = new HttpClient();


        public async void signupPost(SignupBean ob) {
            try
            {
                await _client.PostAsync("https://trolli-194513.appspot.com/registration?fullName=" + ob.name + "&simNumber=" + ob.phoneNumber + "&suburb=" + ob.subrub + "&state=" + ob.states + "&postCode=" + ob.postCodes + "&country=" + ob.country + "&email=" + ob.email + "&userType=" + ob.userType + "&latitude=" + ob.latitude + "&longitude=" + ob.longitude + "&deviceId=" + ob.deviceId, null);
            }
            catch (Exception ex) {
                Log.Warning("Error", ex.ToString());
            }
        }
    }
}
