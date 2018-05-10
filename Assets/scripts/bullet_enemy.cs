using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_enemy : MonoBehaviour
{
    private float time;
    public float lifetime;
    public GameObject explosion;
    // Use this for initialization
    void Start()
    {
        time = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > time + lifetime)
        {
            Destroy(gameObject);
        }
    }
    protected void OnDestroy()
    {
        Instantiate(explosion, transform.position, new Quaternion());
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Player")
        {
            Destroy(this.gameObject);
            col.gameObject.SendMessage("ApplyDamage", 10);
        }
    }
}
