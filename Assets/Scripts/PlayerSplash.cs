using UnityEngine;
using System.Collections;

[DisallowMultipleComponent]
public class PlayerSplash : MonoBehaviour {

    [SerializeField] float splashMoveSpeed = 0.1f;
    [SerializeField] float lifetime = 1;

    void Start ()
    {
        Destroy(this.gameObject, lifetime);
        this.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 50);
    }

	void OnCollisionEnter2D(Collision2D other)
    {
        if(other.transform.CompareTag("FillModifier"))
        {
            Destroy(this.gameObject);
        }
    }
}
