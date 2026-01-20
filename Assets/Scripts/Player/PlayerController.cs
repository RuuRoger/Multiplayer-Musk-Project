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
        [SerializeField] private InputActionReference m_moveAction;
        [SerializeField] private float m_speed = 5f;
        [SerializeField] private float m_speedRotation = 1.5f;
        private CharacterController m_characterController;
        private Vector2 m_moveInput;

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
        }

        private void OnDisable()
        {
            m_moveAction.action.Disable();
        }

        private void Update()
        {
            HandleMovement();
        }

        private void HandleMovement()
        {
          m_moveInput = m_moveAction.action.ReadValue<Vector2>();

          Vector3 movement = new Vector3(m_moveInput.x, 0f, m_moveInput.y);
          movement = transform.TransformDirection(movement);
          m_characterController.Move(movement * m_speed * Time.deltaTime);
        }

    }
}