using System;
using System.Collections.Generic;
using System.Text;

namespace SQRS.Mediatr.Sample.Infrastructure.Contracts.Exception
{
   public class ExceptionContract
    {
        public List<ExceptionErrorContract> Errors { get; set; }
    }
}
