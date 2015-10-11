using System;

namespace ECS {
    public interface IEntityFilter {
        bool apply(Entity entity);
    }
}

