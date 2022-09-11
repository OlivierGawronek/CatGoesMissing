using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public static Shooting instance;

    public Rigidbody2D bullet;


    Player Player;
    private void Start()
    {
        Player = GetComponent<Player>();

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {

    }

    public void Shoot()
    {
        Rigidbody2D instatedBullet = Instantiate(bullet, transform.position, transform.rotation) as Rigidbody2D;

        instatedBullet.velocity = transform.TransformDirection(new Vector3(Player.transform.position.x, Player.transform.position.y, 0));

    }
}
