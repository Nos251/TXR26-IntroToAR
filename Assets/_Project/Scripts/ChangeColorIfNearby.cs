using UnityEngine;

namespace _Project.Scripts
{
    public class ChangeColorIfNearby : MonoBehaviour
    {
        [SerializeField, Tooltip("Distance at which we change the color")] private float _colorSwapThreshold = 1.4f;
        [SerializeField, Tooltip("Default Material of this cube")] private Material _defaultMaterial;
        [SerializeField] private Material _nearbyMaterial;
        [SerializeField] private MeshRenderer _renderer;
        [SerializeField] private TMPro.TMP_Text _text;
        [SerializeField] private Transform _textContainer;
    
        private Camera _camera;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        private void Awake()
        {
            if(_renderer == null) Debug.LogWarning("No MeshRenderer found!");
        }

        private void Start()
        {
            _camera = Camera.main;
        }


        // Update is called once per frame
        private void Update()
        {
            Vector3 direction = _text.transform.position - _camera.transform.position;
            Quaternion rotation = Quaternion.LookRotation(direction);
        
            Vector3 distanceTestVector =  transform.position - _camera.transform.position;
        
            float distance =  distanceTestVector.magnitude;

            if (distance > _colorSwapThreshold) _renderer.material = _defaultMaterial;
            else _renderer.material = _nearbyMaterial;
            _text.SetText(distance.ToString("F2"));
            _text.transform.rotation = rotation;
        
        }
    }
}