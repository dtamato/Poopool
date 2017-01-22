using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class AreaEffector : MonoBehaviour {

    AreaEffector2D areaEffector;

	void Awake ()
    {
        areaEffector = this.GetComponent<AreaEffector2D>();
    }

    IEnumerator ChangeForceDirection ()
    {
        areaEffector.forceAngle = Random.Range(0, 360f);

        yield return new WaitForSeconds(Random.Range(3, 5));

        StartCoroutine(ChangeForceDirection());
    }
}
