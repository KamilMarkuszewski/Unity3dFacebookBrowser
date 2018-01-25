using System;
using System.Net;
using System.Text;
using Assets.Scripts.FacebookService.Entities;
using Assets.Scripts.FacebookService.Entities.JsonEntities;
using Assets.Scripts.FacebookService.Entities.JsonEntities.InnerData;
using UnityEngine;
using UnityEngine.Networking;
using System.Collections.Generic;
using System.Linq;

namespace Assets.Scripts.FacebookService
{
    public class FacebookPresonService : FasebookServiceBase
    {
        private static volatile FacebookPresonService _instance;
        private static readonly object SyncRoot = new object();

        private FacebookPresonService() { }

        public static FacebookPresonService Instance
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
                        _instance = new FacebookPresonService();
                    }
                }

                return _instance;
            }
        }

        protected override string BuildFacebookUrl(string accessToken)
        {
            var url = "https://graph.facebook.com/me";
            var args = "id,first_name,last_name,picture,location,currency";
            return string.Format("{0}?access_token={1}&fields={2}", url, accessToken, args);
        }
    }
}
