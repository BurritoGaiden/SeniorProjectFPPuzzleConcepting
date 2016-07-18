using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {

    public ButtonType thisButton = ButtonType.Gravity;
    public Transform spawnableObjectPosition;
    public GameObject spawnableObject;

    public void DoButtonStuff(GameObject player) {
        
        if (thisButton == ButtonType.Gravity) {
            player.GetComponent<FirstPersonDrifter>().gravity *= -1;
            print(player.GetComponent<Transform>().rotation);
            var rotationVector = player.GetComponent<Transform>().rotation.eulerAngles;
            print(Camera.main);
            GameObject cam = GameObject.FindGameObjectWithTag("MainCamera");
            var camVector = cam.GetComponent<Transform>().rotation.eulerAngles;
            if (rotationVector.z == 0)
            {
                rotationVector.z = 180;
                camVector.z = 180;
                player.GetComponent<Transform>().rotation = Quaternion.Euler(rotationVector);
                Camera.main.GetComponent<Transform>().rotation = Quaternion.Euler(camVector);
            }
            else
            {
                rotationVector.z = 0;
                camVector.z = 0;
                player.GetComponent<Transform>().rotation = Quaternion.Euler(rotationVector);
                Camera.main.GetComponent<Transform>().rotation = Quaternion.Euler(camVector);
            }

            
            /*
            Camera playerCam = Camera.main;
            print(playerCam);
            Vector3 startRotation = playerCam.GetComponent<Transform>().rotation;
            if (startRotation.y == -180f)
            {
                startRotation.y = 0;
            }
            else {
                startRotation.y = -180f;
            }
            */
        }
        

        if (thisButton == ButtonType.Spawn)
        {
            //Instantiate(spawnableObject, spawnableObjectPosition.position, Quaternion.Identity);
            print("Spawning object");
            Instantiate(spawnableObject);


        }
    }
}
