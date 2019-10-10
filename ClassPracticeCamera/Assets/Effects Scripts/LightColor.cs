using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightColor : MonoBehaviour
{
	public Light myLighht;
	public float speed = 1.0f;
	public Color firstColor;
	public Color secondColor;
	public bool isColor;
	public float startTime;

    // Start is called before the first frame update
    void Start()
    {
		startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
		if (isColor)
		{
			float t = Mathf.Sin(Time.time - startTime) * speed;
			myLighht.color = Color.Lerp(firstColor, secondColor, t);
        }
        else
        {
            myLighht.color = firstColor;
            startTime = Time.time;
        }
        
    }
}
