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
	public bool vibrate;

	[SerializeField]public float angle;
	[SerializeField]public float period = 1f;
	private float _Time = 1;

	public GameObject bar;
	public GameObject barFill;


	public bool isFilling = false;

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
				isFilling = true;
				Debug.Log (isFilling);

                if (fillBar.fillAmount >= 1)
                {
                    gameManager.SetWinner(isTeam1);
                }
            }

			if (fillRate <= 0)
			{
				isFilling = false;
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
