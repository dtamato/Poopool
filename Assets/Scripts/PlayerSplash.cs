using UnityEngine;
using System.Collections;

[DisallowMultipleComponent]
public class PlayerSplash : MonoBehaviour {

    [SerializeField] float splashForce = 20f;
    [SerializeField] float moveSpeed = 1;
    [SerializeField] float lifetime = 1;

    void Start ()
    {
        Destroy(this.gameObject, lifetime);
    }

    void Update ()
    {
        this.transform.Translate(moveSpeed * Vector3.up * Time.deltaTime);
    }

	void OnTriggerEnter2D(Collider2D other)
    {
        if(other.transform.CompareTag("FillModifier"))
        {
            other.GetComponent<Rigidbody2D>().AddForce(splashForce * other.transform.up, ForceMode2D.Impulse);
            Destroy(this.gameObject);
        }
    }
}
