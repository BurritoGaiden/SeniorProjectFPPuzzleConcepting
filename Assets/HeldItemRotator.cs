using UnityEngine;
using System.Collections;
using DG.Tweening;

public class HeldItemRotator : MonoBehaviour
{
    public Transform cube;
    public float duration = 2;

    public void startStartStart() {
        StartCoroutine(Start());

    }

    public void stopStart() {
        StopCoroutine(Start());
    }

    public IEnumerator Start()
    {
        // Start after one second delay (to ignore Unity hiccups when activating Play mode in Editor)
        yield return new WaitForSeconds(1);

        // Create a new Sequence.
        // We will set it so that the whole duration is 6
        Sequence s = DOTween.Sequence();
        // Add an horizontal relative move tween that will last the whole Sequence's duration
        s.Append(cube.DOMoveY(.5f, duration).SetRelative().SetEase(Ease.InOutQuad));
        // Insert a rotation tween which will last half the duration
        // and will loop forward and backward twice
        //s.Insert(0, cube.DORotate(new Vector3(360, 45, 0), duration / 2).SetEase(Ease.InQuad).SetLoops(2, LoopType.Yoyo));
        // Add a color tween that will start at half the duration and last until the end
        //s.Insert(duration / 2, cube.GetComponent<Renderer>().material.DOColor(Color.yellow, duration / 2));
        // Set the whole Sequence to loop infinitely forward and backwards
        s.SetLoops(-1, LoopType.Yoyo);

        Sequence r = DOTween.Sequence();
        //r.Insert(0, cube.DORotate(new Vector3(360, 0, 0), duration / 2).SetEase(Ease.InQuad).SetLoops(2, LoopType.Yoyo));
        //r.Append(cube.DORotate(new Vector3(360, 0, 0), duration).SetEase(Ease.InOutQuad).SetLoops(2, LoopType.Yoyo));
        r.SetLoops(-1, LoopType.Incremental);
    }
}
