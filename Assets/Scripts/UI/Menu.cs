using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{

    public List<Image> onImages;
    public List<Image> offImages;
    public List<GameObject> contents;

    public List<ContentItem> detailValues;

    public void OnClick()
    {
        transform.GetChild(0).gameObject.SetActive(true);
    }

    public void OnClickHome()
    {
        SelectOnButton(0);
    }

    public void OnClickSearch()
    {
        SelectOnButton(1);
    }

    public void OnClickHeart()
    {
        SelectOnButton(2);
    }

    public void OnClickProfile()
    {
        SelectOnButton(3);
    }

    private void SelectOnButton(int index)
    {
        for (int i = 0; i < onImages.Count; i++)
        {
            if (i == index) {
                contents[i].SetActive(true);
                onImages[i].enabled = true;
                offImages[i].enabled = false;
            } 
            else
            {
                contents[i].SetActive(false);
                onImages[i].enabled = false;
                offImages[i].enabled = true;
            }
                
        }
    }


}
