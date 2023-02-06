using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundRepeat : MonoBehaviour
{
    private Vector3 start_position;
    private float repeat_width;

    // Start is called before the first frame update
    void Start()
    {
        start_position = transform.position;
        repeat_width = GetComponent<BoxCollider>().size.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < start_position.x - repeat_width)
        {
            transform.position = start_position;

        }
    }
}
