﻿//
// File: WebHttpRequest.cs
//
// Authors:
//   Steinar Herland <steinar.herland@gecko.no>
//
// Copyright (C) 2008 Steinar Herland
// Copyright (C) 2008 Gecko Informasjonssystmer AS (http://www.gecko.no)
//
// Licensed under the terms of the GNU Lesser General Public License
// (http://www.opensource.org/licenses/lgpl-license.php)

using System;
using System.Collections.Specialized;
using System.Web;
using GeoCache.Core.Web;

namespace GeoCache.Web
{
	public class WebHttpRequest : IHttpRequest
	{
		readonly HttpRequest _request;
		public WebHttpRequest(HttpRequest request)
		{
			_request = request;
		}
		public NameValueCollection Params { get { return _request.Params; } }
		public Uri Url { get { return _request.Url; } }
	}
}
