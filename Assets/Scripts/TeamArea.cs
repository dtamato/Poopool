using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[DisallowMultipleComponent]
[RequireComponent(typeof(Collider2D))]
public class TeamArea : MonoBehaviour {

	[SerializeField] Image fillBar;

    float fillRate = 0;

    void Start ()
    {
        if(fillBar)
        {
            fillBar.fillAmount = 0;
        }
    }

    void Update ()
    {
        if (fillBar.fillAmount < 1)
        {
            fillBar.fillAmount += fillRate;

            if(fillBar.fillAmount == 1)
            {
                Debug.Log("Game ended!");
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("FillModifier"))
        {
            fillRate += other.GetComponent<FillModifier>().GetFillRate();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("FillModifier"))
        {
            fillRate -= other.GetComponent<FillModifier>().GetFillRate();
        }
    }
}
