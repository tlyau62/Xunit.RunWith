using System;

namespace Xunit.RunWith
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = false)]
    public class RunWithAttribute : Attribute
    {
        public Type RunWithClass { get; set; }

        public RunWithAttribute(Type runWithClass)
        {
            if (!typeof(IRunWith).IsAssignableFrom(runWithClass))
            {
                throw new InvalidOperationException("Type mismatched.");
            }

            RunWithClass = runWithClass;
        }
    }
}
