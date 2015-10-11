using System;
using System.Collections.Generic;
using System.Linq;

namespace ECS {
    public class ComponentSet {
        private HashSet<IComponent> components = new HashSet<IComponent>();

        private Predicate<Object> getObjectTypePredicate(Type componentType) {
            return component => component.GetType() == componentType;
        }

        public bool Contains<T>() where T : IComponent {
            return Contains(typeof(T));
        }

        public bool Contains(Type componentType) {
            return components.Any(component => component.GetType() == componentType);
        }

        public IComponent Add(IComponent component) {
            if (Contains(component.GetType())) {
                throw new InvalidOperationException(String.Format("component of type `{0}' already in set",
                    component.GetType().Name));
            }

            components.Add(component);

            return component;
        }

        public void Remove<T>() where T : IComponent {
            Remove(typeof(T));
        }

        public void Remove(Type componentType) {
            if (!Contains(componentType)) {
                throw new InvalidOperationException(String.Format("component of type `{0}' not in set",
                    componentType.Name));
            }

            components.RemoveWhere(component => component.GetType() == componentType);
        }

        public T Get<T>() where T : IComponent {
            return (T) Get(typeof(T));
        }

        public IComponent Get(Type componentType) {
            if (!Contains(componentType)) {
                throw new InvalidOperationException(String.Format("component of type `{0}' not in set",
                    componentType.Name));
            }

            return components.Single(component => component.GetType() == componentType);
        }
    }
}
