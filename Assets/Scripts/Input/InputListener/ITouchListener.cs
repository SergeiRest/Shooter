using System;
using UniRx;
using VContainer.Unity;

namespace Input.InputListener
{
    public interface ITouchListener
    {
        public ReactiveCommand LeftMouseButtonDown { get; }
        public ReactiveCommand LeftMouseButtonUp { get; }
        public ReactiveCommand LeftMouseButton { get; }
    }

    public class MouseTouchListener : ITouchListener, ITickable, IDisposable
    {
        private ReactiveCommand _leftMouseButtonDown;
        private ReactiveCommand _leftMouseButtonUp;
        private ReactiveCommand _leftMouseButton;

        public ReactiveCommand LeftMouseButtonDown => _leftMouseButtonDown;
        public ReactiveCommand LeftMouseButtonUp => _leftMouseButtonUp;
        public ReactiveCommand LeftMouseButton => _leftMouseButton;

        public MouseTouchListener()
        {
            _leftMouseButtonDown = new ReactiveCommand();
            _leftMouseButtonUp = new ReactiveCommand();
            _leftMouseButton = new ReactiveCommand();
        }
        
        public void Tick()
        {
            if (UnityEngine.Input.GetMouseButtonDown(0))
            {
                _leftMouseButtonDown?.Execute();
            }
            else if (UnityEngine.Input.GetMouseButton(0))
            {
                _leftMouseButton?.Execute();
            }
            else if(UnityEngine.Input.GetMouseButtonUp(0))
            {
                _leftMouseButtonUp?.Execute();
            }
        }


        public void Dispose()
        {
            _leftMouseButtonDown?.Dispose();
            _leftMouseButtonUp?.Dispose();
            _leftMouseButton?.Dispose();
        }
    }
}