//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Tripadvisor.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Bien
    {
        public int IdBien { get; set; }
        public Nullable<int> IdTypeBien { get; set; }
        public string CodeBien { get; set; }
        public string LebelleBien { get; set; }
        public string DescriptionBien { get; set; }
        public Nullable<double> PU { get; set; }
        public Nullable<int> NbrePlaceDisponible { get; set; }
        public Nullable<int> NbrePlaceTotal { get; set; }
    }
}
