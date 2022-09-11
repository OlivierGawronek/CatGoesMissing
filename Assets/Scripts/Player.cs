using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private static Player instance;

    private Vector2 move;

    public float health;

    public GameObject Camera;

    [SerializeField]
    private Camera Cam;

    public GameObject Crosshair;

    private bool isWalking = true;

    [SerializeField]
    private float speed;

    [SerializeField]
    private float runSpeed;


    public void SetRunSpeed(float s)
    {
        s = speed;
    }


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

        Cursor.visible = false;
    }

    private void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        move = new Vector2(x, y).normalized;


        isWalking = !Input.GetKey(KeyCode.LeftShift);

        transform.Translate(move * speed * Time.fixedDeltaTime);

        Camera.transform.position = transform.position - new Vector3(0, 0, 10);

        Crosshair.transform.position = Cam.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0, 0, 10);

        Vector3 mousePosition = Cam.ScreenToWorldPoint(Input.mousePosition);
    }


    
}
