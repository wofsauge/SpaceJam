using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snake_core : MonoBehaviour {

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
    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 pos = this.transform.position;
        Collider2D[] hit_x = Physics2D.OverlapBoxAll(pos, new Vector2(1, 0.1f), 0);
        Collider2D[] hit_y = Physics2D.OverlapBoxAll(pos, new Vector2(0.1f, 1), 0);

        if (hit_x.Length + hit_y.Length <= 2 && Global.LastDeath+0.5f < Time.time)
        {
            Destroy(this.gameObject);
            Instantiate(explosion, transform.position, new Quaternion());
            Global.LastDeath = Time.time;
        }
    }
}
