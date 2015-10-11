using System;

namespace ECS {
    public interface ISystem {
        bool beforeExecute(Entity entity);
        void execute(Entity entity);
    }
}

