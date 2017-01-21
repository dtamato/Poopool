using UnityEngine;
using System.Collections;

[DisallowMultipleComponent]
[RequireComponent(typeof(Collider2D), typeof(Rigidbody2D))]
public class FillModifier : MonoBehaviour {

    [SerializeField] float fillAddition = 0.0001f;

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.transform.CompareTag("Player"))
        {
            // TODO: Stun Player
        }
    }
    
    public float GetFillRate()
    {
        return fillAddition;
    }
}
