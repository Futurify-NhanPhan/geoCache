//
// File: ObjectManager.cs
//
// Author:
//   Steinar Herland <steinar.herland@gecko.no>
//
// Copyright (C) 2008 Steinar Herland
// Copyright (C) 2008 Gecko Informasjonssystmer AS (http://www.gecko.no)
//
// Licensed under the terms of the GNU Lesser General Public License
// (http://www.opensource.org/licenses/lgpl-license.php)

using System.Collections.Generic;
using GeoCache.Core;

namespace GeoCache.Layers.Wms
{
	static class ObjectManager
	{
		internal static IEnumerable<IResponseValidator> GetResponseValidators()
		{
			return Resolver.Current.ResolveAll<IResponseValidator>();
		}

		internal static IEnumerable<UriInterceptor> GetUriInterceptors()
		{
			return Resolver.Current.ResolveAll<UriInterceptor>();
		}
	}
}
