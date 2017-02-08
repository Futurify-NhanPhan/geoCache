﻿//
// File: WmsClient.cs
//
// Author:
//   Steinar Herland <steinar.herland@gecko.no>
//
// Copyright (C) 2006-2007 MetaCarta, Inc.
// Copyright (C) 2008 Steinar Herland
// Copyright (C) 2008 Gecko Informasjonssystmer AS (http://www.gecko.no)
//
// Licensed under the terms of the GNU Lesser General Public License
// (http://www.opensource.org/licenses/lgpl-license.php)

using System;
using System.Collections.Generic;
using System.Diagnostics;
using GeoCache.Extensions.Base;

namespace GeoCache.Layers.Wms
{
	class WmsClient
	{
		static string[] _fields = new string[] 
			{ "bbox", "srs", "width", "height", "format", "layers", "styles" };
		
		static Dictionary<string, string> _defaultParams = new Dictionary<string, string>
		{
			{"EXCEPTIONS", "application/vnd.ogc.se_xml"},
			{"version", "1.1.1"},
			{"request", "GetMap"},
			{"service", "WMS"},
		};

		Uri _uri;

		#region python
		/*
		def __init__ (self, base, params):
			self.base    = base
			if self.base[-1] not in "?&":
				if "?" in self.base:
					self.base += "&"
				else:
					self.base += "?"

			self.params  = {}
			self.client  = urllib2.build_opener()
			for key, val in self.defaultParams.items():
				if self.base.lower().rfind("%s=" % key.lower()) == -1:
					self.params[key] = val
			for key in self.fields:
				if params.has_key(key):
					self.params[key] = params[key]
				elif self.base.lower().rfind("%s=" % key.lower()) == -1:
					self.params[key] = ""
		 */
		#endregion
		public WmsClient(Uri uri, IDictionary<string, string> @params)
		{
			var newParams = new Dictionary<string, string>(_defaultParams);
			foreach (var key in _fields)
				if (@params.ContainsKey(key))
				{
					if (newParams.ContainsKey(key))
						newParams[key] = @params[key];
					else
						newParams.Add(key, @params[key]);
				}

			//Reset params given in uriBase:
			var uriBuilder = new UriBuilder(uri);
			var queryParams = uriBuilder.GetQueryParams();
			foreach(var p in queryParams)
				if(newParams.ContainsKey(p.Key))
					newParams[p.Key] = p.Value;
				else
					newParams.Add(p.Key, p.Value);
			
			//UrlEncode params:
			uriBuilder.SetQuery(newParams, true);
			foreach (var interceptor in ObjectManager.GetUriInterceptors())
				interceptor.Intercept(uriBuilder);

			_uri = uriBuilder.Uri;
		}

		public byte[] Fetch()
		{
			int retryCount = 3;
			while (retryCount-- > 0)
			{
				using (var client = new System.Net.WebClient())
				{
					client.Headers.Add("user-agent", "GeoCache");
					//throw new NotImplementedException(this._uri.ToString());
					System.Diagnostics.Trace.WriteLine("Fetching data from " + _uri, "WmsRequest");
					var data = client.DownloadData(_uri);
					var dataOk = true;
					foreach (var validator in ObjectManager.GetResponseValidators())
					{
						if (!validator.Validate(data))
							dataOk = false;
					}
					if (dataOk)
						return data;
					Trace.WriteLine("Data failed to validate. Will retry " + retryCount + " times.");
				}
			}
			throw new Exception("Data failed to validate");
		}
	}
}
