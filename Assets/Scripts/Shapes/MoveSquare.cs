using UnityEngine;
using System.Collections;

public class MoveSquare : MonoBehaviour
{
    public float SpeedPerSecond { get; set; }

    private void Start()
    {
        StartCoroutine(Drop());
    }

    private IEnumerator Drop()
    {
        while (true)
        {
            transform.position += Vector3.down * SpeedPerSecond * Time.deltaTime;

            yield return null;
        }
    }
}
