using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Detail : MonoBehaviour
{
    public PlacementController placementController;


    public int index;
    public Text firmaName;
    public Image logo;
    public Text url;
    public Text number;
    public Image image;
    public Text objName;
    public Text sum;
    public Text discreption;

    public void SetValues(string firmaName, Sprite logo, string url, string number, Sprite image, string objName, string sum, string discreption)
    {
        this.firmaName.text = firmaName;
        this.logo.sprite = logo;
        this.url.text = url;
        this.number.text = number;
        this.image.sprite = image;
        this.objName.text = objName;
        this.sum.text = sum;
        this.discreption.text = discreption;
    }


    public void OnClickButton()
    {
        placementController.OnClickCreate(index);
    }

}
