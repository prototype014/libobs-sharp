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
using System.Runtime.InteropServices;

namespace OBS
{
	using obs_volmeter_t = IntPtr;
	using obs_source_t = IntPtr;

	public static partial class libobs
	{
		[UnmanagedFunctionPointer(importCall, CharSet = importCharSet)]
		public delegate void obs_volmeter_updated_t(IntPtr data, float level, float mag,
			float peak, float muted);

		[DllImport(importLibrary, CallingConvention = importCall)]
		public static extern obs_volmeter_t obs_volmeter_create(obs_fader_type fader);

		[DllImport(importLibrary, CallingConvention = importCall)]
		public static extern void obs_volmeter_destroy(obs_volmeter_t volmeter);

		[DllImport(importLibrary, CallingConvention = importCall)]
		public static extern bool obs_volmeter_attach_source(obs_volmeter_t volmeter, obs_source_t source);

		[DllImport(importLibrary, CallingConvention = importCall)]
		public static extern void obs_volmeter_detach_source(obs_volmeter_t volmeter);

		[DllImport(importLibrary, CallingConvention = importCall)]
		public static extern void obs_volmeter_add_callback(obs_volmeter_t volmeter, obs_volmeter_updated_t callback, IntPtr param);

		[DllImport(importLibrary, CallingConvention = importCall)]
		public static extern void obs_volmeter_remove_callback(obs_volmeter_t volmeter, obs_volmeter_updated_t callback, IntPtr param);

		public enum obs_fader_type : int
		{
			OBS_FADER_CUBIC,
			OBS_FADER_IEC,
			OBS_FADER_LOG
		};
	}
}