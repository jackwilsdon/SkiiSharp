using System;

namespace ECS {
    public class EntityComponentTypeFilter : IEntityFilter {
        public Type[] ComponentTypes { get; private set; }

        public EntityComponentTypeFilter(params Type[] componentTypes) {
            ComponentTypes = componentTypes;
        }

        public bool apply(Entity entity) {
            foreach (Type componentType in ComponentTypes) {
                if (!entity.HasComponent(componentType)) {
                    return false;
                }
            }

            return true;
        }
    }
}

