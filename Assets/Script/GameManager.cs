using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public struct UI
    {
        public UIHealthBar uiHealthBar;
    };

    public UI ui;
    public static string BoostSceneName = "Boost";
    public static string StartUpSceneName {get; private set;}


    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void LoadBoostScene()
    {
        var sceneName = SceneManager.GetActiveScene().name;
        if (sceneName == GameManager.BoostSceneName) return;

        Debug.Log($"Loading {GameManager.BoostSceneName} scene");
        StartUpSceneName = sceneName;
        SceneManager.LoadScene(GameManager.BoostSceneName);
    }
}
