using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.UI;

namespace UnityCsprojNuget.OpenUpmTest
{
    public sealed class Dummy : MonoBehaviour
    {
        [SerializeField] private Text _text;

        private void Start() => _text.text = JsonConvert.SerializeObject(new Demo());
    }
}
