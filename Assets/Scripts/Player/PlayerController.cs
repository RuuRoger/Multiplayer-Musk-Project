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

            // Horizontal movement
            Vector3 moveDirection = Vector3.zero;
            if (inputDirection.sqrMagnitude > 0.1f)
            {
                moveDirection = transform.TransformDirection(inputDirection.normalized);
                Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, m_speedRotation * Time.deltaTime);
            }

            // Jump
            if (m_characterController.isGrounded)
            {
                if (m_verticalVelocity < 0) 
                {
                    m_verticalVelocity = -2f; // This force to stay in ground. Good tip.
                }

                if (m_jumpAction.action.triggered)
                {
                    m_verticalVelocity = m_jumpForce;
                }
            }
            m_verticalVelocity += GRAVITY * Time.deltaTime;

            // Horizontal + vertical movement
            Vector3 totalMove = (moveDirection * m_speed + Vector3.up * m_verticalVelocity) * Time.deltaTime;
            m_characterController.Move(totalMove);
        }
    }
}