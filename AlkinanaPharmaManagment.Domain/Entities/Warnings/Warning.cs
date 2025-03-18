using AlkinanaPharmaManagment.Domain.Entities.Images;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlkinanaPharmaManagment.Domain.Entities.Warnings
{
    public class Warning
    {
        public Guid Id { get; set; }
        public string Message { get; set; }
        public Guid ImageId { get; set; }
        public Image Image { get; set; }
        public Warning() { }
    }
}
