using System;
using UnityEngine;

public class DistanceVisualizerElement : MonoBehaviour
{
    public event Action<GameObject> OnDestroyEvent; 
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        if(OnDestroyEvent != null)  OnDestroyEvent.Invoke(gameObject);
        // est équivalent à
        //OnDestroyEvent?.Invoke();
    }
}
