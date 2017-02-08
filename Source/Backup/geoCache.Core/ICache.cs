//
// File: ICache.cs
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
	public interface ICache
	{
		byte[] Set(ITile tile, byte[] data);
		void Lock(ITile tile);
		bool Lock(ITile tile, bool blocking);
		byte[] Get(ITile tile);
		void Unlock(ITile tile);
	}
}
