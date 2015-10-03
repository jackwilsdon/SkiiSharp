using System;
using System.Collections.Generic;
using System.Linq;

namespace ECS {
    public class ComponentSet {
        private HashSet<Component> components = new HashSet<Component>();

        private Predicate<Object> getObjectTypePredicate(Type componentType) {
            return component => component.GetType() == componentType;
        }

        public bool Contains<T>() where T : Component {
            return Contains(typeof(T));
        }

        public bool Contains(Type componentType) {
            return components.Any(component => component.GetType() == componentType);
        }

        public Component Add(Component component) {
            if (Contains(component.GetType())) {
                throw new InvalidOperationException(String.Format("component of type `{0}' already in set",
                    component.GetType().Name));
            }

            components.Add(component);

            return component;
        }

        public void Remove<T>() where T : Component {
            Remove(typeof(T));
        }

        public void Remove(Type componentType) {
            if (!Contains(componentType)) {
                throw new InvalidOperationException(String.Format("component of type `{0}' not in set",
                    componentType.Name));
            }

            components.RemoveWhere(component => component.GetType() == componentType);
        }

        public T Get<T>() where T : Component {
            return (T) Get(typeof(T));
        }

        public Component Get(Type componentType) {
            if (!Contains(componentType)) {
                throw new InvalidOperationException(String.Format("component of type `{0}' not in set",
                    componentType.Name));
            }

            return components.Single(component => component.GetType() == componentType);
        }
    }
}
