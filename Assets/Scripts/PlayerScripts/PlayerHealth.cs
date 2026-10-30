using Unity.Cinemachine;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] public float Basehealth = 100f;
    [SerializeField] public CinemachineCamera deathCamera;
    [SerializeField] public Transform weaponsCamera;
    [SerializeField] public GameObject canvas;

    float currentHealth;
    int gameOverCamPriority = 20;

    void Awake()
    {
        currentHealth = Basehealth;
    }

    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;


        if(currentHealth <= 0)
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
            canvas.SetActive(false);
            Destroy(this.gameObject);
        }
    }

}