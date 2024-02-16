using UnityEngine;

namespace Parallax
{
    public class ParallaxController : MonoBehaviour
    {
        [SerializeField] private float _animationSpeed = 0.05f;

        private MeshRenderer _meshRenderer;

        private void Awake()
        {
            _meshRenderer = GetComponent<MeshRenderer>();
        }

        private void Update()
        {
            Paralaxed();
        }

        private void Paralaxed()
        {
            _meshRenderer.material.mainTextureOffset += new Vector2(0, Time.deltaTime * _animationSpeed);
        }
    }
}