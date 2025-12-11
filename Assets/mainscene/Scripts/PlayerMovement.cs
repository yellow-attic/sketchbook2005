using UnityEngine;


namespace sketchbook.map
{
    public class PlayerMovement : MonoBehaviour
    {
        [Header("Movement")]
        [SerializeField] private float moveSpeed = 5f;

        private Animator anim;
        private SpriteRenderer sr;

        private Vector2 input;


        void Start()
        {
            anim = GetComponent<Animator>();
            sr = GetComponent<SpriteRenderer>();
        }

        void Update()
        {
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical"); 

            Vector3 move = new Vector3(input.x, input.y, 0f).normalized;
            transform.Translate(move * moveSpeed * Time.deltaTime, Space.World);

            bool iswalking = move.sqrMagnitude > 0.01f;
            anim.SetBool("isWalking", iswalking);

            if (input.x > 0.1f) sr.flipX = true;
            if (input.x < -0.1f) sr.flipX = false;
        }

    }
}