using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boost : MonoBehaviour
{
    private void Awake()
    {
        // ���Ǵ�Boost���������ģ���ת����ʵ����
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
