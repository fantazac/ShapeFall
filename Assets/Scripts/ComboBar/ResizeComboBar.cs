using UnityEngine;
using System.Collections;

public class ResizeComboBar : MonoBehaviour
{
    private PointsStored _pointsStored;

    private float _sizeIncreaseOnCatch;

    private Vector3 _initialLocalScale;
    private Vector3 _initialPosition;

    private void Start()
    {
        GetComponentInParent<CatchOrb>().OnOrbCaught += ResizeBar;
        _pointsStored = GetComponent<PointsStored>();
        _pointsStored.OnComboBarFull += ResetBar;
        
        _sizeIncreaseOnCatch = 1f / _pointsStored.OrbsToCatchBeforePowerUp;
        _initialLocalScale = transform.localScale;
        _initialPosition = transform.position;
    }

    private void ResizeBar()
    {
        transform.localScale += Vector3.up * _sizeIncreaseOnCatch;
        transform.position += Vector3.up * _sizeIncreaseOnCatch * 5;
    }

    private void ResetBar()
    {
        transform.localScale = _initialLocalScale;
        transform.position = _initialPosition;
    }
}
