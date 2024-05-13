using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]

public class SpeedBoost : MonoBehaviour
{
    [SerializeField]
    private float _speedIncreaseAmount = 5;
    [SerializeField]
    private float _powerupDuration = 0.5f;

    [SerializeField]
    private GameObject _artDisable = null;

    private Collider _collider;

    private void Awake()
    {
        _collider = GetComponent<Collider>();    
    }


    private void OnTriggerEnter(Collider other)
    {
        AvionMovememnt avionMovemnt = other.gameObject.GetComponent<AvionMovememnt>();
        if (avionMovemnt != null )
        {
            StartCoroutine(PowerupSequence(avionMovemnt));
        }
    }
    public IEnumerator PowerupSequence(AvionMovememnt avionMovememnt)
    {
        _collider.enabled = false;
        _artDisable.SetActive(false);

        ActivatePowerup(avionMovememnt);
        yield return new WaitForSeconds( _powerupDuration );
        DeactivePowerup(avionMovememnt);

        Destroy(gameObject);
    }

    private void ActivatePowerup(AvionMovememnt avionMovememnt)
    {
        avionMovememnt.SetMoveSpeed( _speedIncreaseAmount );
    }
    private void DeactivePowerup(AvionMovememnt avionMovememnt)
    {
        avionMovememnt.SetMoveSpeed(_speedIncreaseAmount);
    }


}
