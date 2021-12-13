using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RubyController : MonoBehaviour
{
    public float speed = 6.0f;
    public uint maxHealth = 5;
    public uint curHealth = 0;

    Animator _animator;
    Rigidbody2D _rigidbody2d;
    Vector2 _lookDirection = new Vector2(1.0f, 0);


    private void Awake()
    {
    }
    // Start is called before the first frame update
    void Start()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;

        _animator = GetComponent<Animator>();
        _rigidbody2d = GetComponent<Rigidbody2D>();
        
        curHealth = 0;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");

        Vector2 move = new Vector2(horizontal, vertical);
        if (!Mathf.Approximately(move.x, 0) || !Mathf.Approximately(move.y, 0))
        {
            _lookDirection.Set(move.x, move.y);
            _lookDirection.Normalize();
        }

        _animator.SetFloat("Look X", _lookDirection.x);
        _animator.SetFloat("Look Y", _lookDirection.y);
        _animator.SetFloat("Speed", move.magnitude);

        // Debug.Log(horizontal.ToString() + " " + vertical.ToString() + " " + Time.deltaTime + "  " + (1/ Time.deltaTime).ToString() );
        Vector2 position = _rigidbody2d.position;
        position.x = position.x + speed * horizontal * Time.deltaTime;
        position.y = position.y + speed * vertical * Time.deltaTime;
        _rigidbody2d.MovePosition(position);
    }

    private void FixedUpdate()
    {
        
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
