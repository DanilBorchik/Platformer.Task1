using UnityEngine;
namespace fishscripts
{
    public class shcriptos
    {
        public static float GetValueWithDeadZone(float value, float deadZone)
        {
            if (Mathf.Abs(value) > deadZone)
            {
                return value;
            }
            else
            {
                return 0f;
            }
        }
        
    }
}