using UnityEngine;
using System.Collections;
using DG.Tweening;

public class ItemHolder : MonoBehaviour {


    public CarryableObject itemHeld;
    public float duration = 2;
    public bool rotatesItem;
    public bool floatsItem;
    public Vector3 eulerAngleVelocity;
    public float amplitude = 1f;
    public float speed = 1f;
	// Use this for initialization
	void Start () {
	
	}
	
	

    public void LoadItem(CarryableObject item) {
        itemHeld = item;
        item.transform.parent = transform;
        item.transform.position = this.transform.position;
        //StartCoroutine(StartHover());
        
        /*
        if (this.gameObject.GetComponent<HeldItemRotator>()) {
            this.gameObject.GetComponent<HeldItemRotator>().cube = itemHeld.transform;
            this.gameObject.GetComponent<HeldItemRotator>().startStartStart();

        }
        */
    }

    public void FixedUpdate() {
        if (rotatesItem) {
            if (itemHeld != null)
            {

                Quaternion deltaRotation = Quaternion.Euler(eulerAngleVelocity * Time.deltaTime);
                itemHeld.transform.GetComponent<Rigidbody>().MoveRotation(itemHeld.transform.GetComponent<Rigidbody>().rotation * deltaRotation);

            }

        }
        if (floatsItem) {
            if (itemHeld != null) {
                float y0 = itemHeld.transform.position.y;

                itemHeld.transform.GetComponent<Transform>().position = new Vector3(itemHeld.transform.GetComponent<Transform>().position.x - 3f, y0 + amplitude * Mathf.Sin(speed * Time.time));
            }
            
        }
        
    }




    public IEnumerator StartHover()
    {
        // Start after one second delay (to ignore Unity hiccups when activating Play mode in Editor)
        yield return new WaitForSeconds(1);

        // Create a new Sequence.
        // We will set it so that the whole duration is 6
        Sequence s = DOTween.Sequence();
        // Add an horizontal relative move tween that will last the whole Sequence's duration
        s.Append(itemHeld.transform.DOMoveY(.5f, duration).SetRelative().SetEase(Ease.InOutQuad));
        // Insert a rotation tween which will last half the duration
        // and will loop forward and backward twice
        //s.Insert(0, cube.DORotate(new Vector3(360, 45, 0), duration / 2).SetEase(Ease.InQuad).SetLoops(2, LoopType.Yoyo));
        // Add a color tween that will start at half the duration and last until the end
        //s.Insert(duration / 2, cube.GetComponent<Renderer>().material.DOColor(Color.yellow, duration / 2));
        // Set the whole Sequence to loop infinitely forward and backwards
        s.SetLoops(-1, LoopType.Yoyo);

        //Sequence r = DOTween.Sequence();
        //r.Insert(0, cube.DORotate(new Vector3(360, 0, 0), duration / 2).SetEase(Ease.InQuad).SetLoops(2, LoopType.Yoyo));
        //r.Append(cube.DORotate(new Vector3(360, 0, 0), duration).SetEase(Ease.InOutQuad).SetLoops(2, LoopType.Yoyo));
        //r.SetLoops(-1, LoopType.Incremental);
    }
    /*
    public bool LoadItem(CarryableObject loaded)
    {
        if (loaded.carryableType == currentState)
        {
            if (currentState == CannonState.Cleaner)
                currentState = 0;
            else
                currentState += 1;
            if (loaded.carryableType == CannonState.Gunpowder || loaded.carryableType == CannonState.Cannonball || loaded.carryableType == CannonState.Wadding)
                Destroy(loaded.gameObject);
            return true;
        }
        return false;
    }
    */
}
