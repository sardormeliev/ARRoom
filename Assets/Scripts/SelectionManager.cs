using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    [SerializeField]
    private string selectableTag = "Selectable";
    public Material highlightMaterial;
    public Material defaultMaterial;

    private Transform _selection;
    private TouchHandler touchHandler;

    private Vector3 offSet;
    private float zPosition;
    private float rotSpeed = 20f;

    void Start()
    {
        touchHandler = GetComponent<TouchHandler>();
    }

    void Update()
    {
        var ray = Camera.current.ScreenPointToRay(Input.GetTouch(0).position);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            var selection = hit.transform;

            if (selection.CompareTag(selectableTag))
            {
                if (_selection != null)
                {
                    //var _selectionRenderer = _selection.GetComponent<Renderer>();
                    //_selectionRenderer.material = defaultMaterial;
                    _selection = null;

                }

                //var selectionRenderer = selection.GetComponent<Renderer>();

                //if (selectionRenderer != null)
                //{
                //   // selectionRenderer.material = highlightMaterial;
                //}

                _selection = selection;

                touchHandler.enableRotation = true;
                touchHandler.AugmentationObject = _selection;
            }
        } // raycast if end


        if (_selection != null && Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0); // get first touch since touch count is greater than zero

            if (touch.phase == TouchPhase.Began)
            {
               // zPosition = Camera.current.WorldToScreenPoint(_selection.position).z;

                offSet = _selection.position - GetInputWorldPosition();
                //_selection.GetChild(0).gameObject.SetActive(true);
            }
            else if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
            {
                Vector3 result = GetInputWorldPosition() + offSet;
                _selection.position = new Vector3(result.x, result.y, _selection.position.z);
            }
            else {
                //_selection.GetChild(0).gameObject.SetActive(false);
            }
        }
       
        //if (_selection != null && Input.touchCount == 2)
        //{
        //    Touch touch = Input.GetTouch(0);
           

        //    if (touch.phase == TouchPhase.Moved)
        //    {
        //        _selection.Rotate(0, touch.deltaPosition.x * rotSpeed, 0, Space.World);
        //    }
        //}


    } // end update

    private Vector3 GetInputWorldPosition()
    {
        Vector3 touchPoint = Input.GetTouch(0).position;

        touchPoint.z = zPosition;

        return Camera.current.ScreenToWorldPoint(touchPoint);
    }
}
