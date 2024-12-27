using UnityEngine;
using Zenject;  
public class Wolf : MonoBehaviour
{
    [SerializeField] private MainCharacter player;
    [Inject]
    public void Constructor(MainCharacter player)
    {
        this.player = player;
    }
}
