using System;

namespace Assets.Scripts.FacebookService.Entities.JsonEntities.InnerData
{
    [Serializable]
    public class InnerPictureJsonData
    {
        #region Json serialization fields.
        // Json serialization fields. Doeas not match convention rules but must be named exactly as facebook json data.
        public int height;
        public bool is_silhouette;
        public string url;
        public int width;
        #endregion
    }
}
