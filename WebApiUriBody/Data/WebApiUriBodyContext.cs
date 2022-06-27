using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApiUriBody;

namespace WebApiUriBody.Data
{
    public class WebApiUriBodyContext : DbContext
    {
        public WebApiUriBodyContext (DbContextOptions<WebApiUriBodyContext> options)
            : base(options)
        {
        }

        public DbSet<WebApiUriBody.Employee>? Employee { get; set; }
    }
}
