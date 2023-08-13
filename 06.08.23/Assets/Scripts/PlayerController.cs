using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    public float jumpForce;
    public float gravityModifier;

    private bool isGrounded;
    private Vector3 originalGravity;

    public bool gameOver = false;

    private Animator anim;

    public GameObject CanvasUI;

    public ParticleSystem deathEffect;
    public ParticleSystem runEffect;

    private GameManager gameManager;
    private float point = 1f;

    public int maxJumps = 2;
    private int jumps;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        gameManager=GameObject.FindObjectOfType<GameManager>();
        originalGravity = Physics.gravity;
        Physics.gravity *= gravityModifier;
    }

    void ResetGravity()
    {
        Physics.gravity = originalGravity;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && /*isGrounded &&*/ !gameOver)
        {
            this.Jump();
            //rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            //isGrounded = false;
            //anim.SetTrigger("Jump_trig");
            //runEffect.Stop();
        }
    }

    private void Jump()
    {
        if (jumps > 0)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
            anim.SetTrigger("Jump_trig");
            runEffect.Stop();
            jumps = jumps - 1;
        }
        if (jumps == 0)
        {
            return;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Money"))
        {
            Destroy(other.gameObject);
            gameManager.AddScore(5);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            jumps = maxJumps;
            isGrounded = true;
            runEffect.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            anim.SetBool("Death_b", true);
            anim.SetInteger("DeathType_int", 1);
            Debug.Log("Oyun Bitti!");
            CanvasUI.SetActive(true);
            ResetGravity();
            runEffect.Stop();
            deathEffect.Play();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
        runEffect.Stop();
    }
}
