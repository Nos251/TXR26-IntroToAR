using UnityEngine;
using UnityEngine.XR.ARFoundation;

namespace _Project.Scripts
{
    public class ImageDetector : MonoBehaviour
    {
        private ARTrackedImageManager _trackedImageManager;
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        private void Awake()
        {
            _trackedImageManager = GetComponent<ARTrackedImageManager>();
        }

        private void OnEnable()
        {
            _trackedImageManager.trackablesChanged.AddListener(OnChanged);
        }

        private void OnDisable()
        {
            _trackedImageManager.trackablesChanged.RemoveListener(OnChanged);
        }

        private void OnChanged(ARTrackablesChangedEventArgs<ARTrackedImage> eventArgs)
        {
            foreach (ARTrackedImage image in eventArgs.added)
            {
                string imageName = image.referenceImage.name;
                Vector3 spawnPosition = image.transform.position;
                Debug.Log($"Image Added: {image.referenceImage.name}");
                switch (imageName)
                {
                    case "one":
                        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                        cube.transform.position = spawnPosition;
                        cube.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);

                        break;
                    
                    case "untitylogonwiteonblack":
                        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                        sphere.transform.position = spawnPosition;
                        sphere.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                        break;
                    
                    default:
                        Debug.Log();
                }
            }

            foreach (ARTrackedImage image in eventArgs.updated)
            {
                
            }
        }

        // Update is called once per frame
        private void Update()
        {
        
        }
        
        public void ReactToTrackableChanges(ARTrackablesChangedEventArgs<ARTrackedImage> eventArgs)
        {
            Debug.Log("ARTrackedImagesChanged");
        }
    }
}
