using UnityEngine;
using Zenject;
public class EnemySpanFabric : MonoBehaviour
{
    [Inject] private DiContainer dic;
    [SerializeField] private GameObject obj;
    [ContextMenu("Start")]
    public void Start()
    {
        dic.InstantiatePrefab(obj, transform.position, Quaternion.identity, null);
    }
}
