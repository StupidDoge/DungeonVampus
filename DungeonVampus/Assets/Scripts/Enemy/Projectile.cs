using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private int _speed;
    [SerializeField] private Transform _sprite;

    public int Damage { get; set; }

    void Update()
    {
        _sprite.LookAt(Camera.main.transform.position, -Vector3.up);
        transform.Translate(new Vector3(0, 0, _speed * Time.deltaTime));
        Destroy(gameObject, 3f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            player.HealthSystem.TakeDamage(Damage);
            player.gameObject.GetComponent<PlayerSoundController>().PlayHitSound();
        }

        if (other.CompareTag("Enemy"))
            Physics.IgnoreCollision(GetComponent<SphereCollider>(), other);
        else 
            Destroy(gameObject);
    }
}
