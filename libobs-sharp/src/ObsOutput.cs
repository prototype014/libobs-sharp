using System;

namespace OBS
{
    public class ObsOutput
    {
        internal IntPtr instance; //pointer to unmanaged object

		// TODO: Create

        public unsafe bool Start(IntPtr instance)
        {
            this.instance = instance;

            return libobs.obs_output_start(ref instance);
        }

		// TODO: Stop
    }
}
