//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TaxLink
{
    using System;
    using System.Collections.Generic;
    
    public partial class CitizenshipTaxpayer
    {
        public int IdTaxpayer { get; set; }
        public string ShortContryName { get; set; }
        public string Description { get; set; }
    
        public virtual Citizenship Citizenship { get; set; }
        public virtual Taxpayer Taxpayer { get; set; }
    }
}
