namespace Dondoko
{
    internal abstract class Module
    {
        public const int DefaultModulePriority = 0;

        protected Module() { }

        /// <summary>
        /// Gets the priority of the framework module.
        /// </summary>
        /// <remarks>Modules with higher priority will be updated earlier.</remarks>
        public virtual int Priority => DefaultModulePriority;

        public abstract void Update(float logicalElapse, float realElapse);

        public abstract void Shutdown();
    }
}