using System;

namespace ECS {
    public class CompoundFilter : IEntityFilter {
        public IEntityFilter[] Filters { get; private set; }

        public CompoundFilter(params IEntityFilter[] filters) {
            Filters = filters;
        }

        public bool apply(Entity entity) {
            foreach (IEntityFilter filter in Filters) {
                if (!filter.apply(entity)) {
                    return false;
                }
            }

            return true;
        }
    }
}

