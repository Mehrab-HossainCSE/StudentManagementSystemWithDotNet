using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementStytem.Service.Utilities
{
    public static class Extensions
    {
        public static int GetEnumLength(this Type enumType)
        {
            return Enum.GetNames(enumType).Length;
        }
    }
}
