using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Rigidbody rb;
    float speed = 35f;
    Vector3 lastVelocity;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        StartCoroutine(shootBall());
    }

    // Update is called once per frame
    void Update()
    {
        lastVelocity = rb.velocity;
    }
    IEnumerator shootBall() {
        yield return new WaitForSeconds(3f);
        //Shoots the ball to radom player
        float dir = Random.Range(0f, 1f);
    
        if (dir < 0.5f)
        {
            dir = -1f;
        }
        else
        {
            dir = 1f;
        }
        rb.AddForce(new Vector3(Random.Range(-0.2f, 0.2f), 0, dir * speed), ForceMode.Impulse);
    }
    private void OnCollisionEnter(Collision collision)
    {
        var speed = lastVelocity.magnitude;
        var direction = Vector3.Reflect(lastVelocity.normalized, collision.contacts[0].normal);
        rb.velocity = direction * Mathf.Max(speed, 0f);
    }
}
