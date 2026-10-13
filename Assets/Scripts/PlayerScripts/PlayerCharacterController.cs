using UnityEngine;
using UnityEngine.Events;


namespace Player
{
    public class PlayerCharacterController : MonoBehaviour
    {
        [Header("References")]
        public Camera PlayerCamera;

        [Header("General")]

        public float Gravity = 9.81f;
        public LayerMask GroundLayerMask = -1;
        

        [Header("Movement")]
        public float SprintSpeedMultiplier = 1.5f;
        public float CrouchSpeedMultiplier = 0.5f;

        [Header("Character Rotation")]

        [Range(0,1)]
        public float ADSSensitivityMultiplier = 0.5f;

        [Header("Character Heights")]
        public float CameraHeightRatio = .7f;
        public float CapsuleHeightStanding = 1.8f;
        public float CapsuleHeightCrouching = .9f;
        public float CrouchTransitionSpeed = 12f;
        
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            
        }
    }
}