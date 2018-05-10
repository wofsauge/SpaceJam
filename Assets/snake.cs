using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class snake : MonoBehaviour
{
    public GameObject explosion;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 pos = this.transform.position;
        Collider2D[] hit_x = Physics2D.OverlapBoxAll(pos, new Vector2(1, 0.1f), 0);
        Collider2D[] hit_y = Physics2D.OverlapBoxAll(pos, new Vector2(0.1f, 1), 0);

        if (hit_x.Length + hit_y.Length <= 3 && Global.LastDeath+0.5f < Time.time)
        {
            Destroy(this.gameObject);
            Instantiate(explosion, transform.position, new Quaternion());
            Global.LastDeath = Time.time;
        }
    }
}
