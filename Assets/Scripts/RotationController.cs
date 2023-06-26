using UnityEngine;

namespace Sanktuary.Sometimes
{
    public class RotationController : MonoBehaviour
    {
        [Header("Rotation Variables")]
        [SerializeField]
        private Transform rotationPoint;
        public float rotationSpeed = 3f;
        public Vector3 rotationDirection = new Vector3(0, 0, -1);

        private void Start() {
            if (rotationPoint == null) {
                this.rotationPoint = transform;
            }    
        } 

        void Update() {
            transform.RotateAround(rotationPoint.position, rotationDirection, rotationSpeed * Time.deltaTime);
        }
    }
}
