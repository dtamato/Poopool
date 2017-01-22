using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[DisallowMultipleComponent]
[RequireComponent(typeof(Collider2D))]
public class TeamArea : MonoBehaviour {

	[SerializeField] Image fillBar;
    [SerializeField] bool isTeam1;
    float fillRate = 0;
    GameManager gameManager;

    void Start ()
    {
        gameManager = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameManager>();

        if(fillBar)
        {
            fillBar.fillAmount = 0;
        }
    }

    void Update ()
    {
        if (fillBar.fillAmount < 1)
        {
            if (gameManager.isGameRunning) {

                fillBar.fillAmount += fillRate;

                if (fillBar.fillAmount >= 1)
                {
                    gameManager.SetWinner(isTeam1);
                }
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
