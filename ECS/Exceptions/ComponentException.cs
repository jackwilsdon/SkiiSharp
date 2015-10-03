using System;

namespace ECS {
    namespace Exceptions {
        public abstract class ComponentException : Exception {
            public Component Component { get; private set; }

            public ComponentException(Component component, string format) : base(GetMessage(component, format)) {
                Component = component;
            }

            private static string GetMessage(Component component, string messageFormat) {
                string componentName = component == null ? "null" : component.GetType().Name;
                return ReplaceFirst(messageFormat, "{type}", componentName);
            }

            private static string ReplaceFirst(string sourceValue, string searchValue, string replacementValue) {
                int replaceStart = sourceValue.IndexOf(searchValue);
                int replaceEnd = replaceStart + searchValue.Length;

                if (replaceStart == -1) {
                    return sourceValue;
                }

                return sourceValue.Substring(0, replaceStart) + replacementValue + sourceValue.Substring(replaceEnd);
            }
        }
    }
}

