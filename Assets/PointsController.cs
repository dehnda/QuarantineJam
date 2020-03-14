using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsController : MonoBehaviour
{
    [SerializeField]
    private float startPoints = 100f;
    [SerializeField]
    private float curentPoints = 100f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddPoints(float points)
    {
        curentPoints += points;
        curentPoints = Mathf.Min(curentPoints, startPoints);
    }
}
