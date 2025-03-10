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
    
    public partial class Arrears
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Arrears()
        {
            this.Payment = new HashSet<Payment>();
        }
    
        public int IdArrears { get; set; }
        public int IdTax { get; set; }
        public int IdTaxpayer { get; set; }
        public decimal Sum { get; set; }
        public System.DateTime StartDate { get; set; }
        public Nullable<System.DateTime> FinishDate { get; set; }
        public bool Status { get; set; }
    
        public virtual Tax Tax { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Payment> Payment { get; set; }

        public string FormatedStartDate
        {
            get
            {
                string formattedDate = StartDate.ToString("dd.MM.yy HH:mm:ss");
                return formattedDate;
            }
        }

        public string TaxpayerName
        {
            get
            {
                return Tax.Taxpayer.FIO;
            }
        }

        public string StatusName
        {
            get
            {
                string name = "";

                if (Status == true)
                {
                    name = "Оплачен";
                }
                else
                {
                    name = "Не оплачен";
                }

                return name;
            }
        }

        public string SumRub
        {
            get
            {
                string sum = Sum.ToString("N2");
                return sum;
            }
        }

        public string Peni
        {
            get
            {
                int days = 0;

                if (FinishDate == null)
                {
                    DateTime currentDate = DateTime.Now;
                    TimeSpan difference = currentDate - StartDate;
                    days = difference.Days;
                }
                else
                {
                    TimeSpan difference = (DateTime)FinishDate - StartDate;
                    days = difference.Days;
                }

                double peni = (double)Sum * 0.16 / 300 * days;

                string sum = peni.ToString("N2");

                return sum;
            }
        }

        public string FSum
        {
            get
            {
                int days = 0;

                if (FinishDate == null)
                {
                    DateTime currentDate = DateTime.Now;
                    TimeSpan difference = currentDate - StartDate;
                    days = difference.Days;
                }
                else
                {
                    TimeSpan difference = (DateTime)FinishDate - StartDate;
                    days = difference.Days;
                }

                double peni = (double)Sum * 0.16 / 300 * days;

                double fsum = (double)Sum + peni;

                string sum = fsum.ToString("N2");

                return sum;
            }
        }

        public string FormatedFinishDate
        {
            get
            {
                string formattedDate = "";
                if (FinishDate.HasValue)
                {
                    formattedDate = FinishDate.Value.ToString("dd.MM.yy HH:mm:ss");
                }

                return formattedDate;
            }
        }
    }
}
