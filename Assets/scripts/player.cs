using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class player : MonoBehaviour
{
    public float speed;             //Floating point variable to store the player's movement speed.
    public float bulletspeed;
    public Rigidbody2D rb2d;       //Store a reference to the Rigidbody2D component required to use 2D Physics.
    public GameObject bullet;
    public float bulletDelay;
    public GameObject explosion;

    private float health;
    public float MaxHealth;

    private float lastBullet = 0;

    void Start()
    {
        health = MaxHealth;
        GameObject.Find("HUD_HP").GetComponent<Text>().text = "HP: " + health + " / " + MaxHealth;
    }

    //FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
    void FixedUpdate()
    {
        //Store the current horizontal input in the float moveHorizontal.
        float moveHorizontal = Input.GetAxis("Horizontal");

        //Store the current vertical input in the float moveVertical.
        float moveVertical = Input.GetAxis("Vertical");
        bool shootbutton = Input.GetButton("Fire1");


        //Use the two store floats to create a new Vector2 variable movement.
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        //Call the AddForce function of our Rigidbody2D rb2d supplying movement multiplied by speed to move our player.
        rb2d.AddForce(movement * speed);

        var pos = Camera.main.WorldToScreenPoint(transform.position);
        var dir = Input.mousePosition - pos;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        if (shootbutton && lastBullet + bulletDelay < Time.time)
        {
            GameObject projectile = Instantiate(bullet, transform.position, new Quaternion(0, 0, 0, 0));
            dir.Normalize();
            projectile.GetComponent<Rigidbody2D>().AddForce(dir * bulletspeed);
            projectile.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            lastBullet = Time.time;
        }
    }
    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }

    void ApplyDamage(float damage)
    {
        health -= damage;
        GameObject.Find("HUD_HP").GetComponent<Text>().text = "HP: " + health + " / " + MaxHealth;
        if (health <= 0)
        {
            Destroy(this.gameObject);
            Instantiate(explosion, transform.position, new Quaternion());

        }
    }
}
