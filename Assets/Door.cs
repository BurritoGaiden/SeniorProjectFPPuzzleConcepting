using UnityEngine;
using System.Collections;
public enum DoorType {Door, AutoDoor };

public class Door : MonoBehaviour
{
    public Animator animator;
    public string onTriggerEnterParameterName;
    public string onTriggerExitParameterName;
    public DoorType thisDoor = DoorType.Door;
    public bool doorClosed = true;
    void Start()
    {
        if (animator == null)
        {
            animator = GetComponent<Animator>();
            if (animator == null)
            {
                Debug.LogError("No animator component on this script!", gameObject);
            }
        }
        if (thisDoor == DoorType.Door)
        {
            this.GetComponent<BoxCollider>().size = new Vector3(.2f, 1, 1);
        }
        else {
            this.GetComponent<BoxCollider>().size = new Vector3(2, 1, 1);
        }
    }

    void OnTriggerEnter()
    {
        if (thisDoor == DoorType.AutoDoor)
        {
            if (onTriggerEnterParameterName != null)
            {
                animator.SetTrigger(onTriggerEnterParameterName);
                doorClosed = false;
            }
        }
    }

    void OnTriggerExit()
    {
        if (thisDoor == DoorType.AutoDoor)
        {
            if (onTriggerExitParameterName != null)
            {
                animator.SetTrigger(onTriggerExitParameterName);
                doorClosed = true;
            }
        }
    }

    public void InteractDoor() {

        if (thisDoor == DoorType.Door)
        {
            this.GetComponent<BoxCollider>().size = new Vector3(.2f, 1, 1);
            if (this.GetComponent<Animation>().clip.name == "DoorClose")
            {
                animator.SetTrigger(onTriggerEnterParameterName);
                //doorClosed = !doorClosed;
            }
            else {
                animator.SetTrigger(onTriggerExitParameterName);
            }
        }
        else {
            this.GetComponent<BoxCollider>().size = new Vector3(2, 1, 1);
        }


    }

    public void CloseDoor() {
        if (thisDoor == DoorType.Door)
        {
            this.GetComponent<BoxCollider>().size = new Vector3(.2f, 1, 1);
            animator.SetTrigger(onTriggerExitParameterName);
            //doorClosed = !doorClosed;
        }
        else
        {
            this.GetComponent<BoxCollider>().size = new Vector3(2, 1, 1);
        }





    }
}
