using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxLink
{
    /// <summary>
    /// Данные о текущем пользователе
    /// </summary>
    public class CurrentUser
    {
        public static string Login { get; set; }
        public static int Id { get; set; }
        public static int TypeUser { get; set; }
    }
}
