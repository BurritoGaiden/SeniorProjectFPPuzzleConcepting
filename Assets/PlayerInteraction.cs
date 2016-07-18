//using MovementEffects;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteraction : MonoBehaviour
{
    // Movement vars.
    public float speed = 10f;
    float currSpeed;
    public float sprintMultiplier = 1.4f;

    // Look vars.
    public float sensitivityX = 15F;
    public float sensitivityY = 15F;
    public float minimumY = -60F;
    public float maximumY = 60F;
    float rotationY = 0F;

    Rigidbody rb;

    public Transform hand;

    public Image crosshair;
    public Text textDisplay;

    public Sprite crossDefault;
    public Sprite crossUse;

    public bool isHolding = false;
    public bool isHoverHolding = false;
    public CarryableObject currentlyHolding;

    public Camera cam { get; private set; }

    //public bool inCannonAimMode { get; set; }
    /*
    void Awake()
    {
        cam = GetComponentInChildren<Camera>();
        cam.enabled = true;
        inCannonAimMode = false;
        rb = GetComponent<Rigidbody>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    */
    void Update()
    {
        PlayerInteract();
        /*
        if (!inCannonAimMode)
        {
            float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;
            rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
            rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);
            Camera.main.transform.localEulerAngles = new Vector3(-rotationY, 0, 0);
            transform.localEulerAngles = new Vector3(0, rotationX, 0);
            currSpeed = Input.GetButton("Sprint") ? speed * sprintMultiplier : speed;
            currSpeed = Input.GetButton("Sprint") ? speed * sprintMultiplier : speed;
            PlayerInteraction();
        }
        */
        /*
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = !Cursor.visible;
            Cursor.lockState = Cursor.visible ? CursorLockMode.Locked : CursorLockMode.None;
        }
        */
    }
    /*
    void FixedUpdate()
    {
        if (!inCannonAimMode)
        {
            float moveX = Input.GetAxis("Horizontal");
            float moveZ = Input.GetAxis("Vertical");
            rb.velocity = (transform.TransformDirection(new Vector3(moveX, 0, moveZ) * currSpeed));
        }
    }
    */
    #region Player Interaction
    void PlayerInteract()
    {
        //Sets the frame drop to false, so the script recognizes that it doesn't need to skip a frame in all if statements
        bool droppedThisFrame = false;

        ///If the player is holding an object and left clicks, while not looking at anything.
        ///The player sets their held object to null, turns off the parent to the held object, and throws it, resetting its held variables and letting the frame skip
        if (isHolding && Input.GetMouseButtonDown(0) && !isHoverHolding)
        {
            Transform objectHolding = hand.GetChild(0);
            currentlyHolding = null;
            Rigidbody tempRb = objectHolding.GetComponent<Rigidbody>();
            tempRb.constraints = RigidbodyConstraints.None;
            tempRb.AddForce(Camera.main.transform.forward * 10, ForceMode.Impulse);
            tempRb.detectCollisions = true;
            objectHolding.parent = null;
            isHolding = false;
            droppedThisFrame = true;
            isHoverHolding = false;
        }

        //The game's raycast is set to a bool, hit
        RaycastHit hit;

        ///If the raycast hits something
        ///

        Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward, Color.green);
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 500))
        {
            ///If the raycast hits a carryable object, and the player is not holding anything, or hasn't just thrown their object
            if (hit.collider.tag == "Carryable" && !isHolding && !droppedThisFrame)
            {
                CarryableObject tempObj = hit.collider.GetComponent<CarryableObject>();

                //textDisplay.text = "Pick up " + tempObj.carryableType;
                //crosshair.sprite = crossUse;

                ///If the player clicks while the raycast is hitting a carryable object, and the player isn't holding or hasn't thrown anything
                ///the object is childed to the player, and the player is now holding something.
                if (Input.GetMouseButtonDown(0))
                {
                    hit.transform.SetParent(hand, true);
                    hit.transform.position = hand.position;
                    currentlyHolding = tempObj.GetComponent<CarryableObject>();
                    Rigidbody tempRb = hit.collider.GetComponent<Rigidbody>();
                    tempRb.constraints = RigidbodyConstraints.FreezeAll;
                    tempRb.detectCollisions = false;
                    isHolding = true;
                    isHoverHolding = false;
                }
            }
            ///If the raycast hits a zone that can hold an item and the player is holding an item
            else if (hit.collider.tag == "ItemZone" && isHolding)
            {
                if (currentlyHolding.thisST != Seatable.Nonseatable)
                {

                    ///The game declares that the player is hovering over something and holding an item
                    isHoverHolding = true;
                    //crosshair.sprite = crossUse;
                    //if (currentlyHolding.carryableType == CannonState.Ramrod || currentlyHolding.carryableType == CannonState.Cleaner)
                    //    textDisplay.text = "Use " + currentlyHolding.carryableType;
                    //else
                    //    textDisplay.text = "Load " + currentlyHolding.carryableType;
                    if (Input.GetMouseButtonDown(0))
                    {
                        #region
                        //CannonController tempCannon = hit.transform.parent.GetComponent<CannonController>();
                        //if (tempCannon.LoadItem(currentlyHolding))
                        //{
                        //    if (currentlyHolding.carryableType != CannonState.Ramrod && currentlyHolding.carryableType != CannonState.Cleaner)
                        //  {
                        //    isHoverHolding = false;
                        //  isHolding = false;
                        //currentlyHolding = null;
                        //}
                        //}
                        #endregion

                        Transform objectHolding = hand.GetChild(0);
                        #region
                        //Rigidbody tempRb = objectHolding.GetComponent<Rigidbody>();
                        //tempRb.constraints = RigidbodyConstraints.None;
                        //tempRb.detectCollisions = true;
                        //objectHolding.parent = null;
                        //hit.transform.SetParent(hand, true);

                        //objectHolding = tempObj.GetComponent<CarryableObject>();

                        //objectHolding.transform.position = hit.transform.position;
                        #endregion
                        objectHolding.parent = null;
                        //objectHolding.position = hit.transform.position;
                        hit.transform.GetComponent<ItemHolder>().LoadItem(currentlyHolding);
                        isHoverHolding = false;
                        isHolding = false;
                        currentlyHolding = null;
                        droppedThisFrame = true;

                    }
                }

            }
            else if (hit.collider.tag == "ItemZone" && !isHolding && !droppedThisFrame)
            {
                CarryableObject tempObj = hit.collider.GetComponent<ItemHolder>().itemHeld;

                if (Input.GetMouseButtonDown(0))
                {

                    try
                    {
                        Transform tempItem = hit.transform.GetChild(1);
                        //print(hit.transform.GetChild(0));
                        tempItem.transform.SetParent(hand, true);
                        tempItem.transform.position = hand.position;
                        currentlyHolding = tempObj;
                        Rigidbody tempRb = tempObj.GetComponent<Rigidbody>();
                        tempRb.constraints = RigidbodyConstraints.FreezeAll;
                        hit.transform.GetComponent<ItemHolder>().itemHeld = null;
                        hit.transform.GetComponent<ItemHolder>().StopAllCoroutines();
                        tempRb.detectCollisions = false;
                        isHolding = true;
                        isHoverHolding = true;

                    }
                    catch
                    {

                    }


                }
                #region


                /*
                else if (hit.collider.tag == "Fuse" && isHolding)
                {
                    if (currentlyHolding.carryableType == CannonState.Igniter)
                    {
                        isHoverHolding = true;
                        var tempCannon = hit.transform.parent.GetComponent<CannonController>();
                        if (tempCannon.currentState == CannonState.Igniter)
                        {
                            textDisplay.text = "Fire Cannon";
                            crosshair.sprite = crossUse;
                            if (Input.GetMouseButtonDown(0))
                            {
                                tempCannon.Fire();
                            }
                        }
                    }
                }
                else if (hit.collider.tag == "AimMode" && !isHolding)
                {
                    crosshair.sprite = crossUse;
                    textDisplay.text = "Aim Cannon.";
                    if (Input.GetMouseButtonDown(0))
                    {
                        var tempCannon = hit.transform.parent.GetComponent<CannonController>();
                        cam.enabled = false;
                        tempCannon.cam.enabled = true;
                        inCannonAimMode = true;
                        crosshair.enabled = false;
                        textDisplay.text = "Click again to leave Aim Mode.";
                        rb.constraints = RigidbodyConstraints.FreezeAll;
                        rb.detectCollisions = false;
                    }
                }
                else
                {
                    isHoverHolding = false;
                    crosshair.sprite = crossDefault;
                    textDisplay.text = "";
                }
                */
                #endregion
            }
            else if (hit.collider.tag == "Button" && !isHolding && !droppedThisFrame)
            {

                if (Input.GetMouseButtonDown(0))
                {
                    //print(hit.transform);
                    //print(hit.transform.GetComponent<Button>());
                    //print(this.gameObject);
                    print(hit.transform.GetComponent<Button>().thisButton);
                    hit.transform.GetComponent<Button>().DoButtonStuff(gameObject);

                    droppedThisFrame = true;
                }



            }
            else if (hit.collider.tag == "Door" && !isHolding && !droppedThisFrame) {

                if (hit.transform.GetComponent<Door>().thisDoor == DoorType.Door) {
                    if (Input.GetMouseButton(0)) {
                        //if (hit.transform.GetComponent<Door>().doorClosed == true)
                        //{
                            //hit.transform.GetComponent<Door>().InteractDoor();
                        //}
                        //else {
                        //    hit.transform.GetComponent<Door>().CloseDoor();
                        //}

                    }
                    
                }

            }
            ///If none of that is true, than they're obviously not hoverholding
            else
            {
                isHoverHolding = false;
                //crosshair.sprite = crossDefault;
                //textDisplay.text = "";
            }
        }
        #region
        /*
        public IEnumerator<float> LeaveAimMode(CannonController cannon)
        {
            rb.constraints = RigidbodyConstraints.FreezeRotation;
            rb.detectCollisions = true;
            cannon.cam.enabled = false;
            cam.enabled = true;
            textDisplay.text = "";
            crosshair.enabled = true;
            crosshair.sprite = crossDefault;
            yield return Timing.WaitForSeconds(0.1f);
            inCannonAimMode = false;
        }
        */
        #endregion
        #endregion
    }
}