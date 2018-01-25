using System;
using UnityEngine;

namespace Assets.Scripts.FacebookService.Entities.JsonEntities.InnerData
{
    [Serializable]
    public class FriendJsonData
    {
        #region Json serialization fields.
        // Json serialization fields. Doeas not match convention rules but must be named exactly as facebook json data.
        public int id;
        public string first_name;
        public string last_name;
        public PictureJsonData picture;
        #endregion
    }
}
