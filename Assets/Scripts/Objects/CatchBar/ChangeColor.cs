using UnityEngine;
using System.Collections;

public class ChangeColor : MonoBehaviour
{
    [SerializeField]
    private GameObject _shapeColors;

    private SpriteRenderer _spriteRenderer;
    private ShapeColors _colors;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _colors = _shapeColors.GetComponent<ShapeColors>();
        GetComponent<CatchBarInputManager>().OnColorChange += UpdateColor;
    }

    private void UpdateColor(int id)
    {
        _spriteRenderer.color = _colors.Colors[id];
    }

}
