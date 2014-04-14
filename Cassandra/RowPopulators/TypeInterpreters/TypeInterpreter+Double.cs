//
//      Copyright (C) 2012 DataStax Inc.
//
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//
//      http://www.apache.org/licenses/LICENSE-2.0
//
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.
//
﻿using System;

namespace Cassandra
{
    internal partial class TypeInterpreter
    {
        public static object ConvertFromDouble(IColumnInfo type_info, byte[] value, Type cSharpType)
        {
            var buffer = (byte[])value.Clone();
            Array.Reverse(buffer);
            return BitConverter.ToDouble(buffer, 0);
        }

        public static Type GetDefaultTypeFromDouble(IColumnInfo type_info)
        {
            return typeof(double);
        }

        public static byte[] InvConvertFromDouble(IColumnInfo type_info, object value)
        {
            CheckArgument<double>(value);
            byte[] ret = BitConverter.GetBytes((double)value);
            Array.Reverse(ret);
            return ret;
        }
    }
}