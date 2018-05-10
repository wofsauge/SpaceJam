using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public float hp;
    public float speed;
    public float shootDelay;
    public float BulletSpeed;
    public GameObject projectile;
    private float lastBullet = 0;
    private GameObject player;
    public GameObject explosion;

    void Start()
    {
        player = GameObject.Find("Player");
    }

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
    void FixedUpdate()
    {
        float step = speed * Time.deltaTime;
        if (!GameObject.Find("Player")) { return; }
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, step);
        transform.right = player.transform.position - transform.position;


        if (lastBullet + shootDelay < Time.time)
        {
            GameObject bullet = Instantiate(projectile, transform.position, new Quaternion(0, 0, 0, 0));

            var dir = player.transform.position - transform.position;
            dir.Normalize();
            bullet.GetComponent<Rigidbody2D>().AddForce(dir * BulletSpeed);
            var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            bullet.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            lastBullet = Time.time;
        }
    }
    protected void OnDestroy()
    {
        Instantiate(explosion, transform.position, new Quaternion());
    }
}
