using UnityEngine;
public class DestroyOnEnable : MonoBehaviour
{
    public void OnEnable()
    {
        Destroy(gameObject);
    }
}