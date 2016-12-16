using UnityEngine;
using System.Collections;

public class CatchShape : MonoBehaviour
{
    public delegate void OnValidShapeCaughtHandler(Vector3 shapePosition);
    public event OnValidShapeCaughtHandler OnValidShapeCaught;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Shape")
        {
            OnValidShapeCaught(collider.gameObject.transform.position);
            Destroy(collider.gameObject);
        }
    }
}
