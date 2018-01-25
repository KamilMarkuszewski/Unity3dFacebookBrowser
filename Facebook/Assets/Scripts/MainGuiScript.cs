using UnityEngine;

namespace Assets.Scripts
{
    public class MainGuiScript : MonoBehaviour
    {
        private readonly MainGuiViewModel _model;

        public MainGuiScript()
        {
            _model = new MainGuiViewModel();
        }

        private void GetPersonData()
        {
            StartCoroutine(_model.FetchPerson(_model.AccessToken, withOnFinished: GetPicture));
            StartCoroutine(_model.FetchFriends(_model.AccessToken, withOnFinished: GetFriendsPictures));
        }

        private void GetPicture()
        {
            StartCoroutine(_model.GetPicture());
        }

        private void GetFriendsPictures()
        {
            foreach (var friend in _model.Friends.FriendsList)
            {
                StartCoroutine(_model.GetFriendPicture(friend));
            }
        }

        private void OnGUI()
        {
            _model.AccessToken = GUI.TextField(new Rect(10, 10, 500, 30), _model.AccessToken);

            if (GUI.Button(new Rect(520, 10, 100, 30), Resources.FetchData))
            {
                GetPersonData();
            }

            if (_model.Person != null)
            {
                GUI.BeginGroup(new Rect(10, 80, 500, 500));

                if (_model.Picture != null)
                {
                    GUI.DrawTexture(new Rect(10, 10, 50, 50), _model.Picture);
                }

                GUI.Label(new Rect(70, 0, 400, 30), _model.LabelId);
                GUI.Label(new Rect(70, 40, 400, 30), _model.LabelFirstName);
                GUI.Label(new Rect(70, 80, 400, 30), _model.LabelLastName);
                GUI.Label(new Rect(70, 120, 400, 30), _model.City);
                GUI.Label(new Rect(70, 160, 400, 30), _model.Currency);
                GUI.Label(new Rect(70, 200, 400, 30), _model.CurrencyUsdExchange);

                GUI.EndGroup();

                if (_model.Friends != null && _model.Friends.FriendsList.Count > 0)
                {
                    int yCor = 10;
                    _model.ScrollPosition = GUI.BeginScrollView(new Rect(500, 80, 500, 500), _model.ScrollPosition,
                        new Rect(0, 0, 480, 40 * _model.Friends.FriendsList.Count + 20));
                    foreach (var friend in _model.Friends.FriendsList)
                    {
                        if (friend.Picture != null)
                        {
                            GUI.DrawTexture(new Rect(0, yCor, 50, 50), friend.Picture);
                        }
                        GUI.Label(new Rect(60, yCor + 15, 400, 30), friend.Name);
                        yCor += 60;
                    }

                    GUI.EndScrollView();
                }
            }

            ShowErrorIfAny();

        }

        private void ShowErrorIfAny()
        {
            if (!_model.IsSuccess)
            {
                GUI.BeginGroup(new Rect(Screen.width / 2 - 300, Screen.height / 2 - 40, 600, 80));
                GUI.Box(new Rect(0, 0, 600, 80), Resources.Error);

                GUI.Label(new Rect(10, 20, 600, 30), _model.ErrorMessage);

                if (string.IsNullOrEmpty(_model.AccessToken))
                {
                    GUI.Label(new Rect(10, 50, 600, 30), Resources.ProvideAccessToken);
                }

                GUI.EndGroup();
            }
        }
    }
}
