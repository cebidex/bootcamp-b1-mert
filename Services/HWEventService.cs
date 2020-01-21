using net_core_bootcamp_b1_mert.DTOs;
using net_core_bootcamp_b1_mert.Helpers;
using net_core_bootcamp_b1_mert.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace net_core_bootcamp_b1_mert.Services
{
    public interface IHWEventService
    {
        public ApiResult Add(HWEventAddDto model);
        public ApiResult Update(HWEventUpdateDto model);
        public ApiResult Delete(Guid Id);
        public IList<HWEventGetDto> Get();
    }

    public class HWEventService : IHWEventService
    {
        private static readonly IList<HWEvent> data = new List<HWEvent>();
        public ApiResult Add(HWEventAddDto model)
        {
            var entity = new HWEvent
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTime.UtcNow

            };
            entity.Name = model.Name;
            entity.StartDate = model.StartDate;
            entity.FinishDate = model.FinishDate;
            entity.Address = model.Address;
            entity.IsFree = model.IsFree;
            entity.Price = model.Price;
            entity.Subject = model.Subject;
            entity.Desc = model.Desc;

            data.Add(entity);

            return new ApiResult { Data = model.Name, Message = ApiResultMessages.Ok };
        }

        public ApiResult Delete(Guid Id)
        {
            var entity = data.Where(x => x.Id == Id).FirstOrDefault();
            if (entity == null)
            {
                return new ApiResult { Data = Id, Message = ApiResultMessages.HEE01 };
            }
            entity.IsDeleted = true;

            return new ApiResult { Data = entity.Name, Message = ApiResultMessages.Ok };
        }

        public IList<HWEventGetDto> Get()
        {
            var result = new List<HWEventGetDto>();

            result = data
                .Where(x => !x.IsDeleted)
                .Select(s => new HWEventGetDto
                {
                    Id = s.Id,
                    CreatedAt = s.CreatedAt,
                    Name = s.Name,
                    StartDate = s.StartDate,
                    FinishDate = s.FinishDate,
                    Address = s.Address,
                    IsFree = s.IsFree,
                    Price = s.Price,
                    Subject = s.Subject,
                    Desc = s.Desc
                })
                .ToList();

            return result;
        }

        public ApiResult Update(HWEventUpdateDto model)
        {
            var entity = data.Where(x => x.Id == model.Id && !x.IsDeleted).FirstOrDefault();
            if (entity == null)
            {
                return new ApiResult { Data = model.Id, Message = ApiResultMessages.HEE01 };
            }

            entity.Name = model.Name;
            entity.StartDate = model.StartDate;
            entity.FinishDate = model.FinishDate;
            entity.Address = model.Address;
            entity.IsFree = model.IsFree;
            entity.Price = model.Price;
            entity.Subject = model.Subject;
            entity.Desc = model.Desc;

            return new ApiResult { Data = entity.Id, Message = ApiResultMessages.Ok };
        }
    }
}