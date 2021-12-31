using UnityEngine;
using Console = Code.Common.Console;

namespace Code.GUI
{
    public class ConsoleDisplay : MonoBehaviour
    {
        [SerializeField] private Console _console;

        // TODO: implement UI
        private void Update()
        {
            if (_console.ShouldFlush)
            {
                var content = _console.Flush();
                foreach (var line in content)
                {
                    Debug.Log(line);
                }
            }
        }
    }
}