using System;

namespace ECS {
    namespace Exceptions {
        public class ComponentAlreadyPresentException : ComponentException {
            private const string MESSAGE_FORMAT = "component of type {type} already present";

            public ComponentAlreadyPresentException(Component component) : base(component, MESSAGE_FORMAT) {}
        }
    }
}

