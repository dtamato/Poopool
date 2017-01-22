using UnityEngine;
using System.Collections;

[DisallowMultipleComponent]
[RequireComponent(typeof(Collider2D), typeof(Rigidbody2D))]
public class FillModifier : MonoBehaviour {

    [SerializeField] float fillAddition = 0.0001f;
	[SerializeField] float pooHealth = 5;
	void OnCollisionEnter2D(Collision2D other)
    {
        if(other.transform.CompareTag("Player"))
        {
            // TODO: Stun Player
        }
    }

	void Update()
	{
		pooHealth -= Time.deltaTime;
		if (pooHealth <= 0) {
		}
			
			//Destroy (this.gameObject);
	}
    
    public void ShakePoop ()
    {
        this.GetComponentInChildren<Animator>().SetTrigger("Shake");
    }

    public float GetFillRate()
    {
        return fillAddition;
    }
}
