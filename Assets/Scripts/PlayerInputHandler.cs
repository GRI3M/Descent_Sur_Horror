using UnityEngine;
using UnityEngine.InputSystem;


namespace Player
{

    public class PlayerInputHandler : MonoBehaviour
    {
        public float LookSensitivity = 1f;

        PlayerCharacterController PlayerCharacterController;

        private InputAction MoveAction;
        private InputAction LookAction;
        private InputAction JumpAction;
        private InputAction SprintAction;
        private InputAction CrouchAction;
        private InputAction InteractAction;
        private InputAction PauseAction;
        private InputAction InventoryAction;
        private InputAction FireAction;
        private InputAction ReloadAction;
        private InputAction NextWeaponAction;


        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            PlayerCharacterController =  GetComponent<PlayerCharacterController>();
        }

        // Update is called once per frame
        void Update()
        {
            
        }
    }
}
