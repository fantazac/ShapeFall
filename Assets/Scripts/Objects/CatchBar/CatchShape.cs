using UnityEngine;
using System.Collections;

public class CatchShape : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;

    public delegate void OnValidShapeCaughtHandler(Vector3 shapePosition);
    public event OnValidShapeCaughtHandler OnValidShapeCaught;

    public delegate void OnInvalidShapeCaughtHandler();
    public event OnInvalidShapeCaughtHandler OnInvalidShapeCaught;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Shape")
        {
            if (ValidateShape(collider))
            {
                OnValidShapeCaught(collider.gameObject.transform.position);
            }
            else
            {
                OnInvalidShapeCaught();
            }
            Destroy(collider.gameObject);
        }
    }

    private bool ValidateShape(Collider2D collider)
    {
        return collider.GetComponent<SpriteRenderer>().color == _spriteRenderer.color;
    }
}
