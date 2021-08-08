using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField]
    private GameObject moveIndicator;
    public GameObject GetIndicator { get { return moveIndicator; } }

    private Canvas canvas;

    private void Start()
    {
        canvas = GetComponentInChildren<Canvas>();

        canvas.worldCamera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
    }


    public void OnClickCancel()
    {
        Destroy(gameObject);
    }

}
