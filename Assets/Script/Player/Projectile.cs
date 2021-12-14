using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody2D _rigidbody2d;
    GameObject _firer;          // 发射子弹的对象

    void Awake()
    {
        _rigidbody2d = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        var firerPos = _firer.GetComponent<Rigidbody2D>();
        var projectilePos = GetComponent<Rigidbody2D>();
        if (firerPos == null || projectilePos == null)
        {
            Debug.LogWarning("pos is null");
            return;
        }
        var dist = Vector3.Distance(firerPos.position, projectilePos.position);
        Debug.Log($"dist: {dist}");
        if (dist > 5)
        {
            Destroy(gameObject);
        }
    }

    public void Launcher(GameObject firer, Vector2 direction, float force)
    {
        _firer = firer;
        _rigidbody2d.AddForce(direction * force);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var enemy = collision.gameObject.GetComponent<EnemyController>();
        if (enemy)
        {
            enemy.Fix();
        }
        // Debug.Log("Projectile Collision with " + collision.gameObject);
        Destroy(gameObject);
    }

}
