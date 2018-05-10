using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snake_arm : MonoBehaviour {

    public GameObject explosion;
    public float hp;

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Projectile")
        {
            Destroy(col.gameObject);
            this.gameObject.SendMessage("ApplyDamage", 10);
        }
    }
    void ApplyDamage(float damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    
    protected void OnDestroy()
    {
        Instantiate(explosion, transform.position, new Quaternion());
        Global.LastDeath = Time.time;
    }
}
