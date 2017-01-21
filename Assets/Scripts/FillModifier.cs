using UnityEngine;
using System.Collections;

[DisallowMultipleComponent]
[RequireComponent(typeof(Collider2D), typeof(Rigidbody2D))]
public class FillModifier : MonoBehaviour {

    [SerializeField] float fillAddition = 0.0001f;

    public float GetFillRate()
    {
        return fillAddition;
    }
}
