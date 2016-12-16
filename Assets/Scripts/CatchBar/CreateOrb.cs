using UnityEngine;
using System.Collections;

public class CreateOrb : MonoBehaviour
{
    [SerializeField]
    private GameObject _orb;

    [SerializeField]
    private GameObject _comboBar;

    private GameObject _newOrb;

    private void Start()
    {
        GetComponent<CatchShape>().OnValidShapeCaught += CreateNewOrb;
    }

    private void CreateNewOrb(Vector3 shapePosition)
    {
        _newOrb = (GameObject)Instantiate(_orb, shapePosition, new Quaternion());
        _newOrb.GetComponent<MoveOrb>().CalculateTrajectory(gameObject, _comboBar);
    }
}
