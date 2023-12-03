using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candy : MonoBehaviour
{
    public float speed;
    public float newSpeed;
    private Rigidbody2D rb;
    private Pooler pool;
    [SerializeField] private AudioSource punch;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        pool = transform.parent.GetComponent<Pooler>();
        
    }

    private void OnEnable()
    {
        StartCoroutine(DestroyCandy());
    }

    IEnumerator DestroyCandy()
    {
        yield return new WaitForSeconds(8f);
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
            speed = 0;
            rb.gravityScale = 3f;
        }

        if (other.gameObject.CompareTag("Punch"))
        {
            Quaternion target = Quaternion.Euler(transform.rotation.x,transform.rotation.y,-90f);
            transform.rotation = target;
            speed = -5f;
            rb.gravityScale = 3f;
            punch.Play();
        }
    }
}
