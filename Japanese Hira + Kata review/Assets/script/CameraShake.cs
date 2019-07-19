using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public IEnumerator Shake(float duration, float magnitude)
    {
        Vector3 position = transform.localPosition;

        float time = 0.0f;
        while(time < duration)
        {
            float x = Random.Range(-.1f, .1f) * magnitude;
            float y = Random.Range(-.1f, .1f) * magnitude;

            transform.localPosition = new Vector3(x, y, position.z);

            time += Time.deltaTime;

            Debug.Log("Camera shake");

            yield return null;//wait to execute another loop after a new frame is drawn
        }

        transform.localPosition = position;
    }
}
