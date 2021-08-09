using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.UI;

[RequireComponent(typeof(ARRaycastManager))]
public class PlacementController : MonoBehaviour
{
    public List<GameObject> objectToPlace;
    //public GameObject placementIndicator;

    public GameObject menuObject;
    public GameObject detailObject;

    public Button addButton;

    private Pose placementPose;
    private bool placementPoseIsValid = false;

    private ARRaycastManager arRaycastManager;

    private static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    void Awake()
    {
        arRaycastManager = GetComponent<ARRaycastManager>();
    }

   

    void Update()
    {
        UpdatePlacmentPose();
       // UpdatePlacmentIndicator();
    }

    public void OnClickCreate(int index)
    {
        //if (placementPoseIsValid)
        //{
            PlaceObject(index);

            menuObject.SetActive(false);
            detailObject.SetActive(false);
       // }
    }

    private void PlaceObject(int index)
    {
        Instantiate(objectToPlace[index], placementPose.position, placementPose.rotation);
    }

   

    private void UpdatePlacmentPose()
    {
        var screenCenter = Camera.current.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
      //  var hits = new List<ARRaycastHit>();

        arRaycastManager.Raycast(screenCenter, hits, UnityEngine.XR.ARSubsystems.TrackableType.Planes);

        placementPoseIsValid = hits.Count > 0;

        if (placementPoseIsValid)
        {
            
            placementPose = hits[0].pose;

            var cameraForward = Camera.current.transform.forward;
            var cameraBearing = new Vector3(cameraForward.x, 0, cameraForward.z).normalized;

            placementPose.rotation = Quaternion.LookRotation(cameraBearing);

        }// end if placment pose is valid

    } // end update plament pose


    public bool IsPoseValid {
        get {
            return placementPoseIsValid;
        }
    }


}
