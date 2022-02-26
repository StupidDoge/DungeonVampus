using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearingWallsTrigger : MonoBehaviour
{
    [SerializeField] private GameObject _wallToDisappear;
    [SerializeField] private GameObject _wallToAppear;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) 
        {
            _wallToAppear.SetActive(true);
            _wallToDisappear.SetActive(false);
        }
    }
}
