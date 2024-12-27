using UnityEngine;
using Zenject;
public class MainCharacterInstaller : MonoInstaller
{
    [SerializeField] private MainCharacter player;
    public override void InstallBindings()
    {
        Container.Bind<MainCharacter>().FromInstance(player).AsSingle();
    }
}