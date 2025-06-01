using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    private GameObject _enemy;
    void Update()
    {
        if(_enemy == null)
        {
            _enemy = Instantiate(enemyPrefab);
            _enemy.transform.position = this.transform.position;
        }
    }
}
