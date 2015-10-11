using System;

namespace ECS {
    public class Entity {
        public Guid Identifier { get; private set; }
        private ComponentSet Components = new ComponentSet();

        public Entity(params IComponent[] components) {
            Identifier = Guid.NewGuid();

            foreach (IComponent component in components) {
                Components.Add(component);
            }
        }

        public bool HasComponent<T>() where T : IComponent {
            return Components.Contains<T>();
        }

        public bool HasComponent(Type componentType) {
            return Components.Contains(componentType);
        }

        public IComponent AddComponent(IComponent component) {
            return Components.Add(component);
        }

        public void RemoveComponent<T>() where T : IComponent {
            Components.Remove<T>();
        }

        public void RemoveComponent(Type componentType) {
            Components.Remove(componentType);
        }

        public T GetComponent<T>() where T : IComponent {
            return Components.Get<T>();
        }

        public IComponent GetComponent(Type componentType) {
            return Components.Get(componentType);
        }
    }
}

