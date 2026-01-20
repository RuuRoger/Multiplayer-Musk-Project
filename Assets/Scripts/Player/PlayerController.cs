using System;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

/*
    This is my first time workign with InputSytem, so this scrits takes some notes
*/

namespace Assets.Scripts.Player
{
    public class PlayerController : MonoBehaviour
    {
        // ================================================== FIELDS ==================================================
        //'Actions Map' about InputSystem
        private const float GRAVITY = -9.81f;
        [SerializeField] private InputActionReference m_moveAction;
        [SerializeField] private InputActionReference m_jumpAction;
        [SerializeField] private float m_speed = 5f;
        [SerializeField] private float m_speedRotation = 1.5f;
        [SerializeField] private float m_jumpForce = 5f;
        private CharacterController m_characterController;
        private Vector2 m_moveInput;
        private float m_verticalVelocity = 0f;

        // ================================================== METHODS ==================================================
        private void Awake()
        {
            m_characterController = GetComponent<CharacterController>();
        }

        /*
            Rembember that InputASystem works with events, so we must to suscribe it and unsuscribe it
        */
        private void OnEnable()
        {
            m_moveAction.action.Enable();
            m_jumpAction.action.Enable();
        }

        private void OnDisable()
        {
            m_moveAction.action.Disable();
            m_jumpAction.action.Disable();
        }

        private void Update()
        {
            HandleMovement();
        }

        private void HandleMovement()
        {
            m_moveInput = m_moveAction.action.ReadValue<Vector2>();
            Vector3 inputDirection = new Vector3(m_moveInput.x, 0f, m_moveInput.y);

            // This is "important" because control "accidental movement".
            if (inputDirection.sqrMagnitude > 0.1f)
            {
                // The method "TransformDirection()" transform direction from local space. ¡READ THE TOOLTIP IN INTELLISENSE!
                Vector3 moveDirection = transform.TransformDirection(inputDirection.normalized);

                Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, m_speedRotation * Time.deltaTime);
                m_characterController.Move(moveDirection * m_speed * Time.deltaTime);
            }
        }
    }
}