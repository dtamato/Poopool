using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waver : MonoBehaviour {
	private LineRenderer line;
	public Color c1 = Color.yellow;
	public Color c2 = Color.red;
	public int lengthOfLineRenderer = 20;

	// Use this for initialization
	void Start () {
		line = gameObject.AddComponent<LineRenderer>();
		line.material = new Material (Shader.Find ("Particles/Additive"));
		line.SetColors(c1, c2);
		line.SetWidth(0.02F, 0.02F);
		line.SetVertexCount(lengthOfLineRenderer);
	}



	// Update is called once per frame
	void Update () {
		int i = 0;
		//lengthOfLineRenderer++;
		while(i < lengthOfLineRenderer)
		{
			Vector3 pos = new Vector3 (i * 0.05f, this.transform.position.y + Mathf.Sin (i + Time.time), 0);
			line.SetPosition (i, pos);
			i++;
		}
	}
}
