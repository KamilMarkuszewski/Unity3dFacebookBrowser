using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.FacebookService.Entities.JsonEntities.InnerData;
using UnityEngine;

namespace Assets.Scripts.FacebookService.Entities
{
    public class Friend
    {
        private readonly FriendJsonData _friendJsonData;
        public Friend(FriendJsonData friendJsonData)
        {
            _friendJsonData = friendJsonData;
        }

        public string Name
        {
            get { return String.Format("{0} {1}", _friendJsonData.first_name, _friendJsonData.last_name); }
        }

        public bool IsPictureDefault
        {
            get { return _friendJsonData.picture.data.is_silhouette; }
        }

        public string PictureUrl
        {
            get { return _friendJsonData.picture.data.url; }
        }

        public Texture2D Picture { get; set; }
    }
}
