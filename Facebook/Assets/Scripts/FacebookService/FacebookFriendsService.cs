using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine.Networking;

namespace Assets.Scripts.FacebookService
{
    public class FacebookFriendsService : FasebookServiceBase
    {
        private static volatile FacebookFriendsService _instance;
        private static readonly object SyncRoot = new object();

        private FacebookFriendsService() { }

        public static FacebookFriendsService Instance
        {
            get
            {
                if (_instance != null)
                {
                    return _instance;
                }

                lock (SyncRoot)
                {
                    if (_instance == null)
                    {
                        _instance = new FacebookFriendsService();
                    }
                }

                return _instance;
            }
        }

        protected override string BuildFacebookUrl(string accessToken)
        {
            var url = "https://graph.facebook.com/me/friends";
            var args = "id,first_name,last_name,picture";
            return string.Format("{0}?access_token={1}&fields={2}", url, accessToken, args);
        }
    }
}
