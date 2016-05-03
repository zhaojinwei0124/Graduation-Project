using UnityEngine;

namespace UI
{
    public class UICamera : MonoBehaviour
    {
        private float devHeight = 9.6f;
        private float devWidth = 6.4f;
        public static UICamera Instance;
        [HideInInspector] 
		public Camera Camera;

#if UNITY_EDITOR
        private void OnValidate()
        {
            Camera = GetComponent<Camera>();
        }
#endif

        private void Awake()
        {
			Instance = this;
            Camera = GetComponent<Camera>();
        }

        private void Start()
        {
            float orthographicSize = this.GetComponent<Camera>().orthographicSize;
            float aspectRatio = Screen.width*1.0f/Screen.height;
            float cameraWidth = orthographicSize*2*aspectRatio;
            if (cameraWidth < devWidth)
            {
                orthographicSize = devWidth/(2*aspectRatio);
                this.GetComponent<Camera>().orthographicSize = orthographicSize;
            }
        }
    }
}