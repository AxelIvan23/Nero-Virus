using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

    public class SimplePlayerController : MonoBehaviour
    {
        public float movePower = 10f;
        public float jumpPower = 15f; //Set Gravity Scale in Rigidbody2D Component to 5

        private Rigidbody2D rb;
        private Animator anim;
        Vector3 movement;
        private int direction = 1;
        bool isJumping = false; 
        private bool alive = true;
        [SerializeField]
        private ManagerData data;
        [SerializeField]
        private GameObject gameEnd;
        [SerializeField] 
        private GameObject gameWon;
        [SerializeField] 
        private Transform controladorDisparo;
        [SerializeField] 
        private GameObject bola;
        [SerializeField] private GameObject mode1Container;

        [SerializeField] private float velocidadDash;
        [SerializeField] private float tiempoDash;
        private float gravedadinicial;
        private bool puedeHacerDash = true;
        private bool sepuedeMover = true;

        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            anim = GetComponent<Animator>();
            gravedadinicial = rb.gravityScale;
        }

        private void Update()
        {
            Restart();
            if (alive)
            {
                //Hurt();
                //Die();
                Attack();
                Jump();
                Run();
                if (Input.GetKeyDown(KeyCode.C) && puedeHacerDash && sepuedeMover)
                {
                    StartCoroutine(Dash());
                }
            }
        }
        private void OnTriggerEnter2D(Collider2D other) {
            anim.SetBool("isJump", false);
            if (other.tag == "Hit") {
                    Hurt();
                data.data.HP = data.data.HP -0.5f;
                if (data.data.HP<=0)
                    Die();
            }
            if (other.tag == "Message" || other.tag == "Terminal") {
                other.gameObject.transform.GetChild(0).gameObject.SetActive(true);
            }
            if (other.tag == "Portal") {
                SceneManager.LoadScene("Boss Harpy");
            }
            if (other.tag == "card") {
                gameWon.SetActive(true);
                Destroy(this);
            }
        }
        void OnTriggerStay2D(Collider2D other) {
            if (Input.GetKey ("e")) {
                if (other.tag == "Message") {
                    other.gameObject.transform.GetChild(0).gameObject.SetActive(false);
                    other.gameObject.GetComponent<DialogSystem>().enabled = true;
                    other.gameObject.GetComponent<Cinematic>().enabled = true;
                    other.gameObject.GetComponent<DialogSystem>().StartConversation(0);
                }
                if (other.tag == "Terminal") {
                    SceneManager.LoadScene("Level1 1");
                }
            }
        }
        void OnTriggerExit2D(Collider2D other) {
            if (other.tag == "Message" || other.tag == "Terminal") {
                other.gameObject.transform.GetChild(0).gameObject.SetActive(false);
            }
        }
        private void OnCollisionStay2D(Collision2D col) {
            if (col.gameObject.CompareTag("Ground")) {
                sepuedeMover = true;
            }
        }

        private IEnumerator Dash() {
            sepuedeMover = false;
            puedeHacerDash = false;
            rb.gravityScale = 0;

            if (Input.GetAxisRaw("Horizontal") < 0)
                rb.velocity = new Vector2(-velocidadDash, 0);
            if (Input.GetAxisRaw("Horizontal") > 0)
                rb.velocity = new Vector2(velocidadDash, 0);
            
            yield return new WaitForSeconds(tiempoDash);

            puedeHacerDash = true;
            rb.gravityScale = gravedadinicial;
        }

        void Run()
        {
            Vector3 moveVelocity = Vector3.zero;
            anim.SetBool("isRun", false);


            if (Input.GetAxisRaw("Horizontal") < 0)
            {
                direction = -1;
                moveVelocity = Vector3.left;
                transform.rotation = Quaternion.Euler(0,180,0);
                //transform.localScale = new Vector3(direction, 1, 1);
                if (!anim.GetBool("isJump"))
                    anim.SetBool("isRun", true);

            }
            if (Input.GetAxisRaw("Horizontal") > 0)
            {
                direction = 1;
                moveVelocity = Vector3.right;
                transform.rotation = Quaternion.Euler(0,0,0);
                //transform.localScale = new Vector3(direction, 1, 1);
                if (!anim.GetBool("isJump"))
                    anim.SetBool("isRun", true);

            }
            transform.position += moveVelocity * movePower * Time.deltaTime;
        }
        void Jump()
        {
            if ((Input.GetButtonDown("Jump") || Input.GetAxisRaw("Vertical") > 0)
            && !anim.GetBool("isJump"))
            {
                isJumping = true;
                anim.SetBool("isJump", true);
            }
            if (!isJumping)
            {
                return;
            }

            rb.velocity = Vector2.zero;

            Vector2 jumpVelocity = new Vector2(0, jumpPower);
            rb.AddForce(jumpVelocity, ForceMode2D.Impulse);

            isJumping = false;
        }
        void Attack()
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                anim.SetTrigger("attack");
                if (data.data.mode==1)
                    Instantiate(bola, controladorDisparo.position, controladorDisparo.rotation, mode1Container.transform);
                else
                    Instantiate(bola, controladorDisparo.position, controladorDisparo.rotation);
            }
        }
        void Hurt()
        {
            //if (Input.GetKeyDown(KeyCode.Alpha2)) {
                anim.SetTrigger("hurt");
                if (direction == 1)
                    rb.AddForce(new Vector2(-5f*transform.localScale.x, 1f*transform.localScale.y), ForceMode2D.Impulse);
                else
                    rb.AddForce(new Vector2(5f*transform.localScale.x, 1f*transform.localScale.x), ForceMode2D.Impulse);
            //}
        }
        void Die() {
            anim.SetTrigger("die");
            gameEnd.SetActive(true);
        }
        void Restart()
        {
            if (Input.GetKeyDown(KeyCode.Alpha0))
            {
                anim.SetTrigger("idle");
                alive = true;
            }
        }
    }
