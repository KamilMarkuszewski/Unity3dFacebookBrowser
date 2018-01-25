using System;

namespace Assets.Scripts.FacebookService.Entities.JsonEntities.InnerData
{
    [Serializable]
    public class ErrorInnerJsonData
    {
        #region Json serialization fields.
        // Json serialization fields. Doeas not match convention rules but must be named exactly as facebook json data.
        public string message;
        public string type;
        public int code;
        public int fbtrace_id;
        #endregion
    }
}
