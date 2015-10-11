using System;

namespace ECS {
    namespace Exceptions {
        public class ComponentNotFoundException : ComponentException {
            private const string MESSAGE_FORMAT = "component of type {type} not found";

            public ComponentNotFoundException(IComponent component) : base(component, MESSAGE_FORMAT) {}
        }
    }
}

