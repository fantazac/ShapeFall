using UnityEngine;
using System.Collections;

public class CatchBarInputManager : MonoBehaviour
{

    public delegate void OnColorChangeHandler(int id);
    public event OnColorChangeHandler OnColorChange;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            OnColorChange(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            OnColorChange(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            OnColorChange(2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            OnColorChange(3);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            OnColorChange(4);
        }
    }
}
