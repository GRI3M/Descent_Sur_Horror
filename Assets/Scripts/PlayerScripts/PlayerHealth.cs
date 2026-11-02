using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [Header("Health Values")]
    [Range(1f,100f)][SerializeField] public float Basehealth = 100f;
    
    [Header("Pluggins")]
    [SerializeField] public CinemachineCamera deathCamera;
    [SerializeField] public Transform weaponsCamera;
    [SerializeField] public GameObject canvas;
    [SerializeField] public Image[] healthBar;

    //Private values
    float currentHealth;
    int gameOverCamPriority = 20;

    void Awake()
    {
        currentHealth = Basehealth;
        HandleHealthBarUpdate();
    }

    /// <summary>
    /// When the player uses a healing item, heal health up to max.
    /// Might update this to heal to a temp max where temp max degrades over time.
    /// </summary>
    /// <param name="healthAmount">The amount of health to replenish</param>
    public void HealDamage(float healthAmount)
    {
        if(currentHealth < Basehealth + healthAmount) currentHealth += healthAmount;
        else currentHealth = Basehealth;
        HandleHealthBarUpdate();
    }

    /// <summary>
    /// When the player takes damage, apply that damage.
    /// If the player dies, Kill player and disengage overlay
    /// </summary>
    /// <param name="damageAmount">The amount of damage taken from attack</param>
    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;
        HandleHealthBarUpdate();


        if(currentHealth <= 0)
        {
            SetUpDeathCamera();
            canvas.SetActive(false);
            Destroy(this.gameObject);
        }
    }

    /// <summary>
    /// Disengages the main camera and goes to the death camera which zooms out from where the player died
    /// Might update this to where the main camera doesn't have to be disengaged because the player gameobject
    /// won't be destroyed and instead will play a death animation.
    /// </summary>
    void SetUpDeathCamera()
    {
        Camera mainCamera = Camera.main;
        CinemachineBrain brain = mainCamera.GetComponent<CinemachineBrain>();
        CinemachineVirtualCameraBase outgoingCamera =
            brain.ActiveVirtualCamera as CinemachineVirtualCameraBase;

        float pullbackDistance = 3f;
        Vector3 deathCameraDestination = mainCamera.transform.position - mainCamera.transform.forward * pullbackDistance;
        deathCameraDestination.y += 1f;

        if (outgoingCamera != null && outgoingCamera != deathCamera)
        {
            outgoingCamera.Follow = null;
            outgoingCamera.LookAt = null;
            outgoingCamera.ForceCameraPosition(mainCamera.transform.position, mainCamera.transform.rotation);
        }

        weaponsCamera = null;
        deathCamera.LookAt = null;
        deathCamera.ForceCameraPosition(deathCameraDestination, mainCamera.transform.rotation);
        deathCamera.Priority = gameOverCamPriority;
    }

    /// <summary>
    /// Handles updating the health bar UI
    /// </summary>
    void HandleHealthBarUpdate()
    {
        int healthBars = (int) Mathf.Ceil(currentHealth / 10f);
        for(int i = 0; i < healthBar.Length; i++)
        {
            if(healthBars > i) healthBar[i].gameObject.SetActive(true);
            else healthBar[i].gameObject.SetActive(false);
        }   
    }

}