﻿//
// File: Cell.cs
//
// Author:
//   Steinar Herland <steinar.herland@gecko.no>
//
// Copyright (C) 2008 Steinar Herland
// Copyright (C) 2008 Gecko Informasjonssystmer AS (http://www.gecko.no)
//
// Licensed under the terms of the GNU Lesser General Public License
// (http://www.opensource.org/licenses/lgpl-license.php)

using System;

namespace GeoCache.Core
{
	public struct Cell : IEquatable<Cell>
	{
		//public Cell() { }
		public Cell(double x, double y, int z)
		{
			_x = x;
			_y = y;
			_z = z;
		}
		double _x, _y;
		int _z;
		public double X { get { return _x; } set { _x = value; } }
		public double Y { get { return _y; } set { _y = value; } }
		public int Z { get { return _z; } set { _z = value; } }

		public override string ToString()
		{
			return string.Format("Cell X={0} Y={1} Z={2}", X, Y, X);
		}

		public override int GetHashCode()
		{
			return X.GetHashCode() ^ Y.GetHashCode() ^ Z;
		}

		public override bool Equals(object obj)
		{
			if (obj is Cell)
				return Equals((Cell)obj);
			return false;
		}

		public bool Equals(Cell other)
		{
			return other.X == X && other.Y == Y && other.Z == Z;
		}

		public static bool operator ==(Cell cell1, Cell cell2)
		{
			return cell1.Equals(cell2);
		}

		public static bool operator !=(Cell cell1, Cell cell2)
		{
			return !cell1.Equals(cell2);
		}
	}
}
