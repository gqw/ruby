using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RubyController : MonoBehaviour
{
    public float speed = 6.0f;
    public uint maxHealth = 5;
    public uint curHealth = 0;

    Rigidbody2D rigidbody2d;
    MainPanel mainUI;

    private void Awake()
    {
        mainUI = GetComponent<MainPanel>();
    }
    // Start is called before the first frame update
    void Start()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;

        rigidbody2d = GetComponent<Rigidbody2D>();
        curHealth = 0;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");

        // Debug.Log(horizontal.ToString() + " " + vertical.ToString() + " " + Time.deltaTime + "  " + (1/ Time.deltaTime).ToString() );
        Vector2 position = rigidbody2d.position;
        position.x = position.x + speed * horizontal * Time.deltaTime;
        position.y = position.y + speed * vertical * Time.deltaTime;
        rigidbody2d.MovePosition(position);
    }

    public void ChangeHealth(int amount)
    {
        curHealth = (uint)Mathf.Clamp(curHealth + amount, 0, maxHealth);
        // Debug.Log(curHealth + "/" + maxHealth);
        // curHpDesc.text = $"{curHealth}/{maxHealth}";
        GameManager.Instance.ui.uiHealthBar.SetValue(curHealth * 1.0f / maxHealth);
    }

    public bool IsFullHealth()
    {
        return curHealth == maxHealth;
    }
}
