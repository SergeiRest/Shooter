using System;
using System.Collections.Generic;
using System.Linq;
using VContainer;
using Object = UnityEngine.Object;

namespace Modules.UI
{
    public interface IUIContainer
    {
        public T GetUI<T>() where T : UIView;
    }
    public class UIContainer : IUIContainer
    {
        private readonly IObjectResolver _resolver;
        
        private Dictionary<Type, UIView> _views = new Dictionary<Type, UIView>();
        private UIView[] _prefabs;

        public UIContainer(IObjectResolver resolver, UIView[] prefabs)
        {
            _prefabs = prefabs;
            _resolver = resolver;
        }

        public T GetUI<T>() where T : UIView
        {
            Type type = typeof(T);
            if (_views.TryGetValue(type, out UIView value))
            {
                return (T)value;
            }

            try
            {
                UIView selected = _prefabs.First(prefab => prefab is T);
                UIView obj = Object.Instantiate(selected);
                _views.Add(type, obj);
                return (T)obj;
            }
            catch (Exception e)
            {
                throw new NullReferenceException($"None object of type {type}");
            }
        }
    }
}