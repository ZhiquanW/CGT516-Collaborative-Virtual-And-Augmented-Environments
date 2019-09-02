using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour {
    public Button colorButton;
    public Button textureButton;
    public GameObject[] colorButtonPosList;
    public GameObject[] textureButtonPosList;
    public bool isSubColorHiden;
    public bool isSubTextureHiden;
    public Color[] colorList;
    public bool[] colorChosen = new bool[3];
    public bool[] textureChosen = new bool[3];
    public Sprite[] textureList;

    void Awake()
    {
    }
    // Use this for initialization
    void Start () {
        isSubColorHiden = true;
        isSubTextureHiden = true;
        for(int i = 0;i < colorButtonPosList.Length;++i)
        {
            colorButtonPosList[i].GetComponent<Image>().color = colorList[i];
        }
        for(int i = 0;i < textureButtonPosList.Length;++i)
        {
            textureButtonPosList[i].GetComponent<Image>().sprite= textureList[i];
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void popupSubMenuColor()
    {
        if (isSubColorHiden)
        {
            for (int i = 0; i < colorButtonPosList.Length; ++i)
            {
                colorButtonPosList[i].SetActive(true);
            }
        }
        else
        {
            for (int i = 0; i < colorButtonPosList.Length; ++i)
            {
                colorButtonPosList[i].SetActive(false);
                clearChosen();
            }
        }
        isSubColorHiden = !isSubColorHiden;
    }
    public void popupSubMenuTexture()
    {
        if (isSubTextureHiden)
        {
            for (int i = 0; i < textureButtonPosList.Length; ++i)
            {
                textureButtonPosList[i].SetActive(true);
            }
        }
        else
        {
            for (int i = 0; i < textureButtonPosList.Length; ++i)
            {
                textureButtonPosList[i].SetActive(false);
                clearChosen();
            }
        }
        isSubTextureHiden = !isSubTextureHiden;
    }
    public void color0()
    {
        clearChosen();
        colorChosen[0] = true;
    }
    public void color1()
    {
        clearChosen();
        colorChosen[1] = true;
    }
    public void color2()
    {
        clearChosen();
        colorChosen[2] = true;
    }

    public void texture0()
    {
        clearChosen();
        textureChosen[0] = true;
    }
    public void texture1()
    {
        clearChosen();
        textureChosen[1] = true;
    }
    public void texture2()
    {
        clearChosen();
           textureChosen[2] = true;
    }
    void clearChosen()
    {
        for(int i = 0;i < 3;++i)
        {
            colorChosen[i] = false;
            textureChosen[i] = false;
        }
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
