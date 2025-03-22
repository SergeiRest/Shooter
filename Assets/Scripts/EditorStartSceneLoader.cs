using UnityEngine;
using UnityEngine.SceneManagement;

namespace Main
{
    public static class EditorStartSceneLoader
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void LoadFirstScene()
        {
            int sceneIndex = 0;
            if (SceneManager.sceneCount == 0 || SceneManager.GetActiveScene().buildIndex != sceneIndex)
            {
                // Если нет, загружаем нужную сцену
                SceneManager.LoadScene(sceneIndex);
            }
        }
    }
}