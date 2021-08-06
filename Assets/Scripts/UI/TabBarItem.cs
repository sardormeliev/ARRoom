using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabBarItem : MonoBehaviour
{

    public GameObject content;
    public Text titleLabel;
    public Image bgImage;

    public void SetOn() {
        var color = new Color(86f / 255f, 103f / 255f, 246f / 255f); //qizil

        titleLabel.color = color;
        bgImage.enabled = true;
        bgImage.color = color;

        content.SetActive(true);

    }

    public void SetOff() {
        var color = new Color(100f / 255f, 100f / 255f, 100f / 255f);

        titleLabel.color = color;
        bgImage.enabled = false;

        content.SetActive(false);

    }


}
