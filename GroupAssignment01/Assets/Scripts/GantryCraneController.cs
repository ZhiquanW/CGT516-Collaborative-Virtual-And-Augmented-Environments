using System;
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
    public AudioSource backgroundSource;
    Audio(AudioClip[] audios) {
        this.audios = audios;
    }
}
public class GantryCraneController : MonoBehaviour {

    public static GantryCraneController instance;
    public bool isEngineOn;
    public GameObject[] arms;
    public Vector2 armLenConstraint;
    public float moveSpeed = 0.0f;
    public float liftSpeeed = 0.0f;
    public Audio craneAudio;
    public GameObject frontHandPole;
    public GameObject frontHand;
    public GameObject backHandPole;
    public GameObject backHand;
    public Vector2 handRange; 
    public bool isEngineIgnited;
    public float engineTimer;

    public HandDetector[]  detectors;
    public GameObject caughtCargo;
    public Transform refTransform;
    public Vector3 offsetPos;
    public bool isLock;

    private void Awake() {
        instance = this;
    }

    // Start is called before the first frame update
    void Start() {
    }

    // Update is called once per frame
    void Update() {
        if (isEngineIgnited) {
            engineTimer += Time.deltaTime;
            GameManager.instance.cockpit.LiftCockpit();
            if (engineTimer > 7) {
                isEngineOn = true;
                isEngineIgnited = false;
            }
        }
        if (isEngineOn) {
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");
            float s = Input.mouseScrollDelta.y;
            Vector2 ss = OVRInput.Get(OVRInput.RawAxis2D.RThumbstick);
            s = ss.y;
            MoveCrane(h);   
            LiftArms(-v);
            SlideHands(s);
            engineTimer += Time.deltaTime;
        }
        else {
            if (Input.GetKeyDown(KeyCode.E) || OVRInput.GetDown(OVRInput.RawButton.A)) {
                StartEngine();
                isEngineIgnited = true;
            }
        }

        isLock = detectors[0].isAttachCargo && detectors[1].isAttachCargo &&
                  detectors[0].targetCargo == detectors[1].targetCargo;
        if (isLock) {
            catchCargo();
        }
       
    }

    void StartEngine() {
        craneAudio.audioSource.clip = craneAudio.audios[(int) Audio.Index.StartEngine]; 
        craneAudio.audioSource.Play();
        craneAudio.backgroundSource.clip = craneAudio.audios[(int) Audio.Index.Common];
        craneAudio.backgroundSource.volume = 0.3f;
        craneAudio.backgroundSource.Play();

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
            foreach (var hinge in hinges) {
                hinge.anchor = new Vector3(0.0f, -2.0f, -0.0f);
            }
        }

        if (Mathf.Abs(_p)<0.01f ) {
            craneAudio.audioSource.Stop();
            craneAudio.backgroundSource.volume = 1f;
        }
        else {
            craneAudio.audioSource.clip = craneAudio.audios[(int) Audio.Index.LiftArms];
            craneAudio.audioSource.volume = Mathf.Abs(_p);
            if (!craneAudio.audioSource.isPlaying) {
                craneAudio.audioSource.Play();
                craneAudio.backgroundSource.volume = 0.6f;
            }
        }

    }

    void SlideHands(float _y) {
        float tmpLen = frontHandPole.transform.localScale.z;
        if (isLock && _y > 0) {
            return;
        }
        if ((tmpLen < handRange.x && _y > 0) ||
            (tmpLen > handRange.y && _y < 0) ||
            (handRange.x <= tmpLen && tmpLen <= handRange.y)) {
            frontHandPole.transform.localScale += _y * Time.deltaTime * Vector3.forward;
            backHandPole.transform.localScale += _y * Time.deltaTime * Vector3.forward;
            frontHand.transform.position += _y * Time.deltaTime * Vector3.forward;
            backHand.transform.position -= _y * Time.deltaTime * Vector3.forward;

        }
    }

    void catchCargo() {
        caughtCargo.GetComponent<Rigidbody>().isKinematic = true;
        caughtCargo.transform.position = refTransform.position + offsetPos;
    }

    public void dropCargo() {
        caughtCargo.GetComponent<Rigidbody>().isKinematic = false;
    }
}
