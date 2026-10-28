using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] public float Basehealth = 100f;

    float currentHealth;

    void Awake()
    {
        currentHealth = Basehealth;
    }

    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;
        Debug.Log(damageAmount + " damage taken");


        if(currentHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }

}