using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using UnityEngine;

namespace Script.Enemies
{
    [RequireComponent(typeof(BombGenerator))]
    public class BombPool : MonoBehaviour
    {
        [SerializeField] private GameObject _bombPrefab;
        
        private List<Bomb> _bombs = new List<Bomb>();

        public Bomb InflateBomb(Vector2 location, Vector2 scale, float speed)
        {
            var bombInstance = GetBombToReuse();
            if (bombInstance == null)
            {
                bombInstance = Instantiate(_bombPrefab).GetComponent<Bomb>();
                _bombs.Add(bombInstance);
            }

            bombInstance.gameObject.transform.localPosition = location;
            bombInstance.gameObject.transform.localScale = scale;
            bombInstance.Speed = speed;
            bombInstance.gameObject.SetActive(true);
            
            return bombInstance;
        }
        
        private Bomb GetBombToReuse()
        {
            return _bombs.FirstOrDefault(bomb => !bomb.gameObject.active);
        }
    }
}