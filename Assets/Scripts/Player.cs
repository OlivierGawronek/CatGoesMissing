using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private static Player instance;

    private Vector2 move;

    public GameObject Camera;

    [SerializeField]
    private Camera Cam;

    public GameObject Crosshair;

    private bool isWalking = true;

    [SerializeField]
    private float speed;

    [SerializeField]
    private float runSpeed;

    [HideInInspector]
    public StaminaController _staminaController;

    public void SetRunSpeed(float s)
    {
        s = speed;
    }


    private void Start()
    {
        _staminaController = GetComponent<StaminaController>();

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

        if(isWalking)
        {
            _staminaController.isSprinting = false;
            
        }

        if(!isWalking)
        {
            if(_staminaController.playerStamina > 0)
            {
                _staminaController.isSprinting = true;
                _staminaController.Sprinting();
            }
            else
            {
                isWalking = true;
            }
        }



        transform.Translate(move * speed * Time.fixedDeltaTime);

        Camera.transform.position = transform.position - new Vector3(0, 0, 10);

        Crosshair.transform.position = Cam.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0, 0, 10);
    }
    
}
