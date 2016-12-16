using UnityEngine;
using System.Collections;

public class SpawnShapes : MonoBehaviour
{

    [SerializeField]
    private GameObject _shapeToSpawn;

    [SerializeField]
    private GameObject _shapeColors;

    [SerializeField]
    private float _timeBetweenSpawns = 1;

    [SerializeField]
    private GameObject _catchBar;

    [SerializeField]
    private float _shapeMinimumSpeed = 2;

    [SerializeField]
    private float _shapeMaximumSpeed = 4;

    private WaitForSeconds _delaySpawn;

    private float _halfOfBar;
    private Vector3 _initialShapePosition;
    private GameObject _createdShape;
    private ShapeColors _colors;
    private System.Random _random;

    private void Start()
    {
        _delaySpawn = new WaitForSeconds(_timeBetweenSpawns);
        _halfOfBar = (_catchBar.transform.localScale.x * 0.5f) - (_shapeToSpawn.transform.localScale.x * 0.75f);
        _initialShapePosition = (Vector3.right * transform.position.x) + (Vector3.up * transform.position.y);
        _random = new System.Random();
        _colors = _shapeColors.GetComponent<ShapeColors>();

        StartCoroutine(SpawnShape());
    }

    private IEnumerator SpawnShape()
    {
        while (true)
        {
            CreateShape();

            yield return _delaySpawn;
        }
    }

    private void CreateShape()
    {
        _createdShape = (GameObject)Instantiate(_shapeToSpawn, SetShapeInitialPosition(), new Quaternion());
        _createdShape.GetComponent<SpriteRenderer>().color = GetShapeColor();
        _createdShape.GetComponent<MoveSquare>().SpeedPerSecond = GetShapeSpeed();
    }

    private Vector3 SetShapeInitialPosition()
    {
        return Vector3.right * Random.Range(-_halfOfBar, _halfOfBar) + _initialShapePosition;
    }

    private Color GetShapeColor()
    {
        return _colors.Colors[_random.Next(0, _colors.Colors.Length)];
    }

    private float GetShapeSpeed()
    {
        return Random.Range(_shapeMinimumSpeed, _shapeMaximumSpeed);
    }
}
