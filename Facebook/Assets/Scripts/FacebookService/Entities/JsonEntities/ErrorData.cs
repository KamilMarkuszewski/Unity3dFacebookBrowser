using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.FacebookService.Entities.JsonEntities;
using Assets.Scripts.FacebookService.Entities.JsonEntities.InnerData;

namespace Assets.Scripts.FacebookService.Entities
{
    [Serializable]
    public class ErrorData
    {
        #region Json serialization fields.
        // Json serialization fields. Doeas not match convention rules but must be named exactly as facebook json data.
        public ErrorInnerJsonData error;
        #endregion
    }
}
