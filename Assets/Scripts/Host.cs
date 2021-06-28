using MLAPI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Host : MonoBehaviour
{
    private void Start()
    {
        NetworkManager.Singleton.StartHost();
    }
}
