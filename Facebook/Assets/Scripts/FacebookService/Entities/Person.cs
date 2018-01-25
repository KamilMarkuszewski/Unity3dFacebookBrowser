using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.FacebookService.Entities.JsonEntities;
using Assets.Scripts.FacebookService.Entities.JsonEntities.InnerData;
using UnityEngine;

namespace Assets.Scripts.FacebookService.Entities
{
    public class Person : JsonSerializableBase
    {
        private PersonData _personData;

        public override void FillFromJson<T>(string jsonString)
        {
            PersonData personData = JsonUtility.FromJson<PersonData>(jsonString);
            _personData = personData;
        }

        public int Id
        {
            get { return _personData.id; }
        }

        public string FirstName
        {
            get { return _personData.first_name; }
        }

        public string LastName
        {
            get { return _personData.last_name; }
        }

        public string CurrencySymbol
        {
            get { return _personData.currency.user_currency; }
        }

        public double CurrencyUsdExchange
        {
            get { return _personData.currency.usd_exchange_inverse; }
        }

        public string City
        {
            get { return _personData.location.name.Split(',').FirstOrDefault(); }
        }

        public bool IsPictureDefault
        {
            get { return _personData.picture.data.is_silhouette; }
        }

        public string PictureUrl
        {
            get { return _personData.picture.data.url; }
        }
    }
}
