using Microsoft.EntityFrameworkCore;
using net_core_bootcamp_b1_mert.Database;
using net_core_bootcamp_b1_mert.DTOs;
using net_core_bootcamp_b1_mert.Helpers;
using net_core_bootcamp_b1_mert.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace net_core_bootcamp_b1_mert.Services
{
    public interface IHWEventService
    {
        public Task<ApiResult> Add(HWEventAddDto model);
        public Task<ApiResult> Update(HWEventUpdateDto model);
        public Task<ApiResult> Delete(Guid Id);
        public Task<IList<HWEventGetDto>> Get();
    }

    public class HWEventService : IHWEventService
    {
        private readonly MertDBContext _context;

        public HWEventService(MertDBContext context)
        {
            _context = context;
        }

        public async Task<ApiResult> Add(HWEventAddDto model)
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

            await _context.HWEvent.AddAsync(entity);
            await _context.SaveChangesAsync();

            return new ApiResult { Data = model.Name, Message = ApiResultMessages.Ok };
        }

        public async Task<ApiResult> Delete(Guid Id)
        {
            var entity = await _context.HWEvent.Where(x => x.Id == Id).FirstOrDefaultAsync();
            if (entity == null)
            {
                return new ApiResult { Data = Id, Message = ApiResultMessages.HEE01 };
            }
            entity.IsDeleted = true;

            await _context.SaveChangesAsync();

            return new ApiResult { Data = entity.Name, Message = ApiResultMessages.Ok };
        }

        public async Task<IList<HWEventGetDto>> Get()
        {
            var result = new List<HWEventGetDto>();

            result = await _context
                .HWEvent
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
                .ToListAsync();

            return result;
        }

        public async Task<ApiResult> Update(HWEventUpdateDto model)
        {
            var entity = await _context.HWEvent.Where(x => x.Id == model.Id && !x.IsDeleted).FirstOrDefaultAsync();
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

            await _context.SaveChangesAsync();

            return new ApiResult { Data = entity.Id, Message = ApiResultMessages.Ok };
        }
    }
}