using AutoMapper;
using SQRS.Mediatr.Sample.Infrastructure.Contracts.Exception;
using System;
using System.Collections.Generic;

namespace SQRS.Mediatr.Sample.Infrastructure.Mapping.Profiles
{
    public class ExceptionMappingProfile : Profile
    {
        public ExceptionMappingProfile()
        {
            CreateMap<Exception, ExceptionContract>()
                .ForMember(x => x.Errors, o => o.MapFrom(x => MapError(x)));
        }

        private IEnumerable<ExceptionErrorContract> MapError(Exception ex)
        {
            var srcExc = ex;

            while (srcExc != null)
            {
                yield return new ExceptionErrorContract { Type = srcExc.GetType().Name, Message = srcExc.Message };
                srcExc = srcExc.InnerException;
            }
        }
    }
}
