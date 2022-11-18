using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private Rigidbody2D _rigidBody;
    [SerializeField] private float _collisionOffset = 0.05f;

    private Vector2 _movementInput;
    private ContactFilter2D _movementFilter;
    private List<RaycastHit2D> _castCollisions = new List<RaycastHit2D>();
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;

    // Animation Hashes

    public static int IdleHorizontalAnimation;
    public static int IdleUpAnimation;
    public static int IdleDownAnimation;
    public static int MoveHorizontalAnimation;
    public static int MoveUpAnimation;
    public static int MoveDownAnimation;

    void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    // MOVEMENT

    // Update is called once per frame
    void FixedUpdate() 
    {
        if (_movementInput != Vector2.zero) // So it doesn't cast every update
        {
            bool couldMove = TryMove(_movementInput);

            if (!couldMove)
                TrySlideInDiagonalCollision();
        }
    }

    // gets input for movement
    private void OnMove(InputValue movementValue)
    {
        _movementInput = movementValue.Get<Vector2>();
    }

    // Diagonal collision (THIS CODE IS FROM A SIMPLE PROTOTYPE I WORKED ON)
    private void TrySlideInDiagonalCollision()
    {
        bool couldSlide = TryMove(new Vector2(_movementInput.x, 0));

        if (!couldSlide)
            TryMove(new Vector2(0, _movementInput.y));
    }

    // Moves character (THIS CODE IS FROM A SIMPLE PROTOTYPE I WORKED ON)
    private bool TryMove(Vector2 direction)
    {
        if (direction != Vector2.zero)
        {
            int count = _rigidBody.Cast(
                  direction,
                  _movementFilter,
                  _castCollisions,
                  _moveSpeed * Time.fixedDeltaTime + _collisionOffset);

            if (count == 0)
            {
                _rigidBody.MovePosition(_rigidBody.position + _movementInput * _moveSpeed * Time.fixedDeltaTime);
                return true;
            }
            else
                return false;
        }
        else
            return false;
    }

    // ANIMATION
    private void OverrideAnimatorHashes()
    {
    }

    private void ChooseMovementAnimation()
    {

    }

    private void FlipSprite()
    {
        if (_movementInput.x < 0)
            _spriteRenderer.flipX = true;
        else if ((_movementInput.x > 0))
            _spriteRenderer.flipX = false;
    }
}
