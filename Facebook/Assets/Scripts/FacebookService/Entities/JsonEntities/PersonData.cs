using System;
using Assets.Scripts.FacebookService.Entities.JsonEntities.InnerData;

namespace Assets.Scripts.FacebookService.Entities.JsonEntities
{
    [Serializable]
    public class PersonData
    {
        #region Json serialization fields.
        // Json serialization fields. Doeas not match convention rules but must be named exactly as facebook json data.
        public int id;
        public string first_name;
        public string last_name;
        public PictureJsonData picture;
        public LocationJsonData location;
        public CurrencyJsonData currency;

        #endregion
    }
}
