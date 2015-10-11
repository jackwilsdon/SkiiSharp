using System;

namespace ECS {
    public abstract class FilteredSystem : ISystem {
        public IEntityFilter Filter;

        public FilteredSystem(IEntityFilter filter = null) {
            Filter = filter;
        }

        public bool beforeExecute(Entity entity) {
            if (Filter == null) {
                return true;
            }

            return Filter.apply(entity);
        }

        public abstract void execute(Entity entity);
    }
}

