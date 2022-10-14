using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGunShell : MonoBehaviour
{
    public float startVelocity, falloff, timeToLive, damage;

    float timer;

    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        timer = timeToLive;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0){
            timer -= Time.deltaTime;
            transform.position += transform.TransformDirection(Vector3.left) * Time.deltaTime * startVelocity;
            startVelocity = Mathf.Lerp(startVelocity, 0, falloff * Time.deltaTime);
        } else {
            Die();
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Damageable")){
            other.gameObject.GetComponentInChildren<Damageable>().TakeDamage(damage);
        }
    }

    void Die(){
        Destroy(gameObject);
    }
}
