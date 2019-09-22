using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Audio {
    public  enum Index {
        StartEngine = 0,
        LiftArms = 1,
        Common = 2
    }
    public AudioClip[] audios;
    public AudioSource audioSource;
    Audio(AudioClip[] audios) {
        this.audios = audios;
    }
}
public class GantryCraneController : MonoBehaviour {


    public bool isEngineOn;
    public GameObject[] arms;
    public Vector2 armLenConstraint;
    public float moveSpeed = 0.0f;
    public float liftSpeeed = 0.0f;
    public Audio craneAudio;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {

        if (isEngineOn) {
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");
            float s = Input.mouseScrollDelta.y;
            MoveCrane(h);   
            LiftArms(v);
        }
        else {
            if (Input.GetKeyDown(KeyCode.E)) {
                StartEngine();
                isEngineOn = true;
            }
          
        }
      
    }

    void StartEngine() {
        craneAudio.audioSource.clip = craneAudio.audios[(int) Audio.Index.StartEngine];
        craneAudio.audioSource.Play();
        if (craneAudio.audioSource.time > 4) {
            Debug.Log("11");
            craneAudio.audioSource.clip = craneAudio.audios[(int) Audio.Index.Common];
            craneAudio.audioSource.Play();
        }
    }
    void MoveCrane(float _p) {
        this.transform.Translate(new Vector3(_p * moveSpeed * Time.deltaTime, 0.0f, 0.0f));
    }

    void LiftArms(float _p) {
        float armLen = this.arms[0].transform.localScale.y;
        HingeJoint[] hinges = new[] {arms[0].GetComponent<HingeJoint>(), arms[1].GetComponent<HingeJoint>()};
        if ((armLen < armLenConstraint.x && _p > 0) ||
            (armLen > armLenConstraint.y && _p < 0) ||
            (armLen >= armLenConstraint.x && armLen <= armLenConstraint.y)) {
            foreach (var arm in arms) {
                arm.transform.localScale += _p *liftSpeeed* Time.deltaTime * Vector3.up;;
            }

            //Debug.Log(_p);
            foreach (var hinge in hinges) {
                hinge.anchor = new Vector3(0.0f, -2.0f, -0.0f);
            }
        }
    }

    void SlideArms(float _y) {
        
    }
}
