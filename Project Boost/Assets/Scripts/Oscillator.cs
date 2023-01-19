using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    Vector3 startingPosition;
    [SerializeField] Vector3 movementVector;
    float movementFactor;
    [SerializeField] float period = 2f;
    void Start()
    {
        startingPosition = transform.position;
        Debug.Log(startingPosition);
    }

    // Update is called once per frame
    void Update()
    {
        float cycles = Time.time / period;  // continually growing over time
        const float tau = Mathf.PI * 2;     // constant value of 6.283
        float rawSinWave = Mathf.Sin(cycles * tau);   // 프레임을 반복하면서 -1 ~ 1 사이의 값이 반복됨   

        movementFactor = (rawSinWave + 1f) / 2f;   // recalculated to go from 0 to 1 so its cleaner
        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPosition + offset;
    }
}
