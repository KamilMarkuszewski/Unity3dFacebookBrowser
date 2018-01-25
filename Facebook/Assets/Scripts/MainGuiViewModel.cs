using System;
using System.Collections;
using Assets.Scripts.FacebookService;
using Assets.Scripts.FacebookService.Entities;
using UnityEngine;
using UnityEngine.Networking;

namespace Assets.Scripts
{
    public class MainGuiViewModel
    {
        public string ErrorMessage;
        public bool IsSuccess = true;
        public Person Person;
        public string AccessToken;
        public Texture2D Picture;
        public Vector2 ScrollPosition = Vector2.zero;
        public Friends Friends;

        private string PictureUrl
        {
            get { return Person == null ? String.Empty : Person.PictureUrl; }
        }

        private bool IsPictureDefault
        {
            get { return Person == null || Person.IsPictureDefault; }
        }

        #region Label values

        public string LabelId
        {
            get { return Person == null ? String.Empty : Resources.LabelId + Person.Id; }
        }

        public string LabelFirstName
        {
            get { return Person == null ? String.Empty : Resources.LabelFirstName + Person.FirstName; }
        }

        public string LabelLastName
        {
            get { return Person == null ? String.Empty : Resources.LabelLastName + Person.LastName; }
        }

        public string City
        {
            get { return Person == null ? String.Empty : Resources.LabelLastCity + Person.City; }
        }

        public string Currency
        {
            get { return Person == null ? String.Empty : Resources.LabelLastCurrency + Person.CurrencySymbol; }
        }

        public string CurrencyUsdExchange
        {
            get
            {
                return Person == null ? String.Empty
                    : Resources.LabelLastCurrencyUsdExchange + Math.Round(Person.CurrencyUsdExchange, 2, MidpointRounding.AwayFromZero);
            }
        }
        #endregion

        public IEnumerator GetFriendPicture(Friend friend)
        {
            if (friend.IsPictureDefault || string.IsNullOrEmpty(friend.PictureUrl))
            {
                friend.Picture = null;
                yield return null;
            }
            else
            {
                using (WWW www = new WWW(friend.PictureUrl))
                {
                    yield return www;
                    friend.Picture = www.texture;
                }
            }
        }

        public IEnumerator GetPicture()
        {
            if (IsPictureDefault || string.IsNullOrEmpty(PictureUrl))
            {
                Picture = null;
                yield return null;
            }
            else
            {
                using (WWW www = new WWW(PictureUrl))
                {
                    yield return www;
                    Picture = www.texture;
                }
            }
        }

        public IEnumerator FetchFriends(string accessToken, Action withOnFinished)
        {
            UnityWebRequest webRequest;
            Friends friends;
            string errorMessage;

            yield return FacebookFriendsService.Instance.SendWebRequest(out webRequest, accessToken);
            IsSuccess = FacebookFriendsService.Instance.TryFetchData(webRequest, out friends, out errorMessage);
            Friends = friends;
            ErrorMessage = errorMessage;

            withOnFinished();
        }


        public IEnumerator FetchPerson(string accessToken, Action withOnFinished)
        {
            UnityWebRequest webRequest;
            Person person;
            string errorMessage;

            yield return FacebookPresonService.Instance.SendWebRequest(out webRequest, accessToken);
            IsSuccess = FacebookPresonService.Instance.TryFetchData(webRequest, out person, out errorMessage);
            Person = person;
            ErrorMessage = errorMessage;

            withOnFinished();
        }

    }
}
