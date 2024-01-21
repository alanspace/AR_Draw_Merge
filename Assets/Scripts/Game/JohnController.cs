using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JohnController : MonoBehaviour
{
    Rigidbody2D rigidbody;
    bool canJump = false;
    bool gameOver = false;

    private void Awake() {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver)
            return;


        if (Input.GetKeyDown(KeyCode.Space) && canJump) {
            rigidbody.AddForce(Vector2.up * 100);
            canJump = false;
        }

        Vector2 newVelocity = rigidbody.velocity;
        if (Input.GetKey(KeyCode.RightArrow)) {
            if (rigidbody.velocity.x < 0)
                newVelocity.x = -0;
            rigidbody.velocity = newVelocity;
            rigidbody.AddForce(Vector2.right * Time.deltaTime * 180);
        } else if (Input.GetKey(KeyCode.LeftArrow)) {
            if (rigidbody.velocity.x > 0)
                newVelocity.x = 0;
            rigidbody.velocity = newVelocity;
            rigidbody.AddForce(Vector2.left * Time.deltaTime * 180);
        }

        Vector2 newPosition = transform.localPosition;
        if (transform.localPosition.x >= 9) {
            newPosition.x = -9;
        } else if (transform.localPosition.x <= -9) {
            newPosition.x = 9;
        }
        transform.localPosition = newPosition;
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.contacts.Length > 0) {
            ContactPoint2D contact = collision.contacts[0];
            if (Vector3.Dot(contact.normal, Vector3.up) > 0.5) {
                canJump = true;
                if (collision.gameObject.name.StartsWith("P")) {
                    GameController.instance.TouchedPlatform(collision.gameObject.name);
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.name == "GameOver colider") {
            GameController.instance.GameOver();
            gameOver = true;
        }
    }
}
