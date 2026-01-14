using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Scripts.Player
{
    public class PlayerController : MonoBehaviour
    {
        // ================================================== FIELDS ==================================================
        [SerializeField] private InputActionAsset m_inputActions;
        [SerializeField] private float m_moveSpeed;
        [SerializeField] private float m_rotateSpeed;
        [SerializeField] private float m_jumpSpeed;

        private InputAction m_moveAction;
        private InputAction m_jumpAction;
        private InputAction m_lookAction;
        private Vector2 m_moveXY;
        private Vector2 m_lookXY;
    }
}