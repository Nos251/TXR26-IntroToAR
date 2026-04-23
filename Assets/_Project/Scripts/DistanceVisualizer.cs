using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;

public class DistanceVisualizer : MonoBehaviour
{
    private ObjectSpawner _objectSpawner;
    private LineRenderer _lineRenderer;
    
    private List<GameObject> _objectList;
    [SerializeField] private float _offset=.1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        _objectSpawner = GetComponent<ObjectSpawner>();
        _lineRenderer = GetComponent<LineRenderer>();
        
        _objectList = new List<GameObject>();
        
    }

    private void OnEnable()
    {
        _objectSpawner.objectSpawned += OnObjectSpawn;
    }

    private void OnDisable()
    {
        _objectSpawner.objectSpawned -= OnObjectSpawn;
    }

    private void OnObjectSpawn(GameObject obj)
    {
        Debug.Log("Object Spawned:  " + obj.name);
        DistanceVisualizerElement element = obj.GetComponent<DistanceVisualizerElement>();
        if (element != null)
        {
            element.OnDestroyEvent += ElementOnOnDestroyEvent;
            _objectList.Add(obj);
        }
    }

    private void ElementOnOnDestroyEvent(GameObject obj)
    {
        Debug.Log("Object Destroyed");
        _objectList.Remove(obj);
    }

    // Update is called once per frame
    void Update()
    {
        if (_objectList.Count > 1)
        {
            _lineRenderer.positionCount = _objectList.Count;
            //Tracer la ligne
            for (int i = 0; i < _objectList.Count; i++)
            {
                _lineRenderer.SetPosition(i, _objectList[i].transform.position+_offset*Vector3.up);
            }
        }
        else
        {
            _lineRenderer.positionCount = 0;
        }
    }
    
    
    
}
