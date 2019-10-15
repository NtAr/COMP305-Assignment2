using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;

namespace Hero
{
    public class HeroController : MonoBehaviour
    {
        public Animator animator;

        public SpriteRenderer spriteRenderer;

        public HeroAnimState heroAnimState;

        public Transform groundTarget;

        public Rigidbody2D playerrb2d;

        public bool grounded;
        public bool dead;

        public GameBounds bounds;

        public GameController controller;

        // Start is called before the first frame update
        void Start()
        {
            Reset();
            heroAnimState = HeroAnimState.IDLE;
            spriteRenderer.flipX = true;
        }

        // Update is called once per frame
        void Update()
        {
            Debug.DrawRay(transform.position, Vector2.down * 2, Color.yellow);

            //RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down * 2);

            //Debug.Log(hit.collider.gameObject.name);

            bool hit = Physics2D.Linecast(
                transform.position,
                groundTarget.position,
                1 << LayerMask.NameToLayer("ground"));

            bool die = Physics2D.Linecast(
                transform.position,
                groundTarget.position,
                1 << LayerMask.NameToLayer("water"));

            if (die)
            {
                dead = true;
            }

            if (hit)
            {
                grounded = true;
            }
            else
            {
                grounded = false;
            }
            // idle

            if (Input.GetAxis("Horizontal") == 0)
            {
                animator.SetInteger("AnimState", (int)HeroAnimState.IDLE);
                heroAnimState = HeroAnimState.IDLE;
            }

            // moving to the right
            if ((Input.GetAxis("Horizontal") > 0) && (grounded))
            {
                animator.SetInteger("AnimState", (int)HeroAnimState.WALK);
                heroAnimState = HeroAnimState.WALK;
                spriteRenderer.flipX = false;
                playerrb2d.AddForce(Vector2.right * 35.0f);
            }

            // moving to the left
            if ((Input.GetAxis("Horizontal") < 0) && (grounded))
            {
                animator.SetInteger("AnimState", (int)HeroAnimState.WALK);
                heroAnimState = HeroAnimState.WALK;
                spriteRenderer.flipX = true;
                playerrb2d.AddForce(Vector2.left * 35.0f);
            }

            // jumping
            if ((Input.GetAxis("Jump") > 0) && (grounded))
            {
                animator.SetInteger("AnimState", (int)HeroAnimState.JUMP);
                heroAnimState = HeroAnimState.JUMP;
                playerrb2d.AddForce(Vector2.up * 200.0f);
            }

            // not jumping
            if (Input.GetKeyUp(KeyCode.Space))
            {
                animator.SetInteger("AnimState", (int)HeroAnimState.IDLE);
                heroAnimState = HeroAnimState.IDLE;
            }

            if ((transform.position.y < bounds.TopBounds) || (dead))
            {
                Reset();
                controller.Lives -= 1;
                dead = false;
            }
        }


        
        private void OnTriggerEnter2D (Collider2D collision)
        {
            if (collision.gameObject.tag == "coin")
            {
                Destroy(collision.gameObject);
                controller.Score += 1;

            }
        }

        public void Reset()
        {
            transform.position = new Vector2(0.0f, 0.0f);
        }
    }
}
