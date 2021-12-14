using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boost : MonoBehaviour
{
    private void Awake()
    {
        // 直接从boost场景启动，跳转到默认场景
        if (GameManager.BoostSceneName.Length == 0 || GameManager.BoostSceneName == "Boost")
        {
            Debug.Log($"load startup scene: {GameManager.StartUpSceneName}");
            SceneManager.LoadScene(1);
            return;
        }
        // 不是从Boost场景启动的，跳转到真实场景
        if (GameManager.StartUpSceneName != GameManager.BoostSceneName)
        {
            Debug.Log($"load startup scene: {GameManager.StartUpSceneName}");
            SceneManager.LoadScene(GameManager.StartUpSceneName);
            return;
        }
    }

     void Start()
    {
        
    }

    void Update()
    {
        
    }
}
