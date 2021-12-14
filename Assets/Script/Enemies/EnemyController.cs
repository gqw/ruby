using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 6.0f;
    public float changeTime = 3.0f;
    public bool vertical = true;

    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private int _direction = 1;
    private float _timer = 0;
    bool isBreak = true;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _timer = changeTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isBreak)
        {
            return;
        }

        _timer -= Time.deltaTime;
        if (_timer < 0)
        {
            _direction = -_direction;
            _timer = changeTime;
        }
    }

    void FixedUpdate()
    {
        if (!isBreak)
        {
            return;
        }

        Vector2 position = _rigidbody.position;
        if (vertical)
        {
            _animator.SetFloat("Move X", 0);
            _animator.SetFloat("Move Y", _direction);
            position.y += Time.deltaTime * speed * _direction;
        } 
        else
        {
            _animator.SetFloat("Move X", _direction);
            _animator.SetFloat("Move Y", 0);
            position.x += Time.deltaTime * speed * _direction;
        }
        _rigidbody.MovePosition(position);
    }

    public void Fix()
    {
        isBreak = false;
        _rigidbody.simulated = false;
        _animator.SetTrigger("Fixed");
    }
}
