﻿using System;
using System.Collections.Generic;

namespace Assets.Scripts.FacebookService.Entities.JsonEntities.InnerData
{
    [Serializable]
    public class FriendsJsonData
    {
        #region Json serialization fields.
        // Json serialization fields. Doeas not match convention rules but must be named exactly as facebook json data.
        public List<FriendJsonData> data = new List<FriendJsonData>();
        #endregion
    }
}
