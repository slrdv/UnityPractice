using TMPro;
using UnityEngine;

namespace Game
{
    public sealed class StatsPanel : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text _name;
        [SerializeField]
        private TMP_Text _health;
        [SerializeField]
        private TMP_Text _damage;
        [SerializeField]
        private TMP_Text _speed;
        [SerializeField]
        private TMP_Text _fireRate;

        public void SetName(string name)
        {
            _name.text = name;
        }

        public void SetHealth(int health)
        {
            _health.text = $"Health: {health}";
        }

        public void SetDamage(int damage)
        {
            _damage.text = $"Damage: {damage}";
        }

        public void SetSpeed(float speed)
        {
            _speed.text = $"Speed: {speed}";
        }

        public void SetFireRate(float fireRate)
        {
            _fireRate.text = $"Fire Rate: {fireRate}";
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}
