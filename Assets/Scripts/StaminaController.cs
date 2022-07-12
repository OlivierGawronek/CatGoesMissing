using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaController : MonoBehaviour
{
    [Header("Stamina Glowne Parametry")]
    public float playerStamina = 100f;
    [SerializeField] private float maxStamina = 100f;
    [HideInInspector] public bool hasRegenerated = true;
    [HideInInspector] public bool isSprinting = false;

    [Header("Stamina Regeneracja Parametry")]
    [Range(0, 50)] [SerializeField] private float staminaDrain = 0.5f;
    [Range(0, 50)] [SerializeField] private float staminaRegen = 0.5f;

    [Header("Stamina Szybkosc Parametry")]
    [SerializeField] private int slowedSpeed = 4;
    [SerializeField] private int normalSpeed = 6;

    [Header("Stamina UI Parametry")]
    [SerializeField] private Image staminaProgressUI = null;
    [SerializeField] private CanvasGroup sliderGroup = null;

    private Player _player;

    private void Start()
    {
        _player = GetComponent<Player>();
    }

    private void Update()
    {
        if (!isSprinting)
        {
            if (playerStamina <= maxStamina - 0.01f)
            {
                playerStamina += staminaRegen * Time.deltaTime;
                UpdateStamina(1);

                if (playerStamina >= maxStamina)
                {
                    _player.SetRunSpeed(normalSpeed);
                    sliderGroup.alpha = 0;
                    hasRegenerated = true;
                }
            }
        }
    }

    public void Sprinting()
    {
        if (hasRegenerated)
        {
            isSprinting = true;
            playerStamina -= staminaDrain * Time.deltaTime;
            UpdateStamina(1);

            if (playerStamina <= 0)
            {
                hasRegenerated = false;
                _player.SetRunSpeed(slowedSpeed);
                sliderGroup.alpha = 0;
            }
        }
    }
    void UpdateStamina(int value)
    {
        staminaProgressUI.fillAmount = playerStamina / maxStamina;

            if (value == 0)
            {
                sliderGroup.alpha = 0;
            }
            else
            {
                sliderGroup.alpha = 1;
            }
    }
}
