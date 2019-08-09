using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Google.Apis.Auth.OAuth2.Mvc;
using Google.Apis.Auth.OAuth2;
using System.Threading;


namespace GooglePhotosFilter.Classes
{
    public class GoogleLogin
    {
        private string googleClientId = string.Empty;
        private string googleClientSecret = string.Empty;

        private static string[] Scopes = { "https://www.googleapis.com/auth/photoslibrary" };

        public GoogleLogin()
        {

        }

        public string Login(string clientId, string clientSecret)
        {
            string token = string.Empty;

            try
            {
                ClientSecrets clientSecrets = new ClientSecrets();
                clientSecrets.ClientId = clientId;
                clientSecrets.ClientSecret = clientSecret;

                UserCredential credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    clientSecrets,
                    Scopes,
                    "user",
                    CancellationToken.None).Result;

                if(credential.Token.IsExpired(Google.Apis.Util.SystemClock.Default))
                {
                    bool isRefreshed = credential.RefreshTokenAsync(CancellationToken.None).Result;
                }

                token = credential.Token.AccessToken;         
            }
            catch(Exception ex)
            {
                token = string.Empty;
            }

            return token;
        }
    }
}
