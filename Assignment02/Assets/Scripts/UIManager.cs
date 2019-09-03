using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour {
    public Button colorButton;
    public Button textureButton;
    public Slider sizeSilder;
    public Slider poxXSilder;
    public GameObject[] colorButtonPosList;
    public GameObject[] textureButtonPosList;
    public bool isSubColorHiden;
    public bool isSubTextureHiden;
    public Color[] colorList;
    public int colorChosen;
    public int textureChosen;
    public Sprite[] textureList;
    public bool activeReplace;
    void Awake() {
    }
    // Use this for initialization
    void Start() {
        isSubColorHiden = true;
        isSubTextureHiden = true;
        for (int i = 0; i < colorButtonPosList.Length; ++i) {
            colorButtonPosList[i].GetComponent<Image>().color = colorList[i];
        }
        for (int i = 0; i < textureButtonPosList.Length; ++i) {
            textureButtonPosList[i].GetComponent<Image>().sprite = textureList[i];
        }
    }

    // Update is called once per frame
    void Update() {

    }
    public void popupSubMenuColor() {
        if (isSubColorHiden) {
            for (int i = 0; i < colorButtonPosList.Length; ++i) {
                colorButtonPosList[i].SetActive(true);
                textureChosen = -1;
            }
        } else {
            for (int i = 0; i < colorButtonPosList.Length; ++i) {
                colorButtonPosList[i].SetActive(false);
                colorChosen = -1;

            }
        }
        isSubColorHiden = !isSubColorHiden;
    }
    public void popupSubMenuTexture() {
        if (isSubTextureHiden) {
            for (int i = 0; i < textureButtonPosList.Length; ++i) {
                textureButtonPosList[i].SetActive(true);
                colorChosen = -1;
                activeReplace = false;
            }
        } else {
            for (int i = 0; i < textureButtonPosList.Length; ++i) {
                textureButtonPosList[i].SetActive(false);
                textureChosen = -1;
                activeReplace = false;
            }
        }
        isSubTextureHiden = !isSubTextureHiden;
    }

    public void changePosX() {
        if (GameManager.instance.selectedPart != null) {
            int tmpId = -1;
            for(int i = 0;i < GameManager.instance.iniTransformList.Length;++i) {
                if(GameManager.instance.carPartList[i] == GameManager.instance.selectedPart) {
                    tmpId = i;
                    break;
                }
            }
            Debug.Log(poxXSilder.value);
            GameManager.instance.selectedPart.transform.position = GameManager.instance.iniTransformList[tmpId] + (float)(poxXSilder.value - 0.5f) * new Vector3(5, 0, 0);
            Debug.Log((float)(poxXSilder.value - 0.5f) * new Vector3(5, 0, 0));

        }
    }
    public void changeSize() {
        if(GameManager.instance.selectedPart != null) {
            Debug.Log(sizeSilder.value);
            GameManager.instance.selectedPart.transform.localScale = new Vector3(1 + sizeSilder.value, 1 + sizeSilder.value, 1 + sizeSilder.value);

        }
    }

    public void replace() {
        activeReplace = !activeReplace;
        colorChosen = -1;
        textureChosen = -1;
    }
    public void color0() {
        colorChosen = 0;
    }
    public void color1() {
        colorChosen = 1;
    }
    public void color2() {
        colorChosen = 2;
    }

    public void texture0() {

        textureChosen = 0;
    }
    public void texture1() {
        textureChosen = 1;

    }
    public void texture2() {
        textureChosen = 2;

    }
    //void OnGUI()
    //{
    //    if (!btnTexture)
    //    {
    //        Debug.LogError("Please assign a texture on the inspector");
    //        return;
    //    }

    //    if (GUI.Button(new Rect(10, 10, 50, 50), btnTexture))
    //        Debug.Log("Clicked the button with an image");

    //    if (GUI.Button(new Rect(10, 70, 50, 30), "Click"))
    //        Debug.Log("Clicked the button with text");
    //}
}
