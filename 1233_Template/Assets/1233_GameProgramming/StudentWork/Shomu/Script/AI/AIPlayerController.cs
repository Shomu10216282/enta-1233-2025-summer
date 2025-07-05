using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPlayerController : MonoBehaviour
{
    [SerializeField] private AgentMoveToTransform Mover;
    [SerializeField] private int MaxHp;
    [SerializeField] private HealthBarDisplay HealthDisplay;
    [SerializeField] private LayerMask DamageLayers;

    // Start is called before the first frame update

    private int _currentHp;

    void Start()
    {
        _currentHp = MaxHp;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == DamageLayers)
        {
            _currentHp--;
            OnDamageTaken();
        }
    }

    private void OnDamageTaken()  
    {
        float currentHpPercent = (float)_currentHp / MaxHp;
        HealthDisplay.UpdateHp(currentHpPercent);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
