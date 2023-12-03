using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : MonoBehaviour
{
    public float speed;
    public float newSpeed;
    private Rigidbody2D rb;
    private Animator animator;
    [SerializeField] private AudioSource punch;
    private Pooler pool;
    


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        pool = transform.parent.GetComponent<Pooler>();
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        StartCoroutine(DestroyCandy());
    }

    IEnumerator DestroyCandy()
    {
        yield return new WaitForSeconds(8.9f);
        transform.rotation = Quaternion.identity;
        transform.position = Vector3.zero;
        speed = newSpeed;
        rb.gravityScale = 0f;
       
        pool.ReturnObject(gameObject);
    }

    void Update()
    {
        transform.position += Vector3.right * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Hand"))
        {
            Quaternion target = Quaternion.Euler(transform.rotation.x,transform.rotation.y,-90f);
            transform.rotation = target;
            animator.SetBool("IsAttack",true);
            speed = 0;
            rb.gravityScale = 3f;
        }

        if (other.gameObject.CompareTag("Punch"))
        {
            speed = -5f;
            animator.SetBool("IsAttack",true);
            StartCoroutine(NewSpeed(1f));
            punch.Play();
        }
    }

    private IEnumerator NewSpeed(float delay)
    {
        yield return new WaitForSeconds(delay);

        speed = newSpeed - 1f;
        animator.SetBool("IsAttack",false);
    }
}
