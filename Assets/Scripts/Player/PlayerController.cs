using System;
using UnityEngine;
using UnityEngine.InputSystem;

/*
    It's my firts time using InputSystem, so i write some notes for me to underset
    better this script.
*/

namespace Assets.Scripts.Player
{
    public class PlayerController : MonoBehaviour
    {
        // ================================================== FIELDS ==================================================
        [SerializeField] private InputActionAsset m_inputActions; // This is to "collect" all actions to be use it
        [SerializeField] private float m_moveSpeed;
        [SerializeField] private float m_rotateSpeed;
        [SerializeField] private float m_jumpSpeed;
        // With InputAction, can take the map action
        private InputAction m_moveAction;
        private InputAction m_jumpAction;
        private InputAction m_lookAction;
        private Rigidbody m_rigidbodyPlayer;
        private Vector2 m_moveXY;
        private Vector2 m_lookXY;

        // ================================================== PRIVATE METHODS ==================================================
        // This is necesarry to find all action map and activate it
        private void Onnable()
        {
            m_inputActions.FindActionMap("Player").Enable();
        }

        private void OnDisable()
        {
            m_inputActions.FindAction("Player").Enable();
        }

        private void Awake()
        {
            m_moveAction = InputSystem.actions.FindAction("Move");
            m_lookAction = InputSystem.actions.FindAction("Look");
            m_jumpAction = InputSystem.actions.FindAction("Jump");
        }
    }
}