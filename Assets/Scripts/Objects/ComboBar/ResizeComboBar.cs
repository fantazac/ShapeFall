using UnityEngine;
using System.Collections;

public class ResizeComboBar : MonoBehaviour
{
    [SerializeField]
    private float _increaseSpeed = 8;

    [SerializeField]
    private float _decreaseSpeed = -20;

    private PointsStored _pointsStored;

    private float _sizeIncreaseOnCatch;
    private bool _canResize = true;
    private bool _resetBar = false;

    private Vector3 _initialLocalScale;
    private Vector3 _initialPosition;

    private void Start()
    {
        GetComponentInParent<CatchOrb>().OnOrbCaught += ResizeBar;
        _pointsStored = GetComponent<PointsStored>();
        _pointsStored.OnComboBarFull += ResetBar;
        _pointsStored.OnEmptyBar += ResetBarFail;

        _sizeIncreaseOnCatch = 1f / _pointsStored.OrbsToCatchBeforePowerUp;
        _initialLocalScale = transform.localScale;
        _initialPosition = transform.position;
    }

    private void ResizeBar()
    {
        //transform.localScale += Vector3.up * _sizeIncreaseOnCatch;
        //transform.position += Vector3.up * _sizeIncreaseOnCatch * 5;
        if (_canResize)
        {
            _canResize = false;
            StartCoroutine(ResizeBarWithAnim());
        }
    }

    private IEnumerator ResizeBarWithAnim()
    {
        while (transform.localScale.y <
            (Vector3.up * _sizeIncreaseOnCatch * (_pointsStored.OrbsInComboBar % _pointsStored.OrbsToCatchBeforePowerUp)).y)
        {
            ChangeBarSize(_increaseSpeed);

            yield return null;
        }

        if (_resetBar)
        {
            StartCoroutine(ResetBarSize());
        }
        else
        {
            _canResize = true;
            transform.localScale = (Vector3.right * _initialLocalScale.x) +
                (Vector3.up * _sizeIncreaseOnCatch * (_pointsStored.OrbsInComboBar % _pointsStored.OrbsToCatchBeforePowerUp));
            transform.position = (Vector3.right * _initialPosition.x) +
                (Vector3.up * _initialPosition.y) +
                (Vector3.up * _sizeIncreaseOnCatch * 5 * (_pointsStored.OrbsInComboBar % _pointsStored.OrbsToCatchBeforePowerUp));
        }
    }

    private IEnumerator ResetBarSize()
    {
        _resetBar = false;
        while (transform.localScale.y > _initialLocalScale.y)
        {
            ChangeBarSize(_decreaseSpeed);

            yield return null;
        }
        _canResize = true;
        transform.localScale = _initialLocalScale;
        transform.position = _initialPosition;
        if ((_pointsStored.OrbsInComboBar % _pointsStored.OrbsToCatchBeforePowerUp) > 0)
        {
            StartCoroutine(ResizeAfterReset());
        }
    }

    private IEnumerator ResizeAfterReset()
    {
        yield return null;

        ResizeBar();
    }

    private void ChangeBarSize(float speed)
    {
        transform.localScale += Vector3.up * _sizeIncreaseOnCatch * Time.deltaTime * speed;
        transform.position += Vector3.up * _sizeIncreaseOnCatch * 5 * Time.deltaTime * speed;
    }

    private void ResetBar()
    {
        _resetBar = true;
    }

    private void ResetBarFail()
    {
        StopAllCoroutines();
        StartCoroutine(ResetBarSize());
    }
}
