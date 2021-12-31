using System.Collections.Generic;
using UnityEngine;

namespace Code.Common
{
    [CreateAssetMenu]
    public class Console : ScriptableObject
    {
        private Queue<string> _logs = new Queue<string>();
        public bool ShouldFlush { get; private set; }

        public void Send(string text)
        {
            _logs.Enqueue(text);
            ShouldFlush = true;
        }

        public string[] Flush()
        {
            ShouldFlush = false;
            var result = _logs.ToArray();
            _logs.Clear();
            return result;
        }
        
    }
}