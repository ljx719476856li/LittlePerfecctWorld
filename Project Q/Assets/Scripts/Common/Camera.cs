using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    private Transform _playerTransform;

    private Vector3 offSet;
    // Start is called before the first frame update
    void Start()
    {
        _playerTransform = GameObject.FindWithTag(Tags.PlayerTag).transform;
        offSet = _playerTransform.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = _playerTransform.position- offSet;
    }
}
