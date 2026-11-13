using ItemScripts.WeaponScripts.GunScripts;
using Unity.VisualScripting;
using UnityEngine;
using StarterAssets;

public class PlayerInteraction : MonoBehaviour
{

    // [SerializeField] public LayerMask layerMask;
    [SerializeField] GameObject interactText;
    EquippedItem equippedItem;
    StarterAssetsInputs starterAssetsInputs;

    [SerializeField] float interactionRange = 2.5f;

    void Awake()
    {
        equippedItem = GetComponentInChildren<EquippedItem>();
        starterAssetsInputs = GetComponent<StarterAssetsInputs>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HandleInteraction();
    }

    void HandleInteraction()
    {
        RaycastHit hit;
   
        if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, interactionRange))
        {
            Pickups pickup = hit.collider.GetComponentInParent<Pickups>();
            if(pickup) interactText.SetActive(true);

            if(!starterAssetsInputs.interact) return;
            pickup?.PlayerPickupInteraction(equippedItem);
        }
        interactText.SetActive(false);
        starterAssetsInputs.InteractInput(false);
    }
}
