using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContentItem : MonoBehaviour
{

    public int index;
    public string firmaName;
    public Sprite logo;
    public string url;
    public string number;
    public Sprite image;
    public string objName;
    public string sum;
    public string discreption;

    private Detail detail;

    private PlacementReticle placementController;

    public void OnClickDetail()
    {
        if(detail == null)
            detail = FindObjectOfType<Detail>();

        detail.transform.GetChild(0).gameObject.SetActive(true);
        detail.index = index;
        detail.SetValues(firmaName, logo, url, number, image, objName, sum, discreption);
    }


    public void OnClick3D()
    {
        if (placementController == null)
            placementController = FindObjectOfType<PlacementReticle>();

        placementController.OnClickCreate(index);
    }


}
