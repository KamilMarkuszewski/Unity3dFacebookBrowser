using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.FacebookService.Entities;
using Assets.Scripts.FacebookService.Entities.JsonEntities;
using UnityEngine;
using UnityEngine.Networking;

namespace Assets.Scripts.FacebookService
{
    public abstract class FasebookServiceBase
    {
        protected static string GetErrorMessage(UnityWebRequest webRequest)
        {
            var errorJson = Encoding.UTF8.GetString(webRequest.downloadHandler.data);
            var errorData = JsonUtility.FromJson<ErrorData>(errorJson);
            return errorData.error.message;
        }

        protected static bool IsSuccess(UnityWebRequest webRequest)
        {
            if (webRequest.isNetworkError || webRequest.isHttpError)
            {
                return false;
            }
            return true;
        }

        public UnityWebRequestAsyncOperation SendWebRequest(out UnityWebRequest webRequest, string accessToken)
        {
            var adress = BuildFacebookUrl(accessToken);
            webRequest = UnityWebRequest.Get(adress);
            return webRequest.SendWebRequest();
        }


        public bool TryFetchData<T>(UnityWebRequest webRequest, out T entity, out string errorMessage)
            where T : JsonSerializableBase, new()
        {
            if (!IsSuccess(webRequest))
            {
                entity = null;
                errorMessage = GetErrorMessage(webRequest);
                return false;
            }

            var responseJson = Encoding.UTF8.GetString(webRequest.downloadHandler.data);
            entity = new T();
            entity.FillFromJson<T>(responseJson);
            errorMessage = String.Empty;
            return true;
        }

        protected abstract string BuildFacebookUrl(string accessToken);


    }
}
