using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    // Start is called before the first frame update
    public float maxHealth = 100;
    public float currenthealth;
    [SerializeField] private Gradient colorGradient;
    [SerializeField] private Image healthBarFill;
    [SerializeField] private GameController gameController;
    [SerializeField] private int damageAmount;
    [SerializeField] private float fillSpeed;
    [SerializeField] private Transform healthBarTransform;
    [SerializeField] private Sprite_change_script color;
    [SerializeField]private SpriteRenderer playerColor;
    public int damageTaken = 0;
    public int deaths = 0;

    AudioManager audioManager;

    private void Awake()
    {
        currenthealth = maxHealth;
        damageAmount = 30;
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void Update()
    {
        if (transform.localScale.x < 0) healthBarTransform.localScale = new Vector3(-0.003f, 0.004f, 1);
        else healthBarTransform.localScale = new Vector3(0.003f, 0.004f, 1);
        if(playerColor.color == color.squareColor[2]) UpdateHealthBar();
    }

    private void TakeDamage(float amount)
    {
        currenthealth -= amount;
        audioManager.PlaySFX(audioManager.takeDamage);
        currenthealth = Mathf.Clamp(currenthealth, 0, maxHealth);
        if (currenthealth <= 0)
        {
            gameController.Die();
            deaths++;
            currenthealth = maxHealth;
        }
        UpdateHealthBar();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("obstacle"))
        {
            TakeDamage(damageAmount);
            if (currenthealth < damageAmount) damageTaken += (int)currenthealth;
            else damageTaken += damageAmount;
        }
    }

    public void UpdateHealthBar()
    {
        float targetFillAmount = currenthealth / maxHealth;
        healthBarFill.fillAmount = targetFillAmount;
        healthBarFill.color = colorGradient.Evaluate(targetFillAmount);
    }
}
