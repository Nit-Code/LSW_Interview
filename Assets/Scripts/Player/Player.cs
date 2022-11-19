using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Singleton<Player>
{
    private Rigidbody2D _rigidBody2D;

    private bool _isPlayerInputDisabled = false;
    [SerializeField] private Camera _mainCamera;

    public bool IsPlayerInputDisabled { get => _isPlayerInputDisabled; set => _isPlayerInputDisabled = value; }

    protected override void Awake()
    {
        base.Awake();

        _rigidBody2D = GetComponent<Rigidbody2D>();
    }


}
