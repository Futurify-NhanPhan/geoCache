//
// File: IResponseValidator.cs
//
// Author:
//   Steinar Herland <steinar.herland@gecko.no>
//
// Copyright (C) 2008 Steinar Herland
// Copyright (C) 2008 Gecko Informasjonssystmer AS (http://www.gecko.no)
//
// Licensed under the terms of the GNU Lesser General Public License
// (http://www.opensource.org/licenses/lgpl-license.php)

namespace GeoCache.Layers.Wms
{
	public interface IResponseValidator
	{
		bool Validate(byte[] data);
	}
}
