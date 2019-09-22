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
    public AudioSource audioSound;
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

    public GameObject middlePole;
    public Vector2 middlePoleLenRange; 
    public GameObject frontHand;

    public GameObject backHand;
    // Start is called before the first frame update
    void Start() {
        PlayCraneBackground();
        craneAudio.audioSound.volume = 0;
    }

    // Update is called once per frame
    void Update() {
      
        if (isEngineOn) {
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");
            float s = Input.mouseScrollDelta.y;
            MoveCrane(h);   
            LiftArms(-v);
            SlideHands(s);
            //Set Crane Background Sound to 1 
            if (!craneAudio.audioSource.isPlaying) {
                craneAudio.audioSound.volume = 1;
            }
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
        craneAudio.audioSound.volume = 0.5f;
    }

    void PlayCraneBackground() {
        craneAudio.audioSound.clip = craneAudio.audios[(int) Audio.Index.Common];
        craneAudio.audioSound.Play();
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

    void SlideHands(float _y) {
        float tmpLen = middlePole.transform.localScale.y;
        if ((tmpLen < middlePoleLenRange.x && _y > 0) ||
            (tmpLen > middlePoleLenRange.y && _y < 0) ||
            (middlePoleLenRange.x <= tmpLen && tmpLen <= middlePoleLenRange.y)) {
            middlePole.transform.localScale += _y * Time.deltaTime * Vector3.up;
            frontHand.transform.position += 9*_y * Time.deltaTime * Vector3.up;
        }
    }
}
