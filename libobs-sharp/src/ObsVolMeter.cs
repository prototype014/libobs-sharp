/***************************************************************************
	Copyright (C) 2014-2015 by Ari Vuollet <ari.vuollet@kapsi.fi>

	This program is free software; you can redistribute it and/or
	modify it under the terms of the GNU General Public License
	as published by the Free Software Foundation; either version 2
	of the License, or (at your option) any later version.

	This program is distributed in the hope that it will be useful,
	but WITHOUT ANY WARRANTY; without even the implied warranty of
	MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
	GNU General Public License for more details.

	You should have received a copy of the GNU General Public License
	along with this program; if not, see <http://www.gnu.org/licenses/>.
***************************************************************************/

using System;
using System.Collections.Generic;
using OBS.Utility.Tuple;

namespace OBS
{
	using delegateTuple = Tuple<libobs.obs_volmeter_updated_t, IntPtr>;

	public class ObsVolMeter : IObsContextData, IDisposable
	{
		internal IntPtr instance; //pointer to unmanaged object

		// stored references to all delegates
		private List<delegateTuple> delegateRefs = new List<delegateTuple>();

		public unsafe ObsVolMeter(ObsFaderType faderType)
		{
			instance = libobs.obs_volmeter_create((libobs.obs_fader_type)faderType);

			if (instance == null)
				throw new ApplicationException("obs_volmeter_create failed");
		}

		public unsafe bool AttachSource(ObsSource source)
		{
			return libobs.obs_volmeter_attach_source(instance, source.GetPointer());
		}

		public unsafe void DetachSource()
		{
			libobs.obs_volmeter_detach_source(instance);
		}

		public unsafe void AddCallBbck(libobs.obs_volmeter_updated_t callback)
		{
			AddCallback(callback, IntPtr.Zero);
		}

		public unsafe void AddCallback(libobs.obs_volmeter_updated_t callback, IntPtr param)
		{
			// store the delegate tuple to prevent delegate getting removed
			// by garbage collector

			delegateTuple tuple = new delegateTuple(callback, param);
			delegateRefs.Add(tuple);
			libobs.obs_volmeter_add_callback(instance, tuple.Item1, tuple.Item2);
		}

		public unsafe void Dispose()
		{
			if (instance == IntPtr.Zero)
				return;

			libobs.obs_volmeter_destroy(instance);

			instance = IntPtr.Zero;
		}

		public unsafe IntPtr GetPointer()
		{
			return instance;
		}
	}

	public enum ObsFaderType : int
	{
		OBS_FADER_CUBIC,
		OBS_FADER_IEC,
		OBS_FADER_LOG
	};
}