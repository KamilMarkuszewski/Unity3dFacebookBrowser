using System;

namespace Assets.Scripts.FacebookService.Entities.JsonEntities.InnerData
{
    [Serializable]
    public class CurrencyJsonData
    {
        #region Json serialization fields.
        // Json serialization fields. Doeas not match convention rules but must be named exactly as facebook json data.
        public double currency_exchange;
        public double currency_exchange_inverse;
        public int currency_offset;
        public double usd_exchange;
        public double usd_exchange_inverse;
        public string user_currency;
        #endregion
    }
}
