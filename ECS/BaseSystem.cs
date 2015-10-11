using System;

namespace ECS {
    public abstract class BaseSystem : ISystem {
        public bool beforeExecute(Entity entity) {
            return true;
        }

        public abstract void execute(Entity entity);
    }
}

