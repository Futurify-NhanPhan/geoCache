﻿//
// File: ITile.cs
//
// Author:
//   Steinar Herland <steinar.herland@gecko.no>
//
// Copyright (C) 2008 Steinar Herland
// Copyright (C) 2008 Gecko Informasjonssystmer AS (http://www.gecko.no)
//
// Licensed under the terms of the GNU Lesser General Public License
// (http://www.opensource.org/licenses/lgpl-license.php)

namespace GeoCache.Core
{
	public interface ITile
	{
		string BBox { get; }
		IBBox Bounds { get; }
		Cell Cell { get; set; }
		System.Drawing.Size Size { get; }
		double X { get; }
		double Y { get; }
		int Z { get; }
		ILayer Layer { get; }
	}
}
