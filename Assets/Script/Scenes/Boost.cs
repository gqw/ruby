using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boost : MonoBehaviour
{
    private void Awake()
    {
        // ֱ�Ӵ�boost������������ת��Ĭ�ϳ���
        if (GameManager.BoostSceneName.Length == 0 || GameManager.BoostSceneName == "Boost")
        {
            Debug.Log($"load startup scene: {GameManager.StartUpSceneName}");
            SceneManager.LoadScene(1);
            return;
        }
        // ���Ǵ�Boost���������ģ���ת����ʵ����
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
