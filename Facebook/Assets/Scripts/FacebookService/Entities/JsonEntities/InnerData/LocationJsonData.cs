using System;

namespace Assets.Scripts.FacebookService.Entities.JsonEntities.InnerData
{
    [Serializable]
    public class LocationJsonData
    {
        #region Json serialization fields.
        // Json serialization fields. Doeas not match convention rules but must be named exactly as facebook json data.
        public int id;
        public string name;
        #endregion
    }
}
