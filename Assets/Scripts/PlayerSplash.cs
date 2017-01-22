using UnityEngine;
using System.Collections;

[DisallowMultipleComponent]
public class PlayerSplash : MonoBehaviour {

    [SerializeField] float splashForce = 20f;
    [SerializeField] float moveSpeed = 1;
    [SerializeField] float lifetime = 1;

    Rigidbody2D rb2d;

    void Start ()
    {
        rb2d = this.GetComponent<Rigidbody2D>();
        Destroy(this.gameObject, lifetime);
    }

    void Update ()
    {
        //this.transform.Translate(moveSpeed * Vector3.up * Time.deltaTime);
        rb2d.MovePosition((Vector2)this.transform.position + moveSpeed * (Vector2)this.transform.right * Time.deltaTime);
    }

	void OnTriggerEnter2D(Collider2D other)
    {
        if(other.transform.CompareTag("FillModifier"))
        {
            other.GetComponentInChildren<FillModifier>().ShakePoop();
            Vector3 splashDirection = other.transform.position - this.transform.position;
            other.GetComponent<Rigidbody2D>().AddForce(splashForce * splashDirection, ForceMode2D.Impulse);
            this.GetComponent<Collider2D>().enabled = false;
        }
    }
}
