using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace TestExtenject
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 2;
        [SerializeField] private float jumpHeight = 2;
        [SerializeField] private Rigidbody2D rb;
        [SerializeField] private LayerMask groundLayer;

        private ScoreManager scoreManager;

        [Inject]
        private void Construct(ScoreManager _scoreManager)
        {
            scoreManager = _scoreManager;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Coin"))
            {
                Destroy(collision.gameObject);
                scoreManager.IncreaseScore();
            }
        }

        void Update()
        {
            Move();
        }

        private void Move()
        {
            rb.linearVelocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, rb.linearVelocity.y);

            if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
            {
                rb.AddForce(new Vector2(0, jumpHeight), ForceMode2D.Impulse);
            }
        }

        private bool IsGrounded()
        {
            return Physics2D.BoxCast(transform.position, Vector2.one * 0.2f, 0, transform.up * -1, 1, groundLayer);
        }
    }
}
