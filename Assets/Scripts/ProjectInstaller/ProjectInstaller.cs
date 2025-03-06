using System;
using UniRx;
using UnityEngine.SceneManagement;
using VContainer;

namespace ProjectInstaller
{
    public class ProjectInstaller : MonoInstaller
    {
        private void Start()
        {
            Observable.Timer(TimeSpan.FromSeconds(0.5f)).Subscribe(_ =>
            {
                SceneManager.LoadScene(1);
            }).AddTo(gameObject);
        }
    }
}