using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour {
    public string[] instructions = { "Connect the two green cubes together", "Press 'R' to rotate them", "Plug the key into the hole", "Press R to rotate!" };
    public Text instructionText;
    public int index;
    static public UIManager instance;
    void Awake() {
        instance = this;
    }
    // Start is called before the first frame update
    void Start() {
        index = 0;
    }

    // Update is called once per frame
    void Update() {

    }
    public void UpdateInstruction() {
        instructionText.text = instructions[index++];
    }
}
