﻿/***************************************************************************
	Copyright (C) 2014-2015 by Nick Thijssen <lamah83@gmaill.com>

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

using OBS;

namespace test
{
	public class Source : ObsSource
	{
		public Source(ObsSourceType type, string id, string name)
			: base(type, id, name)
		{
		}

		public Source(ObsSourceType type, string id, string name, ObsData settings)
			: base(type, id, name, settings)
		{
		}
	}
}