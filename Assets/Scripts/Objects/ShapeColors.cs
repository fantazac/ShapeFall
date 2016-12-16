using UnityEngine;
using System.Collections;

public class ShapeColors : MonoBehaviour
{

    private Color[] _shapeColors;

    public Color[] Colors { get { return _shapeColors; } }

    private void Start()
    {
         _shapeColors = new Color[] { Color.green, Color.red, Color.yellow, Color.blue, Color.magenta };
    }

}
