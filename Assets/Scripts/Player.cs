using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private static Player instance;

    private Vector2 move;

    public GameObject Camera;


    [SerializeField]
    private float speed;

    private void Start()
    {
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

    private void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        move = new Vector2(x, y).normalized;

        transform.Translate(move * speed * Time.fixedDeltaTime);

        Camera.transform.position = transform.position - new Vector3(0, 0, 10);


    }       
}
