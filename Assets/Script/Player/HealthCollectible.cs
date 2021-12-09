using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var ruby = collision.GetComponent<RubyController>();
        if (ruby == null) return;
        if (ruby.IsFullHealth()) return;

        ruby.ChangeHealth(1);
        Destroy(gameObject);
    }
}
