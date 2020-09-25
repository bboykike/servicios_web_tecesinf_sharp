namespace RestApi.Models.DBarchivero
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Security.Cryptography.X509Certificates;

    public partial class ImagenesSE
    {

        [Key]
        public int IDimagenes { get; set; }
        [Required]
        public string Foto { get; set; }
        public string Comentario { get; set; }
        [Required]
        public int IDServiceSE { get; set; }
    }
}