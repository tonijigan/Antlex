using UnityEngine;

public class Root : MonoBehaviour
{
    [SerializeField] private UpdateObject[] _updateObjects;

    private void Update()
    {
        foreach (var obj in _updateObjects)
            obj.StartUpdate();
    }
}
