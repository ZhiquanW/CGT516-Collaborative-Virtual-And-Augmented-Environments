using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetObjController : MonoBehaviour {
    public bool isTarget;
    public bool isDone;
    public Color targetObjColor;
    public Color previousColor;
    public Color doneColor;
    public float colorChangeSpeed;
    public MeshRenderer[] renderers;
    // Start is called before the first frame update
    void Start() {
        previousColor = renderers[0].material.color;
    }

    // Update is called once per frame
    void Update() {
        if (isTarget) {
            foreach(var render in renderers) {
                render.material.color = Color.Lerp(render.material.color,targetObjColor * Mathf.Abs(Mathf.Cos(Time.time))*targetObjColor, colorChangeSpeed);
            }
        } else if(isDone){
            foreach (var render in renderers) {
                render.material.color = Color.Lerp(render.material.color, doneColor, colorChangeSpeed);
            }
        }
    }
}
