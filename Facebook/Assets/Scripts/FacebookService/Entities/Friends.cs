using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.FacebookService.Entities.JsonEntities.InnerData;
using UnityEngine;

namespace Assets.Scripts.FacebookService.Entities
{
    public class Friends : JsonSerializableBase
    {
        public List<Friend> FriendsList;

        public override void FillFromJson<T>(string jsonString)
        {
            FriendsJsonData friendJsonData = JsonUtility.FromJson<FriendsJsonData>(jsonString);
            FriendsList = friendJsonData.data.Select(f => new Friend(f)).ToList();
        }
    }
}
