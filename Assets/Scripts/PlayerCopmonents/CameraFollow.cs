using Assets.Scripts.GlobalConstantValues;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public CameraConstants cameraConstants;
    public Vector3 offset; //Distance between camera and player

    //FUTURE: implement view toggling by explicitly setting the camera offset to third person
    //void Start()
    //{
    //    offset.y = cameraConstants.ThirdPersonY;
    //    offset.z = cameraConstants.ThirdPersonZ;
    //}

    // Update is called once per frame
    void Update()
    {
    //FUTURE: Implement view switching
        //if (Input.GetKey(KeyCode.P))
        //{
        //    TogglePersonView();
        //}

        transform.position = target.position + offset;
    }

    //FUTURE: Implement view switching
    //void TogglePersonView()
    //{
    //    if (offset.y > 0)
    //    {
    //        offset.y = cameraConstants.FirstPerson;
    //        offset.z = 0;
    //        transform.position = target.position + offset;
    //    }
    //    else
    //    {
    //        offset.y = cameraConstants.ThirdPersonY;
    //        offset.z = cameraConstants.ThirdPersonZ;
    //        transform.position = target.position + offset;
    //    }
    //}
}
