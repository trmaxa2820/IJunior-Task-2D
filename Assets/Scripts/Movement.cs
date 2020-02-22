using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpPower;

    private Animator _animator;
    private SpriteRenderer _spriteRenderer2D;
    private Player _player;
    private bool _isGround;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer2D = GetComponent<SpriteRenderer>();
        _player = GetComponent<Player>();
    }

    private void Update()
    {
        if (_player.IsAlive())
        {
            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(_speed * Time.deltaTime, 0, 0);
                _spriteRenderer2D.flipX = false;
                _animator.SetTrigger("MoveRight");
            }

            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(-_speed * Time.deltaTime, 0, 0);
                _spriteRenderer2D.flipX = true;
                _animator.SetTrigger("MoveLeft");
            }

            if (Input.GetKeyDown(KeyCode.Space) && _isGround)
            {
                transform.Translate(0, _jumpPower * Time.deltaTime, 0);
                _isGround = false;
            }

            if (!Input.anyKey)
            {
                _animator.SetTrigger("Idle");
            }
        }
        else
        {
            Debug.Log("Player Dead");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            _isGround = true;
        }
        else
        {
            _isGround = false;
        }
    }
}
