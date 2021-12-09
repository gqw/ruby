using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boost : MonoBehaviour
{
    private void Awake()
    {
        // 不是从Boost场景启动的，跳转到真实场景
        if (GameManager.StartUpSceneName != GameManager.BoostSceneName)
        {
            Debug.Log($"load startup scene: {GameManager.StartUpSceneName}");
            SceneManager.LoadScene(GameManager.StartUpSceneName);
        }
    }

     void Start()
    {
        
    }

    void Update()
    {
        
    }
}
