using UnityEngine;

namespace Screen_Border
{
    public class ScreenBorder
    {
        public void CheckBorder(Transform transform, float borderX, float borderY)
        {
            transform.position = new Vector3(
                Mathf.Clamp(transform.position.x, -borderX, borderX),
                Mathf.Clamp(transform.position.y, -borderY, borderY), transform.position.z);
        }
    }
}