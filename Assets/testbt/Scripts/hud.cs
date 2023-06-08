using UnityEngine;

namespace Daisy {
    public class HUDComponent : MonoBehaviour {
        public Transform target;
        public Camera sceneCamera;
        public Camera uiCamera;
        public RectTransform rectTrans;

        public static bool AllOutHide = false;


        #region MonoBehaviour methods

        void Start() {
            rectTrans = GetComponent<RectTransform>();
        }

        void LateUpdate() {
            UpdatePosition();
        }

        #endregion

        #region private methods

        void UpdatePosition() {


            if (AllOutHide) {
                (transform as RectTransform).anchoredPosition = new Vector2(10000f, 0);

                return;
            }

            if (target == null) return;
            if (sceneCamera == null) return;
            if (uiCamera == null) return;



            var screenPos = sceneCamera.WorldToScreenPoint(target.position);
            Vector2 uiPos;

            RectTransformUtility.ScreenPointToLocalPointInRectangle(transform.parent as RectTransform,
            new Vector2(screenPos.x, screenPos.y), uiCamera, out uiPos);

            (transform as RectTransform).anchoredPosition = uiPos; 
                
         }

        #endregion

        #region public methods

        public void SetCamera(Camera camera) {
            uiCamera = camera;
        }

        public void SetTarget(Transform target) {
            if (target == this.target) return;

            this.target = target;
            UpdatePosition();
        }

        #endregion
    }
}