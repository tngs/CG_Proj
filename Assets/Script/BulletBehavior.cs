using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    public float speed = 20f;
    public float damage = 10f;
    public float lifetime = 5f;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.linearVelocity = transform.forward * speed;
        Destroy(gameObject, lifetime);
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Enemy")) {
            EnemyCharacter enemy = collision.gameObject.GetComponent<EnemyCharacter>();
            if (enemy != null)
                enemy.TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}
