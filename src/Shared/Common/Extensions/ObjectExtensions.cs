// Copyright (c) Alexander Shlyakhto (InfDev). All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.
// Created:  2019.05.26
// Modified: 2021.10.21

using System;
using System.Collections.Generic;

namespace CDPN.Common.Extensions
{
    public static class ObjectExtensions
    {
		public static Dictionary<string, string> GetPropertiesWithValues(this object obj)
		{
			var props = new Dictionary<string, string>();
			if (obj == null)
				return props;

			var type = obj.GetType();
			foreach (var prop in type.GetProperties())
			{
				var val = prop.GetValue(obj, Array.Empty<object>());
				var valStr = val == null ? "" : val.ToString();
				props.Add(prop.Name, valStr);
			}

			return props;
		}
	}
}
