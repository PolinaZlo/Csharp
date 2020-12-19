using System;
using System.Windows;
using System.Windows.Input;
using System.Collections.Generic;

namespace lab3AWPF
{
    internal class KeyInfo
    {
        private string keyCode = null;
        private int keyValue = 0;
        private string keyState = null;
        private char keyChar = '\0';
        private string systemKey = null;
        private string keyDown = false.ToString();
        private string keyUp = false.ToString();

        public KeyInfo(KeyEventArgs k)
        {
            KeyCode = k.Key.ToString();
            KeyValue = (int)k.Key;
            KeyChar = (char)k.Key;
            KeyState = k.KeyStates.ToString();
            SystemKey = k.SystemKey.ToString();
            KeyDown = k.IsDown.ToString();
            KeyUp = k.IsUp.ToString();
        }

        public string KeyCode { get {return keyCode;} set {keyCode = value; }}
        public int KeyValue { get { return keyValue; } set { keyValue = value; } }
        public string KeyState { get { return keyState; } set { keyState = value; } }
        public char KeyChar { get { return keyChar; } set { keyChar = value; } }
        public string SystemKey { get { return systemKey; } set { systemKey = value; } }
        public string KeyDown { get { return keyDown; } set { keyDown = value; } }
        public string KeyUp { get { return keyUp; } set { keyUp = value; } }
    }
}
